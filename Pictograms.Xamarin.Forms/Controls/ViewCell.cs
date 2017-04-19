using System;
using Xamarin.Forms.Pictograms;

namespace Xamarin.Forms.Pictograms
{
    public class ViewCell<T> : Forms.ViewCell where T : Pictogram
    {
        #region Constructor

        public ViewCell()
        {
            Pictogram = Activator.CreateInstance<T>();
            InitializeComponent();
        }

        #endregion Constructor

        #region Designer

        private void InitializeComponent()
        {
            #region Styles

            //
            // styleText
            //
            Style styleText = new Style(typeof(Label));
            styleText.Setters.Add(Label.TextColorProperty, TextColor);
            styleText.Setters.Add(Label.HorizontalOptionsProperty, LayoutOptions.FillAndExpand);
            styleText.Setters.Add(Label.VerticalOptionsProperty, LayoutOptions.CenterAndExpand);
            styleText.Setters.Add(Label.FontAttributesProperty, FontAttributes.None);
            styleText.Setters.Add(Label.FontSizeProperty, Helpers.Common.GetNamedSize(NamedSize.Medium));

            //
            // styleDetail
            //
            Style styleDetail = new Style(typeof(Label));
            styleDetail.Setters.Add(Label.TextColorProperty, DetailColor);
            styleDetail.Setters.Add(Label.HorizontalOptionsProperty, LayoutOptions.FillAndExpand);
            styleDetail.Setters.Add(Label.VerticalOptionsProperty, LayoutOptions.StartAndExpand);
            styleDetail.Setters.Add(Label.FontSizeProperty, Helpers.Common.GetNamedSize(NamedSize.Small));

            #endregion Styles

            //
            // fontIcon
            //
            fontIcon = new Icon(Pictogram.GetFontFace())
            {
                FontSize = Helpers.Common.GetNamedSize(NamedSize.Default) * 2,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = IconColor,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                AutoSize = true
            };

            //
            // labelText
            //
            labelTitle = new Label()
            {
                Style = styleText,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            //
            // labelDetail
            //
            labelDetail = new Label()
            {
                Style = styleDetail,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            //
            // StackVertical
            //
            stackVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0
            };
            stackVertical.Children.Add(labelTitle);
            if (!string.IsNullOrEmpty(Detail) || !ForceDetails)
            {
                labelTitle.VerticalOptions = LayoutOptions.EndAndExpand;
                stackVertical.Children.Add(labelDetail);
            }

            //
            // StackContent
            //
            StackLayout stackContent = new StackLayout()
            {
                Padding = new Thickness(10, 0),
                Spacing = 20,
                Orientation = StackOrientation.Horizontal
            };
            stackContent.Children.Add(fontIcon);
            stackContent.Children.Add(stackVertical);

            this.View = stackContent;
            this.View.BackgroundColor = BackgroundColor;
        }

        private StackLayout stackVertical;
        public Icon fontIcon;
        public Label labelTitle;
        public Label labelDetail;

        #endregion Designer

        #region Properties

        #region FontFamily

        public string FontFamily
        {
            get
            {
                return (string)GetValue(ViewCell<T>.FontFamilyProperty);
            }
            set
            {
                SetValue(ViewCell<T>.FontFamilyProperty, value);
            }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(ViewCell<T>), string.Empty, propertyChanged: OnFontFamilyChanged);

        private static void OnFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bindable as ViewCell<T>).labelTitle != null)
                (bindable as ViewCell<T>).labelTitle.FontFamily = (string)newValue;
            if ((bindable as ViewCell<T>).labelDetail != null)
                (bindable as ViewCell<T>).labelDetail.FontFamily = (string)newValue;
        }

        #endregion FontFamily

        private bool forceDetails = true;

        public bool ForceDetails { get { return forceDetails; } set { forceDetails = value; } }

        public string FontFace
        {
            get
            {
                return (string)GetValue(ViewCell<T>.FontFaceProperty);
            }
            set
            {
                SetValue(ViewCell<T>.FontFaceProperty, value);
            }
        }

        public Double FontSize
        {
            get
            {
                return (Double)GetValue(ViewCell<T>.FontSizeProperty);
            }
            set
            {
                SetValue(ViewCell<T>.FontSizeProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(ViewCell<T>.TextProperty);
            }
            set
            {
                SetValue(ViewCell<T>.TextProperty, value);
            }
        }

        public string Detail
        {
            get
            {
                return (string)GetValue(ViewCell<T>.DetailProperty);
            }
            set
            {
                SetValue(ViewCell<T>.DetailProperty, value);
            }
        }

        public string Icon
        {
            get
            {
                return (string)GetValue(ViewCell<T>.IconProperty);
            }
            set
            {
                SetValue(ViewCell<T>.IconProperty, value);
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(ViewCell<T>.BackgroundColorProperty);
            }
            set
            {
                SetValue(ViewCell<T>.BackgroundColorProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(ViewCell<T>.TextColorProperty);
            }
            set
            {
                SetValue(ViewCell<T>.TextColorProperty, value);
            }
        }

        public Color IconColor
        {
            get
            {
                return (Color)GetValue(ViewCell<T>.IconColorProperty);
            }
            set
            {
                SetValue(ViewCell<T>.IconColorProperty, value);
            }
        }

        public Color DetailColor
        {
            get
            {
                return (Color)GetValue(ViewCell<T>.DetailColorProperty);
            }
            set
            {
                SetValue(ViewCell<T>.DetailColorProperty, value);
            }
        }

        public static readonly BindableProperty FontFaceProperty =
            BindableProperty.Create("FontFace", typeof(string), typeof(ViewCell<T>), string.Empty, propertyChanged: OnFontFaceChanged);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(ViewCell<T>), Helpers.Common.GetNamedSize(NamedSize.Default), propertyChanged: OnFontSizeChanged);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(ViewCell<T>), string.Empty, propertyChanged: OnTextChanged);

        public static readonly BindableProperty DetailProperty =
            BindableProperty.Create("Detail", typeof(string), typeof(ViewCell<T>), string.Empty, propertyChanged: OnDetailChanged);

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(string), typeof(ViewCell<T>), string.Empty, propertyChanged: OnIconChanged);

        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create("BackgroundColor", typeof(Color), typeof(ViewCell<T>), Color.Default, propertyChanged: OnBackgroundColorChanged);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(ViewCell<T>), Color.Default, propertyChanged: OnTextColorChanged);

        public static readonly BindableProperty IconColorProperty =
            BindableProperty.Create("IconColor", typeof(Color), typeof(ViewCell<T>), Color.Default, propertyChanged: OnIconColorChanged);

        public static readonly BindableProperty DetailColorProperty =
            BindableProperty.Create("DetailColor", typeof(Color), typeof(ViewCell<T>), Color.Default, propertyChanged: OnDetailColorChanged);

        private static void OnFontFaceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!string.IsNullOrEmpty((string)newValue))
                (bindable as ViewCell<T>).labelTitle.FontFamily = (string)newValue;
            else
                (bindable as ViewCell<T>).labelTitle.FontFamily = "";
        }

        private static void OnFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ViewCell<T>).labelTitle.FontSize = (double)newValue;
        }

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                if (!string.IsNullOrEmpty((string)newValue))
                    (bindable as ViewCell<T>).labelTitle.Text = (string)newValue;
                else
                    (bindable as ViewCell<T>).labelTitle.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private static void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!string.IsNullOrEmpty((string)newValue))
                (bindable as ViewCell<T>).labelDetail.Text = (string)newValue;
            else
                (bindable as ViewCell<T>).labelDetail.Text = "";

            (bindable as ViewCell<T>).UpdateUI();
        }

        private void UpdateUI()
        {
            if (!string.IsNullOrEmpty(labelDetail.Text))
            {
                stackVertical.Children.Insert(1, labelDetail);
                labelTitle.VerticalOptions = LayoutOptions.EndAndExpand;
            }
            else
            {
                stackVertical.Children.Remove(labelDetail);
                labelTitle.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
        }

        private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!String.IsNullOrEmpty((string)newValue))
                (bindable as ViewCell<T>).fontIcon.Text = (string)newValue;
            else
                (bindable as ViewCell<T>).fontIcon.Text = null;
        }

        private static void OnBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bindable as ViewCell<T>).View != null)
            {
                if (newValue != null)
                    (bindable as ViewCell<T>).View.BackgroundColor = (Color)newValue;
                else
                    (bindable as ViewCell<T>).View.BackgroundColor = Color.Default;
            }
        }

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                (bindable as ViewCell<T>).labelTitle.TextColor = (Color)newValue;
            else
                (bindable as ViewCell<T>).labelTitle.TextColor = Color.Default;
        }

        private static void OnIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                (bindable as ViewCell<T>).fontIcon.TextColor = (Color)newValue;
            else
                (bindable as ViewCell<T>).fontIcon.TextColor = Color.Default;
        }

        private static void OnDetailColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                (bindable as ViewCell<T>).labelDetail.TextColor = (Color)newValue;
            else
                (bindable as ViewCell<T>).labelDetail.TextColor = Color.Default;
        }

        #endregion Properties

        public Pictogram Pictogram;
    }

    public class ViewCell : ViewCell<FontAwesome>
    {
        public ViewCell()
            : base()
        {
        }

        protected override void OnTapped()
        {
            base.OnTapped();
            (Parent as ListView).SelectedItem = null;
        }
    }

    public class ChevronViewCell<T, TC> : ViewCell<T> where T : Pictogram where TC : Pictogram
    {
        #region Constructor

        public ChevronViewCell()
            : base()
        {
            ChevronPictogram = Activator.CreateInstance<TC>();
            InitializeComponent();
        }

        #endregion Constructor

        #region Properties

        public string ChevronFontFace
        {
            get
            {
                return (string)GetValue(ChevronViewCell<T, TC>.ChevronFontFaceProperty);
            }
            set
            {
                SetValue(ChevronViewCell<T, TC>.ChevronFontFaceProperty, value);
            }
        }

        public static readonly BindableProperty ChevronFontFaceProperty =
            BindableProperty.Create("ChevronFontFace", typeof(string), typeof(ChevronViewCell<T, TC>), FontAwesome.Typeface, propertyChanged: OnChevronFontFaceChanged);

        public static readonly BindableProperty ChevronColorProperty =
            BindableProperty.Create("ChevronColor", typeof(Color), typeof(ChevronViewCell<T, TC>), Color.Default, propertyChanged: OnChevronColorChanged);

        private static void OnChevronFontFaceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!String.IsNullOrEmpty((string)newValue))
                (bindable as ChevronViewCell<T, TC>).chevron.FontFamily = (string)newValue;
            else
                (bindable as ChevronViewCell<T, TC>).chevron.FontFamily = null;
        }

        public Color ChevronColor
        {
            get
            {
                return (Color)GetValue(ChevronViewCell<T, TC>.ChevronColorProperty);
            }
            set
            {
                SetValue(ChevronViewCell<T, TC>.ChevronColorProperty, value);
            }
        }

        private static void OnChevronColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                (bindable as ChevronViewCell<T, TC>).chevron.TextColor = (Color)newValue;
            else
                (bindable as ChevronViewCell<T, TC>).chevron.TextColor = Color.Transparent;
        }

        #endregion Properties

        #region Designer

        private void InitializeComponent()
        {
            // chevron
            chevron = new Icon(ChevronPictogram.GetFontFace(), ChevronStyle)
            {
                TextColor = ChevronColor,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = Helpers.Common.GetNamedSize(NamedSize.Medium),
                AutoSize = true
            };

            // content
            StackLayout content = (StackLayout)View;
            content.Children.Add(chevron);
        }

        #endregion Designer

        private int chevronStyle = (int)FontAwesome.IconType.chevron_right;

        public int ChevronStyle { get { return chevronStyle; } set { chevronStyle = value; } }

        private Icon chevron;

        public Pictogram ChevronPictogram = FontAwesome.Instance;
    }

    public class ChevronViewCell<T> : ChevronViewCell<T, FontAwesome> where T : Pictogram
    {
        public ChevronViewCell()
            : base()
        {
            ChevronStyle = (int)FontAwesome.IconType.chevron_right;
        }
    }

    public class ChevronViewCell : ChevronViewCell<FontAwesome, FontAwesome>
    {
        public ChevronViewCell()
            : base()
        {
        }
    }
}