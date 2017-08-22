using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if !PORTABLE
namespace System.Drawing.Pictograms.Attributes
#else
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
            this.Name = name;
            this.Typeface = typeface;
            this.Url = url;
        }
    }
}
