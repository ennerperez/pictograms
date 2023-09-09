namespace Xamarin.Forms.Pictograms
{
    public class EmptyLayout<T> : AbsoluteLayout where T : Pictogram
    {
        #region Constructor

        public EmptyLayout()
        {
            pictogram = Pictogram.GetInstance<T>();
            InitializeComponent();
        }

        #endregion Constructor

        #region Designer

        private void InitializeComponent()
        {
            //
            // fontAwesomeIcon
            //
            fontIcon = new Icon(pictogram.GetTypeface())
            {
                FontSize = IconSize,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                AutoSize = true
            };

            //
            // labelText
            //
            labelMessage = new Label()
            {
                FontSize = Helpers.Common.GetNamedSize(NamedSize.Small),
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            };
            var stackContent = new StackLayout()
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            stackContent.Children.Add(fontIcon);
            stackContent.Children.Add(labelMessage);

            Children.Add(stackContent, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);
        }

        private Label labelMessage;
        private Icon fontIcon;

        #endregion Designer

        #region Properties

        #region FontFamily

        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(EmptyLayout<T>), propertyChanged: OnFontFamilyChanged);

        private static void OnFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bindable as EmptyLayout<T>)?.labelMessage != null)
            {
                (bindable as EmptyLayout<T>).labelMessage.FontFamily = (string)newValue;
            }
        }

        #endregion FontFamily

        public string Message
        {
            get
            {
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create("Message", typeof(string), typeof(EmptyLayout<T>), propertyChanged: OnMessageChanged);

        private static void OnMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EmptyLayout<T>)bindable).labelMessage.Text = (string)newValue;
        }

        public string Icon
        {
            get
            {
                return (string)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(string), typeof(EmptyLayout<T>), propertyChanged: OnIconChanged);

        private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EmptyLayout<T>)bindable).fontIcon.Text = (string)newValue;
        }

        public double IconSize
        {
            get
            {
                return (double)GetValue(IconSizeProperty);
            }
            set
            {
                SetValue(IconSizeProperty, value);
            }
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create("IconSize", typeof(double), typeof(EmptyLayout<T>), Helpers.Common.GetNamedSize(NamedSize.Large) * 9, propertyChanged: OnIconSizeChanged);

        private static void OnIconSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EmptyLayout<T>)bindable).fontIcon.FontSize = (double)newValue;
        }

        public Color IconColor
        {
            get
            {
                return (Color)GetValue(IconColorProperty);
            }
            set
            {
                SetValue(IconColorProperty, value);
            }
        }

        public static readonly BindableProperty IconColorProperty =
            BindableProperty.Create("IconColor", typeof(Color), typeof(EmptyLayout<T>), Color.Default, propertyChanged: OnIconColorChanged);

        private static void OnIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var e = new { NewValue = (Color)newValue };
            var color = new Color(e.NewValue.R, e.NewValue.G, e.NewValue.B, 0.5);
            ((EmptyLayout<T>)bindable).fontIcon.TextColor = color;
            ((EmptyLayout<T>)bindable).labelMessage.TextColor = color;
        }

        #endregion Properties

        public Pictogram pictogram;
    }

    public class PictogramEmptyLayout : EmptyLayout<FontAwesome>
    {
    }
}