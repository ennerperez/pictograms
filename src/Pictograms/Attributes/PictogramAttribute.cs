#if !PORTABLE
namespace System.Drawing.Pictograms.Attributes
#else
using System;
namespace Xamarin.Forms.Pictograms.Attributes
#endif
{
    public class PictogramAttribute : Attribute
    {

        public string Name { get; }
        public string Typeface { get; }
        public string Url { get; }

        public PictogramAttribute()
        {

        }

        public PictogramAttribute(string name, string typeface, string url = "")
        {
            Name = name;
            Typeface = typeface;
            Url = url;
        }
    }
}
