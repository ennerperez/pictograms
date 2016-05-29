using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace System.Windows.Forms.Pictograms
{
    public static class Extensions
    {

        #region Generics<T>

        public static void SetImage<T>(this Control @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = (T)Activator.CreateInstance(typeof(T), true);
            SetImage(@this, instance, type, size, color, brush);
        }
        public static void SetText<T>(this Control @this, object type, float size = 0) where T : Pictogram
        {
            T instance = (T)Activator.CreateInstance(typeof(T), true);
            SetText(@this, instance, type, size);
        }

        public static void SetImage<T>(this Component @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = (T)Activator.CreateInstance(typeof(T), true);
            SetImage(@this, instance, type, size, color, brush);
        }
        public static void SetText<T>(this Component @this, object type, float size = 0) where T : Pictogram
        {
            T instance = (T)Activator.CreateInstance(typeof(T), true);
            SetText(@this, instance, type, size);
        }

        public static void SetIcon<T>(this NotifyIcon @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = (T)Activator.CreateInstance(typeof(T), true);
            SetIcon(@this, instance, type, size, color, brush);
        }
        public static void SetIcon<T>(this ImageList @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = (T)Activator.CreateInstance(typeof(T), true);
            SetIcon(@this, instance, type, size, color, brush);
        }

        #endregion

        public static void SetImage(this Control @this, Pictogram pictogram, object type, int size = 0, Color? color = null, Brush brush = null)
        {
            if (size == 0)
                size = (@this.Width + @this.Height) / 2;

            if (color == null)
                color = @this.ForeColor;

            if (brush == null)
                brush = new SolidBrush(color.Value);

            var image = pictogram.GetImage((int)type, size, brush);

            if (typeof(ButtonBase).IsAssignableFrom(@this.GetType()))
                (@this as ButtonBase).Image = image;
            if (typeof(PictureBox).IsAssignableFrom(@this.GetType()))
                (@this as PictureBox).Image = image;
            if (typeof(Panel).IsAssignableFrom(@this.GetType()))
                (@this as Panel).BackgroundImage = image;
            if (typeof(GroupBox).IsAssignableFrom(@this.GetType()))
                (@this as GroupBox).BackgroundImage = image;
        }
        public static void SetText(this Control @this, Pictogram pictogram, object type, float size = 0)
        {
            if (size == 0)
                size = @this.Font.Size;

            if (typeof(ButtonBase).IsAssignableFrom(@this.GetType()) ||
                typeof(Label).IsAssignableFrom(@this.GetType()) ||
                typeof(GroupBox).IsAssignableFrom(@this.GetType()) ||
                typeof(TabPage).IsAssignableFrom(@this.GetType()))
            {
                @this.Text = pictogram.GetText((int)type);
                @this.Font = new Font(pictogram.FontFamily, size, @this.Font.Style, @this.Font.Unit);
            }
        }

        public static void SetImage(this Component @this, Pictogram pictogram, object type, int size = 0, Color? color = null, Brush brush = null)
        {

            if (typeof(ToolStripItem).IsAssignableFrom(@this.GetType()))
            {
                if (size == 0)
                    size = ((@this as ToolStripItem).Width + (@this as ToolStripItem).Height) / 2;

                if (color == null)
                    color = (@this as ToolStripItem).ForeColor;

                if (brush == null)
                    brush = new SolidBrush(color.Value);

                var image = pictogram.GetImage((int)type, size, brush);

                (@this as ToolStripItem).Image = image;
            }
            else if (typeof(NotifyIcon).IsAssignableFrom(@this.GetType()))
            {

                if (color == null)
                    color = SystemColors.ControlText;

                if (size == 0)
                    size = 16;

                if (brush == null)
                    brush = new SolidBrush(color.Value);

                var image = pictogram.GetImage((int)type, size, brush);
                var hIcon = new Bitmap(image).GetHicon();

                (@this as NotifyIcon).Icon = Icon.FromHandle(hIcon);
            }
            else if (typeof(ImageList).IsAssignableFrom(@this.GetType()))
            {
                if (color == null)
                    color = SystemColors.ControlText;

                if (size == 0)
                    size = ((@this as ImageList).ImageSize.Width + (@this as ImageList).ImageSize.Height) / 2;

                if (brush == null)
                    brush = new SolidBrush(color.Value);

                var image = pictogram.GetImage((int)type, size, brush);

                (@this as ImageList).Images.Add(image);

            }


        }
        public static void SetText(this Component @this, Pictogram pictogram, object type, float size = 0)
        {

            if (typeof(ToolStripItem).IsAssignableFrom(@this.GetType()))
            {
                if (size == 0)
                    size = (@this as ToolStripItem).Font.Size;

                var text = pictogram.GetText((int)type);

                if ((@this as ToolStripItem).Text == (@this as ToolStripItem).ToolTipText)
                    (@this as ToolStripItem).ToolTipText = (@this as ToolStripItem).Text;

                (@this as ToolStripItem).Text = text;
                (@this as ToolStripItem).Font = new Font(pictogram.FontFamily, size, (@this as ToolStripItem).Font.Style, (@this as ToolStripItem).Font.Unit);
            }
        }

        public static void SetIcon(this NotifyIcon @this, Pictogram pictogram, object type, int size = 0, Color? color = null, Brush brush = null)
        {
            if (size == 0)
                size = 16;

            SetImage(@this, pictogram, type, size, color, brush);

        }
        public static void SetIcon(this ImageList @this, Pictogram pictogram, object type, int size = 0, Color? color = null, Brush brush = null)
        {

            if (color == null)
                color = SystemColors.ControlText;

            if (size == 0)
                size = (@this.ImageSize.Width + @this.ImageSize.Height) / 2;

            if (brush == null)
                brush = new SolidBrush(color.Value);

            var image = pictogram.GetImage((int)type, size, brush);

            var hIcon = new Bitmap(image).GetHicon();
            var icon = Icon.FromHandle(hIcon);

            @this.Images.Add(icon);

        }
        
    }
}
