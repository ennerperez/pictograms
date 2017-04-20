namespace Xamarin.Forms.Pictograms
{
    public class Button : Forms.Button
    {
        #region Constructors

        public Button()
        {
            AutoSize = true;
        }

        public Button(string fontface)
            : this()
        {
            FontFamily = fontface;
        }

        public Button(string fontface, int type)
            : this(fontface)
        {
            Text = Pictogram.GetText(type);
        }

        public Button(Pictogram glyph)
            : this(glyph.GetFontFace())
        {
        }

        public Button(Pictogram glyph, int type)
            : this(glyph.GetFontFace(), type)
        {
        }

        #endregion Constructors

        protected override void InvalidateMeasure()
        {
            base.InvalidateMeasure();
            if (AutoSize)
            {
                WidthRequest = FontSize;
            }
        }

        private bool autoSize = true;

        public bool AutoSize
        {
            get
            {
                return autoSize;
            }
            set
            {
                autoSize = value;
                InvalidateMeasure();
            }
        }

        public Pictogram Pictogram;
    }
}