using System.Drawing;
using System.Drawing.Pictograms.Attributes;

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
        private Untitled()
#endif
        {
        }

        private static Untitled _instance;

        public static Untitled Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Untitled();
                return _instance;
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
