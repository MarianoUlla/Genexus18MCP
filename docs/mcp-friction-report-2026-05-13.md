# MCP Friction Report — 2026-05-13

Sessão real contra KB `AcademicoHomolog1` (GeneXus 18.0.7.179127), worker em
v2.1.6 publicado. Cenário dirigido 100% via MCP: criar um SDT, criar uma
Procedure consumer, declarar variable bound ao SDT, escrever Source com
`&Var.Field`, fazer patch Variables, buildar, ler de volta. Mesma forma do
report de 2026-05-08, agora colhendo o que ficou (ou voltou) depois do fechamento.

Objetos probe usados (todos deletados ao final):
`SdtFrictionProbe0513`, `PrcFrictionProbe0513`, `PrcFrictionProbe0513B`,
`PrcFrictionProbe0513C`.

---

## 1. `whoami.serverVersion` é hardcoded e ficou pra trás

**Severidade:** baixa, mas confiança 0.

`mcp__genexus_whoami` retornou `"serverVersion": "2.1.3"` mesmo com o repo em
v2.1.6 e binários em `publish/worker/` corretos (timestamp 2026-05-13 13:58).
A string vem de `src/GxMcp.Gateway/McpRouter.cs:13`:

```csharp
public const string ServerVersion = "2.1.3";
```

Não foi bumpada em v2.1.4 / 2.1.5 / 2.1.6. Um agente que chama `whoami` pra
confirmar "tô na versão com o fix" é induzido a achar que não está.

**Recomendação:** ler de `Assembly.GetEntryAssembly().GetName().Version` ou
injetar via MSBuild a partir do `package.json` no build (mesma fonte que o
release.ps1 usa). Bumpar no `chore(release)` deixaria de ser um passo manual.

---

## 2. SDT Structure DSL: write reporta `Success` mas a coleção `Items` da SDK não é atualizada (stale-tree class)

**Severidade:** CRÍTICA. Mesma classe do `webform-write-stale-form-tree`
(fechado para WebForm em `9242c1d`), agora reaparecendo em `SDTStructurePart`.

**Reprodução:**

1. `create_object type=SDT name=SdtFrictionProbe0513` → `Success`. Seed
   `Item1 : VARCHAR(40)` adicionado por `InitializeSDTWithDefaultItem`.
2. `edit part=Structure mode=full content="AluCod : NUMERIC(8,0)\nAluNom : CHARACTER(60)\nAluAtv : CHARACTER(1)"`
   → `{"status":"Success","details":"Structure DSL successfully applied"}`.
3. `read part=Structure` → `AluCod : NUMERIC\nAluNom : CHARACTER\nAluAtv : CHARACTER`
   (lengths sumiram no render, mas nomes estão lá — read aparenta OK).
4. Em outra Procedure, declarar `&Aluno : SdtFrictionProbe0513` (binding via
   ATTCUSTOMTYPE confirmado em log), escrever Source `&Aluno.AluCod = 42` etc.
5. Source save: `Success, persistedVerified=true`. **Nenhuma validação rodou.**
6. Tentar qualquer write subsequente que dispare validação (ex: patch
   Variables) → SDK falha com `src0216: 'AluCod' propriedade inválida`,
   `'AluNom' propriedade inválida`, `'AluAtv' propriedade inválida`.

**Evidência no log (`publish/worker/worker_debug.log`):**

```
14:13:49.469 [SDT ITEM DUMP] SdtFrictionProbe0513/Item1: Type=VARCHAR; Length=40
14:13:49.469 [SDT PARSE] Begin parse for SdtFrictionProbe0513 using part SDTStructurePart
14:13:49.493 [SDT DISCOVERY] Node: Artech.Genexus.Common.Parts.SDT.SDTLevel | Props/Methods: ... AddItem,AddItem,AddItem,AddItem,AddLevel,AddLevel,...
14:13:49.751 InvalidateCache: Object invalidated via reflection.
14:13:51.765 [BACKGROUND-FLUSH] Starting commits...
14:13:51.771 [BACKGROUND-FLUSH] Model.Commit() successful.
14:13:51.772 [BACKGROUND-FLUSH] KB.Commit() successful.
```

Entre `[SDT PARSE] Begin parse` e `InvalidateCache` **não há nenhum log de
`AddItem`** para AluCod/AluNom/AluAtv. O parser dispara discovery (que apenas
enumera methods/props pra debug) e cai direto no commit. Read pós-write não
re-dumpa items, então o read está renderizando text-source da part, não a
coleção `Items` real da SDK.

**Inconsistência observável:**
- `read part=Structure` → mostra meus 3 campos (text-source).
- `inspect include=["structure"]` → `uiStructure: {}` (vazio, nem mostra items).
- `structure action=get_logic` → `subs:[], events:[]` (também vazio).
- SDK validator → SDT só tem `Item1`, dá `propriedade inválida` nos 3 campos.

**Hipóteses de root cause** (precisa decompile, em linha com `7676158`,
`531bdd5`):
- `SdtDslParser.Parse` está achando a `SDTStructurePart` e atribuindo
  text-source/Dirty mas não chamando `SDTLevel.AddItem(...)` (ou chamando
  num node desconectado do `SDT.Root`).
- A correção do `4e9334a` (que fixou criação) introduziu um caminho onde
  a parse falha silenciosamente (catch vazio mencionado no report de 05-08
  pra `SyncSDTNodes`) e o commit do part Dirty=true persiste só o text-source.

**Recomendação:**
- Loggar contagem de items pré e pós-parse. Se delta = 0 mas content != "",
  retornar erro `SDT_STRUCTURE_NOT_APPLIED` em vez de `Success`.
- Adicionar smoke test em `src/GxMcp.Worker.Tests`: cria SDT, escreve 3
  fields, lê via `SDT.Root.GetAllItems().Count` (não via DSL render),
  assert == 3. Esse caso sai do read-back e bate na SDK real.
- Read de `part=Structure` deveria sempre serializar a partir da coleção
  `Items`, nunca de text-source cacheado — caso contrário read mente.

---

## 3. SDT auto-inject skip funciona mas mensagem de erro é enganosa

**Severidade:** média. Fix v2.1.6 #3 (`3dadeb2`) está fazendo o que prometeu —
quando `&Var.Field` é usado e o nome do var não bate com nenhum SDT/BC, a
injeção é skipada (sem criar VARCHAR(100) fantasma). ✅

Mas o erro que sobra é o do SDK, que diz `src0216: 'Id' propriedade inválida`.
Repro: escrevi `&Externo.Id = 1` em procedure sem `&Externo` declarado. O
agente lê "Id é propriedade inválida" e provavelmente pensa "errei o nome do
campo no SDT" — quando o problema é que `&Externo` não existe.

**Recomendação:** detectar (`src0216` + variável referenciada no Source NÃO
está em `Variables.part`) e enriquecer com:

> `src0216 likely caused by undeclared variable &Externo. Source references
> &Externo.Id but &Externo is not in the Variables part. Use
> genexus_add_variable name=<proc> varName=Externo typeName=<Sdt> to declare it.`

Já temos a infra de enrichment (`WritePolicy.PreferDetailedMessage` em v2.1.6).
Esse é um case adicional.

---

## 4. Variables patch volta a falhar verify mesmo no caminho limpo

**Severidade:** ALTA. Regressão direta sobre o fix v2.1.6 #5 — ou o fix não
está cobrindo este path.

**Reprodução (procedure nova, vazia, sem nenhuma referência a SDT broken):**

1. `create_object type=Procedure name=PrcFrictionProbe0513C` → Success.
2. `edit part=Variables mode=patch operation=Append content="&Counter : NUMERIC(4,0)"`
   →
   ```json
   {
     "status":"Error",
     "persistedVerified":false,
     "fallbackWriteStatus":"Success",
     "error":"Patch write verification mismatch after fallback write. Original source restored — re-read and retry.",
     "autoRollbackStatus":"Restored",
     "patchStatus":"Failed",
     "operation":"append",
     "matchCount":1
   }
   ```

Log mostra 3 saves (181 → 181 → 165 bytes): patch tentado, fallback tentado,
rollback aplicado. Ou seja: o SDK aceitou o write, mas o verify line-by-line
rejeitou — exatamente o sintoma que `NormalizeForPartCompare` (set-based em
Variables) deveria ter resolvido.

**Hipóteses:**
- `NormalizeForPartCompare` está sendo chamado, mas o teste de igualdade de
  conjuntos está case-sensitive ou está incluindo as standards
  (`&Today/&Time/...`) com hash diferente entre original e pós-write
  (talvez padding/whitespace diferente).
- O comparador caiu no caminho strict porque a part name não bate
  exatamente `"Variables"` (case ou alias).
- O fallback write (181 bytes idêntico) sobrescreveu a Variables com a
  versão "patched no original", e o verify comparou contra a versão SDK
  re-renderizada (ordem diferente). Verify tem que normalizar dos dois lados.

**Recomendação:** logar no DEBUG-SAVE o set comparado dos dois lados quando
verify falha. Acrescentar unit test em `src/GxMcp.Worker.Tests` que:
(a) cria proc vazio, (b) patch Append `&Counter : NUMERIC(4,0)`, (c) asserta
`persistedVerified=true`. Esse teste estaria caçando esse bug hoje.

---

## 5. Build response: `targets` sempre `null`

**Severidade:** baixa, contract gap.

`genexus_lifecycle action=build target="PrcFrictionProbe0513C"` retorna:

```json
{"status":"Accepted","taskId":"b81157b5","targets":null,"callersToAlsoBuild":null,...}
```

A doc da tool diz: *"The response includes 'targets' (the parsed list) and
status reports 'TargetsTotal'/'TargetsDone'."* Mas `targets` é null no
response inicial (e no `status` polling também — `TargetsTotal: 1` aparece,
`Targets: null`).

**Recomendação:** ou ecoa a lista parseada (`["PrcFrictionProbe0513C"]`) ou
remove o campo do contract para não enganar.

---

## 6. Mojibake em `lifecycle status.TailLines`

**Severidade:** cosmética, mas atrapalha leitura LLM.

```
"Compila��o de 13/05/2026 14:16:47 iniciada.",
"     1>Projeto ... no n� 1 (Execute destino(s)).",
"O ambiente de destino est� configurado para n�o reorganizar..."
```

MSBuild emite em CP1252 (locale PT-BR Windows), o worker está lendo como
UTF-8 e re-emitindo. Caracteres acentuados viram `��`.

**Recomendação:** ao spawnar MSBuild, setar `OutputEncoding =
Encoding.GetEncoding(850)` ou capturar via `ProcessStartInfo` com encoding
explícito. Ou pós-processar via `Encoding.GetEncoding(1252).GetString(...)`
antes de devolver.

---

## 7. `inspect include=["structure"]` em SDT retorna vazio

**Severidade:** média (redundância com #2 acima).

Mesmo num SDT funcional, `inspect(include=["structure"])` retorna
`uiStructure:{}` e nenhum dado dos items. Agente que quer um overview do SDT
sem ir pro `read part=Structure` fica cego.

**Recomendação:** estender `inspect` pra SDT cuspir `items:[{name,type,length,decimals,isCollection,isLevel,children?}]`
quando `structure` está no include. Hoje o tool é Trn-centric e não responde
pra SDT/Table.

---

## 8. `create_object SDT` não anuncia o seed `Item1`

**Severidade:** baixa.

Response do create é minimalista: `{status, type, name, id, correlationId}`.
Agente não sabe que o SDT já vem com seed `Item1 : VARCHAR(40)`, descobre só
depois do primeiro `read`. Para qualquer agent loop "create then populate",
isso significa que um `edit part=Structure mode=full` precisa sobrescrever
(o que apaga Item1) — comportamento que **deveria ser documentado no response**.

**Recomendação:** incluir `"_meta": {"seeded": ["Item1 : VARCHAR(40)"]}` no
response do create quando o tipo seed-by-default.

---

## Wins (sinais de saúde da v2.1.6)

Pra não focar só no negativo — coisas que funcionaram clean no smoke:

- ✅ **Bare-Erro enrichment** (fix #2): erro de SDT cuspiu `src0216` enriquecido
  com linha/char e nome do campo. Agent legível.
- ✅ **Variable→SDT binding read-side** (fix #4): `&Aluno : SdtFrictionProbe0513`
  apareceu corretamente no read da Variables part, não como `GX_SDT(4)`.
  Log mostra `[BindVariableToSdt] ATTCUSTOMTYPE set` e
  `Resolved variable Aluno type to SDT: SdtFrictionProbe0513`.
- ✅ **Auto-inject skip** (fix #3): variable não-resolvível como SDT/BC não
  é mais criada como VARCHAR(100) silencioso.
- ✅ **Source patch round-trip**: `mode=patch operation=Append` em Source
  funcionou (4→5 linhas), `persistedVerified=true`, read confirma.
- ✅ **Worker version match**: binários em `publish/worker/` casam com
  `bin/Release/` (timestamps idênticos). Só a constante hardcoded mente.
- ✅ **Delete_object**: removeu os 4 probes em 4 calls, sem erro nem órfãos
  visíveis no `query` posterior.

---

## Ranking subjetivo de impacto

1. **#2 — SDT Structure write não atualiza Items (stale tree)** — bloqueia
   qualquer fluxo "criar SDT + consumir" via MCP, que é o caso mais óbvio
   de um agente de IA tentar fazer arquitetura num KB.
2. **#4 — Variables patch verify-mismatch** — regressão sobre fix recém-fechado.
   Bloqueia patch de Variables fora do `mode=full`.
3. **#3 — Erro enganoso quando var não declarado** — derrota o objetivo da
   v2.1.6 de eliminar mensagens que levam o agente pra direção errada.
4. **#1 — serverVersion hardcoded** — pequeno, mas frustra exatamente o
   loop "verifica se está na nova versão" que um agente legítimo precisa.
5. **#7/#8 — gaps de inspect/create no SDT** — qualidade de vida do agente.
6. **#5/#6 — contract/encoding em lifecycle** — cosméticos.

---

## Próximo ciclo proposto

1. Decompilar `SdtDslParser` (ILSpy, ver `7676158` template) para isolar #2.
   Provavelmente um catch vazio comendo a falha do `AddItem`.
2. Reproduzir #4 em unit test e instrumentar o NormalizeForPartCompare.
3. Estender `WritePolicy.PreferDetailedMessage` com o case `src0216 + var
   missing` (#3).
4. #1 é trivial: ler de assembly version. ~10 min.
5. #7, #8: extensões diretas em `InspectService` e `CreateService` responses.
