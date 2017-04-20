using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


internal static class NativeMethods
{

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

}
