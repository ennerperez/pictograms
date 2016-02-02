using System.Resources;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyProduct("Pictograms")]

#if !PORTABLE
[assembly: ComVisible(true)]
#endif
[assembly: CLSCompliant(false)]
//[assembly: SecurityRules(SecurityRuleSet.Level2)] 

#if (DEBUG)
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

//#if (NETFX_40 || NETFX_45 || NETFX_451)
//[assembly: AllowPartiallyTrustedCallers()]
//#endif
[assembly: NeutralResourcesLanguageAttribute("en")]