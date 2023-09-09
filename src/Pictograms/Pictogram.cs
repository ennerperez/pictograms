
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net;

#if !PORTABLE

using System.Drawing.Text;
using System.Drawing.Pictograms.Attributes;

namespace System.Drawing
#else
using System;
using Xamarin.Forms.Pictograms.Attributes;

namespace Xamarin.Forms
#endif
{
    public class Pictogram : IDisposable
    {
        public Pictogram()
        {
        }

        internal string name;

        public string GetName()
        {
            if (string.IsNullOrEmpty(name))
#if !PORTABLE
                name = GetType().GetCustomAttributes(true).OfType<PictogramAttribute>().FirstOrDefault().Name;
#else
                name = GetType().GetTypeInfo().GetCustomAttributes(typeof(PictogramAttribute)).OfType<PictogramAttribute>().FirstOrDefault().Name;
#endif
            return name;
        }

        public static string GetName<T>() where T : Pictogram
        {
            return GetInstance<T>().GetName();
        }

        public static string GetName(Type T)
        {
            return GetInstance(T).GetName();
        }

        internal string url;

        public string GetUrl()
        {
            if (string.IsNullOrEmpty(url))
#if !PORTABLE
                url = GetType().GetCustomAttributes(true).OfType<PictogramAttribute>().FirstOrDefault().Url;
#else
                url = GetType().GetTypeInfo().GetCustomAttributes(typeof(PictogramAttribute)).OfType<PictogramAttribute>().FirstOrDefault().Url;
#endif
            return url;
        }

        public static string GetUrl<T>() where T : Pictogram
        {
            return GetInstance<T>().GetUrl();
        }

        public static string GetUrl(Type T)
        {
            return GetInstance(T).GetUrl();
        }

        internal string typeface;

        public string GetTypeface()
        {
            if (string.IsNullOrEmpty(typeface))
#if !PORTABLE
                typeface = GetType().GetCustomAttributes(true).OfType<PictogramAttribute>().FirstOrDefault().Typeface;
#else
                typeface = GetType().GetTypeInfo().GetCustomAttributes(typeof(PictogramAttribute)).OfType<PictogramAttribute>().FirstOrDefault().Typeface;
#endif
            return typeface;
        }

        public static string GetTypeface<T>() where T : Pictogram
        {
            return GetInstance<T>().GetTypeface();
        }

        public static string GetTypeface(Type T)
        {
            return GetInstance(T).GetTypeface();
        }

        public static T GetInstance<T>() where T : Pictogram
        {
#if !PORTABLE
            return (T)typeof(T).GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null, null);
#else
            return (T)typeof(T).GetRuntimeProperty("Instance").GetValue(null);
#endif
        }

        public static Pictogram GetInstance(Type T)
        {
#if !PORTABLE
            if (T.BaseType != typeof(Pictogram))
                throw new InvalidCastException("Type must be a Pictogram based");
            return (Pictogram)T.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null, null);
#else
            if (T.DeclaringType != typeof(Pictogram))
                throw new InvalidCastException("Type must be a Pictogram based");
            return (Pictogram)T.GetRuntimeProperty("Instance").GetValue(null);
#endif
        }

        public static Type GetIconTypes<T>() where T : Pictogram
        {
#if !PORTABLE
            var iconType = typeof(T).Assembly.GetType($"{typeof(T).FullName}+IconType");
#else
            var iconType = typeof(T).GetTypeInfo().Assembly.GetType($"{typeof(T).FullName}+IconType");
#endif
            return iconType;
        }

        public static Type GetIconTypes(Type T)
        {
#if !PORTABLE
            if (T.BaseType != typeof(Pictogram))
                throw new InvalidCastException("Type must be a Pictogram based");
            var iconType = T.Assembly.GetType($"{T.FullName}+IconType");
#else
            if (T.DeclaringType != typeof(Pictogram))
                throw new InvalidCastException("Type must be a Pictogram based");
            var iconType = T.GetTypeInfo().Assembly.GetType($"{T.FullName}+IconType");
#endif
            return iconType;
        }

#if !PORTABLE

        public static void Download<T>() where T : Pictogram
        {
            var instance = GetInstance<T>();
            if (instance == null)
                throw new InvalidOperationException("Can't initialize font instance.");

            var url = instance.GetUrl();

            if (string.IsNullOrEmpty(url))
                throw new InvalidOperationException("Can't download font without an valid URL.");

            var fontCacheFolder = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "fonts");
            if (!IO.Directory.Exists(fontCacheFolder))
                IO.Directory.CreateDirectory(fontCacheFolder);

            var fileName = IO.Path.Combine(fontCacheFolder, $"{typeof(T).Name.ToLower()}.ttf");

            if (IO.File.Exists(fileName) && new IO.FileInfo(fileName).Length == 0)
                IO.File.Delete(fileName);

            if (!IO.File.Exists(fileName))
            {
                try
                {
                    using (var wc = new WebClient())
                        wc.DownloadFile(url, fileName);
                }
                catch (Exception ex)
                {
                    Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            if (IO.File.Exists(fileName))
                instance.InitializeFont(IO.File.ReadAllBytes(fileName));
        }

        public Pictogram(byte[] font) : this()
        {
            InitializeFont(font);
        }

        public Pictogram(string fontFile) : this()
        {
            InitializeFont(IO.File.ReadAllBytes(fontFile));
        }

        /// <summary>
        /// Store the icon font in a static variable to reuse between icons
        /// </summary>
        internal readonly PrivateFontCollection fonts = new PrivateFontCollection();

        /// <summary>
        /// Store the icon font in a static variable to reuse between icons
        /// </summary>
        public FontFamily FontFamily
        {
            get
            {
                return fonts.Families != null && fonts.Families.Any() ? fonts.Families[0] : null;
            }
        }

        /// <summary>
        /// Store the font in a static variable to quick reference
        /// </summary>
        private Font iconFont;

        /// <summary>
        /// Loads the icon font from the resources.
        /// </summary>
        public void InitializeFont(byte[] fontData)
        {
            try
            {
                var fontBuffer = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontBuffer, fontData.Length);

                uint dummy = 0;
                fonts.AddMemoryFont(fontBuffer, fontData.Length);
                NativeMethods.AddFontMemResourceEx(fontBuffer, (uint)fontData.Length, IntPtr.Zero, ref dummy);
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid font data", ex);
            }
        }

        #region Methods

        /// <summary>
        /// Sets a new font with correct size for the allocated space.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="iconChar"></param>
        private void SetFontSize(Graphics g, string iconChar)
        {
            var width = (int)g.VisibleClipBounds.Width;
            var height = (int)g.VisibleClipBounds.Height;
            iconFont = GetAdjustedFont(g, iconChar, width, height, 4, true);
        }

        /// <summary>
        /// Returns a new font that fits the specified character into the allocated space.
        /// </summary>
        /// <param name="g">The graphics object.</param>
        /// <param name="graphicString">The string (icon character) to render as a graphic.</param>
        /// <param name="containerWidth">Width of the container.</param>
        /// <param name="maxFontSize">Size of the max font.</param>
        /// <param name="minFontSize">Size of the min font.</param>
        /// <param name="smallestOnFail">if set to <c>true</c> [smallest on fail].</param>
        /// <returns></returns>
        private Font GetAdjustedFont(Graphics g, string graphicString, int containerWidth, int maxFontSize, int minFontSize, bool smallestOnFail)
        {
            for (double adjustedSize = maxFontSize; adjustedSize >= minFontSize; adjustedSize = adjustedSize - 0.5)
            {
                var testFont = GetFont((float)adjustedSize);
                // Test the string with the new size
                var adjustedSizeNew = g.MeasureString(graphicString, testFont);
                if (containerWidth > Convert.ToInt32(adjustedSizeNew.Width))
                    return testFont;
            }

            return GetFont(smallestOnFail ? minFontSize : maxFontSize);
        }

        #endregion Methods

        public virtual Image GetImage(int type, int size, Brush brush)
        {
            var result = new Bitmap(size, size);
            var iconChar = char.ConvertFromUtf32(type);

            using (var graphics = Graphics.FromImage(result))
            {
                // Set best quality
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality;

                SetFontSize(graphics, iconChar);

                // Measure string so that we can center the icon.
                var stringSize = graphics.MeasureString(iconChar, iconFont, size);
                var w = stringSize.Width;
                var h = stringSize.Height;

                // center icon
                var left = (size - w) / 2;
                var top = (size - h) / 2;

                // Draw string to screen.
                graphics.DrawString(iconChar, iconFont, brush, new PointF(left, top));
            }

            return result;
        }

        public virtual Image GetImage(int type, int size, Color color)
        {
            return GetImage(type, size, new SolidBrush(color));
        }

        public virtual Image GetImage(int type, int size)
        {
            return GetImage(type, size, SystemColors.ControlText);
        }

#endif

        public virtual string GetText(int type)
        {
            return char.ConvertFromUtf32(type);
        }

#if !PORTABLE

        public virtual Font GetFont(float size, GraphicsUnit units = GraphicsUnit.Point)
        {
            return new Font(fonts.Families[0], size, units);
        }

#endif

        #region IDisposable Support

        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
#if !PORTABLE
                    fonts.Dispose();
#endif
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~Pictogram() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}