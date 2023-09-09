using System;

namespace Xamarin.Forms.Pictograms
{
    public class Tile : Tile<FontAwesome>
    {
    }

    public class Tile<T> : Frame, IDisposable where T : Pictogram
    {
        private T glyph;

        public Tile()
        {
            glyph = Pictogram.GetInstance<T>();
            InitializeComponent();
        }

        #region Designer

        private void InitializeComponent()
        {
            HasShadow = false;
            BackgroundColor = Color.Accent;
            Padding = new Thickness(3);

            //
            // glyphIcon
            //
            glyphIcon = new Icon(glyph)
            {
                FontSize = 70,
                TextColor = Color.White,
                AutoSize = true
            };

            //
            // absoluteLayoutIcon
            //
            absoluteLayoutIcon = new AbsoluteLayout()
            {
                WidthRequest = 80,
                HeightRequest = 80
            };
            absoluteLayoutIcon.Children.Add(glyphIcon);
            AbsoluteLayout.SetLayoutFlags(glyphIcon, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(glyphIcon, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            //
            // labelTitle
            //
            labelTitle = new Label()
            {
                FontSize = 20,
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.White
            };
            AbsoluteLayout.SetLayoutFlags(labelTitle, AbsoluteLayoutFlags.XProportional);
            AbsoluteLayout.SetLayoutBounds(labelTitle, new Rectangle(0.5, 80, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            //
            // labelDetail
            //
            labelDetail = new Label()
            {
                FontSize = 22,
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.White.MultiplyAlpha(0.65)
            };
            AbsoluteLayout.SetLayoutFlags(labelDetail, AbsoluteLayoutFlags.XProportional);
            AbsoluteLayout.SetLayoutBounds(labelDetail, new Rectangle(0.5, 100, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            //
            // absoluteLayout
            //
            absoluteLayout = new AbsoluteLayout();
            absoluteLayout.SetBinding(WidthRequestProperty, "Width");
            absoluteLayout.SetBinding(HeightRequestProperty, "Height");

            absoluteLayout.Children.Add(absoluteLayoutIcon);
            absoluteLayout.Children.Add(labelTitle);
            absoluteLayout.Children.Add(labelDetail);

            AbsoluteLayout.SetLayoutFlags(absoluteLayoutIcon, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(absoluteLayoutIcon, new Rectangle(0.5, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            //
            // tapGestureRecognizer
            //
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTapped;
            absoluteLayout.GestureRecognizers.Add(tapGestureRecognizer);

            //
            // contentView
            //
            var contentView = new ContentView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = absoluteLayout
            };
            Content = contentView;
        }

        private AbsoluteLayout absoluteLayout;
        private AbsoluteLayout absoluteLayoutIcon;
        private Icon glyphIcon;
        private Label labelTitle;
        private Label labelDetail;

        #endregion Designer

        #region Properties

        public double FontSize
        {
            get
            {
                return (double)GetValue(Tile.FontSizeProperty);
            }
            set
            {
                SetValue(Tile.FontSizeProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(Tile), 20.0, propertyChanged: OnFontSizeChanged);

        private static void OnFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Tile)bindable).labelTitle.FontSize = (double)newValue;
            ((Tile)bindable).labelDetail.FontSize = (double)newValue + ((double)newValue / 2);
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(Tile.TextColorProperty);
            }
            set
            {
                SetValue(Tile.TextColorProperty, value);
            }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(Tile), Color.Default, propertyChanged: OnTextColorChanged);

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bindable as Tile)?.labelTitle != null)
                (bindable as Tile).labelTitle.TextColor = (Color)newValue;
            if ((bindable as Tile)?.labelDetail != null)
                (bindable as Tile).labelDetail.TextColor = (Color)newValue;
            if ((bindable as Tile)?.glyphIcon != null)
                (bindable as Tile).glyphIcon.TextColor = (Color)newValue;
        }

        private double width;

        public new double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                if (absoluteLayout != null)
                {
                    absoluteLayout.WidthRequest = width;
                }
            }
        }

        private double height;

        public new double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                if (absoluteLayout != null)
                {
                    absoluteLayout.HeightRequest = height;
                }
            }
        }

        private int icon;

        public int Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                if (glyphIcon != null)
                {
                    glyphIcon.Text = Pictogram.GetInstance<T>().GetText(Icon);
                }
            }
        }

        private string text;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (labelTitle != null)
                {
                    labelTitle.Text = text;
                }
            }
        }

        private string datail;

        public string Detail
        {
            get
            {
                return datail;
            }
            set
            {
                datail = value;
                if (labelDetail != null)
                {
                    labelDetail.Text = datail;
                }
            }
        }

        #endregion Properties

        #region Methods

        public event EventHandler Tapped;

        private void OnTapped(object sender, EventArgs e)
        {
            Tapped?.Invoke(sender, EventArgs.Empty);
        }

        #endregion Methods

        // Reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        ~Tile()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose();
        }

        #region IDisposable implementation

        // Para detectar llamadas redundantes
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Elimine el estado administrado (objetos administrados).
            }

            // Libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
            // Configure los campos grandes en nulos.
            Tapped = null;
            if (BindingContext != null)
            {
                BindingContext = null;
            }

            disposed = true;
        }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable implementation
    }
}