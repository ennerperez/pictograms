using System;
using System.Drawing;
using System.Drawing.Pictograms.Attributes;

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

        private Nucleo()
#else
        private Nucleo()
#endif
        {
        }

        private static Nucleo _instance;

        public static Nucleo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Nucleo();
                return _instance;
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