[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("Microsoft.Build.Tasks.Core.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("15.1.548.43366")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("15.1.548+g66a9887feb")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® Build Tools®")]
[assembly:System.Reflection.AssemblyTitleAttribute("Microsoft.Build.Tasks.Core.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.Build.Tasks.UnitTests, PublicKey=002400000480000094000000060200000024000052534131000400000100010015c01ae1f50e8cc09ba9eac9147cf8fd9fce2cfe9f8dce4f7301c4132ca9fb50ce8cbf1df4dc18dd4d210e4345c744ecb3365ed327efdbc52603faa5e21daa11234c8c4a73e51f03bf192544581ebe107adee3a34928e39d04e524a9ce729d5090bfd7dad9d10c722c0def9ccc08ff0a03790e48bcd1f9b6c476063e1966a1c4")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.Build.Tasks.Whidbey.Unittest, PublicKey=002400000480000094000000060200000024000052534131000400000100010015c01ae1f50e8cc09ba9eac9147cf8fd9fce2cfe9f8dce4f7301c4132ca9fb50ce8cbf1df4dc18dd4d210e4345c744ecb3365ed327efdbc52603faa5e21daa11234c8c4a73e51f03bf192544581ebe107adee3a34928e39d04e524a9ce729d5090bfd7dad9d10c722c0def9ccc08ff0a03790e48bcd1f9b6c476063e1966a1c4")]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute((System.Runtime.InteropServices.DllImportSearchPath)(4096))]
[assembly:System.Runtime.InteropServices.GuidAttribute("E3D4D3B9-944C-407b-A82E-B19719EA7FB3")]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3", FrameworkDisplayName="")]
namespace Microsoft.Build.Tasks
{
    public partial class AssignCulture : Microsoft.Build.Tasks.TaskExtension
    {
        public AssignCulture() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] AssignedFiles { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] AssignedFilesWithCulture { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] AssignedFilesWithNoCulture { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] CultureNeutralAssignedFiles { get { throw null; } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Files { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class AssignLinkMetadata : Microsoft.Build.Tasks.TaskExtension
    {
        public AssignLinkMetadata() { }
        public Microsoft.Build.Framework.ITaskItem[] Items { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] OutputItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
    public partial class AssignProjectConfiguration : Microsoft.Build.Tasks.ResolveProjectBase
    {
        public AssignProjectConfiguration() { }
        public bool AddSyntheticProjectReferencesForSolutionDependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] AssignedProjects { get { throw null; } set { } }
        public string CurrentProject { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string CurrentProjectConfiguration { get { throw null; } set { } }
        public string CurrentProjectPlatform { get { throw null; } set { } }
        public string DefaultToVcxPlatformMapping { get { throw null; } set { } }
        public bool OnlyReferenceAndBuildProjectsEnabledInSolutionConfiguration { get { throw null; } set { } }
        public string OutputType { get { throw null; } set { } }
        public bool ResolveConfigurationPlatformUsingMappings { get { throw null; } set { } }
        public bool ShouldUnsetParentConfigurationAndPlatform { get { throw null; } set { } }
        public string SolutionConfigurationContents { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] UnassignedProjects { get { throw null; } set { } }
        public string VcxToDefaultPlatformMapping { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class AssignTargetPath : Microsoft.Build.Tasks.TaskExtension
    {
        public AssignTargetPath() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] AssignedFiles { get { throw null; } }
        public Microsoft.Build.Framework.ITaskItem[] Files { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string RootFolder { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    [Microsoft.Build.Framework.RunInMTAAttribute]
    public partial class CallTarget : Microsoft.Build.Tasks.TaskExtension
    {
        public CallTarget() { }
        public bool RunEachTargetSeparately { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] TargetOutputs { get { throw null; } }
        public string[] Targets { get { throw null; } set { } }
        public bool UseResultsCache { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class CombinePath : Microsoft.Build.Tasks.TaskExtension
    {
        public CombinePath() { }
        public string BasePath { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] CombinedPaths { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Paths { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class CommandLineBuilderExtension : Microsoft.Build.Utilities.CommandLineBuilder
    {
        public CommandLineBuilderExtension() { }
        protected string GetQuotedText(string unquotedText) { throw null; }
    }
    public partial class ConvertToAbsolutePath : Microsoft.Build.Tasks.TaskExtension
    {
        public ConvertToAbsolutePath() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] AbsolutePaths { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Paths { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class Copy : Microsoft.Build.Tasks.TaskExtension, Microsoft.Build.Framework.ICancelableTask, Microsoft.Build.Framework.ITask
    {
        public Copy() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] CopiedFiles { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] DestinationFiles { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem DestinationFolder { get { throw null; } set { } }
        public bool OverwriteReadOnlyFiles { get { throw null; } set { } }
        public int Retries { get { throw null; } set { } }
        public int RetryDelayMilliseconds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool SkipUnchangedFiles { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] SourceFiles { get { throw null; } set { } }
        public bool UseHardlinksIfPossible { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool UseSymboliclinksIfPossible { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public void Cancel() { }
        public override bool Execute() { throw null; }
    }
    public partial class CreateCSharpManifestResourceName : Microsoft.Build.Tasks.CreateManifestResourceName
    {
        public CreateCSharpManifestResourceName() { }
        protected override string CreateManifestName(string fileName, string linkFileName, string rootNamespace, string dependentUponFileName, System.IO.Stream binaryStream) { throw null; }
        protected override bool IsSourceFile(string fileName) { throw null; }
    }
    public partial class CreateItem : Microsoft.Build.Tasks.TaskExtension
    {
        public CreateItem() { }
        public string[] AdditionalMetadata { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] Exclude { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Include { get { throw null; } set { } }
        public bool PreserveExistingMetadata { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public abstract partial class CreateManifestResourceName : Microsoft.Build.Tasks.TaskExtension
    {
        protected System.Collections.Generic.Dictionary<string, Microsoft.Build.Framework.ITaskItem> itemSpecToTaskitem;
        protected CreateManifestResourceName() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ManifestResourceNames { get { throw null; } }
        public bool PrependCultureAsDirectory { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ResourceFiles { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ResourceFilesWithManifestResourceNames { get { throw null; } set { } }
        public string RootNamespace { get { throw null; } set { } }
        protected abstract string CreateManifestName(string fileName, string linkFileName, string rootNamespaceName, string dependentUponFileName, System.IO.Stream binaryStream);
        public override bool Execute() { throw null; }
        protected abstract bool IsSourceFile(string fileName);
        public static string MakeValidEverettIdentifier(string name) { throw null; }
    }
    public partial class CreateProperty : Microsoft.Build.Tasks.TaskExtension
    {
        public CreateProperty() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public string[] Value { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string[] ValueSetByTask { get { throw null; } }
        public override bool Execute() { throw null; }
    }
    public partial class CreateVisualBasicManifestResourceName : Microsoft.Build.Tasks.CreateManifestResourceName
    {
        public CreateVisualBasicManifestResourceName() { }
        protected override string CreateManifestName(string fileName, string linkFileName, string rootNamespace, string dependentUponFileName, System.IO.Stream binaryStream) { throw null; }
        protected override bool IsSourceFile(string fileName) { throw null; }
    }
    public partial class Delete : Microsoft.Build.Tasks.TaskExtension, Microsoft.Build.Framework.ICancelableTask, Microsoft.Build.Framework.ITask
    {
        public Delete() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] DeletedFiles { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Files { get { throw null; } set { } }
        public bool TreatErrorsAsWarnings { get { throw null; } set { } }
        public void Cancel() { }
        public override bool Execute() { throw null; }
    }
    public sealed partial class Error : Microsoft.Build.Tasks.TaskExtension
    {
        public Error() { }
        public string Code { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string HelpKeyword { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public sealed partial class ErrorFromResources : Microsoft.Build.Tasks.TaskExtension
    {
        public ErrorFromResources() { }
        public string[] Arguments { get { throw null; } set { } }
        public string Code { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string HelpKeyword { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string Resource { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class Exec : Microsoft.Build.Tasks.ToolTaskExtension
    {
        public Exec() { }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string Command { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ConsoleOutput { get { throw null; } }
        public bool ConsoleToMSBuild { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string CustomErrorRegularExpression { get { throw null; } set { } }
        public string CustomWarningRegularExpression { get { throw null; } set { } }
        public bool IgnoreExitCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IgnoreStandardErrorWarningFormat { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Outputs { get { throw null; } set { } }
        protected override System.Text.Encoding StandardErrorEncoding { get { throw null; } }
        protected override Microsoft.Build.Framework.MessageImportance StandardErrorLoggingImportance { get { throw null; } }
        protected override System.Text.Encoding StandardOutputEncoding { get { throw null; } }
        protected override Microsoft.Build.Framework.MessageImportance StandardOutputLoggingImportance { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string StdErrEncoding { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string StdOutEncoding { get { throw null; } set { } }
        protected override string ToolName { get { throw null; } }
        public string UseUtf8Encoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string WorkingDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        protected internal override void AddCommandLineCommands(Microsoft.Build.Tasks.CommandLineBuilderExtension commandLine) { }
        protected override int ExecuteTool(string pathToTool, string responseFileCommands, string commandLineCommands) { throw null; }
        protected override string GenerateFullPathToTool() { throw null; }
        protected override string GetWorkingDirectory() { throw null; }
        protected override bool HandleTaskExecutionErrors() { throw null; }
        protected override void LogEventsFromTextOutput(string singleLine, Microsoft.Build.Framework.MessageImportance messageImportance) { }
        protected override void LogPathToTool(string toolName, string pathToTool) { }
        protected override void LogToolCommand(string message) { }
        protected override bool ValidateParameters() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ExtractedClassName
    {
        public bool IsInsideConditionalBlock { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class FindAppConfigFile : Microsoft.Build.Tasks.TaskExtension
    {
        public FindAppConfigFile() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem AppConfigFile { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] PrimaryList { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] SecondaryList { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string TargetPath { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class FindInList : Microsoft.Build.Tasks.TaskExtension
    {
        public FindInList() { }
        public bool CaseSensitive { get { throw null; } set { } }
        public bool FindLastMatch { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem ItemFound { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string ItemSpecToFind { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] List { get { throw null; } set { } }
        public bool MatchFileNameOnly { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class FindUnderPath : Microsoft.Build.Tasks.TaskExtension
    {
        public FindUnderPath() { }
        public Microsoft.Build.Framework.ITaskItem[] Files { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] InPath { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] OutOfPath { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem Path { get { throw null; } set { } }
        public bool UpdateToAbsolutePaths { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public sealed partial class FormatVersion : Microsoft.Build.Tasks.TaskExtension
    {
        public FormatVersion() { }
        public string FormatType { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string OutputVersion { get { throw null; } set { } }
        public int Revision { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class GenerateBindingRedirects : Microsoft.Build.Tasks.TaskExtension
    {
        public GenerateBindingRedirects() { }
        public Microsoft.Build.Framework.ITaskItem AppConfigFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem OutputAppConfigFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.Build.Framework.ITaskItem[] SuggestedRedirects { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string TargetName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
    [Microsoft.Build.Framework.RequiredRuntimeAttribute("v2.0")]
    public sealed partial class GenerateResource : Microsoft.Build.Tasks.TaskExtension
    {
        public GenerateResource() { }
        public Microsoft.Build.Framework.ITaskItem[] AdditionalInputs { get { throw null; } set { } }
        public string[] EnvironmentVariables { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.Build.Framework.ITaskItem[] ExcludedInputPaths { get { throw null; } set { } }
        public bool ExecuteAsTool { get { throw null; } set { } }
        public bool ExtractResWFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] FilesWritten { get { throw null; } }
        public bool MinimalRebuildFromTracking { get { throw null; } set { } }
        public bool NeverLockTypeAssemblies { get { throw null; } set { } }
        public string OutputDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] OutputResources { get { throw null; } set { } }
        public bool PublicClass { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] References { get { throw null; } set { } }
        public string SdkToolsPath { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Sources { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem StateFile { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string StronglyTypedClassName { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string StronglyTypedFileName { get { throw null; } set { } }
        public string StronglyTypedLanguage { get { throw null; } set { } }
        public string StronglyTypedManifestPrefix { get { throw null; } set { } }
        public string StronglyTypedNamespace { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] TLogReadFiles { get { throw null; } }
        public Microsoft.Build.Framework.ITaskItem[] TLogWriteFiles { get { throw null; } }
        public string ToolArchitecture { get { throw null; } set { } }
        public string TrackerFrameworkPath { get { throw null; } set { } }
        public string TrackerLogDirectory { get { throw null; } set { } }
        public string TrackerSdkPath { get { throw null; } set { } }
        public bool TrackFileAccess { get { throw null; } set { } }
        public bool UseSourcePath { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class GetFrameworkPath : Microsoft.Build.Tasks.TaskExtension
    {
        public GetFrameworkPath() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion11Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion20Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion30Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion35Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion40Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion451Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion452Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion45Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion461Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion462Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string FrameworkVersion46Path { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string Path { get { throw null; } }
        public override bool Execute() { throw null; }
    }
    public partial class GetReferenceAssemblyPaths : Microsoft.Build.Tasks.TaskExtension
    {
        public GetReferenceAssemblyPaths() { }
        public bool BypassFrameworkInstallChecks { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string[] FullFrameworkReferenceAssemblyPaths { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string[] ReferenceAssemblyPaths { get { throw null; } }
        public string RootPath { get { throw null; } set { } }
        public string TargetFrameworkMoniker { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string TargetFrameworkMonikerDisplayName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
    public partial class Hash : Microsoft.Build.Tasks.TaskExtension
    {
        public Hash() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public string HashResult { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ItemsToHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
    public partial class MakeDir : Microsoft.Build.Tasks.TaskExtension
    {
        public MakeDir() { }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Directories { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] DirectoriesCreated { get { throw null; } }
        public override bool Execute() { throw null; }
    }
    public sealed partial class Message : Microsoft.Build.Tasks.TaskExtension
    {
        public Message() { }
        public string Code { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string HelpKeyword { get { throw null; } set { } }
        public string Importance { get { throw null; } set { } }
        public bool IsCritical { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class Move : Microsoft.Build.Tasks.TaskExtension, Microsoft.Build.Framework.ICancelableTask, Microsoft.Build.Framework.ITask
    {
        public Move() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] DestinationFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.Build.Framework.ITaskItem DestinationFolder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] MovedFiles { get { throw null; } }
        public bool OverwriteReadOnlyFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] SourceFiles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public void Cancel() { }
        public override bool Execute() { throw null; }
    }
    [Microsoft.Build.Framework.RunInMTAAttribute]
    public partial class MSBuild : Microsoft.Build.Tasks.TaskExtension
    {
        public MSBuild() { }
        public bool BuildInParallel { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Projects { get { throw null; } set { } }
        public string[] Properties { get { throw null; } set { } }
        public bool RebaseOutputs { get { throw null; } set { } }
        public string RemoveProperties { get { throw null; } set { } }
        public bool RunEachTargetSeparately { get { throw null; } set { } }
        public string SkipNonexistentProjects { get { throw null; } set { } }
        public bool StopOnFirstFailure { get { throw null; } set { } }
        public string[] TargetAndPropertyListSeparators { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] TargetOutputs { get { throw null; } }
        public string[] Targets { get { throw null; } set { } }
        public string ToolsVersion { get { throw null; } set { } }
        public bool UnloadProjectsOnCompletion { get { throw null; } set { } }
        public bool UseResultsCache { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class ReadLinesFromFile : Microsoft.Build.Tasks.TaskExtension
    {
        public ReadLinesFromFile() { }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem File { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Lines { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class RemoveDir : Microsoft.Build.Tasks.TaskExtension
    {
        public RemoveDir() { }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Directories { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] RemovedDirectories { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class RemoveDuplicates : Microsoft.Build.Tasks.TaskExtension
    {
        public RemoveDuplicates() { }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Filtered { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] Inputs { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class ResolveAssemblyReference : Microsoft.Build.Tasks.TaskExtension
    {
        public ResolveAssemblyReference() { }
        public string[] AllowedAssemblyExtensions { get { throw null; } set { } }
        public string[] AllowedRelatedFileExtensions { get { throw null; } set { } }
        public string AppConfigFile { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] Assemblies { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] AssemblyFiles { get { throw null; } set { } }
        public bool AutoUnify { get { throw null; } set { } }
        public string[] CandidateAssemblyFiles { get { throw null; } set { } }
        public bool CopyLocalDependenciesWhenParentReferenceInGac { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] CopyLocalFiles { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string DependsOnSystemRuntime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool DoNotCopyLocalIfInGac { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] FilesWritten { get { throw null; } set { } }
        public bool FindDependencies { get { throw null; } set { } }
        public bool FindRelatedFiles { get { throw null; } set { } }
        public bool FindSatellites { get { throw null; } set { } }
        public bool FindSerializationAssemblies { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] FullFrameworkAssemblyTables { get { throw null; } set { } }
        public string[] FullFrameworkFolders { get { throw null; } set { } }
        public string[] FullTargetFrameworkSubsetNames { get { throw null; } set { } }
        public bool IgnoreDefaultInstalledAssemblySubsetTables { get { throw null; } set { } }
        public bool IgnoreDefaultInstalledAssemblyTables { get { throw null; } set { } }
        public bool IgnoreTargetFrameworkAttributeVersionMismatch { get { throw null; } set { } }
        public bool IgnoreVersionForFrameworkReferences { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] InstalledAssemblySubsetTables { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] InstalledAssemblyTables { get { throw null; } set { } }
        public string[] LatestTargetFrameworkDirectories { get { throw null; } set { } }
        public string ProfileName { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] RelatedFiles { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ResolvedDependencyFiles { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ResolvedFiles { get { throw null; } }
        public Microsoft.Build.Framework.ITaskItem[] ResolvedSDKReferences { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] SatelliteFiles { get { throw null; } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ScatterFiles { get { throw null; } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string[] SearchPaths { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] SerializationAssemblyFiles { get { throw null; } }
        public bool Silent { get { throw null; } set { } }
        public string StateFile { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] SuggestedRedirects { get { throw null; } }
        public bool SupportsBindingRedirectGeneration { get { throw null; } set { } }
        public string TargetedRuntimeVersion { get { throw null; } set { } }
        public string[] TargetFrameworkDirectories { get { throw null; } set { } }
        public string TargetFrameworkMoniker { get { throw null; } set { } }
        public string TargetFrameworkMonikerDisplayName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string[] TargetFrameworkSubsets { get { throw null; } set { } }
        public string TargetFrameworkVersion { get { throw null; } set { } }
        public string TargetProcessorArchitecture { get { throw null; } set { } }
        public bool UnresolveFrameworkAssembliesFromHigherFrameworks { get { throw null; } set { } }
        public string WarnOrErrorOnTargetArchitectureMismatch { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public sealed partial class ResolveCodeAnalysisRuleSet : Microsoft.Build.Tasks.TaskExtension
    {
        public ResolveCodeAnalysisRuleSet() { }
        public string CodeAnalysisRuleSet { get { throw null; } set { } }
        public string[] CodeAnalysisRuleSetDirectories { get { throw null; } set { } }
        public string MSBuildProjectDirectory { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string ResolvedCodeAnalysisRuleSet { get { throw null; } }
        public override bool Execute() { throw null; }
    }
    public partial class ResolveKeySource : Microsoft.Build.Tasks.TaskExtension
    {
        public ResolveKeySource() { }
        public int AutoClosePasswordPromptShow { get { throw null; } set { } }
        public int AutoClosePasswordPromptTimeout { get { throw null; } set { } }
        public string CertificateFile { get { throw null; } set { } }
        public string CertificateThumbprint { get { throw null; } set { } }
        public string KeyFile { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string ResolvedKeyContainer { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string ResolvedKeyFile { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public string ResolvedThumbprint { get { throw null; } set { } }
        public bool ShowImportDialogDespitePreviousFailures { get { throw null; } set { } }
        public bool SuppressAutoClosePasswordPrompt { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public abstract partial class ResolveProjectBase : Microsoft.Build.Tasks.TaskExtension
    {
        protected ResolveProjectBase() { }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] ProjectReferences { get { throw null; } set { } }
        protected void AddSyntheticProjectReferences(string currentProjectAbsolutePath) { }
        protected System.Xml.XmlElement GetProjectElement(Microsoft.Build.Framework.ITaskItem projectRef) { throw null; }
        protected string GetProjectItem(Microsoft.Build.Framework.ITaskItem projectRef) { throw null; }
    }
    public abstract partial class TaskExtension : Microsoft.Build.Utilities.Task
    {
        internal TaskExtension() { }
        public new Microsoft.Build.Utilities.TaskLoggingHelper Log { get { throw null; } }
    }
    public partial class TaskLoggingHelperExtension : Microsoft.Build.Utilities.TaskLoggingHelper
    {
        public TaskLoggingHelperExtension(Microsoft.Build.Framework.ITask taskInstance, System.Resources.ResourceManager primaryResources, System.Resources.ResourceManager sharedResources, string helpKeywordPrefix) : base (default(Microsoft.Build.Framework.ITask)) { }
        public System.Resources.ResourceManager TaskSharedResources { get { throw null; } set { } }
        public override string FormatResourceString(string resourceName, params object[] args) { throw null; }
    }
    public sealed partial class Telemetry : Microsoft.Build.Tasks.TaskExtension
    {
        public Telemetry() { }
        public string EventData { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string EventName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
    public abstract partial class ToolTaskExtension : Microsoft.Build.Utilities.ToolTask
    {
        internal ToolTaskExtension() { }
        protected internal System.Collections.Hashtable Bag { get { throw null; } }
        protected override bool HasLoggedErrors { get { throw null; } }
        public new Microsoft.Build.Utilities.TaskLoggingHelper Log { get { throw null; } }
        protected internal virtual void AddCommandLineCommands(Microsoft.Build.Tasks.CommandLineBuilderExtension commandLine) { }
        protected internal virtual void AddResponseFileCommands(Microsoft.Build.Tasks.CommandLineBuilderExtension commandLine) { }
        protected override string GenerateCommandLineCommands() { throw null; }
        protected override string GenerateResponseFileCommands() { throw null; }
        protected internal bool GetBoolParameterWithDefault(string parameterName, bool defaultValue) { throw null; }
        protected internal int GetIntParameterWithDefault(string parameterName, int defaultValue) { throw null; }
    }
    public partial class Touch : Microsoft.Build.Tasks.TaskExtension
    {
        public Touch() { }
        public bool AlwaysCreate { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem[] Files { get { throw null; } set { } }
        public bool ForceTouch { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem[] TouchedFiles { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public sealed partial class Warning : Microsoft.Build.Tasks.TaskExtension
    {
        public Warning() { }
        public string Code { get { throw null; } set { } }
        public string File { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string HelpKeyword { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public override bool Execute() { throw null; }
    }
    public partial class WriteCodeFragment : Microsoft.Build.Tasks.TaskExtension
    {
        public WriteCodeFragment() { }
        public Microsoft.Build.Framework.ITaskItem[] AssemblyAttributes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Microsoft.Build.Framework.ITaskItem OutputDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Microsoft.Build.Framework.OutputAttribute]
        public Microsoft.Build.Framework.ITaskItem OutputFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
    public partial class WriteLinesToFile : Microsoft.Build.Tasks.TaskExtension
    {
        public WriteLinesToFile() { }
        public string Encoding { get { throw null; } set { } }
        [Microsoft.Build.Framework.RequiredAttribute]
        public Microsoft.Build.Framework.ITaskItem File { get { throw null; } set { } }
        public Microsoft.Build.Framework.ITaskItem[] Lines { get { throw null; } set { } }
        public bool Overwrite { get { throw null; } set { } }
        public bool WriteOnlyWhenDifferent { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Execute() { throw null; }
    }
}
namespace Microsoft.Build.Tasks.Hosting
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("B5A95716-2053-4B70-9FBF-E4148EBA96BC")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IAnalyzerHostObject
    {
        bool SetAdditionalFiles(Microsoft.Build.Framework.ITaskItem[] additionalFiles);
        bool SetAnalyzers(Microsoft.Build.Framework.ITaskItem[] analyzers);
        bool SetRuleSet(string ruleSetFile);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("8520CC4D-64DC-4855-BE3F-4C28CCE048EE")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface ICscHostObject : Microsoft.Build.Framework.ITaskHost
    {
        void BeginInitialization();
        bool Compile();
        bool EndInitialization(out string errorMessage, out int errorCode);
        bool IsDesignTime();
        bool IsUpToDate();
        bool SetAdditionalLibPaths(string[] additionalLibPaths);
        bool SetAddModules(string[] addModules);
        bool SetAllowUnsafeBlocks(bool allowUnsafeBlocks);
        bool SetBaseAddress(string baseAddress);
        bool SetCheckForOverflowUnderflow(bool checkForOverflowUnderflow);
        bool SetCodePage(int codePage);
        bool SetDebugType(string debugType);
        bool SetDefineConstants(string defineConstants);
        bool SetDelaySign(bool delaySignExplicitlySet, bool delaySign);
        bool SetDisabledWarnings(string disabledWarnings);
        bool SetDocumentationFile(string documentationFile);
        bool SetEmitDebugInformation(bool emitDebugInformation);
        bool SetErrorReport(string errorReport);
        bool SetFileAlignment(int fileAlignment);
        bool SetGenerateFullPaths(bool generateFullPaths);
        bool SetKeyContainer(string keyContainer);
        bool SetKeyFile(string keyFile);
        bool SetLangVersion(string langVersion);
        bool SetLinkResources(Microsoft.Build.Framework.ITaskItem[] linkResources);
        bool SetMainEntryPoint(string targetType, string mainEntryPoint);
        bool SetModuleAssemblyName(string moduleAssemblyName);
        bool SetNoConfig(bool noConfig);
        bool SetNoStandardLib(bool noStandardLib);
        bool SetOptimize(bool optimize);
        bool SetOutputAssembly(string outputAssembly);
        bool SetPdbFile(string pdbFile);
        bool SetPlatform(string platform);
        bool SetReferences(Microsoft.Build.Framework.ITaskItem[] references);
        bool SetResources(Microsoft.Build.Framework.ITaskItem[] resources);
        bool SetResponseFiles(Microsoft.Build.Framework.ITaskItem[] responseFiles);
        bool SetSources(Microsoft.Build.Framework.ITaskItem[] sources);
        bool SetTargetType(string targetType);
        bool SetTreatWarningsAsErrors(bool treatWarningsAsErrors);
        bool SetWarningLevel(int warningLevel);
        bool SetWarningsAsErrors(string warningsAsErrors);
        bool SetWarningsNotAsErrors(string warningsNotAsErrors);
        bool SetWin32Icon(string win32Icon);
        bool SetWin32Resource(string win32Resource);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("D6D4E228-259A-4076-B5D0-0627338BCC10")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface ICscHostObject2 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.ICscHostObject
    {
        bool SetWin32Manifest(string win32Manifest);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("F9353662-F1ED-4a23-A323-5F5047E85F5D")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface ICscHostObject3 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.ICscHostObject, Microsoft.Build.Tasks.Hosting.ICscHostObject2
    {
        bool SetApplicationConfiguration(string applicationConfiguration);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("0DDB496F-C93C-492C-87F1-90B6FDBAA833")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface ICscHostObject4 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.ICscHostObject, Microsoft.Build.Tasks.Hosting.ICscHostObject2, Microsoft.Build.Tasks.Hosting.ICscHostObject3
    {
        bool SetHighEntropyVA(bool highEntropyVA);
        bool SetPlatformWith32BitPreference(string platformWith32BitPreference);
        bool SetSubsystemVersion(string subsystemVersion);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("7D7AC3BE-253A-40e8-A3FF-357D0DA7C47A")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IVbcHostObject : Microsoft.Build.Framework.ITaskHost
    {
        void BeginInitialization();
        bool Compile();
        void EndInitialization();
        bool IsDesignTime();
        bool IsUpToDate();
        bool SetAdditionalLibPaths(string[] additionalLibPaths);
        bool SetAddModules(string[] addModules);
        bool SetBaseAddress(string targetType, string baseAddress);
        bool SetCodePage(int codePage);
        bool SetDebugType(bool emitDebugInformation, string debugType);
        bool SetDefineConstants(string defineConstants);
        bool SetDelaySign(bool delaySign);
        bool SetDisabledWarnings(string disabledWarnings);
        bool SetDocumentationFile(string documentationFile);
        bool SetErrorReport(string errorReport);
        bool SetFileAlignment(int fileAlignment);
        bool SetGenerateDocumentation(bool generateDocumentation);
        bool SetImports(Microsoft.Build.Framework.ITaskItem[] importsList);
        bool SetKeyContainer(string keyContainer);
        bool SetKeyFile(string keyFile);
        bool SetLinkResources(Microsoft.Build.Framework.ITaskItem[] linkResources);
        bool SetMainEntryPoint(string mainEntryPoint);
        bool SetNoConfig(bool noConfig);
        bool SetNoStandardLib(bool noStandardLib);
        bool SetNoWarnings(bool noWarnings);
        bool SetOptimize(bool optimize);
        bool SetOptionCompare(string optionCompare);
        bool SetOptionExplicit(bool optionExplicit);
        bool SetOptionStrict(bool optionStrict);
        bool SetOptionStrictType(string optionStrictType);
        bool SetOutputAssembly(string outputAssembly);
        bool SetPlatform(string platform);
        bool SetReferences(Microsoft.Build.Framework.ITaskItem[] references);
        bool SetRemoveIntegerChecks(bool removeIntegerChecks);
        bool SetResources(Microsoft.Build.Framework.ITaskItem[] resources);
        bool SetResponseFiles(Microsoft.Build.Framework.ITaskItem[] responseFiles);
        bool SetRootNamespace(string rootNamespace);
        bool SetSdkPath(string sdkPath);
        bool SetSources(Microsoft.Build.Framework.ITaskItem[] sources);
        bool SetTargetCompactFramework(bool targetCompactFramework);
        bool SetTargetType(string targetType);
        bool SetTreatWarningsAsErrors(bool treatWarningsAsErrors);
        bool SetWarningsAsErrors(string warningsAsErrors);
        bool SetWarningsNotAsErrors(string warningsNotAsErrors);
        bool SetWin32Icon(string win32Icon);
        bool SetWin32Resource(string win32Resource);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("f59afc84-d102-48b1-a090-1b90c79d3e09")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IVbcHostObject2 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.IVbcHostObject
    {
        bool SetModuleAssemblyName(string moduleAssemblyName);
        bool SetOptionInfer(bool optionInfer);
        bool SetWin32Manifest(string win32Manifest);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("1186fe8f-8aba-48d6-8ce3-32ca42f53728")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IVbcHostObject3 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.IVbcHostObject, Microsoft.Build.Tasks.Hosting.IVbcHostObject2
    {
        bool SetLanguageVersion(string languageVersion);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("2AE3233C-8AB3-48A0-9ED9-6E3545B3C566")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IVbcHostObject4 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.IVbcHostObject, Microsoft.Build.Tasks.Hosting.IVbcHostObject2, Microsoft.Build.Tasks.Hosting.IVbcHostObject3
    {
        bool SetVBRuntime(string VBRuntime);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("5ACF41FF-6F2B-4623-8146-740C89212B21")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IVbcHostObject5 : Microsoft.Build.Framework.ITaskHost, Microsoft.Build.Tasks.Hosting.IVbcHostObject, Microsoft.Build.Tasks.Hosting.IVbcHostObject2, Microsoft.Build.Tasks.Hosting.IVbcHostObject3, Microsoft.Build.Tasks.Hosting.IVbcHostObject4
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.PreserveSig)]int CompileAsync(out System.IntPtr buildSucceededEvent, out System.IntPtr buildFailedEvent);
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.PreserveSig)]int EndCompile(bool buildSuccess);
        Microsoft.Build.Tasks.Hosting.IVbcHostObjectFreeThreaded GetFreeThreadedHostObject();
        bool SetHighEntropyVA(bool highEntropyVA);
        bool SetPlatformWith32BitPreference(string platformWith32BitPreference);
        bool SetSubsystemVersion(string subsystemVersion);
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Runtime.InteropServices.GuidAttribute("ECCF972F-8C2D-4F51-9746-9288661DE2CB")]
    [System.Runtime.InteropServices.InterfaceTypeAttribute((System.Runtime.InteropServices.ComInterfaceType)(1))]
    public partial interface IVbcHostObjectFreeThreaded
    {
        bool Compile();
    }
}
