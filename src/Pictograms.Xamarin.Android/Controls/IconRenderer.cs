using Android.Graphics;
using Android.Widget;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Pictograms.Icon), typeof(Xamarin.Android.Pictograms.IconRenderer))]

namespace Xamarin.Android.Pictograms
{
    /// <summary>
    /// Add the Font.ttf to the Assets folder and mark as "Android Asset"
    /// </summary>
    public class IconRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var fontFamily = ((Label)sender).FontFamily;
            if (!string.IsNullOrEmpty(fontFamily))
            {
                if (!fontFamily.Contains(".ttf"))
                    fontFamily += ".ttf";
                var typeface = Typeface.CreateFromAsset(Forms.Forms.Context.Assets, "Fonts/" + fontFamily);

                var label = ((TextView)Control);
                label.Typeface = typeface;
            }
        }
    }
}