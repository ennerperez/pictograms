#addin "Cake.FileHelpers"

var TARGET = Argument ("target", Argument ("t", "Default"));
var version = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", "1.1.0");

var solutions = new Dictionary<string, string> {
 	{ "./src/Pictograms.sln", "Any" },
};

var packages = new Dictionary<string, string> {
 	{ "./src/Pictograms/Pictograms.csproj", "Any" },
	{ "./src/Pictograms.Forms/Pictograms.Forms.csproj", "Any" },
	{ "./src/Pictograms.Xamarin.Forms/Package.nuspec", "Any" },
};

var BuildAction = new Action<Dictionary<string, string>> (solutions =>
{

	foreach (var sln in solutions) 
    {

		// If the platform is Any build regardless
		//  If the platform is Win and we are running on windows build
		//  If the platform is Mac and we are running on Mac, build
		if ((sln.Value == "Any")
				|| (sln.Value == "Win" && IsRunningOnWindows ())
				|| (sln.Value == "Mac" && IsRunningOnUnix ())) 
        {
			
			// Bit of a hack to use nuget3 to restore packages for project.json
			if (IsRunningOnWindows ()) 
            {
				
				Information ("RunningOn: {0}", "Windows");

				NuGetRestore (sln.Key, new NuGetRestoreSettings
                {
					ToolPath = "./tools/nuget3.exe"
				});

				// Windows Phone / Universal projects require not using the amd64 msbuild
				MSBuild (sln.Key, c => 
                { 
					c.Configuration = "Release";
					c.MSBuildPlatform = Cake.Common.Tools.MSBuild.MSBuildPlatform.x86;
				});
			} 
            else 
            {
                // Mac is easy ;)
				NuGetRestore (sln.Key);

				DotNetBuild (sln.Key, c => c.Configuration = "Release");
			}
		}
	}
});

Task("Solutions").Does(()=>
{
    BuildAction(solutions);
});

Task ("NuGet")
	.IsDependentOn ("Solutions")
	.Does (() =>
{
    if(!DirectoryExists("./build/nuget/"))
        CreateDirectory("./build/nuget");

	var nuGetPackSettings = new NuGetPackSettings
	{
		Version = version,
		IncludeReferencedProjects = true,
		Verbosity = NuGetVerbosity.Detailed,
		OutputDirectory = "./build/nuget/",
		BasePath = "./",
		ToolPath = "./tools/nuget3.exe"
	};
        
	foreach (var proj in packages) 
    {
		NuGetPack(proj.Key, nuGetPackSettings);
	}

});

//Build the component, which build samples, nugets, and solutions
Task ("Default").IsDependentOn("NuGet");


Task ("Clean").Does (() => 
{
	CleanDirectory ("./component/tools/");

	CleanDirectories ("./build/");

	CleanDirectories ("./**/bin");
	CleanDirectories ("./**/obj");
});


RunTarget (TARGET);