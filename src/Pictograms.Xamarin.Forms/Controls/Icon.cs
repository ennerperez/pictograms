namespace Xamarin.Forms.Pictograms
{
    public class Icon : Label
    {
        #region Constructors

        public Icon()
        {
            AutoSize = true;
            HorizontalTextAlignment = TextAlignment.Center;
            VerticalTextAlignment = TextAlignment.Center;
        }

        public Icon(string fontface)
            : this()
        {
            FontFamily = fontface;
        }

        public Icon(string fontface, int type)
            : this(fontface)
        {
            Text = pictogram.GetText(type);
        }

        public Icon(Pictogram glyph)
            : this(glyph.GetTypeface())
        {
        }

        public Icon(Pictogram glyph, int type)
            : this(glyph.GetTypeface(), type)
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

        public Pictogram pictogram;
    }
}