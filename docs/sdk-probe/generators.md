# Generator / Builder / Applier candidates

> Types whose name contains generator-shaped keywords (Generator/Builder/Apply/Refresh/
> Update/Project/Generate/Save/Engine/Helper/Service/Resolver/Process/Execute/Render/
> Compose/Materialize/Wire/Bind/Attach). First 8 public methods shown per type — see
> `raw.json` for the complete member list.

**Count:** 1573

## `Artech.Architecture.Common`

### `Artech.Architecture.Common.Cache.UpdateCacheEventArgs`

```
Contains(EntityKey key) -> Boolean
ContainsType(Guid type) -> Boolean
```

### `Artech.Architecture.Common.Cache.UpdateCacheEventArgs+UpdateType`

```

```

### `Artech.Architecture.Common.Converters.ConverterHelper`

```
static GetModelFromContext(ITypeDescriptorContext context) -> KBModel
static GetModelFromObject(Object instance) -> KBModel
static IsInternalProperty(String propertyName) -> Boolean
static ConvertToStringStorage(T objectValue,String& stringValue) -> Boolean
static ConvertFromStringStorage(String stringValue,T& objectValue) -> Boolean
static ConvertFromKMString(String stringValue,T& objectValue) -> Boolean
static SetModelProperty(IPropertyBag bag,KBModel model) -> Void
static SetKBObjectProperty(IPropertyBag bag,KBObject kbobj) -> Void
```

### `Artech.Architecture.Common.Defaults.IApplyDefaultTarget`

```
GetProviders() -> IList`1<String>
GetProviderData(String provider) -> String
SetProviderData(String provider,String data) -> Void
RemoveProviderData(String provider) -> Void
SilentSetIsDefault(Boolean value) -> Void
CanCalculateDefault() -> Boolean
CalculateDefault() -> Void
PreserveDefaultLock() -> Void
```

### `Artech.Architecture.Common.Events.AttachToKBEventsBeforeOpenAttribute`

```

```

### `Artech.Architecture.Common.Events.BuiltInObjectUpdateEventArgs`

```

```

### `Artech.Architecture.Common.Events.EventsService`

```
Participate(Object item) -> Boolean
Revoke(Object item) -> Boolean
ScopedParticipation(Object item) -> IParticipation
```

### `Artech.Architecture.Common.Events.KBObjectSaveEventArgs`

```

```

### `Artech.Architecture.Common.Helpers.CopyModelSaveOptions`

```

```

### `Artech.Architecture.Common.Helpers.EntityHelper`

```
static TryGetEntitiesFrom(Object obj) -> IEnumerable`1<Entity>
static TryGetEntityFrom(Object obj) -> Entity
static TryGetEntitiesFrom(Object obj) -> IEnumerable`1<TEntity>
static TryGetEntityFrom(Object obj) -> TEntity
static TryGetOnlyOneEntityFrom(Object obj) -> Entity
static TryGetOnlyOneEntityFrom(Object obj) -> TEntity
```

### `Artech.Architecture.Common.Helpers.GxlDocumentHelper`

```
AddNode(Entity entity,String title) -> XmlNode
AddNode(IExportItem item,String title) -> XmlNode
AddNode(KBObject obj,String title,String topicId,Int64 topicNum) -> XmlNode
RemoveNode(KBObject obj) -> Void
AddNode(KBObject obj,String title,String topicId,Int64 topicNum,Boolean overwrite) -> XmlNode
AddVariableNode(XmlNode parent,Int32 varId,String name,String title,String topicId,Int64 topicNum,Boolean overwrite) -> XmlNode
GetObjects() -> IEnumerable`1<XmlNode>
GetObjectVariables(XmlNode objNode) -> IEnumerable`1<XmlNode>
```

### `Artech.Architecture.Common.Helpers.KBObjectParentHelper`

```
static LoadModuleAndFolderChildren(ICollection`1<KBObject> objects) -> Void
```

### `Artech.Architecture.Common.Helpers.KBObjectSelectionHelper`

```
static TryGetKBObjectsFrom(Object obj) -> IEnumerable`1<KBObject>
static TryGetKBModelsFrom(Object obj) -> IEnumerable`1<KBModel>
static TryGetKBObjectFrom(Object obj) -> KBObject
static TryGetKBModelFrom(Object obj) -> KBModel
static TryGetOneKBModelFrom(Object obj) -> KBModel
static TryGetKBObjectsFrom(Object obj) -> IEnumerable`1<TKBObject>
static TryGetKBObjectFrom(Object obj) -> TKBObject
static TryGetOnlyOneKBObjectFrom(Object obj) -> KBObject
```

### `Artech.Architecture.Common.Helpers.KBVersionHelper`

```
static FreezeModel(String kbVersionName,String kbVersionDescription,KBVersion parentKBVersion,Boolean backupModel) -> KBVersion
static FreezeModel(String kbVersionName,String kbVersionDescription,KBVersion parentKBVersion) -> KBVersion
static FreezeModel(String kbVersionName,String kbVersionDescription,KBVersion parentKBVersion,Boolean backupModel,Boolean includeModels) -> KBVersion
static BranchModel(String kbVersionName,String kbVersionDescription,KBVersion parentKBVersion,Boolean includeEnvironments) -> KBVersion
static ModelToBranch(String kbVersionName,String kbVersionDescription,KBVersion parentKBVersion,KBModel branchForModel) -> KBVersion
static SetAsActive(KBVersion kbVersion) -> Void
static SetAsActive(KBVersion kbVersion,Boolean autoUpdate) -> Void
static Revert(KBVersion fromVersion,KBVersion toVersion) -> Void
```

### `Artech.Architecture.Common.Helpers.ObjectDefinitionHelper`

```
static LoadDefinitionsFor(String typeName) -> List`1<ObjectTemplate>
static LoadDefinitionFor(String typeName,String name) -> ObjectTemplate
```

### `Artech.Architecture.Common.Helpers.ObjectNameHelper`

```
static Get(KBModel model,Guid type,String name) -> KBObject
static Get(KBModel model,Guid type,String name,Boolean silent) -> KBObject
static GetKey(KBModel model,Guid type,String name) -> EntityKey
static GetKey(KBModel model,Guid type,String name,Boolean silent) -> EntityKey
static Get(KBModel model,String name,Boolean checkPrefix) -> KBObject
static GetKey(KBModel model,String name,Boolean checkPrefix) -> EntityKey
static Get(KBModel model,String name,Boolean checkPrefix,Boolean silent) -> KBObject
static GetKey(KBModel model,String name,Boolean checkPrefix,Boolean silent) -> EntityKey
```

### `Artech.Architecture.Common.Helpers.ObjectNameListHelper`

```
static GetGXLObjects(KBModel model,String gxlFileName) -> IEnumerable`1<KBObject>
static GetGXLKeys(KBModel model,String gxlFileName) -> IEnumerable`1<KeyValuePair`2<String,String>>
static GetObjects(KBModel model,String objects) -> IEnumerable`1<KBObject>
static GetObjects(KBModel model,String objects,Boolean silent) -> IEnumerable`1<KBObject>
static GetObjects(KBModel model,IEnumerable`1<String> objects,Guid defaultType) -> IEnumerable`1<KBObject>
static GetObjects(KBModel model,IEnumerable`1<String> objects,Guid defaultType,Boolean silent) -> IEnumerable`1<KBObject>
static GetObjectsName(KBModel model,String objects) -> IEnumerable`1<KeyValuePair`2<String,String>>
static SafeSplitBy(String list,Char separator) -> IEnumerable`1<String>
```

### `Artech.Architecture.Common.Helpers.PropertyContextHelper`

```
static GetModel(ITypeDescriptorContext context) -> KBModel
static GetModel(IPropertyBag propertyBag) -> KBModel
static GetModel(Object obj) -> KBModel
static GetModule(ITypeDescriptorContext context) -> Module
static GetModule(IPropertyBag propertyBag) -> Module
static GetModule(Object obj) -> Module
static GetObject(ITypeDescriptorContext context) -> KBObject
static GetObject(IPropertyBag propertyBag) -> KBObject
```

### `Artech.Architecture.Common.Helpers.TeamDevKBObjectHelper`

```
static GetChecksum(KBObject obj) -> String
static TryGetKBObjectsFrom(Object obj) -> IEnumerable`1<KBObject>
static TryGetKBObjectFrom(Object obj) -> KBObject
```

### `Artech.Architecture.Common.Mapping.Definition.Builder`

```
static CreateFrom(String fileDefinition,Mapping& mapping) -> Boolean
static CreateFrom(XmlReader reader,Mapping& mapping) -> Boolean
```

### `Artech.Architecture.Common.Modules.ObjectModuleHelper`

```
static GetModuleAssociation(IKBObject obj) -> ModuleAssociation
static GetModuleAssociation(Guid type) -> ModuleAssociation
static TryGetModuleAssociation(Guid type) -> Nullable`1<ModuleAssociation>
static UsesModule(KBObject obj) -> Boolean
static UsesModule(Guid type) -> Boolean
static UsesModule(ModuleAssociation behavior) -> Boolean
static AllowModuleSeparator(Guid type) -> Boolean
static IsGlobal(Guid type) -> Boolean
```

### `Artech.Architecture.Common.Modules.ObjectNameResolver`

```
static Resolve(KBModel model,Module fromModule,Nullable`1<Guid> type,String name,ResolveResult& result) -> Boolean
static ResolvePossibleTypes(KBModel model,Module fromModule,IEnumerable`1<Guid> types,String name,ResolveResult& result) -> Boolean
static Resolve(KBModel model,Module fromModule,Nullable`1<Guid> type,String name,ResolveKeyResult& result) -> Boolean
static ResolvePossibleTypes(KBModel model,Module fromModule,IEnumerable`1<Guid> types,String name,ResolveKeyResult& result) -> Boolean
static Resolve(KBModel model,Module fromModule,String namespace,String name,ResolveKeyResult& result) -> Boolean
static Qualify(KBModel model,Module fromModule,KBObject obj) -> String
static Qualify(KBModel model,Module fromModule,EntityKey objKey,KBObjectNameKey name) -> String
```

### `Artech.Architecture.Common.Objects.IResolveResult`1`

```

```

### `Artech.Architecture.Common.Objects.KBObject+SaveType`

```

```

### `Artech.Architecture.Common.Objects.KBObjectReferenceHelper`

```
static GetName(KBObject obj) -> String
static GetName(KBModel model,EntityKey entityKey) -> String
static GetFullQualifiedName(KBModel model,EntityKey entityKey) -> String
static GetExclude(ITypeDescriptorContext context) -> EntityKey
static GetModel(ITypeDescriptorContext context) -> KBModel
static GetModule(ITypeDescriptorContext context) -> Module
static GetModule(ITypeDescriptorContext context,UseDesignModel option) -> Module
static GetSettings(ITypeDescriptorContext context) -> KBObjectReferenceSettingsAttribute
```

### `Artech.Architecture.Common.Objects.KBObjectSavePreferences`

```

```

### `Artech.Architecture.Common.Objects.KBVersion+Helper`

```

```

### `Artech.Architecture.Common.Objects.KBVersionRevision+ActionHelper`

```

```

### `Artech.Architecture.Common.Objects.KBVersionRevision+Helper`

```

```

### `Artech.Architecture.Common.Objects.ResolveResult`

```
static NoMatch(Nullable`1<Guid> type,String name) -> ResolveResult
```

### `Artech.Architecture.Common.Objects.ResolveResultBase`1`

```

```

### `Artech.Architecture.Common.Packages.IHistoryOperationResolver`

```
MustBeTransfered(Guid type,Mode mode) -> Boolean
```

### `Artech.Architecture.Common.Packages.IMenuBuilder`

```
AddMenus(Menu[] menus,CommandDefinition[] commands,Group[] groups,IMenuResolver resolver) -> Void
BuildMenus() -> Void
```

### `Artech.Architecture.Common.Packages.IMenuResolver`

```
GetImage(Guid g,String resourceName,Int32 stripId) -> Image
GetString(String resourceName) -> String
GetGuid(String guid) -> Guid
GetDefaultGuid() -> Guid
```

### `Artech.Architecture.Common.Resolvers.DesignModelReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.ImportTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.KBVersionTimeStampResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.ModelNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.ModelNameVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.ModuleManagerVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.ModuleResourcesApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.ModuleVersionValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Architecture.Common.Resolvers.ObjectDescriptionResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.PackagedModuleNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Architecture.Common.Resolvers.PackagedModuleNameValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Architecture.Common.Resolvers.ResolverHelper`

```

```

### `Artech.Architecture.Common.Services.AbstractService`

```
UnloadService() -> Void
Initialize() -> Void
OnAfterOpenKB(Object sender,KBEventArgs e) -> Void
```

### `Artech.Architecture.Common.Services.AbstractServiceWithProgress`

```
NotifyMessageEx(Int32 code,String data) -> Void
IncrementProgress() -> Void
ProgressRange(Int32 range) -> Void
IncrementProgressFile() -> Void
SetFileProgressRange(Int32 range) -> Void
NotifyMessage(String data) -> Void
NotifyStage(String data) -> Void
OnObjectStarted(String name,String type,String desc) -> Void
```

### `Artech.Architecture.Common.Services.ApplicationHelpGeneratorOptions`

```

```

### `Artech.Architecture.Common.Services.CommonServices`

```

```

### `Artech.Architecture.Common.Services.Comparer.IComparerObjectHelper`

```
ShouldComparePart(Guid partType) -> Boolean
ShouldCompareObjects(KBObject left,KBObject right) -> Boolean
```

### `Artech.Architecture.Common.Services.ComparerPartHelper`1`

```
CompareParts(TObjectPart left,TObjectPart right,ComparePartOptions options,IComparerObserver observer,DiffNodes& editScript) -> Void
```

### `Artech.Architecture.Common.Services.ExportItemHelper`

```

```

### `Artech.Architecture.Common.Services.IAzureDeploymentService`

```
DeployToAzureWebRole(KBEnvironment environment,AzureDeployData data) -> Boolean
```

### `Artech.Architecture.Common.Services.ICloudPrototypingService`

```
RegisterServers(ICloudServerManager serverManager) -> Boolean
GetConnectionString(KBModel model,String serverName,CloudConnectionData& connection) -> Boolean
GetConnectionString(KBModel model,String serverName,CloudConnectionData& connection,Boolean force) -> Boolean
GetServers(KBModel model) -> IEnumerable`1<CloudServer>
ValidateConnectionString(KBModel model,String appHost,String appUrl) -> Boolean
```

### `Artech.Architecture.Common.Services.IComparerPartHelper`

```
CompareParts(KBObjectPart left,KBObjectPart right,ComparePartOptions options,IComparerObserver observer,DiffNodes& editScript) -> Void
```

### `Artech.Architecture.Common.Services.IComparerService`

```
AreEqualInContent(KBObject left,KBObject right,CompareObjectOptions objectOptions) -> Boolean
AreEqualInContent(KBObjectPart left,KBObjectPart right,Boolean compareVisualContent,CompareObjectOptions objectOptions) -> Boolean
AreEqualInProperties(PropertiesObject left,PropertiesObject right,ComparePropertiesOptions propertiesOptions) -> Boolean
AreEqualInCategories(KBObject left,KBObject right) -> Boolean
CanCompareObjects(KBObject left,KBObject right) -> Boolean
ShouldComparePart() -> Boolean
ShouldComparePart(Guid objType,Guid partType) -> Boolean
CompareParts(KBObjectPart left,KBObjectPart right,ComparePartOptions options,DiffNodes& editScript) -> Void
```

### `Artech.Architecture.Common.Services.IDeploymentService`

```
Deploy(KBModel model) -> Boolean
```

### `Artech.Architecture.Common.Services.IExportItemSaveObserver`

```
SetAfterSaveHandler(EventHandler`1<EntityStatusArgs> handler) -> Void
```

### `Artech.Architecture.Common.Services.IGXserverService`

```
Commit(ServerCommitData data,Action afterCommitImport,String& errorMsg) -> Boolean
GetUpdateFile(ServerUpdateData data) -> String
GetPartialUpdateFile(ServerUpdateData data,String incomingPath) -> String
GetCommitFile(ServerGetCommitData data) -> Void
GetKBObjectRevision(KBVersionRevision revision,Guid objGuid) -> String
GetRevisionChanges(List`1<KBVersionRevision> revision,DateTime previousTimestamp,Boolean IncludeReferencesDependencies) -> String
GetRevisionChanges(List`1<KBVersionRevision> revision,DateTime previousTimestamp,Guid objectGuid,Boolean justAfterXML,Boolean IncludeReferencesDependencies) -> String
Lock(ServerLockData data) -> ServerLockData
```

### `Artech.Architecture.Common.Services.IGxService`

```
UnloadService() -> Void
Initialize() -> Void
```

### `Artech.Architecture.Common.Services.IGxServiceOverride`

```

```

### `Artech.Architecture.Common.Services.IGxServiceProvider`

```
GetService(Guid serviceId) -> IGxService
GetService() -> TService
TryGetService(Guid serviceId,IGxService& service) -> Boolean
TryGetService(TService& service) -> Boolean
EnableServices() -> Void
UnloadServices() -> Void
ReplaceServices(IServicesExtension extension) -> Void
```

### `Artech.Architecture.Common.Services.IHelpGeneratorService`

```
Generate(ApplicationHelpGeneratorOptions options) -> Boolean
Generate(ApplicationHelpGeneratorOptions options,IProgressListener listener) -> Boolean
Import(String gxlFileName,ApplicationHelpImportOptions options) -> Boolean
Import(String gxlFileName,ApplicationHelpImportOptions options,IProgressListener listener) -> Boolean
```

### `Artech.Architecture.Common.Services.IIndexService`

```
AddContent(KBObject kbObject) -> Void
RegisterIndex(KBModel kb) -> Void
PauseIndexing(KBModel model) -> Void
ResumeIndexing(KBModel model) -> Void
```

### `Artech.Architecture.Common.Services.IIntegratedSecurityService`

```
DefineAPI(KBEnvironment environment,Boolean force) -> Boolean
Deploy(KBModel target) -> Boolean
Deploy(KBModel target,Boolean forceTableCreation,Boolean rebuild) -> Boolean
Deploy(KBModel target,DeploySettings settings) -> Boolean
RegisterType(Guid objectType) -> Void
IsIntegratedSecurityDatastore(String datastoreName) -> Boolean
GetReorganizeGamDatabasePropertyValue(KBModel model) -> Boolean
IsEnabledIntegratedSecurity(KBModel model) -> Boolean
```

### `Artech.Architecture.Common.Services.IKBConversionService`

```
NeedConversion(String location,SourceKBVersion& fromVersion) -> Boolean
Convert(SourceKBVersion fromVersion,KBConnectionInfo connectionInfo) -> Boolean
ConvertKBTablesFromYi(String kbLocation) -> Boolean
AddConverter(IKBConverter converter) -> Void
```

### `Artech.Architecture.Common.Services.IKnowledgeManagerService`

```
ImportFile(String kbxFile,KBModel model,ImportOptions options) -> Boolean
PrepareImport(String kbxFile,KBModel model,ImportOptions options) -> IKnowledgeManagerImport
PrepareImport(KMFileInfo fileInfo,KMSourceInfo sourceInfo,KBModel model,ImportOptions options) -> IKnowledgeManagerImport
PrepareImport(KMFileInfo fileinfo,KMSourceInfo sourceInfo,KBModel model,ImportOptions options,Guid sessionId) -> IKnowledgeManagerImport
ExploreExport(String sFile,KBModel model,ExploreExportOptions options,IList`1& objects,IList`1& actions,IList`1& idMap) -> Void
ExploreExport(String sFile,KBModel model,ExploreExportOptions options,IList`1& objects,IList`1& actions,IList`1& idMap,KMFileInfo& fileInfo,KMSourceInfo& sourceInfo) -> Void
ExploreExport(String sFile,KBModel model,ExploreExportOptions options,IList`1& objects,IList`1& actions,IList`1& idMap,KMFileInfo& fileInfo,KMSourceInfo& sourceInfo,Dictionary`2& objsRefsandDeps) -> Void
ExploreExport(String sFile,KBModel model,ExploreExportOptions options,IList`1& objects,IList`1& actions,IList`1& idMap,KMFileInfo& fileInfo,KMSourceInfo& sourceInfo,IList`1& dependencies) -> Void
```

### `Artech.Architecture.Common.Services.IMergePartHelper`

```
MergeParts(KBObjectPart basePart,KBObjectPart leftPart,KBObjectPart rightPart,KBObject targetObj,IMergeObserver observer) -> Void
```

### `Artech.Architecture.Common.Services.IMergePropertyHelper`

```
TryMergeProperty(PropDefinition def,PropertiesObject baseProp,PropertiesObject leftProp,PropertiesObject rightProp,PropertiesObject resultProp) -> Boolean
```

### `Artech.Architecture.Common.Services.IMergeService`

```
MergeObjects(KBObject baseObj,KBObject leftObj,KBObject rightObj,KBModel targetModel) -> KBObject
MergeObjects(KBObject baseObj,KBObject leftObj,KBObject rightObj,KBModel targetModel,MergeObjectOptions options) -> KBObject
MergeParts(KBObjectPart basePart,KBObjectPart leftPart,KBObjectPart rightPart,KBObject targetObj) -> Void
MergeParts(KBObjectPart basePart,KBObjectPart leftPart,KBObjectPart rightPart,KBObject targetObj,MergeObjectOptions options) -> Void
MergeVersions(KBVersion frozenReference,KBVersion developmentTarget,KBVersion developmentSource,MergeVersionOptions options) -> Boolean
MergeModels(KBModel refModel,KBModel tgtModel,KBModel srcModel) -> Boolean
MergeModels(KBModel refModel,KBModel tgtModel,KBModel srcModel,MergeModelOptions options) -> Boolean
MergeModels(KBModel refModel,KBModel tgtModel,KBModel srcModel,MergeModelOptions options,String filename) -> Boolean
```

### `Artech.Architecture.Common.Services.IModuleManagerService`

```
Install(KBModel model,ModulePackage module) -> Boolean
Install(KBModel model,IModuleManagerServer server,ModulePackage module) -> Boolean
InstallAndOverwrite(KBModel model,IModuleManagerServer server,ModulePackage module) -> Boolean
Install(KBModel model,String opcFile) -> Boolean
InstallByName(KBModel model,String name,String version) -> Boolean
InstallBuiltIn(KBModel model,String name) -> Boolean
InstallAsync(KBModel model,String opcFile,IDictionary`2<String,Object> context,IProgress`1<Int32> progress,CancellationToken cancellationToken) -> Task`1<Boolean>
Update(KBModel model,Module module,String version) -> Boolean
```

### `Artech.Architecture.Common.Services.IModuleManagerServiceSettings`

```

```

### `Artech.Architecture.Common.Services.IOutputService`

```
AddListener(IOutputTarget target) -> Void
AddListener(String outputId,IOutputTarget target) -> Void
AddListener(IMultipleOutputTarget target) -> Void
RemoveListener(IOutputTarget target) -> Void
RemoveListener(IMultipleOutputTarget target) -> Void
SelectOutput(String outputId) -> Void
UnselectOutput(String outputId) -> Void
StartSection(String outputId,String sectionId,String sectionName) -> Void
```

### `Artech.Architecture.Common.Services.IOutputService2`

```

```

### `Artech.Architecture.Common.Services.IReferenceResolver`

```
GetAttributeFromName(KBModel model,String attName) -> Int32
GetAttribute(KBModel model,String attName) -> KBObject
GetKBObject(KBModel model,Module fromModule,Guid objType,String name) -> KBObject
```

### `Artech.Architecture.Common.Services.ISearchService`

```
Search(KBCategory category) -> IList`1<IResultItem>
Search(KBModel model,String text,String tags) -> IList`1<IResultItem>
Search(KBModel model,String query,String tags,Boolean allBranches) -> IList`1<IResultItem>
Search(KBModel model,String text,String tags,Int32 maxCount) -> IList`1<IResultItem>
Search(KBModel model,String text,String tags,Int32 maxCount,Boolean onlyTitles) -> IList`1<IResultItem>
IsCategoryAffected(KBCategory category) -> Boolean
AddSearchableProperties(ISearchableProperties properties) -> Void
```

### `Artech.Architecture.Common.Services.IServicesExtension`

```
CreateService(IGxService currentService) -> IGxService
```

### `Artech.Architecture.Common.Services.IStatisticsService`

```
RegisterEvent(KBModel model,Guid type,String additionalInfo,String user) -> Void
GetOperationsByDate(KBModel model,Guid type,Int32 count) -> IEnumerable`1<OperationEvent>
GetEntitiesByDate(KBModel model,Guid type,Int32 count) -> IEnumerable`1<OperationEvent>
```

### `Artech.Architecture.Common.Services.ITeamDevClientService`

```
GetServerObject(ServerObjectData data) -> KBObject
GetObjectHasConflict(KBModel model,EntityKey key,DateTime time,UpdateConflict conflictType) -> Boolean
GetConflictEntities(KBModel model,UpdateConflict conflictType) -> IEnumerable`1<Entity>
MarkAsResolved(KBModel model,IEnumerable`1<EntityKey> keys) -> Boolean
GetPreviousSynchedObject(KBModel model,EntityKey key) -> KBObject
GetObjectBeforeSynchronization(KBModel model,EntityKey key) -> KBObject
GetLastSynchedObject(KBModel model,EntityKey key) -> KBObject
GetObject(KBModel model,Guid objGuid,String path) -> KBObject
```

### `Artech.Architecture.Common.Services.MergePartHelper`1`

```
MergeParts(TObjectPart basePart,TObjectPart leftPart,TObjectPart rightPart,KBObject targetObj,IMergeObserver observer) -> Void
```

### `Artech.Architecture.Common.Services.ModuleManagerServerContextHelper`

```
static MustForceUpload(IDictionary`2<String,Object> context) -> Boolean
static SetForceUpload(IDictionary`2<String,Object> context,Boolean value) -> Void
static MustForceExtract(IDictionary`2<String,Object> context) -> Boolean
static SetForceExtract(IDictionary`2<String,Object> context,Boolean value) -> Void
static GetBoolValue(IDictionary`2<String,Object> context,String key) -> Boolean
static GetValue(IDictionary`2<String,Object> context,String key) -> Object
static SetValue(IDictionary`2<String,Object> context,String key,Object value) -> Void
```

### `Artech.Architecture.Common.Services.OutputService2Extensions`

```
static GetDefaultOutputId(IOutputService service) -> String
```

### `Artech.Architecture.Common.Services.SaveHeaderHandler`

```
Invoke(IExportItem sender,KBObject obj) -> Void
BeginInvoke(IExportItem sender,KBObject obj,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Architecture.Common.Services.ServiceNotFoundException`

```
GetObjectData(SerializationInfo info,StreamingContext context) -> Void
```

### `Artech.Architecture.Common.Services.Services`

```
static GetService(Guid serviceId) -> IGxService
static GetService() -> TService
static TryGetService(Guid serviceId) -> IGxService
static TryGetService() -> TSrv
```

### `Artech.Architecture.Common.Services.StatisticsService`

```
RegisterEvent(KBModel model,Guid type,String additionalInfo,String user) -> Void
GetOperationsByDate(KBModel model,Guid type,Int32 count) -> IEnumerable`1<OperationEvent>
GetEntitiesByDate(KBModel model,Guid type,Int32 count) -> IEnumerable`1<OperationEvent>
```

### `Artech.Architecture.Common.Services.TeamDev.ITeamDevClientUpdate`

```
IgnoreForUpdate(TeamDevUpdateItem item) -> Void
GetItemPreview(TeamDevUpdateItem item) -> IExportItem
GetExportItem(TeamDevUpdateItem item) -> IExportItem
Update(IEnumerable`1<TeamDevUpdateItem> items) -> Boolean
Update() -> Boolean
GetReferences(IEnumerable`1<TeamDevUpdateItem> selectedItems,IEnumerable`1<TeamDevUpdateItem> includedItems,Boolean actionCheck) -> IEnumerable`1<TeamDevUpdateItem>
```

### `Artech.Architecture.Common.Services.TeamDev.TeamDevUpdateItem`

```

```

### `Artech.Architecture.Common.Services.TeamDevData.Client.TeamDevIgnoreUpdateData`

```

```

### `Artech.Architecture.Common.Services.TeamDevData.Server.ServerUpdateData`

```

```

### `Artech.Architecture.Common.Services.TeamDevData.Server.ServerUpdateToRevisionData`

```

```

### `Artech.Architecture.Common.Services.UpdateConflict`

```

```

### `Artech.Architecture.Common.Threading.ProcessLine`

```
Invoke(String text) -> Boolean
BeginInvoke(String text,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Boolean
```

### `Artech.Architecture.Common.Threading.ProcessRunner`

```
SetData(String sectionName,IEnumerable`1<String> otherSectionNames,ProcessLine processLine,Boolean validOutput) -> Void
SetData(String firstSectionName,IEnumerable`1<String> otherSectionNames,ProcessLine processLine) -> Void
Run(String fileName,String arguments) -> Boolean
GetState() -> ProcessState
SetState(ProcessState state) -> Void
Wait() -> Boolean
Wait(Int32 noerrorExitCode) -> Boolean
Wait(Int32& exitCode) -> Boolean
```

### `Artech.Architecture.Common.Threading.ProcessRunner+ProcessState`

```

```

### `Artech.Architecture.Common.Threading.ProcessRunnerData`

```
Clear() -> Void
```

### `Artech.Architecture.Common.UriHelper`

```
static Build(String kbPath,String[] parameters) -> String
static BuildCommand(Guid packageGuid,String cmdName,String[] parameters) -> String
static Append(String uri,String[] parameters) -> String
static TryParse(String uri,String& kbPath,IDictionary`2<String,String> info) -> Boolean
static Parse(String uri,String& kbPath,IDictionary`2<String,String> info) -> Boolean
```

### `Artech.Packages.Definition.Builder`

```
static CreateFrom(String fileDefinition,Package& package) -> Boolean
static CreateFrom(XmlReader reader,Package& package) -> Boolean
```

### `Artech.Packages.Definition.PackageServices`

```

```

### `Artech.Packages.Definition.Service`

```

```

### `Artech.Packages.Definition.ServiceGenericObjAction`

```

```

## `Artech.Architecture.Language`

### `Artech.Architecture.Language.Datatypes.TypedObjectResolver`

```
Get(ParserInfo info,KBObject obj) -> ITypedObjectInfo
```

### `Artech.Architecture.Language.Helpers.NameHelper`

```
static GetName(IParserObjectBase obj) -> String
static GetName(IParserObjectBase obj,String defaultName) -> String
static GetExpressionText(IParserObjectBase obj) -> String
```

### `Artech.Architecture.Language.Helpers.TypeHelper`

```
static HasModifier(IEnumerable`1<IModifierDefinition> modifiers,String modifierName) -> Boolean
static HasModifierValue(IEnumerable`1<IModifierDefinition> modifiers,String name,String value) -> Boolean
static GetModifierValues(IEnumerable`1<IModifierDefinition> modifiers,String modifierName) -> IEnumerable`1<String>
static GetModifierFirstValue(IEnumerable`1<IModifierDefinition> modifiers,String modifierName) -> String
static GetModifierValue(IModifierDefinition modifier,Int32 indexValue) -> String
static GetModifierValues(IModifierDefinition modifier) -> IEnumerable`1<String>
```

### `Artech.Architecture.Language.Helpers.TypeMethodHelper`

```
static GetMethodSignature(IMethodInfo method) -> String
static GetSignature(String name,String outputTypeName,IEnumerable`1<IParameterInfo> parameters) -> String
static CalculateMethodParameters(IEnumerable`1<IParameterInfo> parameters,Int32& maxParameterCount,Int32& minParameterCount) -> Void
static CalculateMethodParameters(IEnumerable`1<IParameterDefinition> parameters,Int32& maxParameterCount,Int32& minParameterCount) -> Void
```

### `Artech.Architecture.Language.Parser.IParserEngine`

```
GetStringBuffer(String text) -> IParserBuffer
ConvertSourceToString(ParserInfo info,String source) -> String
ConvertStringToSource(ParserInfo info,String text) -> String
ConvertToSource(String& source) -> Boolean
ConvertSourceToProlog(ParserInfo info,String source,Boolean ignorePosition) -> String
ParseFormula(ParserInfo info,IParserBuffer buffer) -> Boolean
ParseSource(ParserInfo info,IParserBuffer buffer) -> Boolean
GetReferences(OutputMessages references) -> Boolean
```

### `Artech.Architecture.Language.Parser.IParserEngine2`

```

```

### `Artech.Architecture.Language.Services.ILanguageService`

```
CreateEngine() -> IParserEngine
CreateManager(KBModel model) -> ILanguageManager
```

## `Artech.Architecture.UI.Framework`

### `Artech.Architecture.UI.Framework.Controls.IOutlinerItem_Refresh`

```

```

### `Artech.Architecture.UI.Framework.Controls.IOutlinerSelectionResolver`

```
IsSelected(IOutlinerItem item) -> Boolean
ItemInSelectionPath(Int32 nDeep,IOutlinerItem item) -> Boolean
```

### `Artech.Architecture.UI.Framework.Controls.ISaveableNodeData`

```
Save() -> Void
```

### `Artech.Architecture.UI.Framework.Controls.SaveableEntityWraper`

```
Save() -> Void
```

### `Artech.Architecture.UI.Framework.Helper.DefaultMenuResolver`

```
GetImage(Guid g,String resourceName,Int32 stripId) -> Image
GetString(String resourceName) -> String
GetGuid(String guidName) -> Guid
GetDefaultGuid() -> Guid
```

### `Artech.Architecture.UI.Framework.Helper.DelayedActionHelper`

```
AddCallBack(Action callback) -> Void
AddCallBack(Action callback,Int32 dueTime) -> Void
AddCallBack(Action callback,Int32 dueTime,Boolean waitExecuting) -> Void
Dispose() -> Void
```

### `Artech.Architecture.UI.Framework.Helper.DialogHelper`

```
static AddFilter(String filter,String description,String extension) -> String
static AddFilter(String filter,String newFilter) -> String
```

### `Artech.Architecture.UI.Framework.Helper.EditorServicesHelper`

```
static GetInterface(Object control) -> T
static GetInterface(Object control,Boolean canReturnInitialControl) -> T
static UpdateServices(Object control) -> Void
```

### `Artech.Architecture.UI.Framework.Helper.FindReplaceHelper`

```
static MatchText(String text,IFindReplaceOptions options) -> Boolean
```

### `Artech.Architecture.UI.Framework.Helper.PartTypeHelper`

```
static GetLanguageInfoFor(Guid objType,Guid partType) -> ILanguageInfo
static GetLanguageConfigInitializerFor(Guid partType) -> ILanguageConfigInitializer
```

### `Artech.Architecture.UI.Framework.Helper.ToMenuServiceCommandChain`

```
AddCommand(CommandKey commandKey,QueryHandler queryHandler,CommandID commandId,Object[] parameters) -> Void
AddCommand(CommandKey commandKey,CommandID commandId,Object[] parameters) -> Void
```

### `Artech.Architecture.UI.Framework.Helper.ToMenuServiceCommandDelegator`

```
AddCommand(CommandKey commandKey,CommandID commandId) -> Void
AddCommand(CommandKey commandKey,CommandID commandId,Object[] parameters) -> Void
AddCommand(CommandKey commandKey,QueryHandler queryHandler,CommandID commandId,Object[] parameters) -> Void
Exec(CommandKey cmdKey,CommandData commandData) -> Boolean
QueryState(CommandKey cmdKey,CommandData commandData,CommandStatus& status) -> Boolean
```

### `Artech.Architecture.UI.Framework.ModelExplorer.Nodes.ObjectNodeIconStateUpdater`

```
SetIconOverlay(String state,IconOverlay overlay) -> Void
GetOrDefault(String state) -> Icon
UpdateStates() -> Void
```

### `Artech.Architecture.UI.Framework.Objects.ControllerBuilder`1`

```
Create() -> IGxPartController
```

### `Artech.Architecture.UI.Framework.Objects.DataSavedEventHandler`

```
Invoke(Object sender,Object data) -> Void
BeginInvoke(Object sender,Object data,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Architecture.UI.Framework.Objects.DocumentManagerBuilder`1`

```
Create() -> IDocumentManagerService
```

### `Artech.Architecture.UI.Framework.Objects.EditorBuilder`1`

```
Create() -> IGxView
```

### `Artech.Architecture.UI.Framework.Objects.IControllerBuilder`

```
Create() -> IGxPartController
```

### `Artech.Architecture.UI.Framework.Objects.IDocumentManagerBuilder`

```
Create() -> IDocumentManagerService
```

### `Artech.Architecture.UI.Framework.Objects.IDocumentManagerServiceProvider`

```
GetDocumentManagers() -> IEnumerable`1<IDocumentManagerMap>
```

### `Artech.Architecture.UI.Framework.Objects.IEditorBuilder`

```
Create() -> IGxView
```

### `Artech.Architecture.UI.Framework.Objects.IToolWindowBuilder`

```
Create() -> IToolWindow
```

### `Artech.Architecture.UI.Framework.Objects.ToolWindowBuilder`1`

```
Create() -> IToolWindow
```

### `Artech.Architecture.UI.Framework.Services.Comparer.IStructDiffHelper`

```
GetNodes(KBObjectPart part) -> StructNodes
```

### `Artech.Architecture.UI.Framework.Services.Comparer.PropertiesDiffHelper`

```
static GetProperties(PropertiesObject obj) -> IEnumerable`1<PropertyDescriptor>
static GetProperties(PropertiesObject obj,Attribute[] atts) -> IEnumerable`1<PropertyDescriptor>
```

### `Artech.Architecture.UI.Framework.Services.Comparer.StructDiffHelper`1`

```
GetNodes(TKBObjPart part) -> StructNodes
```

### `Artech.Architecture.UI.Framework.Services.HelpServiceKeywordHelper`

```
static GetObjectKeyword(String name) -> String
static GetObjectPartKeyword(String name,String partName) -> String
static GetObjectPartKeyword(String fullName) -> String
static GetPartKeyword(String name) -> String
static GetTypeKeyword(String name) -> String
static GetTypeDescriptionKeyword(String name) -> String
static GetToolwindowKeyword(String name) -> String
static GetPropertyKeyword(String name) -> String
```

### `Artech.Architecture.UI.Framework.Services.ICallBrowserService`

```
ShowObjectReferences(KBObject obj) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IClipboardService`

```
AddData(KBObject obj) -> Void
SetData(KBObject obj) -> Void
AddData(IEnumerable`1<KBObject> objects) -> Void
SetData(IEnumerable`1<KBObject> objects) -> Void
AddData(TData obj) -> Void
SetData(TData obj) -> Void
AddData(TData obj,TextFormat`1<TData> textFormat,String separator) -> Void
SetData(TData obj,TextFormat`1<TData> textFormat) -> Void
```

### `Artech.Architecture.UI.Framework.Services.ICommandDispatcherService`

```
Dispatch(CommandKey key) -> Void
Dispatch(CommandKey key,CommandData commandData) -> Void
Dispatch(ICommandTarget target,CommandKey key) -> Void
Dispatch(ICommandTarget target,CommandKey key,CommandData commandData) -> Void
Invoke(Delegate method) -> Object
QueryObjectDefinedPackage(KBObject obj,CommandKey cmdKey,CommandData commandData,CommandStatus& status) -> Boolean
ExecObjectDefinedPackage(KBObject obj,CommandKey cmdKey,CommandData commandData) -> Boolean
GetCommandStatus(CommandKey cmdKey) -> CommandStatus
```

### `Artech.Architecture.UI.Framework.Services.IComparerService`

```
GetComparatorWindow(IComparerItem left,IComparerItem right,Func`3<IComparerItem,IComparerItem,ICollection`1<IComparerPartFrame>> framesFunction,Boolean topPaneVisible) -> UserControl
GetComparatorWindow(IComparerItem left,IComparerItem right) -> UserControl
CompareObjects(KBObject left,KBObject right) -> Void
CompareObjects(KBObject left,KBObject right,UIComparerOptions options) -> Void
CompareVersions(KBVersion left,KBVersion right) -> Void
CompareWithCurrentRevision(KBObject obj) -> Void
CompareWithActiveVersion(KBVersion ver) -> Void
BlameObject(BlameInfo blamedObj,IEnumerable`1<BlameInfo> objRevisions) -> Void
```

### `Artech.Architecture.UI.Framework.Services.ICreateKBDialogService`

```
Do(CreateKBOptions options,List`1<String> actions) -> CreateKBData
CompleteDialog(CreateKBOptions options,List`1<String> actions) -> Void
AddNewKBProvider(INewKBProvider provider) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IDocumentManagerService`

```
AddDocumentManager(Guid objType,IDocumentManagerService manager) -> Void
OpenDocument(KBObject kbObject,OpenDocumentOptions options) -> Boolean
SaveAll(Boolean showUI) -> Boolean
Save(Boolean showUI,IEnumerable`1<EntityKey> kbObjs) -> Boolean
Save(Boolean showUI,KBObject kbObject) -> Boolean
CloseAll() -> Boolean
IsOpenable(KBObjectDescriptor descriptor) -> Boolean
IsOpenDocument(KBObject obj,IGxDocument& documentInfo) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.IDragAndDropService`

```
AddData(IDataObject container,KBObject obj) -> Void
AddData(IDataObject container,IEnumerable`1<KBObject> objects) -> Void
AddData(IDataObject container,TData obj) -> Void
AddData(IDataObject container,TData obj,TextFormat`1<TData> textFormat,String separator) -> Void
AddData(IDataObject container,IEnumerable`1<TData> objects) -> Void
AddData(IDataObject container,IEnumerable`1<TData> objects,TextFormat`1<TData> textFormat,String separator) -> Void
CreateDataObject(KBObject obj) -> IDataObject
CreateDataObject(IEnumerable`1<KBObject> objects) -> IDataObject
```

### `Artech.Architecture.UI.Framework.Services.IEditorManagerService`

```
GetEditor(Guid partId) -> IGxView
GetEditor(Guid preferredPackageId,Guid partId) -> IGxView
GetController(Guid partId) -> IGxPartController
GetController(Guid preferredPackageId,Guid partId) -> IGxPartController
```

### `Artech.Architecture.UI.Framework.Services.IEnvironmentService`

```
Invoke(Delegate method,Object[] args) -> Object
Invoke(Action action) -> Void
Invoke(Func`1<T> func) -> T
BeginInvoke(Action action) -> Void
BeginInvoke(Action`1<T> action,T arg) -> Void
BeginInvoke(Action`2<T1,T2> action,T1 arg1,T2 arg2) -> Void
BeginInvoke(Action`3<T1,T2,T3> action,T1 arg1,T2 arg2,T3 arg3) -> Void
ShowModalDialog(Form dialog) -> DialogResult
```

### `Artech.Architecture.UI.Framework.Services.IEnvironmentServiceExtensions`

```
static InvokeIfRequired(IEnvironmentService envService,Action action) -> Void
static InvokeIfRequired(IEnvironmentService envService,Func`1<T> func) -> T
static BeginInvokeIfRequired(IEnvironmentService envService,Action action) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IEventsService`

```
Participate(Object item) -> Void
Revoke(Object item) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IFindReplaceService`

```
ExecuteFind(FindReplaceAction actionTarget,IFindReplaceOptions options) -> Void
CreateFindForm(FindReplaceAction actionTarget,IFindReplaceOptions options) -> FindForm
CreateFindReplaceForm(FindReplaceAction actionTarget,IFindReplaceOptions options) -> FindReplaceForm
Find(FindReplaceAction actionTarget,IFindReplaceOptions options) -> IFindReplaceResult
Replace(FindReplaceAction actionTarget,IFindReplaceOptions options) -> IFindReplaceResult
ReplaceAll(FindReplaceAction actionTarget,IFindReplaceOptions options) -> IFindReplaceResult
MarkAll(FindReplaceAction actionTarget,IFindReplaceOptions options) -> IFindReplaceResult
```

### `Artech.Architecture.UI.Framework.Services.IHelpService`

```
AddKeyword(String keyword) -> Void
ReplaceKeyword(String keyword,String newKeyword) -> Boolean
RemoveKeyword(String keyword) -> Boolean
AddFilter(String name,String value) -> Void
RemoveFilter(String name) -> Boolean
ShowSearch(String requestText) -> Void
ShowSearch(IHelpSearchRequest request) -> Void
ShowContent(String keyword) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IHistoryManagerService`

```
ShowKBObjectHistory(KBObject obj) -> Void
ShowEntityHistory(Entity ent) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IKBService`

```
CopyModel(KBModel from,KBModel to) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IKnowledgeManagerService`

```
ImportFile(String filename) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IListViewService`

```
CreateListView(Guid listViewId,Icon icon,String contextMenu,ICommandTarget commandTarget) -> IListView
CreateListView(Guid listViewId,Icon icon,String contextMenu) -> IListView
GetListView(Guid listViewId) -> IListView
```

### `Artech.Architecture.UI.Framework.Services.IMenuService`

```
ShowContextMenu(Guid packageId,String menuId,Point screenPoint) -> Void
ShowContextMenu(Int32 activeItemIndex,Guid packageId,String menuId,Point screenPoint) -> Void
ShowContextMenu(String activeItemKey,Guid packageId,String menuId,Point screenPoint) -> Void
ShowContextMenu(Guid packageId,String menuId,Point screenPoint,Object contextData) -> Void
ShowContextMenu(Int32 activeItemIndex,Guid packageId,String menuId,Point screenPoint,Object contextData) -> Void
ShowContextMenu(String activeItemKey,Guid packageId,String menuId,Point screenPoint,Object contextData) -> Void
CloseContextMenu() -> Void
GetMenuItem(Guid packageId,String menuId) -> IMenuItem
```

### `Artech.Architecture.UI.Framework.Services.IMenuServiceExtra`

```
IsContextMenuOpen() -> Boolean
IsMainMenuPopupOpen() -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.IModelTreeResolver`

```
GetRootNode() -> IModelTreeNode
GetRootObjects() -> IEnumerable`1<IModelTreeNode>
GetNode(KBObject kbObject) -> IModelTreeNode
```

### `Artech.Architecture.UI.Framework.Services.IModelTreeService`

```
GetModelTree() -> IModelTree
```

### `Artech.Architecture.UI.Framework.Services.INavigatorService`

```
GetNavigator() -> INavigator
```

### `Artech.Architecture.UI.Framework.Services.INavigatorViewService`

```
AddBar(IToolWindow toolWindow) -> Void
InsertBar(IToolWindow toolWindow) -> Void
RemoveBar(IToolWindow gxToolWindow) -> Void
ContainsBar(Guid toolWindowId) -> Boolean
SelectBar(Guid toolWindowId) -> Boolean
IsNavigatorDefaultBar(Guid toolWindowId) -> Boolean
OpenInNewWindow(Guid toolWindowId) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.INewObjectDialogService`

```
CreateObject(CreateObjectOptions options) -> KBObject
AttachBuilder(IUIObjectBuilder builder,KBObjectDescriptor descriptor) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IObjectsService`

```
Create(CreateObjectOptions options) -> KBObject
Open() -> Boolean
Open(KBObject kbObject,OpenDocumentOptions options) -> Boolean
GetCopyName(KBObject kbObject,Module parent) -> String
Copy(KBObject kbObject) -> KBObject
Copy(KBObject kbObject,IKBObjectParent destinationParent,String destinationName) -> KBObject
Delete(KBObject obj) -> Boolean
Delete(KBObject obj,Boolean askConfirmation) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.IObjectsServiceCache`

```
WaitForAvailability(DoWorkEventArgs state) -> Boolean
GetAll(KBModel model) -> IEnumerable`1<IKBObject>
GetAll(KBModel model,Guid type) -> IEnumerable`1<IKBObject>
GetAllOrderByName(KBModel model,Guid type) -> IEnumerable`1<IKBObject>
GetByPartialName(KBModel model,Guid type,String partialName) -> IEnumerable`1<IKBObject>
GetByPartialName(KBModel model,IEnumerable`1<String> namespaces,String partialName) -> IEnumerable`1<IKBObject>
GetByNamePattern(KBModel model,Guid type,String namePattern) -> IEnumerable`1<IKBObject>
GetByNamePattern(KBModel model,IEnumerable`1<String> namespaces,String namePattern) -> IEnumerable`1<IKBObject>
```

### `Artech.Architecture.UI.Framework.Services.IObjectsServiceCacheSettings`

```

```

### `Artech.Architecture.UI.Framework.Services.IOutlinerService`

```
GetOutliner() -> IOutliner
Reload(IOutlinerItemsDescriptor desc) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IProductInfoService`

```
IsFirstTimeUse() -> Boolean
GetLandingPage() -> StartPageSettings
GetAfterKBCreatedPage() -> StartPageSettings
HasProductInfoProvider() -> Boolean
Support(Features features) -> Boolean
Support(String featureCategory) -> Boolean
IsRemote() -> Boolean
TransformCommand(CommandDefinition commandDefinition) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IPropertyService`

```
GetPropertyInspector() -> IPropertyInspector
```

### `Artech.Architecture.UI.Framework.Services.IRecentKBsService`

```
GetRecentKBs() -> IRecentList`1<IRecentKB>
SaveRecentKBs(IRecentList`1<IRecentKB> recentKBs) -> Boolean
UpdateRecentKBsStartPage() -> Void
UpdateRecentKBsMenu() -> Void
GenerateRecentsSmartPart() -> String
```

### `Artech.Architecture.UI.Framework.Services.IReportViewService`

```
CreateReportView(String xslFileName,String title) -> IReportView
CreateReportView(String xslFileName,String title,Boolean enableStatusStrip) -> IReportView
```

### `Artech.Architecture.UI.Framework.Services.ISearchProviderService`

```
AddProvider(UISearchProvider provider) -> Void
GetSearchProviders() -> IEnumerable`1<UISearchProvider>
Search(Guid providerId,String text) -> Void
```

### `Artech.Architecture.UI.Framework.Services.ISelectAttributeVariableService`

```
SelectAttributeVariable() -> IList`1<Object>
SelectAttributeVariable(AttributeVariableDialogInfo info) -> IList`1<Object>
SelectMembers(Object typedObj,ICollection`1& selected) -> Boolean
SelectMembers(Object typedObj,Control extraControl,ICollection`1& selected) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.ISelectObjectDialogService`

```
SelectObjects(SelectObjectOptions options) -> IList`1<KBObject>
SelectObject(SelectObjectOptions options) -> KBObject
SelectObjectPartItems(String title,String subTitle,KBObject obj,Guid partType) -> ICollection
SelectObjectPartItems(SelectObjectPartOptions options) -> ICollection
RegisterCustom(KBObjectDescriptor type,ICustomSelectObjectDialog customDialog) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IStartPageService`

```
OpenPage(String url,String title) -> Void
OpenPage(String url,String title,Object scriptingFunctions) -> Void
OpenPage(StartPageSettings settings) -> Void
OpenPage(StartPageSettings settings,StartPageSettings staticStartPage) -> Void
SetPage(String htmlPage) -> Void
SetSmartPart(String idSmartPart,String content) -> Void
RefreshContents() -> Void
```

### `Artech.Architecture.UI.Framework.Services.IStatusBarService`

```
GetStatusBar() -> IStatusBar
ShowStatusBar(Boolean show) -> Void
DisplayText(String text) -> Void
```

### `Artech.Architecture.UI.Framework.Services.ITasksService`

```
Run(ITask task) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.ITeamDevClientService`

```
RegisterSessionCredential(String serverUrl,String userPassword) -> Void
GetSessionCredential(String serverUrl,String& userPassword) -> Boolean
GetUserAndPassword() -> KeyValuePair`2<String,String>
GetCreateKBFromServerTask(KBConnectionInfo info) -> ITask
HostedKBs(String serverURL,String user,String password) -> List`1<NewKBInfo>
NewServerVersion(NewVersionData data,Int32& newVersionId) -> Boolean
GetServerAllowVersionManage() -> Boolean
DeleteServerVersion(Int32 versionId) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.ITextComparisonService`

```
ShowDifferences(String textA,String textB) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IToolboxService`

```
GetToolbox() -> IToolbox
ReloadCategories(IToolboxItemsDescriptor desc) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IToolsOptionsService`

```
RegisterCategory(ConfigurationCategory category) -> Void
RegisterCategory(ConfigurationCategory category,String categoryParent) -> Void
ShowOptions() -> Void
ShowOptions(String categoryName) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IToolTipService`

```
AddContentProvider(IToolTipContentProvider contentProvider) -> Void
ShowToolTip(Control control,Object obj) -> Boolean
ShowToolTip(Control control,Object obj,Int32 delay) -> Boolean
ShowToolTip(Control control,ToolTipData toolTipData) -> Void
ShowToolTip(Control control,ToolTipData toolTipData,Int32 delay) -> Void
HideToolTip() -> Void
```

### `Artech.Architecture.UI.Framework.Services.IToolWindowsService`

```
CreateToolWindow(Guid toolWindowId) -> IToolWindow
TryGet(Guid toolWindowId,IToolWindow& window) -> Boolean
ShowToolWindow(Guid toolWindowId) -> Boolean
SelectToolWindow(Guid toolWindowId) -> Boolean
FocusToolWindow(Guid toolWindowId) -> Boolean
PinToolWindow(Guid toolWindowId,Boolean pin) -> Boolean
HighlightToolWindow(Guid toolWindowId) -> Boolean
CloseToolWindow(Guid toolWindowId) -> Boolean
```

### `Artech.Architecture.UI.Framework.Services.ITrackSelectionService`

```
Subscribe(Guid guid,ISelectionListener listener) -> Void
Unsubscribe(Guid guid) -> Void
OnSelectChange(ISelectionContainer pSC) -> Boolean
OnSelectChange(Object selection,Object objToSave) -> Void
OnSelectChange(ICollection selection,ICollection objToSave) -> Void
OnSelectChange(Object selection,Object objToSave,IPosition position) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IUIObjectBuilder`

```
Construct(KBObjectDescriptor type,String name,String description,IKBObjectParent parent,KBCategory inCategory) -> KBObject
DoDefaultAction(KBObject kbObject) -> Void
```

### `Artech.Architecture.UI.Framework.Services.IWebFormService`

```
RegisterProvider(IWebFormControlProvider provider,Guid cls) -> Boolean
GetControlProvider(Guid cls) -> IWebFormControlProvider
```

### `Artech.Architecture.UI.Framework.Services.IWikiService`

```
ShowCategory(KBCategory category) -> Void
ShowDocument(KBObject kbObject) -> Void
Show() -> Void
```

### `Artech.Architecture.UI.Framework.Services.ObjectServiceDeleteOptions`

```

```

### `Artech.Architecture.UI.Framework.Services.UIServices`

```

```

### `Artech.Architecture.UI.Framework.Services.UIServicesGuid`

```

```

## `Artech.Common`

### `Artech.Common.Diagnostics.MessageHelper`

```

```

### `Artech.Common.ProductVersionHelper`

```
static SetProductInfo(String productName,String versionName,String version,String applicationDataDirectoryName) -> Void
static SetProductInfo(String productName,String versionName,String version,String applicationDataDirectoryName,String productType) -> Void
static SetProductInfo(String productName,String versionName,String version,String applicationDataDirectoryName,String productType,Settings settings) -> Void
static SetProductInfo(String productName,String productFlavor,String versionName,String version,String applicationDataDirectoryName,String productType,Settings settings) -> Void
```

### `Artech.Common.Resources.ResourceHelper`

```
static TryGetString(ResourceManager instance,String key,CultureInfo culture) -> String
```

## `Artech.Common.Controls`

### `Artech.Common.Controls.Descriptors.PropertiesPanelBuilder`

```
RefreshControls() -> Void
Update() -> Void
Construct() -> Void
Construct(Font defaFont) -> Void
```

### `Artech.Common.Controls.ToolStrip.ToolStripHelper`

```
static AddToolStripMenu(ToolStripDropDownButton dropDownButton,String text,Image image,Int32 index) -> ToolStripMenuItem
static AddToolStripMenuWithType(ToolStripDropDownButton dropDownButton,String text,Image image,Int32 index) -> ITEM
```

## `Artech.Common.Framework`

### `Artech.Architecture.UI.Framework.Controls.IDynamicMenuUpdater`

```
UpdateDynamicMenu(IDynamicMenuList dynamicMenu,DynamicMenuData data) -> Boolean
```

## `Artech.Common.Helpers`

### `Artech.Common.Helpers.Assemblies.AssemblyHelper`

```
static GetAssemblyDirectory() -> String
static GetAssemblyFullPath() -> String
static GetProductName() -> String
static GetProductName(Assembly assembly) -> String
static GetCompanyName() -> String
static GetCompanyName(Assembly assembly) -> String
static GetVersion() -> Version
static GetVersion(Assembly assembly) -> Version
```

### `Artech.Common.Helpers.CommandExecuter`

```
static ExecuteMSbuild(String projectPath,String target,Dictionary`2<String,String> properties,String verbosity,String additionalMofifiers,IProcessLog log) -> Task`1<Boolean>
static GetProperties(Dictionary`2<String,String> vals) -> String
static ExecuteProcess(String executablePath,String arguments,IProcessLog log) -> Boolean
static ExecuteProcess(String executablePath,String arguments,String workingDir,IProcessLog log) -> Boolean
```

### `Artech.Common.Helpers.ConfigurationHelper`

```
static AddListener(IConfigurationChangeListener listener) -> Void
static SetUserSetting(String name,Int32 value) -> Void
static SetUserSetting(String name,Boolean value) -> Void
static SetUserSetting(String name,String value) -> Void
static SetUserSetting(String sectionName,String name,Boolean value) -> Void
static SetUserSetting(String sectionName,String name,Int32 value) -> Void
static SetUserSetting(String sectionName,String name,String value) -> Void
static GetUserSetting(String name,Int32 defaultValue) -> Int32
```

### `Artech.Common.Helpers.Dates.DateHelper`

```
static ToLocalString(DateTime dateTime) -> String
static ToLocalShortDate(DateTime date) -> String
static ToLocalShortTime(DateTime time) -> String
static DateToStringPattern() -> String
static Maximum(IEnumerable`1<DateTime> times) -> DateTime
static Minimum(IEnumerable`1<DateTime> times) -> DateTime
static GetDeklaritDateTime(DateTime d) -> DateTime
static GetDeklaritDate(DateTime d) -> DateTime
```

### `Artech.Common.Helpers.Dates.ParserDateHelper`

```
static HMSToSeconds(Int32 hours,Int32 minutes,Int32 seconds) -> Int64
static ToYMD(String exp,FMT fmt,Int16& year,Int16& month,Int16& day) -> String
static ToYMD(String exp,FMT fmt,Int32 yearLimit,Int16& year,Int16& month,Int16& day) -> String
static ToTime(String time,Nullable`1& hours,Nullable`1& minutes,Nullable`1& seconds,Nullable`1& milliseconds) -> Boolean
static ValidateDay(Int16 year,Int16 month,Int16 day) -> Boolean
```

### `Artech.Common.Helpers.Enums.EnumHelper`

```
static Parse(String value) -> TEnum
static Parse(String value,Boolean ignoreCase) -> TEnum
static Parse(Int32 value) -> TEnum
static TryParse(Int32 value,TEnum& result) -> Boolean
static TryParse(String value,TEnum& result) -> Boolean
```

### `Artech.Common.Helpers.Gambling.RandomHelper`

```
static Next() -> Int32
```

### `Artech.Common.Helpers.GDI.FontHelper`

```
static Get(String family,Single emSize,FontStyle style,GraphicsUnit unit) -> Font
static GetFontFullName(String fullFilePath) -> String
```

### `Artech.Common.Helpers.GDI.GdiHelper`

```
static DestroyIcon(IntPtr handle) -> Boolean
static DeleteObject(IntPtr hObject) -> IntPtr
static ResizeAndReposition(Rectangle& rect,Size newSize,Boolean onePixelToBottom,Boolean onePixelToRight) -> Boolean
static getLoaderBitmap() -> Tuple`2<Bitmap,Int32>
static getLoaderBitmap(Int32 suggestedSquareSize,Boolean isSquareSizeHdpi) -> Tuple`2<Bitmap,Int32>
static freeLoaderBitmap(Int32 resorceId) -> Boolean
static ResizeSmallIconDPI(Icon icon) -> Icon
static ResizeSmallIconDPI(Icon icon,CacheCriteria criteria) -> Icon
```

### `Artech.Common.Helpers.GDI.IRoundedButtonsGenerator`

```
GetImages(ButtonSettings settings) -> ButtonImages
```

### `Artech.Common.Helpers.GDI.NativeTextRenderer`

```
MeasureString(String str,Font font) -> Size
MeasureString(String str,Font font,Single maxWidth,Int32& charFit,Int32& charFitWidth) -> Size
DrawString(String str,Font font,Color color,Point point) -> Void
DrawString(String str,Font font,Color color,Rectangle rect,TextFormatFlags flags) -> Void
DrawTransparentText(String str,Font font,Color color,Point point,Size size) -> Void
Dispose() -> Void
static DeleteDC(IntPtr hdc) -> Boolean
```

### `Artech.Common.Helpers.Guids.GuidHelper`

```
static TryParse(String input,Guid& parsed) -> Boolean
static Parse(String input) -> Guid
static XOR(Guid guid1,Guid guid2) -> Guid
static Stringify(Guid guid) -> String
static Create(Guid namespaceId,String name,Boolean caseSensitive) -> Guid
static Create(Guid namespaceId,String name,Int32 version) -> Guid
```

### `Artech.Common.Helpers.Hierarchy.FlatHierarchyBuilder`

```
Construct(String name,Object data) -> IHierarchyItem
```

### `Artech.Common.Helpers.Hierarchy.IHierarchyBuilder`

```
Construct(String name,Object data) -> IHierarchyItem
```

### `Artech.Common.Helpers.Identity.ICurrentUserResolver`

```
TryGetCurrentUser(String& userName) -> Boolean
```

### `Artech.Common.Helpers.Identity.IdentityHelper`

```
static AddUserResolver(ICurrentUserResolver resolver) -> Void
```

### `Artech.Common.Helpers.IO.FileHelper`

```
static GetFileName(String uri) -> String
static GetFolderName(String fileFullPath) -> String
static GetFileNameWithoutExtension(String uri) -> String
static GetExtension(String uri) -> String
static RemoveInvalidChars(String name) -> String
static GetTempFileName() -> String
static GetTempFileName(Boolean keepFile) -> String
static GetFileNameWithExtension(String path,String extension,Boolean replaceExtension) -> String
```

### `Artech.Common.Helpers.IO.IniHelper`

```
static GetCategories(String iniFile) -> List`1<String>
static UpdateKey(String iniFile,String section,String key,String value) -> Void
static GetKeys(String iniFile,String section) -> List`1<String>
static GetIniFileString(String iniFile,String section,String key,String defaultValue) -> String
```

### `Artech.Common.Helpers.IO.PathHelper`

```
static SetAssemblyInfo(String companyName,String productName,String majorVersion) -> Void
static SetAssemblyInfo(Assembly assembly) -> Void
static GetAbsolutePath(String fileName) -> String
static GetWindowsPath() -> String
static GetCurrentFrameworkPath() -> String
static GetAssemblyLocation(Assembly assembly) -> String
static GetAssemblyDirectory(Assembly assembly) -> String
static GetFrameworkPath(FrameworkVersion version) -> String
```

### `Artech.Common.Helpers.IProcessLog`

```
AddErrorLine(String value) -> Void
AddLine(String value) -> Void
AddWarningLine(String value) -> Void
```

### `Artech.Common.Helpers.MathHelper`

```
static RoundedIntegerDivision(Int32 a,Int32 b) -> Int32
static CeilingIntegerDivision(Int32 a,Int32 b) -> Int32
```

### `Artech.Common.Helpers.MSBuild.MSBuildHelper`

```
static FullMSBuildExePath() -> String
static FullMSBuildExePath(FrameworkVersion preferredVersion) -> String
static GetMsBuildProperty(String msbuildOptions,String msbuildOptionKey,String msbuildOptionDefaultValue) -> String
static GetMsBuildFlag(String msbuildOptions,String msbuildOptionKey,String msbuildOptionDefaultValue) -> String
static GetMsBuildOption(String msbuildOptions,String msbuildOptionKey,String msbuildOptionDefaultValue,Char[] flagSeparator,Char[] equalSep) -> String
static NormalizeListOfProperties(String inputstring,String propertyName) -> String
static NormalizeListOfProperties(String inputstring,String propertyName,Boolean escapeDelimiters) -> String
```

### `Artech.Common.Helpers.NetCore.NetCoreHelper`

```
static RestoreDependencies(String platformPath,String platformProperty,DataReceivedEventHandler procDataReceived) -> Void
static RestoreDependencies(String platformPath,String targetPath,String platformProperty,DataReceivedEventHandler procDataReceived) -> Void
```

### `Artech.Common.Helpers.NetFramework.NetFramworkHelper`

```
static GetTargetFrameworkFromRegistry() -> String
```

### `Artech.Common.Helpers.ObjectHelper`

```
static Equals(Object v1,Object v2) -> Boolean
static ToString(Object v) -> String
```

### `Artech.Common.Helpers.OutputHelper`

```
static GetFormatedText(String data) -> String
```

### `Artech.Common.Helpers.Protection.AuthorizationHelper`

```
static AuthorizeRenewableLicenses(List`1<String> siteKeys,Dictionary`2<String,ValueTuple`2<Int32,Int32>> siteKeysProductVersionInfo) -> List`1<ProductErrorInfo>
static SetLanguage(CultureInfo cultureInfo) -> Void
static GetProtectVersion() -> String
static CompareProtectVersion(String left,String right) -> Int32
static GetConfig(ConfigType& type,String& server) -> Void
static SetConfig(ConfigType type,String server) -> Void
static GetLogSettings(Boolean& saveLog,LogType& type,String& fileName,Int32& fileMaxSize) -> Void
static SetLogSettings(Boolean saveLog,LogType type,String fileName,Int32 fileMaxSize) -> Void
```

### `Artech.Common.Helpers.RegistryUtilities.RegistryHelper`

```
static RegOpenKeyEx(UIntPtr hKey,String subKey,UInt32 options,UInt32 sam,IntPtr& phkResult) -> Int32
static RegQueryValueEx(IntPtr hKey,String lpValueName,IntPtr lpReserved,UInt32& lpType,IntPtr lpData,UInt32& lpcbData) -> Int32
static RegQueryValueEx(IntPtr hKey,String lpValueName,IntPtr lpReserved,UInt32& lpType,Byte[] lpData,UInt32& lpcbData) -> Int32
static IsWow64Registry() -> Boolean
static GetValue(String subKey,String key) -> Object
static SetDWord(String subKey,String key,Int32 value) -> Void
static SetDWord(String subKey,String key,UInt32 option,UInt32 value) -> Void
static SetString(String subKey,String key,String value) -> Void
```

### `Artech.Common.Helpers.RSSUtilities.RSSFeedGenerator`

```
WriteStartDocument() -> Void
WriteEndDocument() -> Void
Close() -> Void
WriteStartChannel(String title,String link,String description,String copyright,String webMaster) -> Void
WriteEndChannel() -> Void
WriteItem(String title,String link,String description,String author,DateTime publishedDate,String subject) -> Void
```

### `Artech.Common.Helpers.SharedMemory.InProcessBag`

```
static GetBag(String key) -> IDictionary`2<String,Object>
static GetSmartDevicesGeneratorBag() -> IDictionary`2<String,Object>
```

### `Artech.Common.Helpers.Streams.StreamHelper`

```
static GetString(Stream st) -> String
static GetBytes(Stream st) -> Byte[]
static CopyTo(Stream source,Stream target) -> Void
static CopyTo(Stream source,Stream target,CopyProgressObserver observer) -> Void
static CopyTo(Stream source,String filePath) -> Void
static CopyTo(Stream source,String filePath,CopyProgressObserver observer) -> Void
static WriteFrom(Stream target,String filePath) -> Void
```

### `Artech.Common.Helpers.Strings.StringPatternHelper`

```
static IsPattern(String namePattern) -> Boolean
static MatchPattern(String name,String description,String namePattern) -> Boolean
```

### `Artech.Common.Helpers.StringTemplate.PropertyHelper`

```
static AddProperties(Template template,String[] properties) -> Void
```

### `Artech.Common.Helpers.Templates.Generator`

```
static AddAssemblyPath(String path) -> Void
static CleanTempPath() -> Void
static GenerateFile(String templateFile,String outputFile,GeneratorParameters parameters,List`1& errors) -> Void
static GenerateToString(String templateFile,GeneratorParameters parameters,List`1& errors) -> String
static Generate(TextWriter writer,String templateFile,GeneratorParameters parameters,List`1& errors) -> Boolean
static Precompile(String templateFile,GeneratorParameters parameters) -> Void
static Compile(String templateFile,GeneratorParameters parameters,List`1& errors) -> TemplateCompiler
```

### `Artech.Common.Helpers.Templates.Generator+GeneratorParameters`

```

```

### `Artech.Common.Helpers.Threading.CallToPostExecute`

```

```

### `Artech.Common.Helpers.Threading.PostExecuteWorkItemCallback`

```
Invoke(IWorkItemResult wir) -> Void
BeginInvoke(IWorkItemResult wir,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Common.Helpers.Threading.ProcessUtility`

```
static AddKeepAliveProcessGlobal(Int32 pid) -> Void
static AddKeepAliveProcessGlobal(String processName) -> Void
static KillTree(Process process) -> Void
static KillTree(Process process,Boolean killRoot) -> Void
static KillTree(Int32 pid) -> Void
static KillTree(Process process,Boolean killRoot,HashSet`1<Int32> keepAliveProcessList) -> Void
static GetParentProcessId(Int32 processId) -> Int32
static GetChildProcessIds(Int32 parentProcessId) -> Int32[]
```

### `Artech.Common.Helpers.Url.UriHelper`

```
static IsEqualTo(Uri u1,Uri u2) -> Boolean
static AvailablePort(Int32 startingPort) -> Int32
static CanonizeVirtualDirectoryName(String url) -> String
```

### `Artech.Common.Helpers.VersionHelper`

```
static GetMajorVersionNumber(String version,Int32 defaultValue) -> String
static GetMinorVersionNumber(String version,Int32 defaultValue) -> String
static Compare(String left,String right) -> Int32
static Compare(SemVersion leftS,SemVersion rightS) -> Int32
```

### `Artech.Common.Helpers.Web.MIMEHelpers`

```
static GetMimeTypeFromFileExtension(String fileExtension) -> String
```

### `Artech.Common.Helpers.Xml.XmlDocumentHelper`

```
ReadEnumAttribute(String name,Type typ,Object& val) -> Boolean
ReadEnumAttribute(String name,TEnum& val) -> Boolean
ReadAttribute(String name,String& val) -> Boolean
ReadAttribute(String name,Int32& val) -> Boolean
ReadAttribute(String name,Point& val) -> Boolean
ReadAttribute(String name,Size& size) -> Boolean
ReadAttribute(String name,Boolean& b) -> Boolean
ReadAttribute2(String name,ValueType& typ) -> Boolean
```

### `Artech.Common.Helpers.Xml.XmlNodeHelper`

```
static FindChild(XmlNode parent,XmlNodeType type) -> XmlNode
static ReadStr(XmlNode node,String query) -> String
static ReadStr(XmlNode node,String query,String defaultValue) -> String
static ReadInt(XmlNode node,String query,Int32 defaultValue) -> Int32
static TryReadInt(XmlNode node,String query,Int32& value) -> Boolean
```

### `Artech.Common.Helpers.Xml.XmlWriterHelper`

```
BeginNode(String nodeName) -> Void
EndNode() -> Void
WriteAttribute(String name,Object val) -> Void
WriteAttribute(String name,Size size) -> Void
WriteAttribute(String name,Point point) -> Void
WriteElement(String name,String val) -> Void
WriteElement(String name,Object o) -> Void
static WriteNodeFromContent(XmlWriter writer,StringBuilder text,Boolean defAttributes) -> Void
```

### `Artech.Common.Helpers.Xml.XPathNavHelper`

```
static TryGetStr(XPathNavigator nav,String xpath,String& value) -> Boolean
static Read90Str(XPathNavigator nav,String xpath,Int32 codepage) -> String
static ReadStr(XPathNavigator nav,String xpath) -> String
static ReadStr(XPathNavigator nav,String xpath,String defaultValue) -> String
static SelectSingleNode(XPathNavigator nav,String xpath,XPathNavigator& node) -> Boolean
static ReadInt(XPathNavigator nav,String name,Int32 nDefault) -> Int32
static ReadEnum(XPathNavigator nav,String name,EnumType nDefault) -> EnumType
static ReadBool(XPathNavigator nav,String name,Boolean bDefault) -> Boolean
```

### `Artech.Common.Helpers.Zoom.ZoomHelper`

```
static ZoomFactorToIndex(Int32 zoomFactor) -> Int32
static ZoomFactorToIndex(Single zoomFactor) -> Int32
static ZoomFactorFromIndex(Object indexObj) -> Int32
```

### `Win32Mapi.MailAttach`

```

```

## `Artech.Common.IPC`

### `Artech.Common.IPC.IPCService`

```

```

### `Artech.Common.IPC.ProcessExitedException`

```

```

## `Artech.Common.Properties`

### `Artech.Common.Properties.CompositeResolver`

```
Clone() -> CompositeResolver
Add(IResolver resolver) -> Void
Add(IDefaultResolver value) -> Void
Add(IReadOnlyResolver value) -> Void
Add(IValidResolver value) -> Void
Add(IApplyResolver value) -> Void
Add(IValuesResolver value) -> Void
Add(IInitialValueResolver value) -> Void
```

### `Artech.Common.Properties.CustomResolverAttribute`

```

```

### `Artech.Common.Properties.DefinitionsHelper`

```
static GetDefinitions(Type type) -> PropertiesDefinition
static GetDefinitionAttribute(Type type) -> ObjectPropertyDefinitionAttribute
static GetDefinitionAttribute() -> ObjectPropertyDefinitionAttribute
static GetDefinitionAttribute(Object obj) -> ObjectPropertyDefinitionAttribute
static GetPropertiesDefinitionKey(Type type) -> String
static GetPropertiesDefinitionKey() -> String
static GetPropertiesDefinitionKey(PropertiesObject po) -> String
static GetPropertiesDefinitionKey(Object obj) -> String
```

### `Artech.Common.Properties.Helpers`

```
static GetDescription(Object obj) -> String
```

### `Artech.Common.Properties.IApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IContextResolver`

```
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IDefaultResolver2`

```
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
```

### `Artech.Common.Properties.IInitialValueResolver`

```
GetInitialValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Common.Properties.IParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Common.Properties.IReadOnlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IResolver`

```

```

### `Artech.Common.Properties.IResolverFactory`

```
GetDefaultResolver(String propName) -> IDefaultResolver
GetReadOnlyResolver(String propName) -> IReadOnlyResolver
GetValidResolver(String propName) -> IValidResolver
GetVisibleResolver(String propName) -> IVisibleResolver
GetApplyResolver(String propName) -> IApplyResolver
GetValuesResolver(String propName) -> IValuesResolver
GetContextResolver() -> IContextResolver
GetOnAfterSetValueHandler(String propName) -> IAfterSetValueHandler
```

### `Artech.Common.Properties.IResolverFactory_v2`

```
GetInitialValueResolver(String propName) -> IInitialValueResolver
GetCustomInitialValueResolver(String propName) -> IInitialValueResolver
```

### `Artech.Common.Properties.IResourceManagerResolver`

```
GetResourceManager() -> ResourceManager
```

### `Artech.Common.Properties.IStandardValuesResolver`

```
GetStandardValues(IPropertyBag properties) -> StandardValuesStore
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IValuesResolver`

```
GetValues(IPropertyBag properties) -> IEnumerable`1<ValuesItem>
GetValueFromName(String name) -> Object
GetNameFromValue(Object value) -> String
GetNonExclusiveValuesSupported() -> Boolean
```

### `Artech.Common.Properties.IVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.IVisibleResolver2`

```
IsVisible(IPropertyBag properties,PropDefinition definition) -> Boolean
```

### `Artech.Common.Properties.PropertiesHelper`

```
static GetDescriptorSettings(ITypeDescriptorContext context) -> T
static GetDescriptorSettings(IPropertyBag bag,String propName) -> T
static GetDescriptorSettings(PropertyDescriptor propertyDescriptor) -> T
static SetConfigurationProperty(String propertyName,Object propertyValue) -> Void
static GetConfigurationProperty(String propertyName,String& value) -> Boolean
```

### `Artech.Common.Properties.PropertyBindingAttribute`

```

```

### `Artech.Common.Properties.PropObjResolverFactory`

```
static GetResolver(String objectClass) -> IResolverFactory
static AddResolverFactory(String objectClass,IResolverFactory factory) -> Void
```

### `Artech.Common.Properties.Resolvers.DecimalValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.Resolvers.InvisibleResolver`

```

```

### `Artech.Common.Properties.Resolvers.IsDebugVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.Resolvers.ReadOnlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.Resolvers.ValuesResolver`

```
LoadValues(XmlNodeList stdValues) -> Void
GetValues(IPropertyBag properties) -> IEnumerable`1<ValuesItem>
GetValueFromName(String name) -> Object
GetNameFromValue(Object value) -> String
GetNonExclusiveValuesSupported() -> Boolean
```

### `Artech.Common.Properties.Resolvers.VisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Common.Properties.ResolversCache`

```
TryGetDefaultValue(Boolean scoped,IPropertyBag propertyBag,String propName,Object& value,Boolean& isDefault) -> Boolean
SetDefaultValue(Boolean scoped,IPropertyBag propertyBag,String propName,Object value,Boolean isDefault) -> Void
TryGetIsVisible(Boolean scoped,IPropertyBag propertyBag,String propName,Boolean& isVisible) -> Boolean
SetIsVisible(Boolean scoped,IPropertyBag propertyBag,String propName,Boolean isVisible) -> Void
TryGetIsReadonly(Boolean scoped,IPropertyBag propertyBag,String propName,Boolean& isReadOnly) -> Boolean
SetIsReadonly(Boolean scoped,IPropertyBag propertyBag,String propName,Boolean isReadOnly) -> Void
TryGetIsApplicable(Boolean scoped,IPropertyBag propertyBag,String propName,Boolean& isApplicable) -> Boolean
SetIsApplicable(Boolean scoped,IPropertyBag propertyBag,String propName,Boolean isApplicable) -> Void
```

### `Artech.Common.Properties.WithParentDefaultResolver`

```
static Get(IParentResolver parentResolver) -> WithParentDefaultResolver
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
GetDependencies() -> String[]
```

## `Artech.CommonI`

### `Artech.Common.GXtechnicalCloudInitialization.ExecuteCompletedEventArgs`

```

```

### `Artech.Common.GXtechnicalCloudInitialization.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Common.GXtechnicalCloudServers.ExecuteCompletedEventArgs`

```

```

### `Artech.Common.GXtechnicalCloudServers.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Common.GXtechnicalCloudValidateSettings.ExecuteCompletedEventArgs`

```

```

### `Artech.Common.GXtechnicalCloudValidateSettings.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Common.GXtechnicalCloudVDAvailability.ExecuteCompletedEventArgs`

```

```

### `Artech.Common.GXtechnicalCloudVDAvailability.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Common.RenewableLicenses.ExecuteRequest`

```

```

### `Artech.Common.RenewableLicenses.ExecuteRequestBody`

```

```

### `Artech.Common.RenewableLicenses.ExecuteResponse`

```

```

### `Artech.Common.RenewableLicenses.ExecuteResponseBody`

```

```

### `Artech.Common.RenewableLicenses.UpdateLicensesSoapPort`

```
Execute(ExecuteRequest request) -> ExecuteResponse
ExecuteAsync(ExecuteRequest request) -> Task`1<ExecuteResponse>
```

### `Artech.Common.RenewableLicenses.UpdateLicensesSoapPortChannel`

```

```

### `Artech.Common.RenewableLicenses.UpdateLicensesSoapPortClient`

```
Execute(String& Xmltext) -> String
ExecuteAsync(String Xmltext) -> Task`1<ExecuteResponse>
```

### `Artech.Common.Security.OAuthHelper`

```
static Login(IPLoginData loginData) -> OAuthLoginResult
```

### `Artech.Common.ValidateToken.ExecuteRequest`

```

```

### `Artech.Common.ValidateToken.ExecuteResponse`

```

```

## `Artech.Generators`

### `Artech.Generators.Definitions.Generator`

```

```

### `Artech.Generators.Definitions.GeneratorApply`

```

```

### `Artech.Generators.Definitions.GeneratorImplementation`

```

```

### `Artech.Generators.Definitions.GeneratorPropertyDefinition`

```

```

### `Artech.Generators.Definitions.GeneratorResource`

```

```

### `Artech.Generators.ExtensionHelper`

```
static NormalizeActionName(String s) -> String
```

### `Artech.Generators.Extensions.GeneratorInstructions`

```
ExecuteGeneratorIntructions(List`1<IGeneratorInstruction> instructions,ITransformable md,String modulesOutputDirectory,String outputFileName,String objectName,String buildOptions) -> Void
ApplyTemplate(Object input,String outputFile,String templateFile,String templateLibraryRuntimeClass) -> Void
ApplyTemplateGroup(Object input,String outputFile,String templateFile,String groupName,String templateLibraryRuntimeClass) -> Void
```

### `Artech.Generators.Extensions.GeneratorMacros`

```
Add(String name,String value) -> Void
Get(String name) -> String
ApplyMacros(String inp) -> String
```

### `Artech.Generators.Extensions.Helper`

```
static GetModulesDirectory(IMetadataKBObject data,Boolean forWeb) -> String
static CallToName(String call,String instanceComponent) -> String
static FullName(String objectName,String instanceComponent) -> String
```

### `Artech.Generators.Extensions.StringTemplateFunctionsHelper`

```
static Create(String runtimeClass) -> IDictionary`2<String,Object>
```

### `Artech.Generators.Extensions.UIGeneratorExtension`

```
GetFunctionObject() -> Object
GetTransformsDefinitions() -> IEnumerable`1<IMetadataTransformDefinition>
static GetPatternExtension(Guid type) -> String
Generate(IModelData modelData,Object mainData,ITemplateRunner templateRunner,IDictionary`2<String,Object> context) -> Boolean
```

### `Artech.Generators.FilterGenerator`

```
Invoke(String genName,IModelData modelData) -> Boolean
BeginInvoke(String genName,IModelData modelData,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Boolean
```

### `Artech.Generators.GeneratorController`

```
SetBasePath(String path) -> Void
SetRelativeOutput(String path) -> Void
SetExtensionAssemblyPath(String path) -> Void
Generate(GeneratorSpecificationStrategy genStrategy,Object item,IDictionary`2<String,Object> context,CancellationToken cancellationToken) -> Boolean
```

### `Artech.Generators.GeneratorEngine`

```
AddInstanceGenerator(String instanceName,ICustomGenerator generator) -> Void
AddInstanceGenerator(String instanceName,ICustomGenerator generator,GeneratorKind kind) -> Void
AddInstanceGenerator(String instanceName,CustomGeneratorFilter filter,ICustomGenerator generator) -> Void
AddInstanceGenerator(String instanceName,CustomGeneratorFilter filter,ICustomGenerator generator,GeneratorKind kind) -> Void
AddGenerator(ICustomGenerator generator,GeneratorKind kind) -> Void
RunBeforeGenerate(IDictionary`2<String,Object> context,CancellationToken cancellationToken) -> Boolean
RunAfterGenerate(IDictionary`2<String,Object> context,CancellationToken cancellationToken) -> Boolean
RunAfterInstanceGenerators(String instanceName,Object data,IDictionary`2<String,Object> context,CancellationToken cancellationToken) -> Boolean
```

### `Artech.Generators.GeneratorEngine+CustomGeneratorFilter`

```
Invoke(Object data,IDictionary`2<String,Object> context) -> Boolean
BeginInvoke(Object data,IDictionary`2<String,Object> context,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Boolean
```

### `Artech.Generators.GeneratorEngine+FilterAndGenerator`

```

```

### `Artech.Generators.GeneratorEngine+GeneratorKind`

```

```

### `Artech.Generators.GeneratorEngine+ICustomGenerator`

```
Generate(Object data,IDictionary`2<String,Object> context) -> Boolean
```

### `Artech.Generators.GeneratorEngine+ICustomGeneratorWithCancellation`

```
Generate(Object data,IDictionary`2<String,Object> context,CancellationToken token) -> Boolean
```

### `Artech.Generators.GeneratorExtensionFactory`

```
static LoadGeneratorDefinition(String generator) -> GeneratorExtension
```

### `Artech.Generators.GeneratorInstance`

```

```

### `Artech.Generators.GeneratorType`

```
static CreateParameterizedType(String type,GeneratorType[] typeParameters) -> GeneratorType
static FromType(String type,String typeName,String length,String decimals,Boolean isCollection) -> GeneratorType
static FromType(String type,String typeName,Int32 length,Int32 decimals,Boolean isCollection) -> GeneratorType
static FromType(String exprDataType) -> GeneratorType
static FromType(String type,Int32 length,Int32 decimals) -> GeneratorType
static FromType(Int32 internalType) -> GeneratorType
ToString() -> String
Parse(String s) -> GeneratorType
```

### `Artech.Generators.IEngineOutput`

```
AddLine(String v) -> Void
AddErrorLine(String message) -> Void
AddText(String v) -> Void
```

### `Artech.Generators.IExtensionGenerator`

```
Generate(IModelData model,Object main,ITemplateRunner templateRunner,IDictionary`2<String,Object> context) -> Boolean
```

### `Artech.Generators.IGenerator`

```
Generate(Object input,ITemplateRunner templateRunner,IDictionary`2<String,Object> context) -> Boolean
Generate(Object main,Object param,ITemplateRunner templateRunner,IDictionary`2<String,Object> context) -> Boolean
```

### `Artech.Generators.IGeneratorController`

```
SetBasePath(String path) -> Void
SetRelativeOutput(String path) -> Void
SetExtensionAssemblyPath(String path) -> Void
Generate(GeneratorSpecificationStrategy genStrategy,Object item,IDictionary`2<String,Object> context,CancellationToken cancellationToken) -> Boolean
```

### `Artech.Generators.IGeneratorExtensionStatus`

```

```

### `Artech.Generators.IGeneratorMetadataManager`

```
CanGenerate(ISmartDevicesData sdata,IMainData main,IDictionary`2<String,Object> context,IGeneratorExtensionStatus& generatorStatus) -> Boolean
ShouldRebuild(IMetadataKBObject obj,IMainData main) -> Boolean
Initialize(ISmartDevicesData sdata,IMainData main,IDictionary`2<String,Object> context) -> Void
LoadBusinessComponent(IMetadataKBObject obj,IMainData main) -> ITransformable
GetKBModelData() -> ITransformable
GetMainData() -> ITransformable
GetPanels(String metadataFile,String metadataName,String metadataQualifiedName) -> IEnumerable`1<ITransformable>
LoadSDT(IMetadataKBObject obj,IMainData main) -> ITransformable
```

### `Artech.Generators.ITemplateGenerator`

```

```

### `Artech.Generators.ITemplateInputProcessor`

```
GetParameters(Object input) -> Dictionary`2<String,Object>
```

### `Artech.Generators.Metadata.GeneratorMetadata`1`

```
SaveTransformState() -> Void
ApplyTransform(IMetadataTransform transform) -> Boolean
ResetTransformState() -> Void
GetMetadata() -> Object
```

### `Artech.Generators.Metadata.UIMetadataHelper`

```
static DeepCopy(T obj) -> T
```

### `Artech.Generators.TypesHelper`

```
static NormalizeTypeName(String s) -> String
static NormalizeVariableName(String s) -> String
static ToFirstUpper(String s) -> String
static ToCamel(String s) -> String
static GetBCType(String bcName) -> GeneratorType
static GetBCTypes(GeneratorType bcType,GeneratorType& serviceType,GeneratorType& dataType,GeneratorType& instanceType) -> Boolean
```

### `Artech.Packages.Generators.GeneratorExtension`

```
CompareOperationKey(String key,String key2) -> Boolean
ToString() -> String
GetUsedStandardMessages() -> IEnumerable`1<String>
```

### `Artech.Packages.Generators.GeneratorExtension+Generator`

```

```

### `Artech.Packages.Generators.GeneratorExtension+IGeneratorInstruction`

```

```

### `Artech.Packages.Generators.GeneratorExtension+IGeneratorMonitorSetting`

```

```

### `Artech.Packages.Generators.GeneratorExtension+IGeneratorOperation`

```

```

### `Artech.Packages.Generators.GeneratorExtension+RenderTemplateGroupInstruction`

```

```

### `Artech.Packages.Generators.GeneratorExtension+RenderTemplateInstruction`

```

```

### `GeneratorSpecification`

```

```

### `GeneratorSpecificationStrategy`

```

```

### `GeneratorSpecificationStrategyCopyDirectory`

```

```

### `GeneratorSpecificationStrategyCopyFile`

```

```

### `GeneratorSpecificationStrategyExtension`

```

```

### `GeneratorSpecificationStrategyGroup`

```

```

### `GeneratorSpecificationStrategyTemplate`

```

```

### `GeneratorSpecificationStrategyVariable`

```

```

## `Artech.Genexus.Common`

### `Artech.Architecture.BL.Framework.Services.IKnowledgeBaseService`

```

```

### `Artech.Common.Resolvers.ObjectParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Build.BuildDaemonClientGenerator`

```
GenerateAll(KBModel model,Int32 genId,DoBeforeGenerate beforeGenerate,DoAfterGenerate afterGenerate,Boolean isBuildWithTheseOnly) -> Boolean
GenerateGroup(Int32 genId,KBModel model,Int32 objClass,Int32 objId,String objects,Boolean isBuildWithTheseOnly) -> Boolean
EvaluateQuery(KBModel model,EvaluationQueryGen query) -> EvaluationResultGen
GenerateExtraGens(KBModel model,Boolean isBuildWithTheseOnly) -> Boolean
DaemonPreExecute(BuildDaemon daemon,BuildParameters daemonParams) -> Void
DaemonHandleResponse(BuildDaemon daemon,BuildResponse response,BuildParameters daemonParams,Boolean& retValue) -> Boolean
TryDumpSM(Int16 genId,Int32 modId) -> Boolean
SavePerfProps(BuildDaemon daemon) -> Void
```

### `Artech.Genexus.Common.Build.BuildDaemonClientGenerator+DoAfterGenerate`

```
Invoke(KBModel model) -> Boolean
BeginInvoke(KBModel model,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Boolean
```

### `Artech.Genexus.Common.Build.BuildDaemonClientGenerator+DoBeforeGenerate`

```
Invoke(KBModel model) -> Boolean
BeginInvoke(KBModel model,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Boolean
```

### `Artech.Genexus.Common.Build.BuildDaemonClientSpecifier+ParallelProcessingInitData`

```

```

### `Artech.Genexus.Common.Build.BuildDaemonClientSpecifier+ParallelProcessingServiceServer`

```
Process(KBModel model,Int32 batchId,Byte[] msg,Boolean& ok) -> ParallelProcessingInfo
CleanupLocalInfo() -> Void
```

### `Artech.Genexus.Common.Build.BuildDaemonInProcess`

```
static StartInProcessDaemon(BuildDaemonGroup DaemonGroup,StartDaemonDelegate StartDaemon,KnowledgeBase KB,Int32 GenId,String MutexName,String SegmentName,String ProductMSBuildPath,String ProductTriggerMsBuildName,IBuildDaemon idaemon) -> BuildDaemon
IsAlive() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Cloud.GeneratorSupport`

```

```

### `Artech.Genexus.Common.Cloud.LogPropertyApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Cloud.ServiceApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Cloud.ServiceDefinition`

```
GetPropertiesDefinition() -> PropertiesDefinition
```

### `Artech.Genexus.Common.Cloud.ServiceDefinition+ServiceType`

```

```

### `Artech.Genexus.Common.Cloud.ServiceDefinitionLoader`

```
static LoadServices(String serviceTypeDirectory) -> IEnumerable`1<ServiceDefinition>
static LoadService(String serviceDefinitionDirectory) -> IEnumerable`1<ServiceDefinition>
```

### `Artech.Genexus.Common.Cloud.ServiceInstance`

```

```

### `Artech.Genexus.Common.Cloud.ServicePropertyAfterSet`

```
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Cloud.ServicesInstances`

```
Serialize(XmlWriter writer,KBModel model) -> Void
```

### `Artech.Genexus.Common.Commands.DesignSystems.DesignSystemGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Commands.DesignSystems.GenerateDesignSystemCommand`

```
static GetBaseLibraryCssReferences(KBObject obj) -> String[]
static Generate(DesignSystem obj,Boolean rebuild,Boolean generateChildren,String basePath,Boolean silent) -> Boolean
static GetSpecFolder(KBModel model) -> String
```

### `Artech.Genexus.Common.Commands.ExecuteCommand`

```
Do() -> Boolean
Undo() -> Boolean
```

### `Artech.Genexus.Common.Commands.ExecuteSmartDevicesCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.GenerateCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.GenerateMetadataCommand`

```
Do() -> Boolean
Undo() -> Boolean
```

### `Artech.Genexus.Common.Commands.GenerateTableInitializationOrderFile`

```
Do() -> Boolean
Undo() -> Boolean
static DefineInitializationOrder(IEnumerable`1<DataProvider> initializers) -> IEnumerable`1<DataProvider>
```

### `Artech.Genexus.Common.Commands.IGenerateMetadataCommand`

```
AddSpecObject(EntityKey key) -> Void
```

### `Artech.Genexus.Common.Commands.Nemo.NemoGenerateCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.Nemo.NemoGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Commands.Pwa.PwaGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Commands.RestServiceDL.ODataServiceDLGenerateCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.RestServiceDL.ProtocolBufferDLGenerateCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.RestServiceDL.RestServiceDLGenerateCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.RestServiceDL.RestServiceDLSpecifyCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.RestServiceDL.RestServiceGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Commands.SmartDevicesGeneratorCommand`

```
Do() -> Boolean
Undo() -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Commands.UrlRewrite.UrlRewriteGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Commands.UserControls.UCGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Controls.FormHelper`

```
static GetControlByName(KBObject obj,String name) -> IEnumerable`1<IGxControl>
static GetControls(KBObject obj) -> IEnumerable`1<IGxControl>
static GetLastModificationCheck(KBObject obj) -> Int32
```

### `Artech.Genexus.Common.Converters.AdsServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.AnalyticsServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.CacheServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.CloudServiceTypeConverter`

```
CanConvertTo(ITypeDescriptorContext context,Type destinationType) -> Boolean
ConvertTo(ITypeDescriptorContext context,CultureInfo culture,Object value,Type destinationType) -> Object
ConvertFrom(ITypeDescriptorContext context,CultureInfo culture,Object value) -> Object
GetStandardValuesSupported(ITypeDescriptorContext context) -> Boolean
GetStandardValues(ITypeDescriptorContext context) -> StandardValuesCollection
```

### `Artech.Genexus.Common.Converters.GeneratorJavaVersionConverter`

```

```

### `Artech.Genexus.Common.Converters.MapsAppleServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.MapsServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.NotificationsServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.ObservabilityServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.RemoteConfigServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.SessionStateServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.StorageServiceTypeConverter`

```

```

### `Artech.Genexus.Common.Converters.WebNotificationsServiceTypeConverter`

```

```

### `Artech.Genexus.Common.CustomTypes.AttCustomTypeUIValidResolver`

```
Validate(Object instance,String propName,Object value) -> Boolean
```

### `Artech.Genexus.Common.CustomTypes.ButtonImagesBuilder`

```
ToString() -> String
```

### `Artech.Genexus.Common.CustomTypes.DisconnectFromServerActionBuilder`

```
EditValue(ITypeDescriptorContext context,IServiceProvider provider,Object value) -> Object
GetEditStyle(ITypeDescriptorContext context) -> UITypeEditorEditStyle
```

### `Artech.Genexus.Common.CustomTypes.GeneratedLanguage`

```

```

### `Artech.Genexus.Common.CustomTypes.GeneratedLanguageConverter`

```

```

### `Artech.Genexus.Common.CustomTypes.GeneratorCategoryReference`

```
GetReferences(ITypeDescriptorContext context) -> IEnumerable`1<EntityReferenceTo>
```

### `Artech.Genexus.Common.CustomTypes.GeneratorCategoryReferenceTypeConverter`

```

```

### `Artech.Genexus.Common.CustomTypes.GeneratorCustomAllType`

```

```

### `Artech.Genexus.Common.CustomTypes.GeneratorCustomAllTypeConverter`

```

```

### `Artech.Genexus.Common.CustomTypes.GeneratorCustomType`

```

```

### `Artech.Genexus.Common.CustomTypes.GeneratorCustomTypeConverter`

```

```

### `Artech.Genexus.Common.CustomTypes.GenexusTypeUIValidResolver`

```
Validate(Object instance,String propName,Object value) -> Boolean
```

### `Artech.Genexus.Common.DataSources.Datasource+DataSourceGenerator`

```
DeployTo(String directory) -> Void
```

### `Artech.Genexus.Common.Deployment.DeployHelper`

```
static IsAllowedObject(IKBObject obj) -> Boolean
```

### `Artech.Genexus.Common.Deployment.Generator`

```

```

### `Artech.Genexus.Common.Entities.GeneratorType`

```

```

### `Artech.Genexus.Common.Entities.GxGenerator`

```
static Create(KBModel model) -> GxGenerator
SetAsReorgGenerator() -> Void
ToString() -> String
GetPropertiesExtenders() -> IEnumerable`1<ICustomTypeDescriptor>
static GetIcon(Int32 generator) -> Icon
GetPropertiesExtender() -> ICustomTypeDescriptor
ShouldCompileNoMains() -> Boolean
static ShouldCompileNoMainsGenerator(GeneratorType generator) -> Boolean
```

### `Artech.Genexus.Common.Entities.GxGenerator+GeneratorConverter`

```
GetStandardValuesSupported(ITypeDescriptorContext context) -> Boolean
GetStandardValuesExclusive(ITypeDescriptorContext context) -> Boolean
CanConvertFrom(ITypeDescriptorContext context,Type sourceType) -> Boolean
CanConvertTo(ITypeDescriptorContext context,Type destinationType) -> Boolean
ConvertFrom(ITypeDescriptorContext context,CultureInfo culture,Object value) -> Object
ConvertTo(ITypeDescriptorContext context,CultureInfo culture,Object value,Type destinationType) -> Object
GetStandardValues(ITypeDescriptorContext context) -> StandardValuesCollection
```

### `Artech.Genexus.Common.Entities.GxGenerator+LanguageResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Entities.GxGenerator+NameResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Entities.GxGenerator+SetAsReorgPropertyResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Entities.GxGenerator+UserInterfaceResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
IsVisible(IPropertyBag properties) -> Boolean
IsApplicable(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Entities.GxGeneratorReference`

```

```

### `Artech.Genexus.Common.Entities.GxGeneratorReferenceConverter`

```
CanConvertFrom(ITypeDescriptorContext context,Type sourceType) -> Boolean
CanConvertTo(ITypeDescriptorContext context,Type destinationType) -> Boolean
GetStandardValuesSupported(ITypeDescriptorContext context) -> Boolean
GetStandardValuesExclusive(ITypeDescriptorContext context) -> Boolean
ConvertFrom(ITypeDescriptorContext context,CultureInfo culture,Object value) -> Object
ConvertTo(ITypeDescriptorContext context,CultureInfo culture,Object value,Type destinationType) -> Object
GetStandardValues(ITypeDescriptorContext context) -> StandardValuesCollection
```

### `Artech.Genexus.Common.GXtechnicalCheckToken.ExecuteRequest`

```

```

### `Artech.Genexus.Common.GXtechnicalCheckToken.ExecuteResponse`

```

```

### `Artech.Genexus.Common.GXtechnicalLogin.ExecuteRequest`

```

```

### `Artech.Genexus.Common.GXtechnicalLogin.ExecuteResponse`

```

```

### `Artech.Genexus.Common.GXtechnicalLoginForgot.ExecuteRequest`

```

```

### `Artech.Genexus.Common.GXtechnicalLoginForgot.ExecuteResponse`

```

```

### `Artech.Genexus.Common.GXtechnicalLogout.ExecuteRequest`

```

```

### `Artech.Genexus.Common.GXtechnicalLogout.ExecuteResponse`

```

```

### `Artech.Genexus.Common.GXtechnicalNewUser.ExecuteRequest`

```

```

### `Artech.Genexus.Common.GXtechnicalNewUser.ExecuteResponse`

```

```

### `Artech.Genexus.Common.Helpers.BasedOnHelper`

```
static GetBasedOnDomainId(PropertiesObject propertiesObject) -> Int32
static GetBasedOnDomain(PropertiesObject propertiesObject) -> BasedOnReference
static GetBasedOnDomain(KBModel model,PropertiesObject propertiesObject) -> BasedOnReference
static GetBasedOn(PropertiesObject propertiesObject) -> BasedOnReference
static GetBasedOn(KBModel model,PropertiesObject propertiesObject) -> BasedOnReference
```

### `Artech.Genexus.Common.Helpers.BuildHelper`

```
static MacTransfer(MacTransferArguments arguments,String& stdout,String& stderr) -> Boolean
static ExecuteCommand(String executablePath,String arguments,String& stdout,String& stderr) -> Boolean
static ExecuteCommand(String executablePath,String arguments,String& stdout,String& stderr,Encoding outputEncoding) -> Boolean
```

### `Artech.Genexus.Common.Helpers.CloudHelper`

```
static CheckConnectionString(KBModel model,CloudConnectionData& connectionData,Boolean force) -> Boolean
static CheckConnectionString(KBModel model,String dsName,CloudConnectionData& connectionData,Boolean force) -> Boolean
static GetServerNameFromDeployUrlProperty(GxModel gxModel) -> String
static GetServerNameFromDeployUrlProperty(GxModel gxModel,Boolean includePort) -> String
static UseGXtechnicalCloud() -> Boolean
static GetUniqueId(KBModel model) -> String
static GetEnvironmentId(KBModel model) -> String
static GetShortUniqueId(String uniqueCloudId) -> String
```

### `Artech.Genexus.Common.Helpers.CredentialsHelper`

```
static AskGeneXusAccountCredentials() -> Void
static SaveGeneXusAccountCredential(String userName,String userPassword,Boolean persist) -> Boolean
static DefaultSettings() -> CredentialsDialogSettings
```

### `Artech.Genexus.Common.Helpers.DesignSystemHelper`

```
GetAllTokens() -> Dictionary`2<String,Item>
GetTokens(String group) -> List`1<Item>
TryGetToken(String group,String name,Item& token) -> Boolean
GetTokensNames(String group) -> List`1<String>
GetTokensNames() -> Dictionary`2<String,List`1<String>>
GetClassesNames() -> List`1<String>
GetClassesReferences() -> Dictionary`2<String,List`1<ReferenceInfo>>
GetAllImagesNames() -> List`1<String>
```

### `Artech.Genexus.Common.Helpers.GeneratorHelper`

```
static GetGeneratorType(KBModel model) -> GeneratorType
static GetSDGenerator(KBModel model) -> GxGenerator
static GetSDGenerator(GxModel gxModel) -> GxGenerator
static IsWebGenerator(KBModel model) -> Boolean
static IsWebGenerator(GeneratorType genType) -> Boolean
static IsLogsTargetsGenerator(GeneratorType genType) -> Boolean
static IsTextGenerator(GeneratorType genType) -> Boolean
static IsFrontendGenerator(GeneratorType genType) -> Boolean
```

### `Artech.Genexus.Common.Helpers.GxProcess`

```

```

### `Artech.Genexus.Common.Helpers.GXtechnicalCloudServicesManager`

```
static ForgotPassword(String user,String& errorDsc) -> Int32
```

### `Artech.Genexus.Common.Helpers.InterfaceMetadataHelper`

```
static GenerateMetadata(KBModel model,EntityKey key) -> Void
static GenerateMetadata(KBModel model,EntityKey key,String basePath) -> Void
static GetParameterAccessor(ParameterAccess accessor) -> String
```

### `Artech.Genexus.Common.Helpers.JsonHelper`

```
static Serialize(String filename,T kbObject) -> Void
static Deserialize(String filename) -> T
```

### `Artech.Genexus.Common.Helpers.KBHelper`

```
static GetDefaultKBLanguage(KBModel model) -> LanguageReference
static GetDefaultKBLanguage(KnowledgeBase kb) -> LanguageReference
```

### `Artech.Genexus.Common.Helpers.KBModelHelper`

```
static GetFullPath(KBModel model) -> String
static GetFullPath(GxGenerator env) -> String
static GetConnectionConfig(GxGenerator env,GxDataStore dataStore,DeployConfig& config) -> DeployConfig
static GetNewDatastoreName(KBModel model,String baseName) -> String
```

### `Artech.Genexus.Common.Helpers.KBObjectHelper`

```
static IsSpecifiable(KBObject kbObj) -> Boolean
static IsSpecifiable(Guid objClass) -> Boolean
static IsGeneratable(KBObject obj) -> Boolean
static SupportConnectivityProperty(EntityKey key) -> Boolean
static SupportConnectivityProperty(Guid type) -> Boolean
static IsSDObject(EntityKey key) -> Boolean
static IsSDObject(Guid type) -> Boolean
static IsWebObject(Guid type) -> Boolean
```

### `Artech.Genexus.Common.Helpers.KBPropertiesHelper`

```
static IsHostedKB(KBProperties props) -> Boolean
static IsHostedKB(KnowledgeBase kb) -> Boolean
static IsLinkedKB(KBProperties props) -> Boolean
static IsLinkedKB(KnowledgeBase kb) -> Boolean
```

### `Artech.Genexus.Common.Helpers.MultiSignaturesHelper`

```
GetMembers() -> IEnumerable`1<IMultiCallableObject>
```

### `Artech.Genexus.Common.Helpers.ObjectInterfaceHelper`

```
GetSignatures() -> IEnumerable`1<Signature>
GetSignatureDependencies() -> IEnumerable`1<EntityKey>
GetMembers() -> IEnumerable`1<IMultiCallableObject>
GetPublicMethods() -> IEnumerable`1<Signature>
GetPublicMethodDependencies() -> IEnumerable`1<EntityKey>
GetStructuredTypes() -> IEnumerable`1<StructuredTypeInfo>
GetStructuredTypes(Boolean allLevels) -> IEnumerable`1<StructuredTypeInfo>
GetStructuredTypesDependencies() -> IEnumerable`1<EntityKey>
```

### `Artech.Genexus.Common.Helpers.OutputTemplateService`

```
AddErrorLine(String line) -> Void
AddLine(String line) -> Void
```

### `Artech.Genexus.Common.Helpers.ParmSignaturesHelper`

```

```

### `Artech.Genexus.Common.Helpers.PartHelper`

```
static GetGuidFromSpecLocation(Guid objType,String partName) -> Guid
```

### `Artech.Genexus.Common.Helpers.PromptHelper`

```
static GetName(Guid type,Int32 normalizationTableId,String parmSizeStr) -> String
static CurrentNameTypeSuffixLength(Guid type,String promptName) -> Int32
static TableIdAsString(Int32 normalizationTableId) -> String
static Get(KBModel model,Guid type,String name) -> KBObject
static MainTableResponsiveSizes(Boolean hasFilters) -> ResponsiveSizes
static AdvancedBarTableResponsiveSizes(Int32 rows) -> ResponsiveSizes
static GridTableResponsiveSizes(Boolean hasFilters) -> ResponsiveSizes
static FilterTableResponsiveSizes() -> ResponsiveSizes
```

### `Artech.Genexus.Common.Helpers.PublicMethodsHelper`

```

```

### `Artech.Genexus.Common.Helpers.RedundantCollectionHelper`1`

```
GetCollection() -> IRedundantCollection`1<TItem>
GetDependencies() -> IEnumerable`1<EntityKey>
```

### `Artech.Genexus.Common.Helpers.RunHelper`

```
static GetPgmFileName(Int32 nGenerator,IEquatable`1<Guid> pgmType,String pgmName,Boolean isMain) -> String
static GetFirstLetter(Int32 nGenerator,IEquatable`1<Guid> pgmType,Boolean isMain) -> Char
static GetProgramInfo(KBModel model,EntityKey objKey,Guid& pgmType,String& pgmName,Boolean& isMain,String& mainType) -> Boolean
```

### `Artech.Genexus.Common.Helpers.SdtTypesHelper`

```
GetSdtTypes() -> IEnumerable`1<StructuredTypeInfo>
GetSdtTypes(Boolean allLevels) -> IEnumerable`1<StructuredTypeInfo>
```

### `Artech.Genexus.Common.Helpers.SignaturesHelper`

```
GetSignatures() -> IEnumerable`1<Signature>
```

### `Artech.Genexus.Common.Helpers.SpecificationListHelper`

```
IsSpecificationNeeded(EntityKey objKey,GeneratorType genType) -> Boolean
IsSpecificationNeeded(KBObject obj,GeneratorType genType) -> Boolean
IsSpecificationNeeded(EntityKey objKey) -> Boolean
IsSpecificationNeeded(EntityKey objKey,IEnumerable`1<GeneratorType> generators) -> Boolean
IsSpecificationNeeded(KBObject obj,GeneratorType genType,Int32 outputTypeId,Boolean checkGenerateExclusion) -> Boolean
IsSpecificationNeeded(KBObject obj,GeneratorType genType,Int32 outputTypeId,DateTime specTimestamp) -> Boolean
static GetSpecTime(KBObject obj,GeneratorType genType,DateTime& specTime) -> Boolean
static FrontendEnabledGenerators(KBModel target) -> IEnumerable`1<GeneratorType>
```

### `Artech.Genexus.Common.Helpers.StructureHelper`

```
static IsStructuredObject(IPropertyBag obj,eDBType& type) -> Boolean
static IsStructuredType(eDBType type,Object content) -> Boolean
static GetFullMemberName(IStructureItem root,IStructureItem item) -> String
static GetFullMemberName(IEnumerable`1<IStructureItem> itemPath) -> String
static GetComposedName(SDTLevel level) -> String
static GetAssociatedObject(Object typedObj) -> KBObject
static GetAssociatedLevel(ITypedObject typedObj) -> IStructureItem
static GetAssociatedLevelForItem(ITypedObject typedObj,Boolean& isCollection) -> IStructureItem
```

### `Artech.Genexus.Common.Helpers.StyleHelper`

```
static GetObjectStyle(KBObject kbObject,ITypeDescriptorContext context) -> KBObject
```

### `Artech.Genexus.Common.Helpers.TableAccessHelper`

```
static LoadTableDependencies(KBModel model,EntityKey key) -> HashSet`1<String>
static LoadTableDependencies(KBModel model,String objName,String attributeId,String attributeValue) -> HashSet`1<String>
static SaveTableDependencies(KBModel model,EntityKey key,HashSet`1<String> tableDependencies) -> Void
static SaveTableDependencies(KBModel model,String objName,String attributeId,String attributeValue,HashSet`1<String> tableDependencies) -> Void
```

### `Artech.Genexus.Common.Helpers.TemplateHelper`

```

```

### `Artech.Genexus.Common.Helpers.TooltipHelper`

```
static GetTooltipText(ITypedObject typedObj) -> String
```

### `Artech.Genexus.Common.Helpers.UserSettingsHelper`

```

```

### `Artech.Genexus.Common.Helpers.ValueRangeHelper`

```
static Parse(String valueRangeExpression) -> List`1<String>
static Parse(String valueRangeExpression,Boolean preserveSpaces) -> List`1<String>
static IsValidString(String expression) -> Boolean
static IsValidDate(String expression) -> Boolean
static IsValidNumber(String expression) -> Boolean
static IsValidPunctuation(String expression) -> Boolean
static GetTokenType(String expression) -> TokenType
```

### `Artech.Genexus.Common.Helpers.WebPanelReferencesHelper`

```
static CalculatePanelClassesReferences(WebPanel panel) -> List`1<WebPanel>
```

### `Artech.Genexus.Common.Helpers.WorkWithDevicesHelper`

```
static IsTopLabel(String labelPosition) -> Boolean
```

### `Artech.Genexus.Common.KMW.Generators`

```
static Read(KBModel designModel,GeneratorsPart envsPart,XPathNavigator envsNavig,OutputMessages messages,ImportOptions options) -> Void
```

### `Artech.Genexus.Common.KMW.KmwHelper`

```
static GetNameFromObjectReference(XmlNode node,String query) -> String
static GetNameFromObjectReference(String compositeKey) -> String
static GetObject(KBModel model,ObjectIdentityType identityType,Guid guid,Guid type,QualifiedName name,OutputMessages output) -> KBObject
static IsPredefinedThemeClass(KBModel model,Guid type,QualifiedName name) -> Boolean
```

### `Artech.Genexus.Common.MarketplaceAuthentication.AM_AuthServicesSoapPort`

```
LOGIN(LOGINRequest request) -> LOGINResponse
LOGINAsync(LOGINRequest request) -> Task`1<LOGINResponse>
```

### `Artech.Genexus.Common.MarketplaceAuthentication.AM_AuthServicesSoapPortChannel`

```

```

### `Artech.Genexus.Common.MarketplaceAuthentication.AM_AuthServicesSoapPortClient`

```
LOGIN(String Userwebuser,String Password) -> String
LOGINAsync(String Userwebuser,String Password) -> Task`1<LOGINResponse>
```

### `Artech.Genexus.Common.ModelParts.GeneratorDefinition`

```

```

### `Artech.Genexus.Common.ModelParts.GeneratorDefinitionFactory`

```
static GetGeneratorExtension(String name) -> GeneratorExtension
static GetGeneratorDefinition(Int32 env,String& obj,String& friendlyName,String& userInterface) -> PropertiesDefinition
static GetGeneratorDefinition(Int32 env,String& obj,String& friendlyName) -> PropertiesDefinition
static GetIcon(GxGenerator gen) -> Icon
```

### `Artech.Genexus.Common.ModelParts.GeneratorsPart`

```
GetGenerator(Int32 categoryId) -> GxGenerator
GetGenerator(String categoryName) -> GxGenerator
AddGenerator(String categoryName,GeneratorType generator) -> GxGenerator
RemoveGenerator(Int32 categoryId) -> Void
OnSavingEnviromentChange() -> Void
Initialize(ModelTemplate template) -> Void
GetPartReferences() -> IEnumerable`1<EntityReference>
CloneTo(KBModelPart kbModelPart) -> Void
```

### `Artech.Genexus.Common.ModelParts.ModelDefinitionsHelper`

```
static GetFormType(Int32 generatorId) -> FormType
static CanGenerate(GeneratorType genType,Guid objType) -> Boolean
static GetGenerableTypes(GeneratorType genType) -> IEnumerable`1<Guid>
```

### `Artech.Genexus.Common.Objects.GeneratorCategory`

```
GetFullName() -> String
static GetCategories(KBModel model) -> List`1<GeneratorCategory>
static GetCategory(KBModel model,String name) -> GeneratorCategory
static Create(KBModel model) -> GeneratorCategory
static Get(KBModel model,Int32 id) -> GeneratorCategory
static Get(KBModel model,String name) -> GeneratorCategory
static GetKey(KBModel model,String name) -> EntityKey
static Get(KBModel model,Guid guid) -> GeneratorCategory
```

### `Artech.Genexus.Common.Objects.IExposableService`

```

```

### `Artech.Genexus.Common.Objects.Themes.Engine.ThemesEngineInfo`

```
static GetEngineInfoDocument(String engineResource) -> XmlDocument
```

### `Artech.Genexus.Common.Objects.Themes.Helpers.ThemeColorsPartHelper`

```
static GetPaletteColorsFromContext(ITypeDescriptorContext context) -> ThemePaletteColorCollection
```

### `Artech.Genexus.Common.Objects.Themes.Helpers.ThemeEntitiesHelper`

```
static UpdateFromSchema(KnowledgeBase kb) -> Void
static UpdateFromSchema(KBModel model) -> Void
static GetNewName(KBModel model,Guid parentGuid,String oldName) -> String
static AddClassIfPredefined(KBModel model,Guid themeClassGuid) -> EntityKey
static LoadThemeStylesPart(ThemeStylesPart part) -> Void
static UpdateFromThemeStylesPart(ThemeStylesPart part) -> Void
static TryDeleteEntitiesFromRemovedThemeElements(ThemeStylesPart part) -> Void
static FixConflicts(ThemeStylesPart part,Boolean showMessages) -> Void
```

### `Artech.Genexus.Common.Objects.Themes.Helpers.ThemeFontsPartHelper`

```

```

### `Artech.Genexus.Common.Objects.Themes.Helpers.ThemeStylesPartHelper`

```
static ValidPlatform(String themeType,XmlNode themeStyleNode) -> Boolean
static AnalizeCSSPropertyName(String propertyName) -> String
static AnalizePropertyName(String engineResource,String propertyName) -> String
static AnalizePropertyValue(String propertyName,String propertyValue,PropertyManager propertyManager,ThemeStyle themeStyle) -> Object
```

### `Artech.Genexus.Common.Objects.UserControls.UCRender`

```

```

### `Artech.Genexus.Common.Objects.UserControls.UserControlHelper`

```
static CopyControl(KBModel model,UserControl uc) -> Void
static CopyResources(KBModel model) -> Void
```

### `Artech.Genexus.Common.Objects.UserControls.UserControlsAriGenerator`

```
static WriteControlAri(KBModel model,String file,ControlDefinition def) -> Boolean
static CreateDefinitionAri(KBModel model,IEnumerable`1<ControlDefinition> controls,Boolean forceGenerate) -> Void
static CreateDatFile(String folder,IUserControlsContainer container) -> Void
```

### `Artech.Genexus.Common.Parser.Helpers.VariablesHelper`

```
static GetDefinitionById(ParserInfo parserInfo,Int32 id) -> Variable
static GetDefinitionByName(ParserInfo parserInfo,String name) -> Variable
static GetVariables(ParserInfo parserInfo) -> IEnumerable`1<Variable>
```

### `Artech.Genexus.Common.Parts.APIObject.APIObjectHelper`

```

```

### `Artech.Genexus.Common.Parts.APIObject.SuperAppHelper`

```

```

### `Artech.Genexus.Common.Parts.DefaultFormHelper`

```
static HasPrompt(TransactionAttribute trnAttribute) -> Boolean
static ForceInputType(TransactionAttribute trnAttribute) -> Boolean
static ForceEdit(TransactionAttribute trnAttribute) -> Boolean
static CalculateRelations(TransactionLevel level) -> IDictionary`2<TransactionAttribute,Attribute>
static CalculateExcluded(TransactionLevel level,IDictionary`2& substitutions) -> IList`1<Int32>
static GetTransactionAttribute(IPropertyBag properties) -> TransactionAttribute
static IsHiddenAttribute(TransactionAttribute att) -> Boolean
static GetMaxLabels(TransactionLevel level,TemplateHelper helper,IDictionary`2<TransactionAttribute,Attribute> descAttNames) -> Int32
```

### `Artech.Genexus.Common.Parts.Form.DOM.BindableElement`1`

```

```

### `Artech.Genexus.Common.Parts.Form.DOM.IBindable`

```

```

### `Artech.Genexus.Common.Parts.Layout.ApplyBorders`

```

```

### `Artech.Genexus.Common.Parts.Layout.LayoutHelper`

```

```

### `Artech.Genexus.Common.Parts.Layout.ReportBindableElement`

```

```

### `Artech.Genexus.Common.Parts.Layout.SpecificationHelper`

```
static GetPrologDescriptor(Font font) -> String
static GetPrologDescriptor(Rectangle rect,ApplyBorders borders,Int32 borderWidth,Boolean textMode) -> String
static GetPrologDescriptor(ApplyBorders applyBorders) -> String
static GetPrologDescriptor(Color color) -> String
static GetPrologDescriptor(Color color,String propName) -> String
static GetPrologDescriptor(Int32 value,String propName) -> String
static GetPrologDescriptor(String value,String propName) -> String
static GetPrologDescriptor(Alignment alignment) -> String
```

### `Artech.Genexus.Common.Parts.MenubarHelper`

```

```

### `Artech.Genexus.Common.Parts.ServiceGroupSourcePart`

```
CheckReference(Module module,String fullName,Guid& objGUID) -> Boolean
ValidateData(OutputMessages output) -> Boolean
GetPartReferences() -> IEnumerable`1<EntityReference>
ParseSource(ParserInfo info,IKBModelObjects modelObjects,String source,IParserTokenizer tokenizer,OutputMessages output) -> Boolean
GetPublicMethods() -> IEnumerable`1<Signature>
GetPublicMethodDependencies() -> IEnumerable`1<EntityKey>
GetReferencedVariables() -> IEnumerable`1<VariableReference>
```

### `Artech.Genexus.Common.Parts.Services.IEventPartServices`

```
ValidEventNames() -> IEnumerable`1<String>
AddUserEvent(String eventName) -> Void
```

### `Artech.Genexus.Common.Parts.SourceHelper`

```
static GetVariablesNames(ParserInfo info,String source) -> IEnumerable`1<String>
static GetPublicMethods(KBObjectPart objPart,String source,IList`1<Signature> publicSubs) -> Boolean
static ValidateSubroutines(KBObjectPart objPart,IParserEngine engine,ParserInfo settings,OutputMessages output) -> Boolean
static GetParserInfo(KBObjectPart part) -> ParserInfo
static ToStorage(String source,ParserInfo info) -> String
static FromStorage(String source,ParserInfo info) -> String
static GetReferences(IParserEngine parser,String source,ParserInfo info,KBModel model,EntityKey key) -> IEnumerable`1<EntityReference>
static LoadSignature(ParserInfo info,String source,Boolean defaultParameterIn,IList`1<RuleDefinition> signatures) -> Boolean
```

### `Artech.Genexus.Common.Parts.Stencil.StencilHelper`

```

```

### `Artech.Genexus.Common.Parts.Structure.TransactionStructureHelper`

```
static DefaultDescriptionAttribute(TransactionLevel level) -> TransactionAttribute
static DefaultDescriptionAttribute(TransactionLevel level,IEnumerable`1<TransactionAttribute> excludeCandidates) -> TransactionAttribute
```

### `Artech.Genexus.Common.Parts.WebForm.GxControlHelper`

```
static AddProperty(StringBuilder sProps,Object name,Object value) -> Boolean
static EscapePropertyValue(String& value) -> Void
static UnescapePropertyValue(String& value) -> Void
static GetPropObj(GxControlType type) -> String
static GetElementStartHtml(GxControlType type) -> String
static GetElementEndHtml() -> String
static GetElementStartHtml(String type) -> String
static LoadInnerElements(IHTMLElement e,Dictionary`2<String,IHTMLElement> innerElements) -> Void
```

### `Artech.Genexus.Common.Parts.WebForm.HtmlHelpers`

```
static ConvertToSpecialXMLCharacters(String str) -> String
static GetHtmlColor(Color color) -> String
```

### `Artech.Genexus.Common.Parts.WebForm.HtmlSerializerResolver`

```
GetValidAttributeName(String text,String& attName,String& attNamespace) -> Boolean
```

### `Artech.Genexus.Common.Parts.WebForm.HtmlTagHelper`

```
static ConvertValueToSave(TypeDescriptorContext context,Object objvalue,String& value) -> Boolean
static SavePropertiesTo(IDictionary props,PropertiesObject propsObj) -> Void
static GetUserProperties(IWebTag tag) -> Hashtable
static SaveUserProperties(IDictionary gxProps,IDictionary userProps,XmlAttributeCollection nodeAttributes,Boolean hasStyleAttributes,String nodeName) -> Void
static ConvertValueToLoad(TypeDescriptorContext context,String value,Object& objvalue) -> Boolean
static LoadPropertiesFrom(IDictionary props,PropertiesObject propsObj,KBObject kbObj) -> Void
static GetPropObj(String tagName) -> String
static GetStylePropertiesMap(Boolean isFreeStyle,String nodeName) -> IDictionary`2<String,String>
```

### `Artech.Genexus.Common.Parts.WebForm.IWebTagRender`

```
Render() -> Void
```

### `Artech.Genexus.Common.Parts.WebForm.WebControlRender`

```
GetPropertiesObject() -> PropertiesObject
GetPropertiesExtender() -> ICustomTypeDescriptor
GetHTMLControl(String type) -> String
GetHTMLControl(String type,XslCompiledTransform transform) -> String
GetTranslationFor(String text) -> String
GetPropValue(String propName) -> String
GetPropValueImage(String propName) -> String
GetPropValueObject(String propertyName) -> Object
```

### `Artech.Genexus.Common.Parts.WebForm.WebFormHelper`

```
static IsEnumerableWebTagReadonly(WebFormPart webForm) -> Boolean
static EnumerateWebTag(WebFormPart webForm) -> IEnumerable`1<IWebTag>
static EnumerateWebTag(KBObject kbObj,XmlDocument doc) -> IEnumerable`1<IWebTag>
static EnumerateWebTag(KBObject kbObj,XmlElement singleWebFormElement) -> IEnumerable`1<IWebTag>
static GetWebTagTree(KBObject kbObj,XmlElement singleWebFormElement) -> Tree`1<IWebTag>
static MapToGenexusTypeName(String propertyName,Type propertyType) -> String
static CreateWebControl(KBObjectPart webForm,IWebTag tag) -> IGxControl
static GetControlName(IWebTag tag) -> String
```

### `Artech.Genexus.Common.Parts.WebForm.WebGridRender`

```
IsEven(String number) -> Boolean
GetPropValue(String PropertyName) -> String
GetColAttSize(String ColWidth,String ColFont) -> String
GetHtmlUserControl(String userControl,String sColumn) -> String
GetHtmlColumnsProperties(String properties) -> XPathNodeIterator
```

### `Artech.Genexus.Common.Parts.WebForm.WebRenderHelper`

```
static GetImageUrl(KBObject kbObj,PropertiesObject propObj,String propertyName) -> String
```

### `Artech.Genexus.Common.Parts.WebForm.WebUserRender`

```
GetMyPath() -> String
GetAmp() -> String
GetStringPropertyValue(String propName) -> String
SetPropValue(String propName,String propValue) -> String
GetPropertyValueInt(String propName) -> String
GetClickedElementId(String defaultId) -> String
GetPropertyValueColorRGB(String propName) -> String
```

### `Artech.Genexus.Common.Parts.WinForm.IWinTagRender`

```
Render() -> Void
```

### `Artech.Genexus.Common.Parts.WinForm.WinFormHelper`

```
static GetControlName(IWinTag tag,KBObjectPart winForm) -> String
static CreateNavigator(WinFormPart winForm) -> IWinNavigator
```

### `Artech.Genexus.Common.Properties+ActionGroupClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+ActionGroupClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+ActionGroupItemClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+ActionGroupItemClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+API+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+API+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+AttributeClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+AttributeClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+ButtonClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+ButtonClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+CallTargetClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+CallTargetClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+CBL+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+CBL+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+CBL+KeyRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+CBL+KeyRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+CBL+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+CBL+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateDeveloperMenuMakefile_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateDeveloperMenuMakefile_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateOdataInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateOdataInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateStrongNamedAssemblies_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+GenerateStrongNamedAssemblies_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+SearchEngine_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+SearchEngine_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARP+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GenerateDeveloperMenuMakefile_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GenerateDeveloperMenuMakefile_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GenerateStrongNamedAssemblies_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+GenerateStrongNamedAssemblies_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPCF+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateDeveloperMenuMakefile_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateDeveloperMenuMakefile_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateMdiApplication_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateMdiApplication_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateStrongNamedAssemblies_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+GenerateStrongNamedAssemblies_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+CSHARPWIN+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+DEPLOY+AppUpdate_Enum`

```

```

### `Artech.Genexus.Common.Properties+DEPLOY+AppUpdate_Values`

```

```

### `Artech.Genexus.Common.Properties+DPRV+GenerateObservabilitySpan_Enum`

```

```

### `Artech.Genexus.Common.Properties+DPRV+GenerateObservabilitySpan_Values`

```

```

### `Artech.Genexus.Common.Properties+DPRV+GenerateOdataInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+DPRV+GenerateOdataInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+DPRV+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+DPRV+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+DPRV+WebServiceProtocol_Enum`

```

```

### `Artech.Genexus.Common.Properties+DPRV+WebServiceProtocol_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_AS400NATIVE+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_AS400NATIVE+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DAMENG+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DAMENG+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DAMENG+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DAMENG+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DAMENG+GenerateForUpdateClause_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DAMENG+GenerateForUpdateClause_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2400+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2400+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2400+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2400+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2COMMONSERVERS+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2COMMONSERVERS+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2COMMONSERVERS+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_DB2COMMONSERVERS+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_INFORMIX+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_INFORMIX+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_INFORMIX+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_INFORMIX+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_MYSQL+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_MYSQL+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_ORACLE+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_ORACLE+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_ORACLE+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_ORACLE+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_ORACLE+GenerateForUpdateClause_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_ORACLE+GenerateForUpdateClause_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_POSTGRESQL+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_POSTGRESQL+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_SERVICE`

```
static GetConnectionMethod(IPropertyBag properties) -> String
static SetConnectionMethod(IPropertyBag properties,String value) -> Void
static GetServerName(IPropertyBag properties) -> String
static SetServerName(IPropertyBag properties,String value) -> Void
static GetAdditionalConnectionStringAttributes(IPropertyBag properties) -> String
static SetAdditionalConnectionStringAttributes(IPropertyBag properties,String value) -> Void
static GetTimestampLastChange(IPropertyBag properties) -> String
static SetTimestampLastChange(IPropertyBag properties,String value) -> Void
```

### `Artech.Genexus.Common.Properties+DS_SQLCE+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_SQLCE+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_SQLSERVER+CreateSaveFile_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_SQLSERVER+CreateSaveFile_Values`

```

```

### `Artech.Genexus.Common.Properties+DS_SQLSERVER+GenerateCommentOnStatements_Enum`

```

```

### `Artech.Genexus.Common.Properties+DS_SQLSERVER+GenerateCommentOnStatements_Values`

```

```

### `Artech.Genexus.Common.Properties+DV_SERVICE`

```
static GetUseExternalName(IPropertyBag properties) -> String
static SetUseExternalName(IPropertyBag properties,String value) -> Void
static GetHelpKeyword(IPropertyBag properties) -> Int32
static SetHelpKeyword(IPropertyBag properties,Int32 value) -> Void
static GetLocation(IPropertyBag properties) -> String
static SetLocation(IPropertyBag properties,String value) -> Void
static GetName(IPropertyBag properties) -> String
static SetName(IPropertyBag properties,String value) -> Void
```

### `Artech.Genexus.Common.Properties+DVI_SERVICE`

```
static GetUseExternalName(IPropertyBag properties) -> String
static SetUseExternalName(IPropertyBag properties,String value) -> Void
static GetHelpKeyword(IPropertyBag properties) -> Int32
static SetHelpKeyword(IPropertyBag properties,Int32 value) -> Void
static GetLocation(IPropertyBag properties) -> String
static SetLocation(IPropertyBag properties,String value) -> Void
static GetName(IPropertyBag properties) -> String
static SetName(IPropertyBag properties,String value) -> Void
```

### `Artech.Genexus.Common.Properties+ErrorViewerClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+ErrorViewerClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+ErrorViewerLineClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+ErrorViewerLineClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+FlexClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+FlexClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+FormClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+FormClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+FORMSFL+AutomaticRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+FORMSFL+AutomaticRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+FORMSFL+WhenToRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+FORMSFL+WhenToRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+FreeStyleGridClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+FreeStyleGridClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+GenericThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+GenericThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+GridClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+GridClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+GridColumnClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+GridColumnClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+GridRowClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+GridRowClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+GroupClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+GroupClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+HTMLSFLFS+RenderingMode_Enum`

```

```

### `Artech.Genexus.Common.Properties+HTMLSFLFS+RenderingMode_Values`

```

```

### `Artech.Genexus.Common.Properties+HyperlinkClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+HyperlinkClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+ImageClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+ImageClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateMdiApplication_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateMdiApplication_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateOdataInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateOdataInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+SearchEngine_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+SearchEngine_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+StandardClassesUpdatePolicy_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+StandardClassesUpdatePolicy_Values`

```

```

### `Artech.Genexus.Common.Properties+JAVA+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+JAVA+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+MessagesClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+MessagesClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+MODEL+AutomaticRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+MODEL+AutomaticRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+MODEL+GenerateCodeCoverageInformation_Enum`

```

```

### `Artech.Genexus.Common.Properties+MODEL+GenerateCodeCoverageInformation_Values`

```

```

### `Artech.Genexus.Common.Properties+MODEL+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+MODEL+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateDeveloperMenuMakefile_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateDeveloperMenuMakefile_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateOdataInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateOdataInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateStrongNamedAssemblies_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+GenerateStrongNamedAssemblies_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+SearchEngine_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+SearchEngine_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+StandardClassesUpdatePolicy_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+StandardClassesUpdatePolicy_Values`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+NETCORE+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+PopupClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+PopupClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+PRC+AllowUserToCancelProcessing_Enum`

```

```

### `Artech.Genexus.Common.Properties+PRC+AllowUserToCancelProcessing_Values`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateForUpdateClause_Enum`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateForUpdateClause_Values`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateIleRpgForIseries_Enum`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateIleRpgForIseries_Values`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateObservabilitySpan_Enum`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateObservabilitySpan_Values`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+PRC+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+RPG+GenerateIleRpgForIseries_Enum`

```

```

### `Artech.Genexus.Common.Properties+RPG+GenerateIleRpgForIseries_Values`

```

```

### `Artech.Genexus.Common.Properties+RPG+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+RPG+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+RPG+KeyRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+RPG+KeyRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+RPG+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+RPG+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+RPT+AllowUserToCancelProcessing_Enum`

```

```

### `Artech.Genexus.Common.Properties+RPT+AllowUserToCancelProcessing_Values`

```

```

### `Artech.Genexus.Common.Properties+RPT+GenerateIleRpgForIseries_Enum`

```

```

### `Artech.Genexus.Common.Properties+RPT+GenerateIleRpgForIseries_Values`

```

```

### `Artech.Genexus.Common.Properties+RUBY+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+RUBY+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+RUBY+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+RUBY+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+RUBY+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+RUBY+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+RUBY+SearchEngine_Enum`

```

```

### `Artech.Genexus.Common.Properties+RUBY+SearchEngine_Values`

```

```

### `Artech.Genexus.Common.Properties+SectionClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+SectionClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+SINGLEIMAGE+RenderingMode_Enum`

```

```

### `Artech.Genexus.Common.Properties+SINGLEIMAGE+RenderingMode_Values`

```

```

### `Artech.Genexus.Common.Properties+TabClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+TabClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+TableCellClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+TableCellClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+TableClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+TableClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+TableRowClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+TableRowClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+TabPageClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+TabPageClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+TextBlockClassThemeStyle+BackgroundAttachment_Enum`

```

```

### `Artech.Genexus.Common.Properties+TextBlockClassThemeStyle+BackgroundAttachment_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateAsAPopupWindow_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateAsAPopupWindow_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateForUpdateClause_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateForUpdateClause_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateIleRpgForIseries_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateIleRpgForIseries_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateObservabilitySpan_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateObservabilitySpan_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateOdataInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateOdataInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateOpenAPIInterface_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+GenerateOpenAPIInterface_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+UpdatePolicy_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+UpdatePolicy_Values`

```

```

### `Artech.Genexus.Common.Properties+TRN+WebServiceProtocol_Enum`

```

```

### `Artech.Genexus.Common.Properties+TRN+WebServiceProtocol_Values`

```

```

### `Artech.Genexus.Common.Properties+VFP+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFP+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+VFP+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFP+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+VFP+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFP+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+GenerateNullForNullvalue_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+GenerateNullForNullvalue_Values`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+GeneratePromptPrograms_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+GeneratePromptPrograms_Values`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+UpdateKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+VFPCS+UpdateKey_Values`

```

```

### `Artech.Genexus.Common.Properties+WBP+AutomaticRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+WBP+AutomaticRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+WBP+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+WBP+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+AllowUserToCancelProcessing_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+AllowUserToCancelProcessing_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+AutomaticRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+AutomaticRefresh_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+ExecuteLoadEventsInApplicationServer_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+ExecuteLoadEventsInApplicationServer_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+GenerateAsAPopupWindow_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+GenerateAsAPopupWindow_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+GenerateIleRpgForIseries_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+GenerateIleRpgForIseries_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+RefreshKey_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+RefreshKey_Values`

```

```

### `Artech.Genexus.Common.Properties+WKP+WhenToRefresh_Enum`

```

```

### `Artech.Genexus.Common.Properties+WKP+WhenToRefresh_Values`

```

```

### `Artech.Genexus.Common.Resolvers.AddButtonBitmapDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.AllBackColorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.AndroidMultidexBuildDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AndroidNoCompileApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AndroidPackageNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AndroidPackageNameValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AndroidSDKDirDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ApplicationBarsClassDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Apply.AttThemeClassApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Apply.AutoCapitalizationApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAlignDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAUTONUMBER_FORREPLICATIONDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAUTONUMBER_STARTDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAUTONUMBER_STEPDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAUTONUMBERDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAutoResizeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttAvgDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttCOL_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.AttCollectionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttCollectionReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttCollectionValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttColsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttControlInheritDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttControlTypeValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.AttCustomTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttDatePrecisionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttDecimalsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttDecimalsValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttFormatDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttHasDomainDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttHasDomainValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttHORIZONTAL_DESCRIPTIONDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttHourFormatDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttIsFormulaDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttIsSubtypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttLengthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttLengthValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttMaxLengthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttNameValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Resolvers.AttPictureDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttROW_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.AttRowsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttSignedDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttThemeBaseClassDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttThemeClassDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttVERTICAL_DESCRIPTIONDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AttWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AutoLengthPropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.AutomaticPromptsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.AutomaticRefreshDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BackColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BaseAttCollectionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BaseAttTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BasedOnDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BasedOnValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BaseThemePropertyValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag properties,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.BaseThemePropertyVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.BindingDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value,String propName) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.BorderColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BorderRadiusDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BordersJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
```

### `Artech.Genexus.Common.Resolvers.BorderStyleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BorderWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BtnBorderStyleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BtnCaptionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BtnEventDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
static GetEventFromCaption(IPropertyBag properties,String captionPropertyName,String onClickEventPropertyName,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BundleIdentifierDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BundleIdentifierValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.BusinessComponentDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ButtonBitmapDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CanCompileAndroidVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CaptionExpressionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
static GetDefaultCaption(IPropertyBag properties,String onClickEventPropertyName) -> String
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CheckedUncheckedValueValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CheckedValueDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ClasspathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.COL_COUNTDefaultResolver`

```
static GetFieldIfNeeded(IPropertyBag properties,ITypedObject typedObj) -> ITypedObject
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColTitleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColTitleExpressionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColumnAutoResizeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColumnLinesColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColumnLinesFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColumnTitleColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColumnTitleFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ColumnWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CommitOnExitDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CompilerClasspathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CompilerPathValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ConfirmButtonBitmapDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.ConnectivitySupportDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ConnectivitySupportSuperAppDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ContextResolverBase`

```
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ContextualTitleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlAttFormatDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlBaseClassDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlBorderWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlClassDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlName_RPT_ATT_VisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.ControlName_RPT_CTRL_VisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlNameEmptyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.ControlNameValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlNameVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Resolvers.ControlRestrictedByDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlThemeParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Resolvers.ControlTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlTypeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
static SetValidatingControlType(IPropertyBag propertyBag,Object value) -> Void
static GetValidatingControlType(IPropertyBag properties) -> Int32
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlValuesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlValuesValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ControlWhereDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CopyAPKToCloudApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CopyAPKToTomcatApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.CornerRadiusDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DarkThemePropertyValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag properties,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.DarkThemeVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DatabaseSchemaDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.DataProviderOutputDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataSelectorParamsApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataSourceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataSourceFromValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataSourceValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataStoreAccessTechnologyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataStoreAdoNetProviderDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreConnStringAttsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.DataStoreCustomJdbcUrlDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreDBNameDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataStorePropNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataStoreServerInstanceDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreServerInstanceValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataStoreServerInstanceVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DataStoreServerNameDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreServerTcpIpPortDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreSQLServerVersionDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreTrustedConnectionDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreUseCustomJdbcUrlDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreUserIdDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataStoreUserPasswordDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DataTypeStringDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DateFormatValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DatepickerImageDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DatetimeStorageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.AppEncryptionKeyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.AppleFlexibleClientVersionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.AutoCorrectionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.CloseEffectDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Default.DeployToCloudDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.DeployToCloudVirtualDirectoryDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.EffectDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.EnterEffectDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Default.ExoItemCollectionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExoItemDecimalsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExoItemLengthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExoItemSignedDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExoItemTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectIsStaticMethodDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectJSNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectNetCoreAssemblyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectNetCoreConstructorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectNetCoreNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectNetCoreTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.ExternalObjectTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.IsMultilineDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.MainPlatformDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.SDGeneratorEnabledDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.SessionTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.SiteKeyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.TableDescriptionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Default.TransactionLevelAssociatedTableDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultAttFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DefaultBtnFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DefaultDeleteUsageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultDisplayUsageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultEnvironmentDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultExposedNamespaceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultImageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultImagePreviewDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultInsertUsageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultMasterPageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultRptAttFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DefaultRptLayoutFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultRptTextFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DefaultTextFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DefaultThemeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultThemeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DefaultUpdateUsageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DeleteButtonBitmapDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DeleteRowImageDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.DesignSystemDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DesignSystemVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DevelopmentTeamIdValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DimensionsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DimensionsVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DisabledWarningsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DocumentPageLinkDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DomainKeyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DotNetCompilerDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DotNetIISVersionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DotNetWebRootDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
static GetDefaultWebRoot(IPropertyBag properties,KBModel model) -> String
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.DotNetWebServerDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EmptyAsNullDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EmptyAsNullValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnableFirebaseCrashlyticsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnableIntegratedSecurityDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnableIntegratedSecurityReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnableShowPasswordDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnterEffectLengthApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnterIsUserEventApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnumValuesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EnumValuesValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
static Validate(EnumValues values,eDBType type,Boolean signed,Int32 length,Int32 decimals) -> Boolean
GetDependencies() -> String[]
static IsValidValue(EnumValue value,eDBType type,Boolean signed,Int32 length,Int32 decimals) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.ExecSimulatorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ExitEffectLengthApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ExoExternalNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ExposedNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ExposedNamespaceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.EXT_ATT_TYPE_DefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FileExistsGPNValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.FileExistValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FileExternalFileNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FontFileJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
```

### `Artech.Genexus.Common.Resolvers.ForeColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormatDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormatReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormAttHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormAttWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
static GetControlDefaultWidth(Int32 controlType,IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
static GetComboDefaultWidth(IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
static GetCheckDefaultWidth(IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
static GetRadioDefaultWidth(IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
static GetDynListDefaultWidth(IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
static GetDynComboDefaultWidth(IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
static GetEditDefaultWidth(IPropertyBag properties,Font font,Int32 colCount,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.FormButtonHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormButtonWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormColumnAutoResizeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormGridWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormImageHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormImageWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormTextHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FormTextWidthDefaultResolver`

```
static GetBorder(IPropertyBag properties) -> Int32
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FromEnvironmentDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FromEnvironmentDefaultResolver_EncryptUrlParameters`

```

```

### `Artech.Genexus.Common.Resolvers.FromEnvironmentDefaultResolver_ProtocolSpecification`

```

```

### `Artech.Genexus.Common.Resolvers.FromEnvironmentDefaultResolver_WebSecurityLevel`

```

```

### `Artech.Genexus.Common.Resolvers.FromOtherPropertyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FromSDGeneratorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.FromVersionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.GeneratedLanguageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.GeneratorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.GenericAttributeOfGridResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag properties,Object value) -> Boolean
IsReadOnly(IPropertyBag properties) -> Boolean
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.GenericFieldResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
IsValid(IPropertyBag properties,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.GenericResolverFactory`

```
GetApplyResolver(String propName) -> IApplyResolver
GetContextResolver() -> IContextResolver
GetCustomApplyResolver(String propName) -> IApplyResolver
GetCustomDefaultResolver(String propName) -> IDefaultResolver
GetCustomReadOnlyResolver(String propName) -> IReadOnlyResolver
GetCustomValidResolver(String propName) -> IValidResolver
GetCustomValuesResolver(String propName) -> IValuesResolver
GetCustomVisibleResolver(String propName) -> IVisibleResolver
```

### `Artech.Genexus.Common.Resolvers.GetDescByKeyProcApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.GridColumnClassDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.GRPCNamespaceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Handlers.GenerateAndroidAfterSetHandler`

```
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Resolvers.Handlers.GenerateiOSAfterSetHandler`

```
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Resolvers.Handlers.GeneratorAfterSetHandler`

```
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Resolvers.Handlers.SaveFileInKbAfterSetHandler`

```
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Resolvers.Handlers.SaveFileInKbAfterSetHandlerSettingsAttribute`

```
GetExtractFor(String extractForPropertyName) -> Nullable`1<Boolean>
SetExtranctFor(String extractForPropertyName,Nullable`1<Boolean> value) -> Void
GetExtractionDirectory(String extractionDirectoryPropertyName) -> DirectoryType
SetExtractionDirectory(String extractionDirectoryPropertyName,String value) -> Void
SetExtractionDirectory(String extractionDirectoryPropertyName,DirectoryType value) -> Void
```

### `Artech.Genexus.Common.Resolvers.Handlers.StandardClassesUpdatePolicyAfterSetValueHandler`

```
OnAfterResetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
OnAfterSetValueHandler(IPropertyBag properties,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Resolvers.idATTFORMULADefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IdeLanguageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IdeLanguageValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IDesignSystemToJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
```

### `Artech.Genexus.Common.Resolvers.ImageDescriptorsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ImageUploadSizeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.InheritFromGeneratorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.InheritLengthPropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.InitialValueDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.InputHistoryDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.InputTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegerOrEmptyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityAdministratorUserNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityAdministratorUserPasswordDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityAnonymousApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityApplicationClientApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityApplictationIdDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityClientEncryptionKeyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityClientIdDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityClientIdValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityClientSecretDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityClientSecretValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityConnectionUserNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityConnectionUserPasswordDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityGeneralApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityLevelApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityLevelDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityLevelDefaultResolverFormVersion`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityPermissionPrefixApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityPermissionPrefixDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityPermissionPrefixValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityPublicObjectValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityRepositoryIdDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecuritySDLoginValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.IntegratedSecuritySDNotAuhorizedValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.IntegratedSecuritySDPermissionPrefixDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityWebLoginValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.IntegratedSecurityWebNotAuthorizedValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.InviteMessageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsAttributeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsEnumeratedDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsInterfaceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsLanguageDependantDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsolationLevelDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsPaperCustomReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsPasswordDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsRightToLeftDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsSDPanelOrDashboardVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsSDPanelVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsThemeDependantDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsUserControlDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsUserControlWithCustomValuesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsUserControlWithDynamicValuesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsUserControlWithFixedValuesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.IsVariableDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.ItemValuesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaCompilerDefaultResolver`

```
static JDKPath(IPropertyBag properties) -> String
static TomcatDefaultPath(GxModel gxModel) -> String
static CalculateMaxTomcatVersionFromRegistry(Double maxVersiontoSearch,String& tomcatInstallPath) -> Double
static GetNotDefaultJDKVersion(IPropertyBag properties,String defaultJavaVersion) -> String
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaCompilerOptionsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaInterpreterDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaInterpreterPathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaInterpreterPathVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaPackageNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaPackageNameValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JavaPlatformSupportDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JDKDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.JsonNullSerializationDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.KBLanguageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.KBLanguageValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.KBNameValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.LabelClassApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.LanguageParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Resolvers.LengthPropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.LinesBackColorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LinesBackColorEvenDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LinesBackTextColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LinesBackWinColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LinesFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.LinesForeColorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LinesTextColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LinesWinColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.LogLevelDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MasterPageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MasterPageValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MaxNumericLengthValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MBOptionCaptionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MeasureJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
static Split(String propertyValue) -> String[]
```

### `Artech.Genexus.Common.Resolvers.MeasureValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MeasureWidthValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.MenubarDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MenuOptionDescriptionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MSBuildOptionsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleBorderDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleBoxShadowDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleColumnsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleFillAreaDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleMarginDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultiplePaddingDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleScalableAreaDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.MultipleShadowDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.NLSDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.NmakeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.NoneLengthPropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.NonEmptyLengthValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.NonEmptyOpacityValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.NonEmptyTimeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.NotDesignModelReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.NotifyContextChangeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.NotShownWhenDefaultVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
IsVisible(IPropertyBag properties,PropDefinition definition) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OBJ_CTRL_NAME_DefaultResolver`

```
static Get(IPropertyBag properties) -> String
static GetControlNameFromField(String fieldSpecifier) -> String
static GetDefaultFrom(AttributeVariableReference attVarRef,String fieldSpecifier) -> String
static GetDefaultFrom(IPropertyBag properties,AttributeVariableReference attVarRef,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OBJ_DATATYPEDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ObjClsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ObjectGeneratorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ObjectJNDI_NameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OfflineEventAfterReplicationDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.OfflineEventBeforeReplicationDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.OfflineEventReplicationDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OfflineEventReplicationErrorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.OnClickEventVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OnlyDesignModelVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OnSessionTimeoutDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OpacityPropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.OutputCollectionNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.PackageReferencesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.PagingModeApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.PaperHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.PaperSizeDefaultResolver`

```
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.PaperWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Parent.ExoItemParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Resolvers.PromptImageDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Readonly.CheckIfTrialReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Readonly.CheckIfTrialStandardReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Readonly.DeployToCloudVirtualDirectoryReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Readonly.ExoItemTypeReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Readonly.ExternalObjectIsStaticMethodReadonlyResolver`

```
GetDependencies() -> String[]
IsReadOnly(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Readonly.LanguageReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Readonly.TransactionLevelAssociatedTableReadOnlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RectangleBorderStyleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ReferencedFilesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RegExDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RegExValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RemoteUIConnectionStringResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RemoveUmpvValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ReorgGeneratedLanguageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ReorgUserInterfaceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ReportOutputDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ResolverBase`

```

```

### `Artech.Genexus.Common.Resolvers.ResolverFactoryBase`

```

```

### `Artech.Genexus.Common.Resolvers.ResolverHelper`

```
static GetModel(IPropertyBag obj) -> KBModel
static GetObject(IPropertyBag obj) -> KBObject
static GetAttControlParentValue(IPropertyBag properties,String propName,Object& value) -> Boolean
static GetAttControlTypedObject(IPropertyBag properties,String propName) -> ITypedObject
```

### `Artech.Genexus.Common.Resolvers.ResponsiveRuleContentDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ROW_COUNTDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptAttAlignmentDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptAttFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.RptAttHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptAttWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptBorderWidthValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptCOL_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.RptControlTypeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptImgHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptImgWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptLabelHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptLabelWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptLayoutFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptLineHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptLineWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptNameReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptROW_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.RptSystemImageDefaultResolver`

```
static GetImage(IPropertyBag properties) -> ImageWrapper
static GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.RptTxtFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.RubyModuleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SaveStateApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDAnalyticsProviderDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDBordersRadiusDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDDirectionsServiceRequestDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDDirectionsServiceRequestValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDEnableIntegratedSecurityDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDHasAssociatedUITestsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDIntegratedSecurityLevelDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.SDIntegratedSecurityLevelValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDLabelClassResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDLengthPropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDMultipleMarginDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDMultiplePaddingDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDNotificationRegistrationHandlerDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDNotificationRegistrationHandlerValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDPanelCaptionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SdtCollectionItemNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDTimePropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SdtItemObjectDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
static GetMember(ParserInfo info,String fieldSpecifier) -> Object
```

### `Artech.Genexus.Common.Resolvers.SDTransformAnchorValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDTransformAnglePropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDTransformValuePropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SDTransitionsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SearchEngineEnabledDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SecurityObjectReferenceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SecuritySDChangePasswordDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SecuritySDCompleteDataUserDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SecuritySDLoginDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SecuritySDNotAuthorizedDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SecurityWebLoginDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SecurityWebNotAuthorizedObjDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ServicesBasePathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ServicesFilesDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ServicesUrlDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ServletDirectoryDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ShortcutKeysDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ShortcutKeysValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ShowFullAjaxModeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ShowInDefaultFormsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ShowLogoutButtonApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ShowMasterPagePopUpDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SignificantAttributeNameLengthValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SignificantObjectNameLengthReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SignificantObjectNameLengthValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SignificantTableNameLengthValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.SingleImageIsExternalReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SingleImageNinePatchDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SingleImageNinePatchReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
static IsNinePatchFile(IPropertyBag properties) -> Boolean
static IsNinePatchFile(String fileName) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.SingleImageNinePatchVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.StandardClassesSpecificVersionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.StandardClassesSpecificVersionValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag properties,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.StandardFunctionsForEnvironmentDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.StandardFunctionsForObjectsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
static GetEnvironmentDefaultValue(KBModel model,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.StandardFunctionsForObjectsValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.StartupObjectValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.StaticContentDirectoryDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SuggestApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SuggestDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SuggestValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SynchronizeWithExternalDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.SystemClasspathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TableBackColorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TableModuleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TableObjectVisibilityDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TabularTableApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TextColorColumnDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TextShadowDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TextTransformJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
```

### `Artech.Genexus.Common.Resolvers.ThemeBaseCssLibraryPropertyDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeBaseCssLibraryPropertyVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.ThemeButtonBorderStyleDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeLinesFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeStyleNameReadOnlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeStyleParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
static GetExternalParentForResponsiveStyles(ThemeStyle style) -> ThemeStyle
```

### `Artech.Genexus.Common.Resolvers.ThemeTitleFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ThemeTypeConditionalDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDefaultValue(IPropertyBag properties,PropDefinition definition,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TimeInUtcBugVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TimePropertyValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TitleBackColorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TitleBackTextColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TitleBackWinColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TitleFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TitleForeColorDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TitleTextColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TitleWinColorColumnDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.TomcatPathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TomcatPathInitialResolver`

```
GetInitialValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.TomcatVersionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TomcatVersionInitialResolver`

```
GetInitialValue(IPropertyBag properties,Object& value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.TooltipDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TransformJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
```

### `Artech.Genexus.Common.Resolvers.TransformSplitJsonResolver`

```
WriteProperties(DesignStylesJsonWriter writer,Property property) -> Void
```

### `Artech.Genexus.Common.Resolvers.TransitionsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.TranslateToLanguageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.UncheckedValueDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.UndeleteRowImageDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.UpdateButtonBitmapDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.UrlAccessDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.UseReadReplicaValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.AllowEmptyButNotWhiteSpacesValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.AppEncryptionKeyValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Valid.AppleMinimumDeploymentTargetValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Valid.DeployToCloudValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.DesignSystemOptionsValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.DynamicServicesURLValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Valid.GeneratedLanguageValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.GenerateWindowsValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.LastModifiedDateTimeAttributeValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.LogicallyDeletedAttributeValidResolver`

```
IsValid(IPropertyBag properties,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.MainPlatformValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.NonEmptyDirectoryGPNValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.NonEmptyDirectoryValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.RequiredXcodeVersionValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Valid.StableSoftwareVersionValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Valid.TransformationNameValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Valid.VersionValidResolver`

```
GetDependencies() -> String[]
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Valid.WebFormDefaultsUIValidResolver`

```
Validate(Object instance,String propName,Object value) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Valid.WinPhoneValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ValidateFailMessageDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ValueRangeDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ValueRangeReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.ValueRangeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Values.MainPlatformValuesResolver`

```
GetNameFromValue(Object value) -> String
GetNonExclusiveValuesSupported() -> Boolean
GetValueFromName(String name) -> Object
GetValues(IPropertyBag properties) -> IEnumerable`1<ValuesItem>
```

### `Artech.Genexus.Common.Resolvers.Values.SDTransformAnchorValuesResolver`

```
GetValues(IPropertyBag properties) -> IEnumerable`1<ValuesItem>
GetValueFromName(String name) -> Object
GetNameFromValue(Object value) -> String
GetNonExclusiveValuesSupported() -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Values.SDUserTransitionsValuesResolver`

```
GetValues(IPropertyBag properties) -> IEnumerable`1<ValuesItem>
GetValueFromName(String name) -> Object
GetNameFromValue(Object value) -> String
GetNonExclusiveValuesSupported() -> Boolean
```

### `Artech.Genexus.Common.Resolvers.VarBasedOnDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.VersionCodeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.VersionCodeWithOptionalThirdDigitValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.VFPPathDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.AdoNetProviderVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.AllowNullVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.DeploymentTypeVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Visible.DeployToCloudVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.DesignSystemSelectedVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.DockerVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Visible.GenerateObservabilitySpanVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.GrpcProtocolVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.HasDbmsVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties,PropDefinition definition) -> Boolean
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Visible.HasOracleVisibleResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Visible.HasPostgreSQLVisibleResolver`

```

```

### `Artech.Genexus.Common.Resolvers.Visible.HasUITestsVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.IsImageDependantVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.IsolationLevelVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.JavaDeploymentVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Visible.KBCompatibilityIsolationLevelVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.LayoutEditorForWebVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.LogLevelVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.MultiTenantVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.ObservabilityVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.SessionTypeVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.SignInWithAppleVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Visible.SiteKeyVisibleResolver`

```
GetDependencies() -> String[]
IsVisible(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Resolvers.Visible.UseExternalStorageVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.UserLogLevelVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.ValidateFailMessageVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.VarServiceExtNameVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Visible.WindowsGeneratorVisibleResolver`

```
IsVisible(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WebAppNameDefaultResolver`

```
static GetWebAppName(KBModel model) -> String
```

### `Artech.Genexus.Common.Resolvers.WebCOL_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WebColHeightDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WebColorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WebColWidthDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WebControlTypeDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WebControlTypeValidResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WebFormDefaultsDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WebROW_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WebUserExperienceDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.Win8DisplayNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WinAttFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WinBtnFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WinCOL_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WinColumnControlTypeDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WinControlParentResolver`

```
GetParent(IPropertyBag properties,String propNameFor) -> Object
```

### `Artech.Genexus.Common.Resolvers.WinControlTypeDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WinFontDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.WinROW_COUNTDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WinTextFontDefaultResolver`

```

```

### `Artech.Genexus.Common.Resolvers.WndCaptionExpressionDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.XmlDateSerializationDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.XmlNullSerializationDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Resolvers.XmlTypeValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Run.RunBase+ServerProcessId`

```

```

### `Artech.Genexus.Common.Services.ColumnApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.ControlDefinition+ToGeneratorDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.ControlNameDefaultResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.ControlsContextResolver`

```
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.ControlsResolversFactory`

```
static CreateValuesResolvers() -> ValuesResolver
static GetDefaultFromParent(String parentPropertyName) -> IDefaultResolver
static GetDataSourceTypeBasedApplyResolver(String dataSourceType) -> IApplyResolver
```

### `Artech.Genexus.Common.Services.DataSourceTypeBasedApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.DesignTimeOnlyApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.EmptyParallelProcessingInfo`

```
GetObjectData(SerializationInfo info,StreamingContext context) -> Void
```

### `Artech.Genexus.Common.Services.FromParentResolver`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.GeneratorLifecycle`

```

```

### `Artech.Genexus.Common.Services.GenexusBLServices`

```

```

### `Artech.Genexus.Common.Services.GenexusBLServicesGuid`

```

```

### `Artech.Genexus.Common.Services.GenexusUIServices`

```

```

### `Artech.Genexus.Common.Services.GenexusUIServicesGuid`

```

```

### `Artech.Genexus.Common.Services.GxGeneratorAttribute`

```

```

### `Artech.Genexus.Common.Services.GxGeneratorRunAttribute`

```

```

### `Artech.Genexus.Common.Services.IBaseLibraryManagerService`

```
GetBaseLibraries(KBModel model) -> IEnumerable`1<BaseLibrary>
GetBaseLibrary(KBModel model,String name) -> BaseLibrary
```

### `Artech.Genexus.Common.Services.IBotGeneratorService`

```
GenerateAsync(KBModel model,KBObject obj,Boolean forceGeneration) -> Task`1<Boolean>
SynchronizeAsync(KBModel model,KBObject obj) -> Task`1<Boolean>
GenerateAndSynchronizeAsync(KBModel model,KBObject obj,Boolean forceGeneration) -> Task`1<Boolean>
Generate(KBModel model,KBObject obj,Boolean forceGeneration) -> Boolean
Synchronize(KBModel model,KBObject obj) -> Boolean
GenerateAndSynchronize(KBModel model,KBObject obj,Boolean forceGeneration) -> Boolean
GetDialogflowCredentials(String googleCloudProject,String serviceAccountCredentials,String botName) -> Object
GenerateConfig(KBObject obj) -> Void
```

### `Artech.Genexus.Common.Services.IBuildEventsService`

```

```

### `Artech.Genexus.Common.Services.IBuildService`

```
SetDevelopmentWorkingSet(DevelopmentWorkingSet set) -> Void
CreateDatabase() -> Void
ImpactAnalysis() -> Void
ImpactAnalysis(KBModel fromModel,KBModel toModel,ImpactType impactType) -> Void
AddImpactItem(ImpactAnalysisResult result,Boolean clear,Boolean isChild) -> Void
ViewLastImpact() -> Void
SDImpactAnalysis(List`1<EntityKey> keys) -> Void
RebuildArtifacts(Artifacts artifacts) -> Void
```

### `Artech.Genexus.Common.Services.IBuildServiceBL`

```
AskRequiredProperties(KBModel model) -> Boolean
Build(DevelopmentWorkingSet workingSet,EntityKey key,CancellationToken token) -> Void
Build(DevelopmentWorkingSet workingSet,IEnumerable`1<EntityKey> keys,CancellationToken token) -> Void
BuildAll(DevelopmentWorkingSet workingSet,CancellationToken token) -> Void
BuildWithTheseOnly(DevelopmentWorkingSet workingSet,IEnumerable`1<EntityKey> keys,CancellationToken token) -> Void
CreateDatabase(DevelopmentWorkingSet workingSet,CancellationToken token) -> Void
ImpactAnalysis(DevelopmentWorkingSet modelSet,ImpactType impactType,IEnumerable`1<EntityKey> keys,CancellationToken token) -> Void
Rebuild(DevelopmentWorkingSet workingSet,EntityKey key,CancellationToken token) -> Void
```

### `Artech.Genexus.Common.Services.ICloudServicesManagerService`

```
Initialize() -> Void
GetServicesByType(ServiceType type) -> IEnumerable`1<ServiceDefinition>
GetServiceByFriendlyName(ServiceType type,String friendlyName) -> ServiceDefinition
GetServiceByName(ServiceType type,String name) -> ServiceDefinition
AddServicesProperties(Int32 Generator,PropertiesDefinition baseProperties) -> Void
GetReferences(KBModel model) -> String
GetPackageReferences(KBModel model) -> String
GetFiles(KBModel model) -> String
```

### `Artech.Genexus.Common.Services.ICurlGeneratorService`

```
Generate(KBModel model,String procName,String procDescription,KBObject parent,String curlCommand) -> Void
```

### `Artech.Genexus.Common.Services.IDataTypesService`

```
GetTypes(KBModel model,Type objType) -> IEnumerable`1<ITypedObjectInfo>
GetTypeNames(KBModel model,Type objType,Boolean includeDomains) -> IEnumerable`1<String>
GetTypes(KBModel model,Type objType,Boolean includeDomains) -> IEnumerable`1<DataTypeCaps>
GetSortedTypes(KBModel model,Type objType,Boolean includeDomains) -> IEnumerable`1<DataTypeCaps>
```

### `Artech.Genexus.Common.Services.IDeploymentTargetService`

```
GetTargetTypes() -> List`1<DeploymentTarget>
GetTarget(String TargetId) -> DeploymentTarget
```

### `Artech.Genexus.Common.Services.IDeployService`

```
AddPartProvider(IDeployPartProvider deployPartProvider) -> Void
AddHostConfiguration(IHostConfiguration hostConfiguration) -> Void
SetCommandFactory(IDeployCommandFactory factory) -> Void
SetModel(KBModel model) -> Void
Deploy() -> Void
Deploy(GxModel from,GxModel to) -> Void
```

### `Artech.Genexus.Common.Services.IDockerExecutorService`

```
GetExecutor(GxGenerator environment) -> IDockerExecutor
UseDockerChanged(KBModel model,PropertyValueChangedArgs e) -> Void
```

### `Artech.Genexus.Common.Services.IExtensionLibraryManagerService`

```
GetLibraries() -> IEnumerable`1<ExtensionLibrary>
```

### `Artech.Genexus.Common.Services.IExternalGenerator`

```
GetCommands(BuildArgs args,ObjectListCalcCommand objectListCalcCommand) -> IEnumerable`1<ICancelableCommand>
```

### `Artech.Genexus.Common.Services.IExternalObjectInspectorService`

```
LoadFrom(String inspectorsDirectory) -> Void
```

### `Artech.Genexus.Common.Services.IGenerationServices`

```
StartSpecification(String filename) -> Void
EndSpecification() -> Void
GetSpecification(String name) -> Void
GetRemainingSpecs(String kbDirectory) -> Void
GetSpecs(String kbDirectory,String objectNames) -> Void
StartGeneration(String filename) -> Void
EndGeneration() -> Void
StartConsult(String filename) -> Void
```

### `Artech.Genexus.Common.Services.IGenerator`

```
InitializeGenerator(KnowledgeBase kb,String user) -> Void
Generate(KBModel designModel,KBModel workingModel) -> Boolean
StartDaemon() -> Boolean
Cancel() -> Void
FinalizeGenerator() -> Void
ClosingKB(KnowledgeBase kb) -> Void
```

### `Artech.Genexus.Common.Services.IGeneratorsService`

```
Generate(KBModel model,Int32 genId,Boolean isBuildWithTheseOnly) -> Boolean
GenerateGroup(KBModel model,Int32 objClass,Int32 objId,String objects,Boolean isBuildWithTheseOnly) -> Boolean
NotifyNGen(KBModel model,Int32 genId) -> Boolean
StartDaemon(KnowledgeBase kb,Int32 genId,String segmentName,String mutexBaseName,Int32 gxProcessId) -> Boolean
Cancel() -> Void
WaitFinalize() -> Void
GenerateResources(KBModel model) -> Boolean
GenerateResources(KBModel fromModel,KBModel workingModel) -> Boolean
```

### `Artech.Genexus.Common.Services.IGeneratorsService2`

```
RegisterGenerator(IExternalGenerator generator) -> Void
```

### `Artech.Genexus.Common.Services.IGxGenerator`

```
InitializeGenerator(KnowledgeBase kb,String user) -> Void
BeforeGenerate(KBModel model) -> Boolean
GenerateOne(KBModel model,String objectName) -> Boolean
AfterGenerate(KBModel model) -> Void
FinalizeGenerator() -> Void
Cancel() -> Void
```

### `Artech.Genexus.Common.Services.ILibraryService`

```
Install(KBEnvironment kbEnv,String libraryId,Boolean forceImport,IOutputTarget output) -> Void
Install(KBEnvironment kbEnv,String libraryId,Int32 generator,Int32 dbms,Boolean forceImport,IOutputTarget output) -> Void
Install(KBEnvironment kbEnv,String libraryId,Int32 generator,Int32 dbms,Boolean forceImport,IOutputTarget output,LibraryInstallationOptions options) -> Void
Install(KBEnvironment kbEnv,ILibraryInfo libraryInfo,Int32 generator,Int32 dbms,Boolean forceImport,IOutputTarget output,LibraryInstallationOptions options) -> Void
InstallExportFiles(KBEnvironment kbEnv,String libraryId,Boolean forceImport,IOutputTarget output) -> Void
InstallExportFiles(KBEnvironment kbEnv,ILibraryInfo libraryInfo,Boolean forceImport,IOutputTarget output) -> Void
Reorganize(KBModel targetModel,String libraryId,IOutputTarget output,String& version) -> Boolean
Reorganize(KBModel targetModel,String libraryId,IOutputTarget output,DeployConfig configuration,String& version) -> Boolean
```

### `Artech.Genexus.Common.Services.ILogTargetsService`

```
Initialize() -> Void
GetTargets(Int32 generator) -> IEnumerable`1<ServiceDefinition>
GetTargetByFriendlyName(Int32 generator,String friendlyName) -> ServiceDefinition
GetTargetByName(Int32 generator,String name) -> ServiceDefinition
AddServicesProperties(Int32 generator,PropertiesDefinition baseProperties) -> Void
GenerateLogConfig(KBModel model) -> Boolean
CopyResources(KBModel model) -> Void
```

### `Artech.Genexus.Common.Services.IModelInformationService`

```
NeedReorg(KBModel fromModel,KBModel toModel) -> Boolean
GetLastReorgTimestamp(KBModel model) -> DateTime
GetLastModifiedTableTimestamp(KBModel model) -> DateTime
GetLastModifiedObjectTimestamp(KBModel model) -> DateTime
ObjClass_from_GUID(Guid guid) -> Int32
ObjClass_to_GUID(Int32 objClass) -> Guid
GetObjectKey(Int32 objClass,Int32 objId) -> EntityKey
```

### `Artech.Genexus.Common.Services.INemoGeneratorService`

```
Generate(NemoGenerationData data) -> Boolean
Cancel() -> Void
```

### `Artech.Genexus.Common.Services.INemoSpecifierService`

```
Specify(BuildArgs buildArgs,ICollection`1<EntityKey> objsToSpecify,SpecificationListHelper specHelper) -> Boolean
```

### `Artech.Genexus.Common.Services.INormalizationService`

```
ClearAllCaches() -> Void
SaveTransaction(Transaction transaction) -> Void
SaveTransactionTableData(Transaction transaction) -> Void
SaveAttribute(Attribute attribute) -> Void
SaveGroup(Group group) -> Void
SaveTable(Table table) -> Void
SaveDataView(DataView dataview,Int32 oldAssocTableId) -> Void
StartingNormalization() -> Void
```

### `Artech.Genexus.Common.Services.IODataServiceDLGeneratorService`

```
Generate(KBModel model,KBVersion version) -> Boolean
Generate(KBModel model,KBVersion version,String outputFile) -> Boolean
```

### `Artech.Genexus.Common.Services.IParallelProcessingEvents`

```
InitializeBatch(KBModel model) -> Void
CleanupBatch(KBModel model) -> Void
```

### `Artech.Genexus.Common.Services.IParallelProcessingLocalInfo`

```
GetParallelProcessingEvents() -> IParallelProcessingEvents
```

### `Artech.Genexus.Common.Services.IParallelProcessingService`

```
StartBatch(ParallelProcessingInfo InitializationInfo,KBModel Model,Boolean AllowParallelProcessing,ReaderWriterLockPolicy LockPolicy) -> IParallelProcessingServiceClient
StartBatch(Func`2<ParallelProcessingInfo,IParallelProcessingLocalInfo> InitializationAction,ParallelProcessingInfo InitializationInfo,KBModel Model,Boolean AllowParallelProcessing,ReaderWriterLockPolicy LockPolicy) -> IParallelProcessingServiceClient
StartBatch(String SectionName,Func`2<ParallelProcessingInfo,IParallelProcessingLocalInfo> InitializationAction,ParallelProcessingInfo InitializationInfo,KBModel Model,Boolean AllowParallelProcessing,ReaderWriterLockPolicy LockPolicy) -> IParallelProcessingServiceClient
GetServer(Int32 ClientProcessId) -> IParallelProcessingServiceServer
```

### `Artech.Genexus.Common.Services.IParallelProcessingServiceClient`

```
EnqueueItem(Func`3<IParallelProcessingLocalInfo,ParallelProcessingInfo,ParallelProcessingInfo> action,ParallelProcessingInfo info) -> Int32
EndBatch(ICancelEventArgs cancelSignal,Boolean stopOnError) -> IList`1<KeyValuePair`2<Int32,KeyValuePair`2<Boolean,ParallelProcessingInfo>>>
```

### `Artech.Genexus.Common.Services.IParallelProcessingServiceServer`

```
Process(KBModel model,Int32 batchId,Byte[] msg,Boolean& ok) -> ParallelProcessingInfo
CleanupLocalInfo() -> Void
```

### `Artech.Genexus.Common.Services.IPrologService`

```
CreateInstance() -> IReftypeStructureWrapper
Assert(String line) -> Boolean
ConvertToPrologList(String[] items) -> String
ConvertToProlog(String text) -> String
ConvertToPrologString(String text) -> String
```

### `Artech.Genexus.Common.Services.IProtocolBufferServiceDLGeneratorService`

```
Generate(KBModel model,KBVersion version) -> Boolean
Generate(KBModel model,KBVersion version,String outputFile) -> Boolean
```

### `Artech.Genexus.Common.Services.IRestServiceDLGeneratorService`

```
Generate(KBModel model,KBVersion version,IEnumerable`1<String> objects,List`1<String> configFlags) -> Boolean
Generate(KBModel model,KBVersion version,IEnumerable`1<String> objects,List`1<String> configFlags,String ouptutFile) -> Boolean
```

### `Artech.Genexus.Common.Services.IRestServiceDLSpecifierService`

```
Specify(KBModel targetModel,IEnumerable`1<EntityKey> objsToSpecify) -> Boolean
```

### `Artech.Genexus.Common.Services.IRunService`

```
RegisterEnvironment(GeneratorType code,IRunBaseFactory runBase) -> Void
Reorganize(KBModel model,ReorganizeOptions options) -> Boolean
Reorganize(KBModel model,GxGenerator gen,ReorganizeOptions options) -> Boolean
InitializeData(KBModel model) -> Boolean
Compile(KBModel model,EntityKey objKey) -> Boolean
Compile(KBModel model,IEnumerable`1<CompileItemInfo> compileItems) -> Boolean
Compile(KBModel model,IEnumerable`1<CompileItemInfo> compileItems,GxGenerator useGen) -> Boolean
Compile(KBModel model,IEnumerable`1<CompileItemInfo> compileItems,GxGenerator useGen,Boolean rebuild) -> Boolean
```

### `Artech.Genexus.Common.Services.ISelectImageService`

```
SelectImage(KBModel model,LocalizableImageReference& image) -> Boolean
SelectImage(KBObject kbObject,LocalizableImageReference& image) -> Boolean
```

### `Artech.Genexus.Common.Services.ISpecifierService`

```
Initialize(KnowledgeBase kb) -> Boolean
SpecifyAll(KBModel model,BuildOptions options) -> Boolean
SpecifyObjects(KBModel model,IEnumerable`1<EntityKey> objects,BuildOptions options) -> Boolean
SpecifyObjects(KBModel modelInfo,KBModel model,IEnumerable`1<EntityKey> objects,BuildOptions options) -> Boolean
StartDaemon(KnowledgeBase kb,String segmentName,String mutexBaseName,Int32 gxProcessId) -> Boolean
SpecifyObjects(KBModel modelInfo,KBModel model,IEnumerable`1<EntityKey> objects,BuildOptions options,BuildOption option) -> Boolean
Cancel() -> Void
CreateDatabase(KBModel toModel) -> AnalysisResult
```

### `Artech.Genexus.Common.Services.ITableRelationsService`

```
GetRelations(Table table) -> ICollection`1<TableRelation>
GetSubordinated(Table table) -> ICollection`1<TableRelation>
GetSuperordinated(Table table) -> ICollection`1<TableRelation>
GetRelations(KBModel model,IEnumerable`1<Table> tables) -> IEnumerable`1<TableRelation>
GetRelations(KBModel model,IEnumerable`1<Table> tables,Int32 onlyThis) -> IEnumerable`1<TableRelation>
```

### `Artech.Genexus.Common.Services.ITablesService`

```
GetAssociatedTable(KBModel model,EntityKey trnKey,Int32 levelId) -> Table
GetBestAssociatedTransaction(KBModel model,EntityKey tblKey) -> Transaction
GetAssociatedTransactions(Table table) -> IEnumerable`1<Transaction>
GetTableWithKey(KBModel model,IList`1<EntityKey> primaryKeyAtts) -> Table
GetTablesWithKeyAttribute(KBModel model,EntityKey att) -> IList`1<Table>
GetRedundantAttributes(Table table) -> IList`1<EntityKey>
GetPossibleRedundantAttributes(Table table) -> IList`1<EntityKey>
GetUdmTableId(KBModel model,Int32 mappedtableId) -> Int32
```

### `Artech.Genexus.Common.Services.ITemplateControlRender`

```
GetTemplate(String name) -> Template
```

### `Artech.Genexus.Common.Services.ITransactionRelationsService`

```
GetRelations(KBModel model,IEnumerable`1<Transaction> transactions) -> IEnumerable`1<TransactionRelation>
GetRelations(KBModel model,IEnumerable`1<Transaction> transactions,Int32 onlyThis) -> IEnumerable`1<TransactionRelation>
GetRelations(KBModel model,EntityKey trnKey) -> IEnumerable`1<TransactionRelation>
GetLevelRelations(TransactionLevel trnLevel,RelationType type) -> IEnumerable`1<TransactionLevelRelation>
```

### `Artech.Genexus.Common.Services.ITransactionsService`

```
ExportStructures(KBModel model,List`1<EntityKey> objs,String file,ExportOptions options) -> Boolean
ExportStructures(KBModel model,IEnumerable`1<EntityKey> objs,String file,ExportOptions options) -> Boolean
```

### `Artech.Genexus.Common.Services.IUserControlSDContainerEditorRender`

```
SetContainer(Int32 index,Control control) -> Void
GetContainerName(Int32 index) -> String
LayoutContainers() -> Void
```

### `Artech.Genexus.Common.Services.IUserControlSDEditorRender`

```
SetProperties(PropertiesObject properties) -> Void
```

### `Artech.Genexus.Common.Services.IUserControlsManagerService`

```
PostInitialize() -> Void
GetControlDefinitionCollection(KBModel model) -> IEnumerable`1<ControlDefinition>
GetControlInfoDefinitionCollection(KBModel model) -> IEnumerable`1<ControlDefinition>
Initialize(KBModel model) -> Void
GetControlInfoById(KBModel model,Int32 id) -> ControlDefinition
GetDefinition(KBModel model,String name) -> ControlDefinition
GetDefinitionByDesc(KBModel model,String description) -> ControlDefinition
IsUserControlType(KBModel model,Int32 controlId) -> Boolean
```

### `Artech.Genexus.Common.Services.IUserControlsManagerServiceResources`

```
EnsureResources(ControlDefinition definition,KBObject object,PropertiesObject properties) -> Void
EnsureResources(ControlDefinition definition,KBObject object,VariablesPart variablesPart,Action onVariablesPartChanged,String& eventsSource,PropertiesObject properties) -> Void
EnsureResources(String definition,KBObject object,PropertiesObject properties) -> Void
EnsureResources(String definition,KBObject object,VariablesPart variablesPart,Action onVariablesPartChanged,String& eventsSource,PropertiesObject properties) -> Void
```

### `Artech.Genexus.Common.Services.IUserControlValidResolver`

```
IsValidUserControl(IPropertyBag properties) -> Boolean
```

### `Artech.Genexus.Common.Services.NoApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Services.ParallelProcessingInfo`

```
GetObjectData(SerializationInfo info,StreamingContext context) -> Void
Cleanup() -> Void
```

### `Artech.Genexus.Common.Services.ParallelProcessingInfoSimple`1`

```
GetObjectData(SerializationInfo info,StreamingContext context) -> Void
ToString() -> String
```

### `Artech.Genexus.Common.Services.ParallelProcessingLocalInfo`

```
Dispose() -> Void
GetParallelProcessingEvents() -> IParallelProcessingEvents
```

### `Artech.Genexus.Common.Services.ParallelProcessingLocalInfoWithCache`

```
GetParallelProcessingEvents() -> IParallelProcessingEvents
Dispose() -> Void
```

### `Artech.Genexus.Common.Services.ParallelProcessingSerializationContext`

```

```

### `Artech.Genexus.Common.Services.RunTimeOnlyApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Types.DataTypeHelper`

```
static GetTypeText(Module module,String name) -> String
static GetTypeText(QualifiedName name) -> String
static GetTypeText(String modulePath,String name) -> String
static GetTypeText(String categoryName,QualifiedName name) -> String
static GetTypeText(String categoryName,String modulePath,String name) -> String
static GetNameFromText(String text,String& modulePath,String& name) -> Void
static GetNameFromText(String text,String& categoryName,String& modulePath,String& name) -> Void
static GetNameFromText(String description) -> QualifiedName
```

### `Artech.Genexus.Common.Wiki.BlobKBObjectHelper`

```
static UpdateImageObject(WikiBlobPart part,String fileName) -> Boolean
static UpdateImageObject(WikiBlobPart part,String fileName,Boolean updateFileName) -> Boolean
static CreateImageObject(KBModel model,String fileName,String imageName) -> Image
static CreateFileObject(KBModel model,String fileName,String internalName) -> WikiFileKBObject
static CreateFileObject(KBModel model,String fileName,String internalName,String sourceFileName) -> WikiFileKBObject
static CreateFileObject(Module parent,String fileName,String internalName,String sourceFileName,String description) -> WikiFileKBObject
static UpdateFileContent(WikiFileKBObject fileObj,String fileName) -> WikiFileKBObject
static SaveWikiBlobPartFile(WikiBlobPart part,String fileName) -> Void
```

### `Artech.Genexus.Common.Wiki.ContentHelper`

```
GetUrl(Byte[] data,String fileName) -> String
GetUrl(Image image,String fileName) -> String
SaveImage(String name,Icon icon) -> String
GetFriendlyName(String name) -> String
GetData(KBModel model,String type,Int32 id,String& fileName) -> Byte[]
GetUrl(String content,String viewName) -> String
FileToUrl(String fileName) -> String
GetObjectFromLink(String ahref,String& objClass,String& objId) -> Boolean
```

### `Artech.Genexus.Common.Wiki.HtmlHelper`

```
static WikiLink(String name,String description) -> String
static WikiLink(String name) -> String
static ExternalLink(String href,String description) -> String
static ExternalLink(String href,String description,Boolean newWindow) -> String
static HtmlLink(String name,String description,String tooltip,String cssClass) -> String
static Image(String src) -> String
static Image(String name,Icon ico) -> String
static HtmlCommand(String command,String description,String[] args) -> String
```

### `Artech.Genexus.Common.Wiki.Resolvers.CopyConditionDependentApplyResolver`

```
IsApplicable(IPropertyBag propertyBag) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Wiki.Resolvers.CopyToValidResolver`

```
IsValid(IPropertyBag propertyBag,Object value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Wiki.Resolvers.WikiPageNameReadonlyResolver`

```
IsReadOnly(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Genexus.Common.Wiki.WikiPageProvider+PageSavedHandler`

```
Invoke(DocumentationPart doc) -> Void
BeginInvoke(DocumentationPart doc,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Packages.Genexus.Services.UserControls.UserControlATTPropsDefaultResolverWrapper`

```
GetDefaultValue(IPropertyBag properties,Object& value) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Packages.Genexus.Services.UserControls.UserControlGridApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Packages.Genexus.Services.UserControls.UserControlGridColumnApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

### `Artech.Packages.Genexus.Services.UserControls.UserControlInfoApplyResolver`

```
IsApplicable(IPropertyBag properties) -> Boolean
GetDependencies() -> String[]
```

## `Artech.LibraryDeployer`

### `Artech.LibraryDeployer.ConnectionHelper`

```
GetJdbcDriverDescriptor(String name) -> JdbcDriverDescriptor
BuildJdbcUrl(DeployConfig config) -> String
GetIntegratedSecurityAttrs(Boolean useIngratedSecurity) -> String
```

### `Artech.LibraryDeployer.ConnectionHelperFactory`

```
static GetHelper(Int32 dbmsCode) -> ConnectionHelper
```

### `Artech.LibraryDeployer.DamengConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.Db2UdbConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.ExecHelper`

```
ExecuteCommand(Dictionary`2<String,String> envVars,String baseDir,String fileName,DataReceivedEventHandler outputHandler,DataReceivedEventHandler errorHandler,String[] args) -> Boolean
```

### `Artech.LibraryDeployer.GeneralHelper`

```
static GetJDKInterpreterPath() -> String
```

### `Artech.LibraryDeployer.InformixConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.ISeriesConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.MySqlConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.OracleConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.PostgreSqlConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.SAPHanaConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

### `Artech.LibraryDeployer.SqlServerConnectionHelper`

```
BuildJdbcUrl(DeployConfig config) -> String
```

## `Artech.Template.Base`

### `Artech.TemplateEngine.DefaultTemplateEngineResolver`

```
DefaultCustomReferenceAssemblies() -> List`1<String>
DefaultCustomImportNamespaces() -> List`1<String>
AttributeResolve(String name) -> String
TemplateResolve(String name) -> String
```

### `Artech.TemplateEngine.ITemplateResolver`

```
DefaultCustomReferenceAssemblies() -> List`1<String>
DefaultCustomImportNamespaces() -> List`1<String>
AttributeResolve(String name) -> String
TemplateResolve(String name) -> String
```

## `Artech.Template.Helper`

### `Artech.Template.Helper.HelperFileInfo`

```
GetHelperDirectory() -> String
```

## `Artech.Template.Parser`

### `Artech.TemplateEngine.CodeDomTemplateHelper`

```
static AddImports(CodeNamespace nameSpace,String[] importList) -> Void
static InsertComment(CodeMemberMethod start,String comment) -> Void
static InsertComment(CodeStatementCollection statements,String comment) -> Void
static InvokeMethod(CodeMemberMethod start,CodeExpression target,String method,CodeExpression[] parameters) -> Void
static InvokeMethod(CodeStatementCollection statements,CodeExpression target,String method,CodeExpression[] parameters) -> Void
static InsertAssign(CodeMemberMethod start,CodeExpression left,CodeExpression right) -> Void
static InsertAssign(CodeStatementCollection statements,CodeExpression left,CodeExpression right) -> Void
static InsertField(CodeTypeDeclaration class1,String typeName,String name,MemberAttributes memberAttributes,CodeExpression initExpresion) -> Void
```

### `Artech.TemplateEngine.TemplateGenerator`

```
GenerateTemplateCode(String className,TemplateObject template,List`1<String> errors,List`1<String> refAssemblies,Boolean useMetadata,Boolean useTemplateHelper,List`1<String> referencedTemplates,List`1<String> referencedIncludesFiles,TemplateFileInfo templateInfoCache) -> CodeCompileUnit
CleanLast(String text) -> String
CleanFirst(String text) -> String
```

## `Artech.Udm.Architecture.Common`

### `Artech.Udm.Architecture.Common.IUdmCommandEngine`

```
DeleteModelEntityOutput(Int32 modelId,Int32 outputTypeId) -> Void
DeleteModelEntityOutputsBefore(Int32 modelId,Int32 fromOutputTypeId,Int32 toOutputTypeId,DateTime beforeTimestamp) -> Void
DeleteExternalReferences(Int32 modelId,Int32 fromEntityTypeId,Int32 fromEntityId) -> Void
DeleteExternalReferences(Int32 modelId,Int32 fromEntityTypeId,Int32 fromEntityId,IEnumerable`1<Int32> referenceTypes) -> Void
CopyModel(Int32 modelIdSource,Int32 modelIdTarget,CopyModelOptions options,DateTime timestamp,Int32 lowerWeakExternalReferenceType,IEnumerable`1<Int32> objectTypesIds) -> Void
UpdateCopyModelHistory(Int32 modelIdSource,Int32 modelIdTarget,String operationSource,DateTime historyTimestamp) -> Void
CopyModelOutput(Int32 modelIdSource,Int32 modelIdTarget,IEnumerable`1<Int32> outputTypeIds) -> Void
CopyEntities(Int32 modelIdSource,Int32 modelIdTarget,IEnumerable`1<UdmEntityKey> entities,DateTime timestamp) -> Boolean
```

## `Artech.Udm.Framework`

### `Artech.Udm.Framework.SavePreferences`

```

```

## `Artech.Wiki.Services`

### `Artech.Wiki.Services.GxWiki.DeletePage.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.DeletePage.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.DeletePageByName.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.DeletePageByName.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.GetByPartialName.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.GetByPartialName.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.GetCurrentVersion.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.GetCurrentVersion.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.GetInfo.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.GetInfo.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.GetPageById.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.GetPageById.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.GetPageByName.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.GetPageByName.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.GetPageId.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.GetPageId.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.InsertFile.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.InsertFile.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWiki.InsertPage.ExecuteCompletedEventArgs`

```

```

### `Artech.Wiki.Services.GxWiki.InsertPage.ExecuteCompletedEventHandler`

```
Invoke(Object sender,ExecuteCompletedEventArgs e) -> Void
BeginInvoke(Object sender,ExecuteCompletedEventArgs e,AsyncCallback callback,Object object) -> IAsyncResult
EndInvoke(IAsyncResult result) -> Void
```

### `Artech.Wiki.Services.GxWikiServices`

```
GetInfo(GxWikiServer server,WikiInfo& info) -> ErrorCode
DeletePageByName(GxWikiServer server,String name,IStatus[]& status) -> Boolean
DeletePage(GxWikiServer server,Int32 id,IStatus[]& status) -> Boolean
GetPageId(GxWikiServer server,String name,IStatus[]& status) -> Int32
GetCurrentVersion(GxWikiServer server,Int32 id,DateTime& timestamp,String& user,IStatus[]& status) -> Int32
InsertFile(GxWikiServer server,GxWikiPage page,IStatus[]& status) -> Int32
InsertPage(GxWikiServer server,GxWikiPage page,IStatus[]& status) -> Int32
GetPageById(GxWikiServer server,Int32 id,IStatus[]& status) -> GxWikiPage
```

## `GeneXus.Design.Grammars`

### `GeneXus.Design.Grammars.DesignStyles.DesignStylesModifier+UpdaterFocus`

```

```

### `GeneXus.Design.Grammars.DesignStyles.DesignStylesModifier+UpdaterModes`

```

```

### `Genexus.Design.Grammars.DesignStylesGrammarHelper`

```
static TryGetClassName(String selectorName,String& className,Boolean& fullMatch) -> Boolean
static TryGetClassName(String selectorName,String& className) -> Boolean
```

## `GeneXus.Grammar.ServiceGroupSource`

### `GeneXus.Grammar.ServiceGroupSource.IServiceGroupSourcePartListener`

```
ExitAnycomment(AnycommentContext context) -> Void
EnterServiceInterface(ServiceInterfaceContext context) -> Void
ExitServiceInterface(ServiceInterfaceContext context) -> Void
EnterServicemapping(ServicemappingContext context) -> Void
ExitServicemapping(ServicemappingContext context) -> Void
EnterServiceDefinition(ServiceDefinitionContext context) -> Void
ExitServiceDefinition(ServiceDefinitionContext context) -> Void
EnterServiceattributelist(ServiceattributelistContext context) -> Void
```

### `GeneXus.Grammar.ServiceGroupSource.IServiceGroupSourcePartVisitor`1`

```
VisitServiceInterface(ServiceInterfaceContext context) -> Result
VisitServicemapping(ServicemappingContext context) -> Result
VisitServiceDefinition(ServiceDefinitionContext context) -> Result
VisitServiceattributelist(ServiceattributelistContext context) -> Result
VisitServiceattribute(ServiceattributeContext context) -> Result
VisitAttri_desc(Attri_descContext context) -> Result
VisitAttri_rest(Attri_restContext context) -> Result
VisitAttri_path(Attri_pathContext context) -> Result
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupPartListenerEntryPoints`

```
EnterExternal_service(External_serviceContext context) -> Void
ExitExternal_service(External_serviceContext context) -> Void
EnterServiceattribute(ServiceattributeContext context) -> Void
ExitServiceattribute(ServiceattributeContext context) -> Void
EnterAttriparameter(AttriparameterContext context) -> Void
EnterAttripathparameter(AttripathparameterContext context) -> Void
EnterAttrisecuritymodename(AttrisecuritymodenameContext context) -> Void
EnterAttrisecurityname(AttrisecuritynameContext context) -> Void
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupPartListenerTokenizer`

```
EnterServiceName(ServiceNameContext context) -> Void
ExitServiceGroup(ServiceGroupContext context) -> Void
EnterExternal_service(External_serviceContext context) -> Void
EnterServiceattribute(ServiceattributeContext context) -> Void
ExitServiceDefinition(ServiceDefinitionContext context) -> Void
EnterImplementation_name(Implementation_nameContext context) -> Void
EnterImplementation_reference(Implementation_referenceContext context) -> Void
ExitServiceList(ServiceListContext context) -> Void
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartBaseListener`

```
EnterServiceInterface(ServiceInterfaceContext context) -> Void
ExitServiceInterface(ServiceInterfaceContext context) -> Void
EnterServicemapping(ServicemappingContext context) -> Void
ExitServicemapping(ServicemappingContext context) -> Void
EnterServiceDefinition(ServiceDefinitionContext context) -> Void
ExitServiceDefinition(ServiceDefinitionContext context) -> Void
EnterServiceattributelist(ServiceattributelistContext context) -> Void
ExitServiceattributelist(ServiceattributelistContext context) -> Void
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartBaseVisitor`1`

```
VisitServiceInterface(ServiceInterfaceContext context) -> Result
VisitServicemapping(ServicemappingContext context) -> Result
VisitServiceDefinition(ServiceDefinitionContext context) -> Result
VisitServiceattributelist(ServiceattributelistContext context) -> Result
VisitServiceattribute(ServiceattributeContext context) -> Result
VisitAttri_desc(Attri_descContext context) -> Result
VisitAttri_rest(Attri_restContext context) -> Result
VisitAttri_path(Attri_pathContext context) -> Result
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartBaseVisitorAlt`1`

```
VisitImplementation(ImplementationContext context) -> Result
VisitVarparameter(VarparameterContext context) -> Result
VisitImplementation_name(Implementation_nameContext context) -> Result
VisitService_placeholder(Service_placeholderContext context) -> Result
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartLexer`

```

```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartListenerCommon`

```
EnterAttri_rest(Attri_restContext context) -> Void
ExitAttri_rest(Attri_restContext context) -> Void
EnterAttri_path(Attri_pathContext context) -> Void
ExitAttri_path(Attri_pathContext context) -> Void
EnterAttri_security(Attri_securityContext context) -> Void
EnterAttri_desc(Attri_descContext context) -> Void
EnterAttridescriptionpar(AttridescriptionparContext context) -> Void
EnterAttripars(AttriparsContext context) -> Void
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser`

```
serviceInterface() -> ServiceInterfaceContext
servicemapping() -> ServicemappingContext
serviceDefinition() -> ServiceDefinitionContext
serviceattributelist() -> ServiceattributelistContext
serviceattribute() -> ServiceattributeContext
attri_desc() -> Attri_descContext
attri_rest() -> Attri_restContext
attri_path() -> Attri_pathContext
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+External_serviceContext`

```
service_entry_name() -> Service_entry_nameContext
service_parameters() -> Service_parametersContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+Service_entry_nameContext`

```
Ident() -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+Service_parametersContext`

```
OPEN_PAR() -> ITerminalNode
CLOSE_PAR() -> ITerminalNode
parameter() -> ParameterContext[]
parameter(Int32 i) -> ParameterContext
COMMA() -> ITerminalNode[]
COMMA(Int32 i) -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+Service_placeholderContext`

```
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceattributeContext`

```
attri_rest() -> Attri_restContext
attri_path() -> Attri_pathContext
attri_security() -> Attri_securityContext
attri_desc() -> Attri_descContext
attri_securitymode() -> Attri_securitymodeContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceattributelistContext`

```
serviceattribute() -> ServiceattributeContext[]
serviceattribute(Int32 i) -> ServiceattributeContext
COMMA() -> ITerminalNode[]
COMMA(Int32 i) -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceDefinitionContext`

```
servicemapping() -> ServicemappingContext
serviceattributelist() -> ServiceattributelistContext[]
serviceattributelist(Int32 i) -> ServiceattributelistContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceGroupContext`

```
serviceName() -> ServiceNameContext
OPEN_BRACE() -> ITerminalNode
serviceList() -> ServiceListContext
CLOSE_BRACE() -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceInterfaceContext`

```
external_service() -> External_serviceContext
serviceattributelist() -> ServiceattributelistContext[]
serviceattributelist(Int32 i) -> ServiceattributelistContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceListContext`

```
serviceDefinition() -> ServiceDefinitionContext[]
serviceDefinition(Int32 i) -> ServiceDefinitionContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceListInterfaceContext`

```
serviceInterface() -> ServiceInterfaceContext[]
serviceInterface(Int32 i) -> ServiceInterfaceContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServicemappingContext`

```
ARROW() -> ITerminalNode
implementation() -> ImplementationContext
service_placeholder() -> Service_placeholderContext
external_service() -> External_serviceContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupSourcePartParser+ServiceNameContext`

```
Ident() -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.ServiceGroupSource.ServiceGroupToken`

```

```

### `GeneXus.Grammar.ServiceGroupSource.ServiceParameter`

```

```

### `GeneXus.Grammar.SuperAppSource.ServiceParameter`

```

```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+External_serviceContext`

```
service_entry_name() -> Service_entry_nameContext
service_parameters() -> Service_parametersContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+Service_entry_nameContext`

```
Ident() -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+Service_parametersContext`

```
OPEN_PAR() -> ITerminalNode
CLOSE_PAR() -> ITerminalNode
parameter() -> ParameterContext[]
parameter(Int32 i) -> ParameterContext
COMMA() -> ITerminalNode[]
COMMA(Int32 i) -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServiceDefinitionContext`

```
servicemapping() -> ServicemappingContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServiceGroupContext`

```
serviceName() -> ServiceNameContext
OPEN_BRACE() -> ITerminalNode
serviceList() -> ServiceListContext
CLOSE_BRACE() -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServiceInterfaceContext`

```
external_service() -> External_serviceContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServiceListContext`

```
serviceDefinition() -> ServiceDefinitionContext[]
serviceDefinition(Int32 i) -> ServiceDefinitionContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServiceListInterfaceContext`

```
serviceInterface() -> ServiceInterfaceContext[]
serviceInterface(Int32 i) -> ServiceInterfaceContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServicemappingContext`

```
ARROW() -> ITerminalNode
implementation() -> ImplementationContext
superapp_placeholder() -> Superapp_placeholderContext
external_service() -> External_serviceContext
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.SuperAppSource.SuperAppSourcePartParser+ServiceNameContext`

```
Ident() -> ITerminalNode
EnterRule(IParseTreeListener listener) -> Void
ExitRule(IParseTreeListener listener) -> Void
Accept(IParseTreeVisitor`1<TResult> visitor) -> TResult
```

### `GeneXus.Grammar.UserControlSource.UserControlParser+Mustache_projectionContext`

```
LL() -> ITerminalNode
Eq() -> ITerminalNode[]
Eq(Int32 i) -> ITerminalNode
Lt() -> ITerminalNode
Pct() -> ITerminalNode[]
Pct(Int32 i) -> ITerminalNode
Ws_Signficant() -> ITerminalNode
Gtp() -> ITerminalNode
```

