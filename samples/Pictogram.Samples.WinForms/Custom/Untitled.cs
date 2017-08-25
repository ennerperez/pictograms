using System;
using System.Collections.Generic;
using System.Drawing.Pictograms.Attributes;
using System.Linq;
using System.Text;

namespace Pictogram.Samples.WinForms
{
    [Pictogram("Untitled", "Untitled")]
    public class Untitled : System.Drawing.Pictogram
    {
        #region Singleton

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
#if !PORTABLE
        private Untitled() : base(Properties.Resources.Untitled)
#else
        private Untitled() : base()
#endif
        {
        }

        internal static Untitled instance;

        public static Untitled Instance
        {
            get
            {
                if (instance == null)
                    instance = new Untitled();
                return (Untitled)instance;
            }
        }

        #endregion Singleton

        public Untitled(bool @default) : this()
        {
        }


        public enum IconType
        {
            a = 0x41
        }

    }
}
