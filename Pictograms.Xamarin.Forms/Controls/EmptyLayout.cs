using System;

namespace Xamarin.Forms.Pictograms
{
    public class EmptyLayout<T> : AbsoluteLayout where T : Pictogram
    {
        #region Constructor

        public EmptyLayout()
        {
            Pictogram = Activator.CreateInstance<T>();
            InitializeComponent();
        }

        #endregion Constructor

        #region Designer

        private void InitializeComponent()
        {
            //
            // fontAwesomeIcon
            //
            fontIcon = new Icon(Pictogram.GetFontFace())
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
            StackLayout StackContent = new StackLayout()
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            StackContent.Children.Add(fontIcon);
            StackContent.Children.Add(labelMessage);

            this.Children.Add(StackContent, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);
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
                return (string)GetValue(EmptyLayout<T>.FontFamilyProperty);
            }
            set
            {
                SetValue(EmptyLayout<T>.FontFamilyProperty, value);
            }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(EmptyLayout<T>), null, propertyChanged: OnFontFamilyChanged);

        private static void OnFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bindable as EmptyLayout<T>).labelMessage != null)
            {
                (bindable as EmptyLayout<T>).labelMessage.FontFamily = (string)newValue;
            }
        }

        #endregion FontFamily

        public string Message
        {
            get
            {
                return (string)GetValue(EmptyLayout<T>.MessageProperty);
            }
            set
            {
                SetValue(EmptyLayout<T>.MessageProperty, value);
            }
        }

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create("Message", typeof(string), typeof(EmptyLayout<T>), null, propertyChanged: OnMessageChanged);

        private static void OnMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as EmptyLayout<T>).labelMessage.Text = (string)newValue;
        }

        public string Icon
        {
            get
            {
                return (string)GetValue(EmptyLayout<T>.IconProperty);
            }
            set
            {
                SetValue(EmptyLayout<T>.IconProperty, value);
            }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(string), typeof(EmptyLayout<T>), null, propertyChanged: OnIconChanged);

        private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as EmptyLayout<T>).fontIcon.Text = (string)newValue;
        }

        public double IconSize
        {
            get
            {
                return (double)GetValue(EmptyLayout<T>.IconSizeProperty);
            }
            set
            {
                SetValue(EmptyLayout<T>.IconSizeProperty, value);
            }
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create("IconSize", typeof(double), typeof(EmptyLayout<T>), Helpers.Common.GetNamedSize(NamedSize.Large) * 9, propertyChanged: OnIconSizeChanged);

        private static void OnIconSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as EmptyLayout<T>).fontIcon.FontSize = (double)newValue;
        }

        public Color IconColor
        {
            get
            {
                return (Color)GetValue(EmptyLayout<T>.IconColorProperty);
            }
            set
            {
                SetValue(EmptyLayout<T>.IconColorProperty, value);
            }
        }

        public static readonly BindableProperty IconColorProperty =
            BindableProperty.Create("IconColor", typeof(Color), typeof(EmptyLayout<T>), Color.Default, propertyChanged: OnIconColorChanged);

        private static void OnIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var e = new { NewValue = (Color)newValue };
            var color = new Color(e.NewValue.R, e.NewValue.G, e.NewValue.B, 0.5);
            (bindable as EmptyLayout<T>).fontIcon.TextColor = color;
            (bindable as EmptyLayout<T>).labelMessage.TextColor = color;
        }

        #endregion Properties

        public Pictogram Pictogram;
    }

    public class PictogramEmptyLayout : EmptyLayout<FontAwesome>
    {
        public PictogramEmptyLayout()
            : base()
        {
        }
    }
}