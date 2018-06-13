#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define solutions.
var solutions = new Dictionary<string, string> {
 	{ "./src/Pictograms.sln", "Any" },
};

// Define AssemblyInfo source.
var assemblyInfoVersion = ParseAssemblyInfo("./src/Pictograms/Properties/AssemblyInfo.Common.cs");
var assemblyInfoCommon = assemblyInfoVersion;

// Define version.
var elapsedSpan = new TimeSpan(DateTime.Now.Ticks - new DateTime(2001, 1, 1).Ticks);
var assemblyVersion = assemblyInfoVersion.AssemblyVersion.Replace("*", elapsedSpan.Ticks.ToString().Substring(4, 4));
var version = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", assemblyVersion);

// Define directories.
var outputDirectory = "build/" + configuration;
var buildDir = Directory("../" + outputDirectory);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
    CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        NuGetRestore(solution.Key);
    }
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        if (IsRunningOnWindows())
        {
            var settings = new MSBuildSettings()
            .WithProperty("PackageVersion", version)
            .WithProperty("BuildSymbolsPackage", "false");
            settings.SetConfiguration(configuration);
            // Use MSBuild
            MSBuild(solution.Key, settings);
        }
        else
        {
            var settings = new XBuildSettings()
            .WithProperty("PackageVersion", version)
            .WithProperty("BuildSymbolsPackage", "false");
            settings.SetConfiguration(configuration);
            // Use XBuild
            XBuild(solution.Key, settings);
        }
    }
});

Task("Build-NuGet-Packages")
    .IsDependentOn("Build")
    .Does(() =>
    {
    foreach (var solution in solutions)
    {
        foreach (var folder in new System.IO.FileInfo(solution.Key).Directory.GetDirectories())
        {
            foreach (var file in folder.GetFiles("*.nuspec"))
            {
				var path = file.Directory;
                var assemblyInfo = ParseAssemblyInfo(path + "/Properties/AssemblyInfo.cs");
                var nuGetPackSettings = new NuGetPackSettings()
                {
                    OutputDirectory = outputDirectory,
                    IncludeReferencedProjects = false,
                    Id = assemblyInfo.Title.Replace(" ", "."),
                    Title = assemblyInfo.Title,
                    Version = version,
                    Authors = new[] { assemblyInfoCommon.Company },
                    Summary = assemblyInfo.Description,
                    Copyright = assemblyInfoCommon.Copyright,
                    Properties = new Dictionary<string, string>()
                    {{ "Configuration", configuration }}
                };
                NuGetPack(file.FullName, nuGetPackSettings);
            }
        }
    }
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build-NuGet-Packages");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);