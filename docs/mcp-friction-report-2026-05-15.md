# MCP Friction Report — 2026-05-15

**MCP version:** 2.3.8 | **GeneXus:** 18.0.7.179127 | **KB:** AcademicoHomolog1

Sessão real: idempotência do fluxo Clicksign em `ComissaoLiberaPareceres` (Procedure) + status indicator em `ComissaoAgendaDetalhe` (WebPanel WorkWithPlus). 398 pareceres / 11 envelopes em produção. ~60 chamadas MCP, 2 build cycles (ambos falharam por motivos diferentes), descoberta da procedure por trial-and-error.

Só itens **acionáveis no código do MCP**. Quirks do GeneXus runtime ficam fora.

---

## P0 — High-impact

### #1 — `genexus_search_source` timeout silencioso, depois retorna 0 hits válido-mas-falso

**Sintoma:** Patterns simples (`Clicksign|clicksign`, `Extraordin[aá]ria`, `ComissaoLiberaPareceres\s*\(`) timeoutaram (~2min cada). Depois de `lifecycle action=result wait_seconds=25` repetido, retornaram `{count:0, hits:[]}` mesmo com o termo presente em vários objetos (`Root Module/ClickSign/*`, `ComissaoLiberaPareceres`, etc.). 

O que aconteceu: o worker estava ainda indexando ou o search rodou contra um índice estale — não tem como o caller saber. Gastei ~6 turns tentando localizar `ComissaoLiberaPareceres` por search antes de cair no `genexus_read name=...` direto (que funcionou na primeira).

**Sugestão:**
- Status do índice exposto: `genexus_whoami` ou `genexus_lifecycle action=status target=index` devolver `{indexed: bool, lastIndexedAt, totalObjects}`.
- Search com índice frio → retornar `{status: "IndexCold", retryAfterMs: N}` em vez de `count:0`. Nunca silenciar.
- Limite hard timeout 30s + falhar explícito com `{status: "Timeout", partial: N, totalScanned: M}` em vez de aparentar sucesso.

### #2 — `genexus_list_objects filter` matcha em description, não no name; e perde nomes que existem

**Sintoma:** `filter="Pareceres"` retornou 5 objetos cujo nome NÃO contém "Pareceres" (matcha em description: `PSPContParecer` descrita como "...pareceres"). `filter="ComissaoLiberaPareceres"`, `filter="LiberaParecer"`, `filter="Libera"+typeFilter=Procedure` — todos retornaram 0 hits, mesmo com a procedure existindo no Root Module e sendo lida com sucesso por `genexus_read name="ComissaoLiberaPareceres"`. ~5 turns perdidos tentando localizar.

**Sugestão:**
- Parâmetros separados: `nameFilter` (substring no name only) e `descriptionFilter` (descrição).
- Ou: prefixar campos no `filter` (`name:libera`, `desc:pareceres`).
- Documentar o comportamento de matching atual no description da tool.

### #3 — `genexus_list_objects parent / parentPath` não lista filhos de Folder

**Sintoma:** `parent="ClickSign"` → 0 results. `parentPath="Root Module/ClickSign"` → 0. `genexus_inspect name="ClickSign" type="Folder" include=["parts","structure"]` retorna `{availableParts:[], uiStructure:{}}`. Nenhum jeito de listar o conteúdo de uma pasta via MCP.

**Sugestão:** `genexus_list_objects` aceitar `folder=<name>` ou `pathPrefix="Root Module/ClickSign/"`. Indexar `parentFolderName` por objeto pra suportar.

### #4 — `genexus_edit` multi-line `context` falha com CRLF; só single-line funciona

**Sintoma:** 4 tentativas falharam com `patchStatus: NoMatch` em context com `\r\n` literal, com `\n`, escapado, etc. O similarity reportado era 0.5–0.67 mesmo com o bloco existindo idêntico no arquivo. Single-line `context` resolveu na hora.

```
// FALHA — match não encontrado, mesmo com bloco idêntico no fonte:
context: "    Where IdAgenda = &IdAgenda\n    Where ParecerFinal <> 3\n\n    &ListaIdsPareceres.Add(IdParecer)"

// OK:
context: "    Where ParecerFinal <> 3"
```

Gastei ~5 turns descobrindo. Compromete edit em ranges grandes (3 linhas + delete).

**Sugestão:**
- Normalizar EOL antes de comparar (CRLF↔LF). Já parece haver normalização parcial — mas inconsistente.
- Quando similarity ≥ 0.85, retornar o diff exato byte-a-byte vs source no `nearMatchHint` (mostrar o que difere). "Top similar windows in source. Adjust 'context'..." sem mostrar o que adjusting é frustrante.

### #5 — `genexus_add_variable typeName="VarChar(120)"` silenciosamente cria como NUMERIC(4)

**Sintoma:** Sem warning, sem erro: `{status:"Success"}`. Só descobri no build (`spc0010: Type mismatch: &PareceresStatusLabel ... (Numeric=Character)`). Perdi 1 build cycle (~2 min) + 4 turns corrigindo. A doc da tool não lista quais `typeName` aceita.

**Sugestão:**
- Aceitar `typeName` com sinônimos comuns (`VarChar`, `Character`, `String`, `Char`, `Numeric`, `Boolean`, `DateTime`). Resolver internamente.
- Rejeitar inválido com erro explícito: `{status: "Error", message: "Unknown typeName 'VarChar(120)'. Did you mean 'Character(120)'? Accepted: Character, Numeric, ..."}`.
- Documentar enum aceito na schema da tool.

### #6 — Variável criada com tipo errado vira intocável

**Sintoma:** Depois da #5, tentei mudar o tipo:
- `genexus_delete_variable` em WebPanel → `Part 'DeleteVariable' not found in WebPanel` (asymmetry — funciona em Procedure).
- `genexus_edit part="Variables" context="&PareceresStatusLabel : NUMERIC(4)" content="&PareceresStatusLabel : VARCHAR(200)"` → o save retorna `persistedVerified: false` porque GeneXus normaliza OUTRAS linhas (`DATETIME(10,5)` → `DATETIME(8,5)`, `Messages, GeneXus.Common` → `Messages`). Diff fica byte-divergente, auto-rollback restaura.
- Tentar remover a linha via edit → SDK rejeita: `Referência de controle inválida: '[var:64]' 'Vazio' não é um valor válido para a propriedade 'Control Name'`. Aparentemente o GeneXus auto-criou um binding pra ela em algum lugar, mesmo nunca tendo sido referenciada por mim.

Acabei comentando as 4 atribuições à variável e deixando-a órfã.

**Sugestão:**
- `genexus_delete_variable` funcionar em **qualquer** tipo de objeto.
- `genexus_modify_variable name=<obj> varName=<v> typeName=<new>` — operação dedicada.
- Verificação de persistência ignorar diffs em linhas **não tocadas pelo patch**. Patch verify só deve comparar a janela editada, não o arquivo inteiro.
- Quando variable está "presa" por um binding fantasma, mostrar onde está o binding (`form:[var:64]`, `event line X`, etc.).

### #7 — Build segmentado em WebPanel não inclui refs de procedures chamadas

**Sintoma:** Build de `ComissaoAgendaDetalhe` (que chama ~10 procedures: `ComissaoGerarAta`, `ComissaoBlockAgenda`, `ClickSignSignatarioPost`, etc.) falhou com **32× CS0246** mesmo quando incluí TODAS as procedures chamadas no `target`. O `.csproj` per-object gerado pelo MCP não referencia os DLLs das callees.

```
target: "ComissaoLiberaPareceres,ComissaoAgendaDetalhe,ComissaoPautaRelatorio,
         ComissaoGerarAta,ComissaoBaixarPareceres,ComissaoBlockAgenda,...
         ClickSignSignatarioPost,ComissaoEnvLembreteAgenda,..." (20 objetos)
→ "comissaoagendadetalhe.cs(2399,14): error CS0246: type 'comissaopautarelatorio' not found"
```

Spec do GeneXus passou OK (sem `spc0001/0010`); só o .NET linker reclama. Build segmentado é inutilizável pra WebPanels que chamam ≥1 procedure em KBs reais.

**Sugestão:**
- Build de WebPanel detectar automaticamente todas as procedures `calls` (via `analyze impact`) e injetar `<Reference Include="..."/>` no csproj gerado.
- Ou: build em modo "all dependencies" como flag (`includeCallees=true`) que segue a árvore de calls.
- Documentar que build segmentado de WebPanel não funciona, e qual o workaround (Build All pelo IDE).

### #8 — `genexus_analyze mode=impact` indica "Indexing in progress" indefinidamente após edit

**Sintoma:** Depois de editar `ComissaoLiberaPareceres`, chamei `analyze mode=impact` pra mapear chamadores antes de buildar. Resposta: `impactAnalysis.status: "Indexing in progress for this object. Please retry in a few seconds."`. Mesmo após 1+ minuto, mesmo response. `genexus_inspect include=["callers"]` funcionou — então o índice TEM os callers, mas o `analyze` não acessa.

**Sugestão:**
- `analyze impact` cair pro mesmo índice usado por `inspect callers` (parece ser outro path).
- Se o índice realmente está reconstruindo, expor ETA: `{status:"Reindexing", progress:0.62, etaMs:8000}`.
- Auto-wait flag: `analyze mode=impact name=X waitForIndex=true`.

---

## P1 — Médio-impact

### #9 — Resultado de `lifecycle status/result` em build falho vazaa 60K+ chars numa linha

**Sintoma:** Build com 30 errors + 24 warnings → response JSON ~60KB, todo numa linha, supera o tool result token cap. Tive que ler o arquivo dump via Bash + jq pra extrair erros. Aconteceu 2× nesta sessão.

Pior: o payload duplica os erros 3×:
- `Errors[]` (top-level)
- `result.Errors[]`
- `result.Output` (string com log completo, incluindo cada erro outra vez)

**Sugestão:**
- `lifecycle action=status compact=true` → só `{status, errorCount, errors[:10], warningCount, summary}`.
- Não duplicar `Errors` em 3 lugares.
- `Output` opcional via flag, nunca por padrão.
- Truncar warnings repetitivos (ex: 6× a mesma warning de "GAM não será reorganizado" — colapsar pra `{warning:"...", count:6}`).

### #10 — `genexus_read part="Events"` de WebPanel grande overflow do token cap em 1 chamada

**Sintoma:** `ComissaoAgendaDetalhe.Events` é 55KB numa linha. Read default (sem `limit`) explode. Tive que paginar com `offset/limit` na linha — funcional, mas a primeira tentativa sempre falha em panels grandes.

**Sugestão:**
- Default `limit` razoável (ex: 200 linhas) em vez de "tudo".
- Quando vai estourar, retornar `{truncated: true, suggestedOffset: N}` em vez de erro.
- Streaming/chunking automático opcional.

### #11 — `genexus_edit patch` com `{find, replace}` JSON não funciona como documentado

**Sintoma:** A doc da tool diz:
> `patch`: Legacy string replacement OR `{find,replace}` JSON object OR RFC 6902 array.

Testei `{find: "...", replace: "..."}` 3×, sempre retornou `NoMatch` mesmo com strings óbvias. Só funcionou com `operation=Replace + context=<old> + content=<new>` (params separados). Os outros shapes parecem mortos ou bugados.

**Sugestão:**
- Remover shapes que não funcionam da docstring.
- Ou: fixar os 3 modos pra realmente funcionarem com mesmo poder.

### #12 — Asymmetry: `delete_variable` em Procedure ✅ / WebPanel ❌

**Sintoma:** `genexus_delete_variable name="ComissaoAgendaDetalhe"` → `Part 'DeleteVariable' not found in WebPanel`. Em Procedure funciona. Sem alternativa em WebPanel — gastei 3 turns tentando até desistir e workaround via comentar atribuições.

**Sugestão:** suportar em WebPanel/Transaction também. Se realmente requer logic diferente (controles bindados), pelo menos reportar `Error: cannot delete &X — bound to controls [list]` em vez de "part not found".

### #13 — `genexus_edit` rollback restaura conteúdo "original" mas perde normalizações intermediárias

**Sintoma:** Edit em Variables → save → verify falha → "Original source restored". Mas o original já não era idêntico (GeneXus tinha rodado normalize na carga). Resultado: ficamos sem garantia clara do estado final. `persistedSnippet` ajudou mas é manual ler.

**Sugestão:** após rollback, devolver SHA/hash + readback automático para o caller confirmar.

---

## P2 — Pequeno polish

### #14 — `lifecycle build` job ID expira no terminal mas notification continua chegando

**Sintoma:** `_meta.background_jobs` no response do PRÓXIMO tool call mostra o job antigo como "failed" mesmo eu não tendo perguntado. Polui contexto.

**Sugestão:** notification de jobs antigos só uma vez (no primeiro response após completion), não em todos os responses subsequentes da sessão.

### #15 — Mensagens de erro do MCP em PT-BR misturadas com EN

**Sintoma:** `"A validação de Web Panel 'X' falhou.. Detailed Messages:  [VALIDATION]: Referência de controle inválida: '[var:64]'"`. Dois pontos finais, mistura de idiomas, `[var:64]` opaco.

**Sugestão:**
- Mensagens consistentes em 1 idioma (preferência EN, que matcha a API).
- `[var:N]` resolver pro nome simbólico.
- Validação de pontuação.

### #16 — `genexus_lifecycle action=cancel` ainda quebrado (carry over do report 2026-05-14 #7)

Não testei nesta sessão diretamente, mas vale recordar do report anterior: cancel não funciona, e isso aqui me custou turns esperando search timeouts que eu queria abortar.

---

## Quick-wins (pequenas mudanças, alto retorno)

1. **`genexus_add_variable`: validar e mapear `typeName`** — uma tabela de sinônimos resolve 80% dos casos. Hoje qualquer string inválida vira NUMERIC silenciosamente.
2. **`genexus_list_objects`: `nameFilter` separado de `filter`** — 5 turns perdidos hoje achando objeto pelo nome.
3. **`lifecycle status` slim mode** — `compact=true` cortando warnings duplicados e Output. Resolveria os 2 overflows desta sessão.
4. **`edit`: similarity diff no `nearMatchHint`** — quando bloco está 0.93 similar, mostrar QUAL byte difere. Multi-line edits ficariam viáveis.
5. **`inspect callers` retornar internalId/path completo** — pra build segmentado conseguir injetar refs corretas no csproj.

---

## Workflow ideal (pra essa sessão)

O que **deveria** ter rolado em ~15 turns:

1. `analyze impact name=ComissaoLiberaPareceres` → callers, callees, build target sugerido.
2. `read parts=[Source]` → veja o código.
3. `edit operation=Replace` (multi-line OK) — 3 patches em 3 turns.
4. `lifecycle build target=<sugestão do impact> compact=true` → ✅.

O que **rolou** em ~60 turns:
- 6 turns localizando o objeto (search timeout silencioso + list filter falho)
- 5 turns desbravando edit multi-line CRLF
- 4 turns descobrindo `typeName="VarChar"` virou NUMERIC
- 6 turns tentando reparar a variável presa
- 4 turns parseando build output overflow
- 2 build cycles falhos por csproj sem refs

**Ratio de fricção desta sessão: ~75% dos turns gastos em workarounds, não em trabalho de domínio.**
