# WWP pattern projection — discovery log

The narrative of finding the SDK entry points that actually project a WorkWithPlus
PatternInstance onto a target WebPanel's WebForm. Written so the next person
doesn't have to repeat the dead ends.

## The user's question

> Apply WorkWithPlus to an existing WebPanel — and have THAT WebPanel become
> the WWP screen. The IDE can do it via Right-click → Apply Pattern. We should
> be able to too.

## Dead ends (skip these next time)

1. **`PatternEngine.ApplyPattern(KBObject, PatternDefinition)`** (void overload).
   Returns silently for WebPanel/Procedure/SDPanel targets — no error, no
   generation. The engine route alone doesn't work for non-Transaction targets.

2. **Private ctor `PatternInstance(KBObject baseObject, Guid patternId)`** found
   via reflection. Creates a real `WorkWithPlus<X>` KBObject host with a
   PatternInstance part — but the host is **inert**. Editing its XML doesn't
   project onto the parent because no generator step ever fires. Misleading
   Success: F15 verified empirically that controls stay `[]`.

3. **Auto-orchestrate WebPanel → Transaction** (delete WebPanel, create Trn
   with same name, apply WWP). Worked mechanically but **destructive and
   semantically wrong** — the user asked for a WebPanel, not a Transaction.
   Killed by user feedback.

4. **`PatternEngine.ApplyPattern(PatternInstance, ApplySettings)`** (reapply
   overload). Throws `NullReferenceException` even when called with a properly
   materialised `ApplySettings` — the SDK needs additional context from the
   IDE service container that's not available headlessly.

5. **`WWP_ApplyTemplate` MSBuildTask.** Has the exact inputs you'd want
   (`WebPanelName`, `TemplateName`, `KB`) but the constructor fails to
   instantiate outside an MSBuild engine context.

## What actually works

```
PatternInstancePackageInterface.CreatePatternInstanceWithTemplate(
    KBModel model, KBObject parent, String templateName, out PatternInstance host
) -> Boolean

  → creates a real WorkWithPlus<X> KBObject host bound to `parent`, seeded with
    the chosen Template's structure. Return value is unreliable (observed false
    even on success); detect creation by FindObject("WorkWithPlus" + parent.Name).

PatternInstancePackageInterface.SetPatternApplyOnSave(KBObject host) -> Boolean
PatternInstancePackageInterface.ValidateAndSave(KBObject host) -> Boolean

  → toggles apply-on-save, persists.
```

Then the projection step (this was the missing piece):

```
new DVelop.Patterns.WorkWithPlus.WorkWithPattern()  // public ctor!
  ↓
WorkWithPattern.GetBuildProcess() -> IPatternBuildProcess
  ↓
IPatternBuildProcess.UpdateParentObject(KBObject parent, PatternInstance host) -> void

  → THIS is what writes the PatternInstance projection into parent's WebForm.
    The IDE invokes this internally during its save lifecycle.
```

After `UpdateParentObject`, save the parent with `KBObjectSavePreferences
{ ForceSave = true, SkipValidation = true }` — the projected WebForm can fail
WebPanel-level semantic validation while being structurally correct.

## Verified live (2026-05-20)

KB: `AcademicoHomolog1`, GeneXus 18.0.7, MCP worker headless.

```
1. genexus_create_object type=WebPanel name=ProjFinalTest
   → empty WebPanel created

2. genexus_apply_pattern name=ProjFinalTest pattern=WorkWithPlus
                         settings={template: "MatIsoTemplate"}
   → host WorkWithPlusProjFinalTest created with full template-derived
     PatternInstance:
     <instance type="WebPanel" baseWebForm="Abtract Layout" ...>
       <WPRoot Template="MatIsoTemplate">
         <table name="TableMain" type="Responsive">
           <errorViewer />
           <table name="TableContent" type="Responsive" />
         </table>
         <steps />
       </WPRoot>
     </instance>

3. read part=WebForm on ProjFinalTest:
   → BEFORE: empty
   → AFTER:  <Form type="layout"> with LayoutMainTable → TableMain →
             TableContent + errorViewer. The projection HAPPENED.
```

Confirmed in worker log:
```
[BUILD-PROC] Invoking <obfuscated>.UpdateParentObject(parent=ProjFinalTest, host=WorkWithPlusProjFinalTest)
[BUILD-PROC] UpdateParentObject returned successfully
[BUILD-PROC] Saved parent 'ProjFinalTest' (ForceSave+SkipValidation) after projection.
```

## Known gap — projection of subsequent edits

After the initial apply succeeds with projection, editing the host's
PatternInstance via `genexus_edit` lands correctly on disk, but a follow-up
`genexus_apply_pattern --reapply=true` doesn't always re-project. Suspected
cause: the cached `existingInstance` KBObject in the engine's static accessor
returns stale in-memory PatternInstance data. We added a re-resolve via
`FindObject` before calling UpdateParentObject; deeper cache invalidation
(maybe `host.Reset()` or `RefreshDefaultDependentParts()`) is the next stone
to turn.

## Where to keep digging

- `WorkWithPlusInstance.Load(PatternInstance)` (DVelop.Patterns.WorkWithPlus,
  static) returns a semantic wrapper. Investigation doc mentions it was
  successfully instantiated. May expose finer-grained generator hooks.
- `IPatternBuildProcess` has eight other lifecycle methods besides
  `UpdateParentObject` (`BeforeStartBuild`, `BeforeGenerateObjects`,
  `BeforeSaveObjects`, `AfterSaveObjects`, etc). Running the full sequence
  may be what the IDE actually does and might fix the stale-edit issue.
- `PatternImplementation` (the base class) has `InitializeBatch(KBModel)` /
  `CleanupBatch(KBModel)` — likely the surrounding context the engine sets
  up around UpdateParentObject in the real apply flow.
- `Artech.Packages.Patterns.Engine.InstanceObjects` carries `Instance`,
  `Objects`, `GeneratedObjects`, `Groups`. The "GeneratedObjects" set is
  what the IDE shows in the navigation tree after an apply — probably
  populated by `BeforeGenerateObjects` callbacks.

## Type relationship cheatsheet

```
PatternDefinition (Artech.Packages.Patterns.Definition)
  ├ Id, Name, ParentTypes, InstanceSpecification, SettingsSpecification
  ├ Objects: BaseCollection<PatternObject>   // the generators (Selection, View, etc)
  ├ Resources, Files, Appends, PropertyDefinitions
  └ associated impl class: PatternImplementation subclass

PatternImplementation (Artech.Packages.Patterns.Custom) — abstract base
  ├ Initialize()
  ├ GetBuildProcess() -> IPatternBuildProcess     // ← THE projection step is in here
  ├ GetInstanceGenerator() -> IDefaultInstanceGenerator
  ├ GetDeleteProcess() -> IPatternDeleteProcess
  ├ GetInstanceValidator() -> IPatternValidator
  ├ GetInstanceUpdateProcess() -> IPatternUpdateProcess
  ├ GetInstanceVersionAdapter() -> IPatternVersionAdapter
  ├ GetInstanceSources(), GetInstanceOneSource()
  ├ GetInstanceEditorHelper() / GetSettingsEditorHelper()
  ├ GetTemplateHelper() -> IPatternTemplateHelper
  ├ GetReferenceHelper() -> IPatternReferenceHelper
  └ GetExtensionPackage() -> IGxPackage

DVelop.Patterns.WorkWithPlus.WorkWithPattern : PatternImplementation
  ├ public ctor()                       // ← we can instantiate directly!
  ├ Properties: Id, Definition
  └ All the Get* methods overridden with WWP-specific impls

IPatternBuildProcess (Artech.Packages.Patterns.Custom)
  ├ ShouldBuild(PatternInstance) -> bool?
  ├ BeforeStartBuild(PatternInstance)
  ├ AfterImportResources(PatternInstance)
  ├ BeforeGenerateObjects(PatternInstance, IBaseCollection<PatternObject>)
  ├ BeforeGenerateObject(PatternInstance, InstanceObject)
  ├ BeforeSaveObjects(PatternInstance, InstanceObjects)
  ├ UpdateParentObject(KBObject parent, PatternInstance instance)  // ← projection!
  ├ AfterSaveObjects(PatternInstance, InstanceObjects)
  └ AfterEndBuild(PatternInstance)

PatternInstancePackageInterface (DVelop.Patterns.WorkWithPlus.Helpers)
  ├ static CreatePatternInstanceWithTemplate(KBModel, KBObject, String, out PatternInstance) -> bool
  ├ static SetPatternApplyOnSave(KBObject) -> bool
  └ static ValidateAndSave(KBObject) -> bool
```
