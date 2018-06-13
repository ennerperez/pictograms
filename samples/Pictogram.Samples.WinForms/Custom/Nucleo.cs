using System;
using System.Collections.Generic;
using System.Drawing.Pictograms.Attributes;
using System.Linq;
using System.Text;

namespace Pictogram.Samples.WinForms
{
    [Pictogram("nucleo", "nucleo-glyph", "http://github.com/mattcreager/herokai/blob/master/public/fonts/nucleo-glyph.ttf?raw=true")]
    public class Nucleo : System.Drawing.Pictogram
    {
        #region Singleton

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
#if !PORTABLE

        private Nucleo() : base()
#else
        private Nucleo() : base()
#endif
        {
        }

        internal static Nucleo instance;

        public static Nucleo Instance
        {
            get
            {
                if (instance == null)
                    instance = new Nucleo();
                return (Nucleo)instance;
            }
        }

        #endregion Singleton

        public Nucleo(bool @default) : this()
        {
        }

        public class IconType : Tuple<int, int>
        {
            public IconType() : base(58880, 60284)
            {
            }
        }
    }
}