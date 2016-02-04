using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Drawing
{
    public class Pictogram
    {

        public Pictogram()
        {
        }

        public Pictogram(byte[] font) : this()
        {
            InitializeFont(font);
        }

        public Pictogram(string fontFile) : this(System.IO.File.ReadAllBytes(fontFile))
        {
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
                return fonts.Families[0];
            }
            private set
            {
            }
        }

        /// <summary>
        /// Store the font in a static variable to quick reference
        /// </summary>
        private Font iconFont;

        /// <summary>
        /// Loads the icon font from the resources.
        /// </summary>
        internal void InitializeFont(byte[] fontData)
        {
            try
            {
                IntPtr fontBuffer = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontBuffer, fontData.Length);

                uint dummy = 0;
                fonts.AddMemoryFont(fontBuffer, fontData.Length);
                Pictogram.AddFontMemResourceEx((IntPtr)fontBuffer, (uint)fontData.Length, IntPtr.Zero, ref dummy);

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
        private void SetFontSize(Graphics g, string IconChar)
        {
            var Width = (int)g.VisibleClipBounds.Width;
            var Height = (int)g.VisibleClipBounds.Height;
            iconFont = GetAdjustedFont(g, IconChar, Width, Height, 4, true);
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
                Font testFont = GetFont((float)adjustedSize);
                // Test the string with the new size
                SizeF adjustedSizeNew = g.MeasureString(graphicString, testFont);
                if (containerWidth > Convert.ToInt32(adjustedSizeNew.Width))
                {
                    return testFont;
                }
            }

            return GetFont(smallestOnFail ? minFontSize : maxFontSize);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        #endregion

        public Image GetImage(int type, int size, Brush brush)
        {
            System.Drawing.Bitmap result = new System.Drawing.Bitmap(size, size);
            string IconChar = char.ConvertFromUtf32((int)type);

            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(result))
            {
                // Set best quality
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                SetFontSize(graphics, IconChar);

                // Measure string so that we can center the icon.
                SizeF stringSize = graphics.MeasureString(IconChar, iconFont, size);
                float w = stringSize.Width;
                float h = stringSize.Height;

                // center icon
                float left = (size - w) / 2;
                float top = (size - h) / 2;

                // Draw string to screen.
                graphics.DrawString(IconChar, iconFont, brush, new PointF(left, top));

            }

            return result;
        }
        public Image GetImage(int type, int size, Color color)
        {
            return GetImage(type, size, new SolidBrush(color));
        }
        public Image GetImage(int type, int size)
        {
            return GetImage(type, size, SystemColors.ControlText);
        }

        public string GetText(int type)
        {
            return char.ConvertFromUtf32((int)type);
        }

        public Font GetFont(float size, GraphicsUnit units = GraphicsUnit.Point)
        {
            return new Font(fonts.Families[0], size, units);
        }
                
    }
}
