using System.Reflection;

// <major version>.<minor version>.<build number>.<revision>

[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

[assembly: AssemblyInformationalVersion("1.0.0 RTM")]

#if (!DEBUG)
//[assembly: Platform.Support.Attributes.AssemblyProduct.ProductLevel(Platform.Support.ProductLevels.RTW)]
#else
//[assembly: Platform.Support.Attributes.AssemblyProduct.ProductLevel(Platform.Support.ProductLevels.Preview)]
#endif
