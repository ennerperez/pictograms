using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1050 // Declare types in namespaces
public class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Pack);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Environment to build - Default is 'Development' (local) or 'Production' (server)")]
    public string Environment = IsLocalBuild ? "Development" : "Production";

    [Solution]
    readonly Solution Solution;

    static AbsolutePath SourceDirectory => RootDirectory / "src";

    static AbsolutePath PublishDirectory => RootDirectory / "publish";

    static AbsolutePath ArtifactsDirectory => RootDirectory / "output";


    Version _version = new("1.0.0.0");
    string _hash = string.Empty;
    readonly string[] PublishProjects = new[] { "Pictograms", "Pictograms.Xamarin.Forms" };

    Target Prepare => d => d
        .Before(Compile)
        .Executes(() =>
        {
            var assemblyInfoVersionFile = Path.Combine(SourceDirectory, ".files", "AssemblyInfo.Version.cs");
            if (File.Exists(assemblyInfoVersionFile))
            {
                Log.Information("Patching: {File}", assemblyInfoVersionFile);

                using (var gitTag = new Process())
                {
                    gitTag.StartInfo = new ProcessStartInfo("git", "tag --sort=-v:refname") { WorkingDirectory = SourceDirectory, RedirectStandardOutput = true, UseShellExecute = false };
                    gitTag.Start();
                    var value = gitTag.StandardOutput.ReadToEnd().Trim();
                    value = new Regex(@"((?:[0-9]{1,}\.{0,}){1,})", RegexOptions.Compiled).Match(value).Captures.LastOrDefault()?.Value;
                    if (value != null)
                    {
                        _version = Version.Parse(value);
                    }

                    gitTag.WaitForExit();
                }

                using (var gitLog = new Process())
                {
                    gitLog.StartInfo = new ProcessStartInfo("git", "rev-parse --verify HEAD") { WorkingDirectory = SourceDirectory, RedirectStandardOutput = true, UseShellExecute = false };
                    gitLog.Start();
                    _hash = gitLog.StandardOutput.ReadLine()?.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                    gitLog.WaitForExit();
                }

                if (_version != null)
                {
                    var content = File.ReadAllText(assemblyInfoVersionFile);
                    var assemblyVersionRegEx = new Regex(@"\[assembly: AssemblyVersion\(.*\)\]", RegexOptions.Compiled);
                    var assemblyFileVersionRegEx = new Regex(@"\[assembly: AssemblyFileVersion\(.*\)\]", RegexOptions.Compiled);
                    var assemblyInformationalVersionRegEx = new Regex(@"\[assembly: AssemblyInformationalVersion\(.*\)\]", RegexOptions.Compiled);

                    content = assemblyVersionRegEx.Replace(content, $"[assembly: AssemblyVersion(\"{_version}\")]");
                    content = assemblyFileVersionRegEx.Replace(content, $"[assembly: AssemblyFileVersion(\"{_version}\")]");
                    content = assemblyInformationalVersionRegEx.Replace(content, $"[assembly: AssemblyInformationalVersion(\"{_version:3}+{_hash}\")]");

                    File.WriteAllText(assemblyInfoVersionFile, content);

                    Log.Information("Version: {Version}", _version);
                    Log.Information("Hash: {Hash}", _hash);
                }
                else
                {
                    Log.Warning("Version was not found");
                }
            }
        });

    Target Clean => d => d
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(PublishDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => d => d
        .Executes(() =>
        {
            DotNetToolRestore();
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => d => d
        .DependsOn(Clean)
        .DependsOn(Restore)
        .DependsOn(Prepare)
        .Executes(() =>
        {
            MSBuild(s=> s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration));
        });

    Target Publish => d => d
        .DependsOn(Compile)
        .DependsOn(Clean)
        .Executes(() =>
        {

            var publishCombinations =
                from project in PublishProjects.Select(m => Solution.GetProject(m))
                from framework in project.GetTargetFrameworks()
                select new { project, framework };


            DotNetPublish(s => s
                .EnableNoRestore()
                .EnableNoBuild()
                .SetConfiguration(Configuration)
                .DisablePublishSingleFile()
                .CombineWith(publishCombinations, (x, v) => x
                    .SetProject(v.project)
                    .SetFramework(v.framework)
                    .SetOutput($"{PublishDirectory}/{v.project.Name}")));
        });

    Target Pack => d => d
        .DependsOn(Publish)
        .Executes(() =>
        {
            foreach (var project in PublishProjects)
            {
                ZipFile.CreateFromDirectory($"{PublishDirectory}/{project}", $"{ArtifactsDirectory}/{project}.zip");
            }

            EnsureCleanDirectory(PublishDirectory);
            Log.Information($"Output: {ArtifactsDirectory}");
        });
}
#pragma warning restore CA1050 // Declare types in namespaces
#pragma warning restore IDE1006 // Naming Styles
