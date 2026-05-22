# MCP improvements — friction report 2026-05-22

Coletado durante uma sessão real implementando o popup de Registro
Profissional em `ListaAtiCPAlunoUniGra` / `RegProfAlunoUGPopup` no KB
`AcademicoHomolog1`. Cada item lista o sintoma observado, a proposta e
um exemplo concreto da sessão.

## Prioridade alta — agente paga pedágio repetido sem isso

### 1. Mapeamento de runtime IDs no `genexus_inspect`

**Sintoma.** Quando precisei mirar controles via JS / CSS-selector, os
IDs do design-time não casavam com o DOM:

| Design-time (XML) | Runtime (HTML) |
|---|---|
| `id="BtnConfirmar"` | `BTT58` |
| `id="GrpNumRegProf"` | `GRPNUMREGPROF` (uppercase) |
| `id="vNUMREGPROF"` na verdade colide com o gxAttribute interno |

Tive que `Grep -P '_Internalname'` no `.cs` gerado pra descobrir cada
um. `getElementById` é case-sensitive — escolher o id errado falha
silenciosamente.

**Proposta.** `genexus_inspect name=<obj> include=['runtimeIds']` retorna:

```json
{
  "runtimeIds": [
    {"designId": "BtnConfirmar", "htmlId": "BTT58", "kind": "gxButton"},
    {"designId": "GrpNumRegProf", "htmlId": "GRPNUMREGPROF", "kind": "fieldset"},
    {"designId": "vNumRegProf", "htmlId": "vNUMREGPROF", "hidden": false}
  ]
}
```

### 2. Catálogo de sanitização do HTML-form em `whoami.playbooks`

**Sintoma.** A geração de HTML do GeneXus 18 sanitiza alguns elementos
e preserva outros — não está documentado em lugar nenhum acessível ao
agente. Descobri por tentativa-e-erro:

| Padrão | Comportamento |
|---|---|
| `<gxTextBlock Format="HTML">` com `<script>...</script>` no CDATA | **escapado** (renderiza texto literal) |
| `<gxTextBlock Format="HTML">` com `<img src=x onerror=...>` | **escapado** |
| `<input type="radio" onclick="...">` raw HTML dentro do Form | **preservado** |
| `<body onmousedown="...">` | **preservado** |

**Proposta.** Playbook entry em `whoami` com nome `html_form_inline_js`:

```text
GeneXus HTML form sanitization (KB AcademicoHomolog1):
  - <script>, <iframe>, <img onerror> dentro de gxTextBlock Format="HTML" são
    renderizados como texto literal (escapado), não executam.
  - Inline event-attrs em raw HTML preservam: onclick em <input type=radio>,
    onmousedown/onunload em <body>, provavelmente outros on* em <td>/<div>.
  - Para JS pós-event num popup, prefira hook via <body onmousedown> (instala
    listeners ao primeiro mousedown) + addEventListener na execução, em vez
    de tentar emitir <script>.
```

### 3. Aviso de `.Popup()` async + AUTO_REFRESH

**Sintoma.** `RegProfAlunoUGPopup.Popup(...)` é não-bloqueante: retorna
controle imediatamente, out-params chegam num Refresh subsequente. Em
seguida o Refresh do parent NÃO restaura `UnnamedGroup1.Visible` no
AcademicoHomolog1, mesmo com `AUTO_REFRESH=VARS_CHANGE`. Custou ~3
iterações pra mapear esse comportamento.

**Proposta.** Playbook entry `popup_call_async`:

```text
.Popup() é assíncrono. Linha imediatamente após .Popup() vê os out-params
AINDA VAZIOS — checar &OutVar.IsEmpty() ali sempre retorna true.
Os valores chegam num Refresh subsequente disparado por AUTO_REFRESH=VARS_CHANGE,
SE essa propriedade detectar mudança. Em vários KBs (incl. AcademicoHomolog1)
o AUTO_REFRESH não dispara após popup fechar e a visibilidade definida no
Start não se restaura.

Recipe para "popup obrigatório + tela bloqueada + auto-reload": ver
genexus://kb/tool-help/recipes/popup_blocking_with_reload.
```

### 4. Patch-matching robusto a EOL

**Sintoma.** `genexus_edit mode=patch` falhou múltiplas vezes com
"Context block not found" porque o `find` veio com `\n` enquanto o
arquivo tem `\r\n` (ou vice-versa). A mensagem não diz qual é a
divergência — só "not found".

**Proposta.**

- Normalizar EOLs nos dois lados antes de buscar (`find.replaceAll(/\r?\n/g, '\n')` no source e no padrão).
- Em caso de "not found", retornar um diff curto: as 3 linhas que o
  agente passou vs as 3 linhas correspondentes do arquivo, destacando a
  divergência.

### 5. Auto-screenshot opcional no `genexus_edit part=WebForm`

**Sintoma.** Validei meu inject de `<script>`/`<img onerror>` via
`chrome-devtools-axi eval` (DOM property checks: `sessionStorage`
setado, hooks instalados). Vinha tudo true. Mas o GeneXus escapou as
tags como texto e o popup mostrou o código JS literal visível para o
usuário. Só descobri quando o usuário mandou screenshot.

**Proposta.** Flag `visualVerify=true` em `genexus_edit`:

```text
1. Aplica edit
2. genexus_lifecycle build (se compilar)
3. chrome-devtools-axi open <URL canônica do objeto>
4. screenshot → embute no response como base64 (truncado) + path
5. Diff pixel curto contra screenshot pré-edit (se houver)
```

Salva o agente de iterar 2-3 vezes sem perceber que a mudança visual
não pegou.

### 6. Warning automático para `<script>` / `<img onerror>` em `Format="HTML"`

**Sintoma.** O write sucedeu silenciosamente mesmo sabendo que o
sanitizer ia bloquear (item 2). Não tem feedback no tempo do edit.

**Proposta.** No `genexus_edit` quando `part=WebForm`, fazer parse
leve do conteúdo dos CDATA dentro de `<gxTextBlock Format="HTML">`. Se
contiver `<script>`, `<img onerror>`, `<iframe>` etc., retornar
warning estruturado:

```json
{
  "status": "Success",
  "warnings": [{
    "code": "GotchaHtmlFormatScriptStripped",
    "message": "Format=\"HTML\" gxTextBlock with <script> inside CDATA — GeneXus generator escapes this on render. Code will appear as literal text. Use <body onmousedown> + addEventListener to inject runtime JS instead."
  }]
}
```

## Prioridade média — pegadinhas que custaram tempo mas têm workaround

### 7. `spc0150` detectável no edit-time

**Sintoma.** Editei `dani` Events com `For each ... Alu2RegProf = ''
endfor`, esperei 60s pelo build, recebi:
`spc0150: Cannot update database in group starting at line 133.
Changes to database are only allowed in procedures.`

**Proposta.** Lint em `genexus_edit` quando o part for `Events` e
objeto for WebPanel: detectar `For each` com assignments a atributos.
Retornar warning + sugerir recipe:

```text
suggested_action: "extract-to-procedure"
recipe: genexus_create_object type=Procedure name=<X>WriteHelper basedOn=current edit
```

### 8. `Patch write fallback failed after persistence mismatch` — false negatives

**Sintoma.** Esse erro retornou pelo menos 3 vezes nessa sessão, mas o
write tinha sido aplicado. Eu tentava de novo achando que tinha
falhado.

**Proposta.** Diferenciar dois casos:

- `write_not_persisted` — write não chegou ao disco. Retry seguro.
- `persisted_with_concurrent_change` — write OK, mas hash mudou após
  (outro processo, ou worker resnapped). Não é erro — retornar sucesso
  com aviso "post-write hash drift".

### 9. `replaceAll` em `genexus_edit`

**Sintoma.** Tentei `replaceAll: true` em um find de 3 occurrences,
tool retornou `Ambiguous patch: Found 3 exact matches, but expected
1`. Doc menciona replaceAll mas não funcionou.

**Proposta.** Conferir se a flag está implementada. Se não, remover
das docs ou implementar.

### 10. Build response — parar de embrulhar sucesso em `<e>error{...}</e>`

**Sintoma.** O `genexus_lifecycle build` retornou
`"summary":"Build succeeded: 0 warnings, 0 errors"` dentro de um
envelope `<e>error{...}</e>`. Confunde — leitores rasos tratam como
falha.

**Proposta.** Quando `ErrorCount=0 && WarningCount=0`, envelope deve
ser `<result>` ou plain JSON. Falha parcial (DLL ok mas WebAppConfig
falhou) pode usar `<warning>` com `partial_success: true`.

## Prioridade baixa — qualidade de vida

### 11. `genexus_run_object` (substitui dani-pattern)

**Sintoma.** Todo dev mantém um `dani.aspx` próprio com glue de
sessão GAM + Call para testar objetos. Hoje o agente também usa essa
glue.

**Proposta.** Tool:

```text
genexus_run_object {
  name: "ListaAtiCPAlunoUniGra",
  args: [27, 1, 6179],
  gamSession: "auto" | { user: "..." }
}
→ { url: "http://localhost/portal3_desenv/listaaticpalunounigra.aspx?<encoded>", cookies: {...} }
```

Aí `chrome-devtools-axi open <url>` direto, sem mexer no dani.

### 12. `genexus_diff` em código gerado

**Sintoma.** Quando edito Events e quero saber o que mudou no `.cs`
ou `.js` rendered, eu greppo `_Internalname` etc. manualmente.

**Proposta.** `genexus_diff target=<obj> against=last-build
parts=[cs,js,aspx,html]` retornando unified diff dos arquivos
gerados.

### 13. Playbook entry para `chrome-devtools-axi`

**Sintoma.** O CLI está instalado globalmente em `npm` em todos os
devs daqui, mas o agente novo não sabe — só descobre se o usuário
mencionar. Eu mesmo só usei depois do usuário lembrar.

**Proposta.** Adicionar em `whoami.playbooks` entry
`verify_in_browser`:

```text
chrome-devtools-axi (CLI npm global) drives Chrome via CDP.
Usage:
  chrome-devtools-axi open <url>      # navega + retorna a11y tree
  chrome-devtools-axi click @<uid>    # clica por accessible uid
  chrome-devtools-axi eval <js>       # eval JS no page (IIFE para múltiplas linhas)
  chrome-devtools-axi screenshot <path>

Para popups GeneXus (iframe): document.getElementById('gxp0_ifrm').contentDocument
para acessar o DOM interno.
```

### 14. `Form.Caption` / `Form.GoTo` / etc. — discovery

**Sintoma.** Quando tentei achar uma API GX para forçar reload do
parent, eu chutava nomes (`Form.Refresh`, `Form.GoTo`, `Window.Open`)
sem saber quais existem na versão 18.

**Proposta.** `genexus_sdk_probe action=list-methods type=Form`
retornando métodos disponíveis com signatures + 1-line description.

---

## Checklist pra retrabalhar isso

Quando voltar ao roadmap do MCP, priorizar:

1. [ ] Items 1-3 (runtime IDs, sanitization catalog, popup async warning) → cada um economiza 30+ min por agente novo
2. [ ] Item 4 (EOL normalization) → quick win, 1 linha de mudança no patch matcher
3. [ ] Itens 5+6 (auto-screenshot + warning auto) → muda significativamente o feedback-loop de WebForm edits
4. [ ] Itens 7-10 (lint pré-build, error message clarity) → fix de paper cuts
5. [ ] Itens 11-14 (tools novas, playbooks adicionais) → qualidade de vida

Sessão de origem: `2026-05-22` — implementação do popup RegProf no
fluxo UG/contrapartida da UNIVALI.

---

# Wishlist expandido — tudo que poderia melhorar

Brainstorm livre. Cada item: sintoma / proposta / esforço estimado
(S/M/L/XL). Itens marcados com **★** são alto impacto + baixo esforço,
priorizar primeiro.

## Edit UX

### 15. Edit em transação multi-objeto **★**
Editar Object A + B + Procedure C em uma chamada com rollback atômico
se qualquer falhar. Hoje, se eu adiciono variável num WebPanel e
edito Events que usa essa variável, e o segundo edit falha, o
primeiro fica órfão. **Esforço:** M.

### 16. `genexus_undo last=N`
Sistema já tem `EditSnapshotStore` (.gx/snapshots). Expor uma tool
que reverte os últimos N edits do agente atual, sem precisar `git
checkout`. **Esforço:** S.

### 17. Fuzzy patch matching
Quando `find` não bate, propor a melhor match com distância
Levenshtein < N. Retornar `did_you_mean: <snippet>`. **Esforço:** S.

### 18. Edit por diff unified (git-style)
Em vez de find/replace, aceitar `@@ -1,3 +1,4 @@\n linha\n-velha\n+nova`.
Mais natural para o agente quando o edit é grande. **Esforço:** M.

### 19. Edit incremental para WebForm
`genexus_edit_form` que aceita comandos semânticos: `add_textblock`,
`add_button`, `wrap_in_fieldset`, em vez de XML cru. Reduz fricção e
elimina classe inteira de "Invalid visual XML" errors. **Esforço:** XL.

### 20. Auto-format `Events` source
Identação consistente, alinhamento de assignments, normalização de
parm rules. Hoje meu insert de `case &cod = 10` ficou triplamente
indentado por causa do SDK reformatar. **Esforço:** S.

### 21. `dryRun` mostra diff sem persistir **★**
A flag já existe parcialmente em alguns paths; padronizar pra TODOS
os edits + retornar diff de pre/post mesmo sem persistir.
**Esforço:** S.

## Inspeção / busca

### 22. Full-text search em CaptionExpression / nomes / descrições
`genexus_search_source` já busca em Source. Estender para incluir
captions, descriptions, parm names. **Esforço:** S.

### 23. Visualização do event-flow de um WebPanel **★**
ASCII diagram: Start → (gate) → Refresh → user events (Enter,
ButtonClick, Grid.Load). Útil pra entender objetos novos rapidamente.
**Esforço:** M.

### 24. `genexus_find_callers name=<X>` retorna chamada-site precisa
Já há `genexus_analyze mode=impact`, mas retorna list of objects;
queria também a linha exata onde a chamada acontece + contexto.
**Esforço:** S.

### 25. Tree de dependências em árvore visual
`genexus_analyze mode=hierarchy` retornaria ASCII tree em vez de
flat list. **Esforço:** S.

### 26. Glossário de tipos do GeneXus
Tool `genexus_glossary` ou playbook entry explicando quando usar
`gxButton` vs `gxAttribute ControlType="Button"` vs
`gxTextBlock onclick`. **Esforço:** S.

## Build / test

### 27. Cancel build em andamento
Hoje, se o build trava ou eu mudei de ideia, espero 60s+. Tool
`genexus_lifecycle action=cancel target=<jobId>`. **Esforço:** S.

### 28. Build incremental real **★**
Só recompila o que mudou de fato; hoje rebuild ainda copia todos os
módulos GeneXus em cada call (`Copying GeneXusJWT Module`, etc.).
**Esforço:** L.

### 29. Smoke test pós-build
`genexus_lifecycle action=smoke target=<obj>` que faz HTTP 200 check
+ basic DOM sanity check (não tem `<scriptError>`) via
chrome-devtools-axi headless. **Esforço:** M.

### 30. Build graph viz
Mostrar `Plan: A → B → C` antes de compilar, com tempo estimado por
nó. **Esforço:** M.

### 31. Test-stub generator
`genexus_generate_test type=Procedure name=<X>` gera um stub de
unit-test no padrão GXtest. **Esforço:** L.

## Debugging / observabilidade

### 32. `genexus_log_tail` filtrado por objeto **★**
Tail do `Desenv\web\<obj>.log` ou IIS log filtrado pelo objeto
atual. Hoje eu nem sei onde estão os logs do runtime. **Esforço:** S.

### 33. Captura de console / network do browser
Integração com chrome-devtools-axi: `genexus_capture_browser
target=<obj>` abre, navega, retorna console errors + network failures
+ JS exceptions. **Esforço:** M.

### 34. Profile de query do `For each`
`genexus_sql action=navigation` já retorna SQL. Adicionar
`includeExecutionPlan=true` que executa EXPLAIN PLAN no Oracle e
retorna custo + índices usados. **Esforço:** M.

### 35. Watch / breakpoint em Events
Setar breakpoint num Event Source e quando ele bater, capturar
estado de variáveis. Stretch goal — exigiria modificar gerador.
**Esforço:** XL.

### 36. Histórico de execução
"Quem chamou esse objeto nos últimos N runs do app? Com quais
parâmetros?" — útil pra reprodutibilidade de bugs.
**Esforço:** L.

## Verificação visual / a11y

### 37. Pixel-diff automático entre builds **★**
Após cada `genexus_edit part=WebForm`, salva screenshot do objeto.
Próximo edit no mesmo objeto retorna pixel-diff vs anterior na
response. Detecta regressões visuais inadvertidas. **Esforço:** M.

### 38. A11y audit
chrome-devtools-axi tem `lighthouse` e `perf-insight`. Wire para
rodar a11y check automaticamente pós-WebForm-edit.
**Esforço:** S (wrapper).

### 39. Emulação mobile + screenshots responsivos
`chrome-devtools-axi emulate iPhone12 ; screenshot`. Já existe — só
expor via tool MCP que faz o ciclo. **Esforço:** S.

### 40. OCR no screenshot pra detectar texto escapado
Quando o sanitizer escapa `<script>` em texto visível, OCR detecta e
flagga. Backup pra item 6 caso parse estático falhe.
**Esforço:** M.

## Banco de dados / schema

### 41. Drift detection entre Transaction e DB **★**
"Você editou Aluno2 mas a tabela T0001 no Oracle não tem a coluna
nova" — detectar antes do build falhar com erro críptico.
**Esforço:** M.

### 42. Sample data generator
`genexus_generate_sample_data trn=Aluno2 rows=10` insere dados
fakes coerentes com a estrutura. Útil pra testar telas com dados
realistas. **Esforço:** M.

### 43. DDL diff/preview pré-reorg
Antes de rodar `genexus_lifecycle action=reorg`, mostrar `ALTER
TABLE` que vai ser executado. **Esforço:** S.

### 44. Index advisor
"Esse For each com Where X = Y, Where Z = W vai full-scan T0001
(50M rows). Considere índice em (X, Z)." **Esforço:** L.

## Patterns / WWP

### 45. "Por que meu pattern não está aplicando?" diagnóstico **★**
Hoje quando WorkWithPlus falha silenciosamente, o agente fica
chutando. Tool `genexus_diagnose_pattern target=<X> pattern=<P>`
retornando o motivo: parent type errado, conflict de override,
template inválido. **Esforço:** M.

### 46. Pattern visual editor (server-side)
`genexus_edit name=WorkWithPlus<X> part=PatternInstance` aceita JSON
estruturado em vez de XML cru. **Esforço:** L.

### 47. Catálogo de patterns disponíveis com exemplos
`genexus_recipes name=list` já existe parcialmente; estender com
exemplos concretos copy-pasteáveis. **Esforço:** S.

## Segurança / lint

### 48. Detector de credenciais hardcoded
Scan em Events Source por strings tipo `'pwd123'`, `BEGIN
RSA PRIVATE`, etc. **Esforço:** S.

### 49. Lint para SQL injection patterns
`For each` com `Where attr = &var.Concat(...)` sem parametrização
direta. **Esforço:** M.

### 50. GAM settings audit
Detectar configurações inseguras: `IntegratedSecurityLevel=None`,
`USE_ENCRYPTION=NONE`, etc. **Esforço:** S.

## Worker / lifecycle

### 51. Hot-reload sem perder warm cache **★**
Hoje `genexus_worker_reload` derruba tudo. Idealmente recarregar
só o assembly do objeto editado, mantendo SDK loaded.
**Esforço:** XL.

### 52. Worker memory dashboard
"Worker está em 1.2GB heap. Considere reload em N min." (já existe
o problema dos zombies — ver memory existente). **Esforço:** S.

### 53. Worker pool com warm spares
Ter sempre 1 worker pronto pra spawn instantâneo.
**Esforço:** L.

## Cross-KB / sandbox

### 54. Sandbox: clone KB pra mexer sem risco
`genexus_sandbox create from=AcademicoHomolog1 name=sb-feat-X`
cria cópia, redireciona writes pra ela. Merge-back manual.
**Esforço:** XL.

### 55. `genexus_kb_diff` entre dois KBs
Útil pra ver "o que mudou entre AcademicoProd e AcademicoHomolog1".
**Esforço:** L.

### 56. `genexus_import_from` outro KB
Importar um objeto inteiro de outro KB, com suas dependências.
**Esforço:** L.

## Recipes / macros de alto nível **★**

### 57. `genexus_recipe popup_blocking_with_reload`
Macro alto-nível: aceita `parent`, `popup`, `gate_condition` e
gera todo o boilerplate (Start hide + Refresh handle + body
onmousedown auto-reload). Substitui ~3h de trabalho desta sessão por
1 call. **Esforço:** M.

### 58. `genexus_recipe radio_group_show_hide`
Aceita lista de opções e qual mostra/esconde qual outro controle.
Gera o gxAttribute hidden + custom HTML radios + onclick handlers já
encodados corretamente. **Esforço:** M.

### 59. `genexus_recipe extract_to_procedure`
Marca um bloco de Events e move pra uma Procedure nova com parm
inferido. Resolve `spc0150` automaticamente. **Esforço:** M.

### 60. Recipe library com versionamento
Recipes salvas com versão; agentes podem pedir `recipe@v2`. Útil
quando uma recipe muda comportamento entre updates do MCP.
**Esforço:** M.

## LLM-friendly responses

### 61. Token-budget no response **★**
Cada tool retorna `_meta.tokens: { used: 1234, hint: "prefer
pagination" }`. **Esforço:** S.

### 62. Codes estruturados para gotchas
`code: "GotchaPopupAsync"` clicável, link pra doc. Já existe pra
alguns; padronizar pra TODOS. **Esforço:** S.

### 63. "Próximo passo sugerido" sempre presente
Hoje só o build retorna `suggested_retry`. Estender pra todos os
errors: "tentei X, falhou; agora tente Y". **Esforço:** M.

### 64. Compact responses por default, verbose por flag
Muitos retornos têm 30+ campos quando o agente quer 3. Adicionar
`projection=minimal|standard|verbose` em todas as tools.
**Esforço:** M.

## Onboarding / discoverability

### 65. `genexus_orient` ou welcome card **★**
Primeira call de cada sessão retorna: "Você está no KB X. Últimos
edits foram Y, Z. Gotchas conhecidos: ABC. Tools mais usadas neste KB:
DEF." Acelera muito agentes novos. **Esforço:** M.

### 66. Tutorial interativo
`genexus_tutorial step=1` → guia o agente por um fluxo simples
(criar Procedure, edita Source, build, smoke test). **Esforço:** L.

### 67. Glossário em playbooks
"gxButton vs gxButton ControlType vs HTML button" — diferenças
sutis que confundem. **Esforço:** S.

### 68. `genexus_explain object=<X>`
Resume em linguagem natural o que o objeto faz, pra um PM/cliente
ler. Usa o GeneXus structure + descrição + análise das variáveis.
**Esforço:** M.

## Cross-tool / integration

### 69. Playbook entry para chrome-devtools-axi **★**
Já citado (item 13), reforço. **Esforço:** S.

### 70. Hook para Playwright se chrome-devtools-axi não existir
Fallback automático com mesma API. **Esforço:** M.

### 71. Integração com GitHub PR
`genexus_create_pr title=... description=auto` que pega últimos
edits, gera commit + PR. **Esforço:** L.

### 72. Slack/Discord notification quando build falha
Útil em pipelines longos. **Esforço:** S.

## Telemetria / aprendizado

### 73. Per-tool latency stats em `whoami` **★**
"`genexus_edit` p95 = 3s. `genexus_lifecycle build` p95 = 60s."
Ajuda a planejar wait. **Esforço:** S.

### 74. Most-failed tool calls
"Esta sessão: `genexus_edit` falhou 5x (context not found). Considere
ler antes de editar." **Esforço:** S.

### 75. Token-usage breakdown
"Você usou 80% do budget em `genexus_read` retornando código que
não precisava. Use `parts=[only_what_needed]`." **Esforço:** M.

### 76. Aprendizado cross-sessão
Reportar pro MCP "este gotcha aconteceu de novo" → MCP atualiza
playbook automaticamente. **Esforço:** XL.

## Específicas do GeneXus 18 / Artech

### 77. Auto-fix para `WebFormTypedPropertyWriter` quirks
A própria base de conhecimento documenta vários (`OnClickEvent` →
`Event` etc.). MCP podia ter um auto-fixup hook quando detecta o
padrão. **Esforço:** M.

### 78. Suporte a SDPanel além de WebPanel
Boa parte das tools focam em WebPanel. Estender pra mobile/SD.
**Esforço:** L.

### 79. Theme-aware preview
Renderizar com `CarmineTemplate` vs outro tema lado-a-lado.
**Esforço:** M.

### 80. Validação de master page compatibility
"Você está usando MasterPage X mas adicionou um controle que
depende de MasterPage Y." **Esforço:** M.

## Ideias mais malucas / criativas

### 81. AI-prompted code completion no Events Source
Tipo Copilot, mas ciente de variáveis no escopo, parm rules,
SDT structure. **Esforço:** XL.

### 82. Time-travel debugging
"Reverter o KB pro estado de 2 horas atrás, sem perder edits
intermediários — branch ad-hoc." **Esforço:** XL.

### 83. Voice-driven edits
`genexus_voice "adiciona um botão que chama X"` → MCP gera o edit.
Puro jogo. **Esforço:** XL.

### 84. Multi-agent collaboration
2 agentes editando o mesmo KB com lock granular por part. Já tem
problemas de race em parallel edits (citado no CLAUDE.md test
flakies). **Esforço:** XL.

### 85. Auto-PR descriptions do diff acumulado
Detectar mudanças entre dois commits e gerar descrição PR-ready
explicando o "why" + "what". **Esforço:** M.

### 86. "What if" mode
"Se eu trocar AfaCod de NUMERIC(4) pra (5), o que quebra?"
— simulação sem reorg real. **Esforço:** XL.

### 87. Object dependency heat-map
Visual: cores indicando objetos mais alterados / mais bugs / mais
acessados. **Esforço:** L.

### 88. Code archeology mode
`genexus_blame name=<obj> part=Events line=42` — quem mudou, quando,
por que (linkando ao commit hash). **Esforço:** M.

### 89. Auto-screenshot diff publicado num servidor interno
Cada `genexus_edit part=WebForm` publica antes/depois num server
interno (URL retornada no response) pra a equipe ver sem clonar.
**Esforço:** L.

### 90. KB → README generator
`genexus_generate_readme` produz documentação automática do KB:
domínios, transactions, fluxo principal, dependências.
**Esforço:** L.

### 91. Refactor: rename across KB
"Renomeie a Transaction Aluno2 para Aluno" — propaga em
TODA call site, atributos, índices, etc. **Esforço:** XL.

### 92. Bulk import de translations
CSV/JSON com {key, pt, en, es} → atualiza CaptionExpression em
massa. **Esforço:** M.

### 93. Bot que monitora friction logs **★**
Esta própria sessão tem 12+ pontos de fricção. Um bot que detecta
"agente fez X 3x em 5min" e abre issue automaticamente.
**Esforço:** M.

### 94. Heatmap de tempo gasto
"Você gastou 35% da sessão em `genexus_edit` retentando patches.
Considere ler primeiro." Gera relatório no fim. **Esforço:** M.

### 95. Auto-generate test data + tests baseado em real production patterns
Olha o histórico de chamadas no production log, extrai padrões
mais comuns, gera tests reproduzindo. **Esforço:** XL.

### 96. Reverse-engineer pattern from existing objects
"Olha esses 10 WebPanels que parecem CRUD; gere um pattern WWP-like
custom." **Esforço:** XL.

### 97. Latência simulada / chaos
Modo "rede lenta" pra testar UX em conexões ruins.
**Esforço:** S.

### 98. Compatibilidade cruzada: rodar o mesmo objeto em browsers diferentes
chrome-devtools-axi + firefox + safari paralelos, screenshot
comparado. **Esforço:** L.

### 99. Suggest WCAG fixes em CaptionExpression
"Esse texto tem contraste 2.5:1, deveria ser 4.5:1. Tente esse hex
mais escuro." **Esforço:** M.

### 100. Recipe: full feature scaffold
`genexus_recipe new_feature spec=...` recebe uma user-story em
markdown e gera Transaction + WebPanel + Procedures + tests + dani
entry, tudo wired. O Santo Graal. **Esforço:** XL.

---

## Categorização por impacto x esforço

**Quick wins (alto impacto / baixo esforço — ★):**

- Item 1 (runtime IDs), 2 (sanitization catalog), 3 (popup async)
- Item 4 (EOL normalization), 21 (dryRun universal)
- Item 17 (fuzzy patch matching), 23 (event-flow viz)
- Item 32 (log tail), 37 (pixel-diff)
- Item 45 (pattern diagnose), 51 (worker hot-reload)
- Item 57 (popup recipe macro)
- Item 61 (token budget), 65 (welcome card), 73 (latency stats)
- Item 69 (chrome-devtools-axi playbook), 93 (friction bot)

**Strategic medium-term (alto impacto / médio esforço):**

- Items 5-6 (visual verify pipeline)
- Item 15 (multi-object transactions), 19 (semantic WebForm edits)
- Item 28 (incremental build), 41 (DB drift detection)
- Items 57-60 (recipes / macros library)
- Item 76 (cross-session learning)

**Long-term / strategic (alto esforço, alto valor a prazo):**

- Item 51 (hot-reload sem warmup), 54 (sandbox), 78 (SDPanel)
- Items 81-83 (Copilot-like, time-travel, voice)
- Item 84 (multi-agent), 91 (rename across KB)
- Item 100 (full feature scaffold)

**Skip ou aguardar feedback de usuário:**

- Items 82, 83, 86, 95, 96 — alta complexidade, validar demanda primeiro


