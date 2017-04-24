using Android.Graphics;
using System.ComponentModel;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Pictograms.Button), typeof(Xamarin.Android.Pictograms.ButtonRenderer))]

namespace Xamarin.Android.Pictograms
{
    /// <summary>
    /// Add the Font.ttf to the Assets folder and mark as "Android Asset"
    /// </summary>
    public class ButtonRenderer : Forms.Platform.Android.ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var fontFamily = ((Forms.Button)sender).FontFamily;
            if (!string.IsNullOrEmpty(fontFamily))
            {
                if (!fontFamily.Contains(".ttf"))
                    fontFamily += ".ttf";
                var typeface = Typeface.CreateFromAsset(Forms.Forms.Context.Assets, "Fonts/" + fontFamily);

                var control = ((global::Android.Widget.Button)Control);
                control.SetTypeface(typeface, TypefaceStyle.Normal);
            }
        }
    }
}