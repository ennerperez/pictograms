namespace Xamarin.Forms.Pictograms
{
    public class Icon : Label
    {
        #region Constructors

        public Icon()
        {
            AutoSize = true;
            this.HorizontalTextAlignment = TextAlignment.Center;
            this.VerticalTextAlignment = TextAlignment.Center;
        }

        public Icon(string fontface)
            : this()
        {
            FontFamily = fontface;
        }

        public Icon(string fontface, int type)
            : this(fontface)
        {
            Text = Pictogram.GetText(type);
        }

        public Icon(Pictogram glyph)
            : this(glyph.GetFontFace())
        {
        }

        public Icon(Pictogram glyph, int type)
            : this(glyph.GetFontFace(), type)
        {
        }

        #endregion Constructors

        protected override void InvalidateMeasure()
        {
            base.InvalidateMeasure();
            if (AutoSize)
            {
                WidthRequest = FontSize + (FontSize * 0.15);
                HeightRequest = WidthRequest;
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