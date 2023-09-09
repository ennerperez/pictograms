﻿using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms.Pictograms
{
    public static class Extensions
    {
        #region Generics<T>

        public static void SetImage<T>(this Control @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = Pictogram.GetInstance<T>();
            SetImage(@this, instance, type, size, color, brush);
        }

        public static void SetText<T>(this Control @this, object type, float size = 0) where T : Pictogram
        {
            T instance = Pictogram.GetInstance<T>();
            SetText(@this, instance, type, size);
        }

        public static void SetImage<T>(this Component @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = Pictogram.GetInstance<T>();
            SetImage(@this, instance, type, size, color, brush);
        }

        public static void SetText<T>(this Component @this, object type, float size = 0) where T : Pictogram
        {
            T instance = Pictogram.GetInstance<T>();
            SetText(@this, instance, type, size);
        }

        public static void SetIcon<T>(this NotifyIcon @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = Pictogram.GetInstance<T>();
            SetIcon(@this, instance, type, size, color, brush);
        }

        public static void SetIcon<T>(this ImageList @this, object type, int size = 0, Color? color = null, Brush brush = null) where T : Pictogram
        {
            T instance = Pictogram.GetInstance<T>();
            SetIcon(@this, instance, type, size, color, brush);
        }

        #endregion Generics<T>

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
                ((ButtonBase)@this).Image = image;
            if (typeof(PictureBox).IsAssignableFrom(@this.GetType()))
                ((PictureBox)@this).Image = image;
            if (typeof(Panel).IsAssignableFrom(@this.GetType()))
                ((Panel)@this).BackgroundImage = image;
            if (typeof(GroupBox).IsAssignableFrom(@this.GetType()))
                ((GroupBox)@this).BackgroundImage = image;
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
                    size = (((ToolStripItem)@this).Width + (@this as ToolStripItem).Height) / 2;

                if (color == null)
                    color = (@this as ToolStripItem)?.ForeColor;

                if (brush == null && color != null)
                        brush = new SolidBrush(color.Value);

                var image = pictogram.GetImage((int)type, size, brush);

                ((ToolStripItem)@this).Image = image;
            }
            else if (typeof(NotifyIcon).IsAssignableFrom(@this.GetType()))
            {
                if (size == 0)
                    size = 16;

                if (color == null)
                    color = SystemColors.ControlText;

                if (brush == null)
                    brush = new SolidBrush(color.Value);

                var image = pictogram.GetImage((int)type, size, brush);
                var hIcon = new Bitmap(image).GetHicon();

                ((NotifyIcon)@this).Icon = Icon.FromHandle(hIcon);
            }
            else if (typeof(ImageList).IsAssignableFrom(@this.GetType()))
            {
                if (size == 0)
                    size = (((ImageList)@this).ImageSize.Width + (@this as ImageList).ImageSize.Height) / 2;

                if (color == null)
                    color = SystemColors.ControlText;

                if (brush == null)
                    brush = new SolidBrush(color.Value);

                var image = pictogram.GetImage((int)type, size, brush);

                (@this as ImageList)?.Images.Add(image);
            }
        }

        public static void SetText(this Component @this, Pictogram pictogram, object type, float size = 0)
        {
            if (typeof(ToolStripItem).IsAssignableFrom(@this.GetType()))
            {
                if (size == 0)
                    size = ((ToolStripItem)@this).Font.Size;

                var text = pictogram.GetText((int)type);

                if ((@this as ToolStripItem)?.Text == (@this as ToolStripItem)?.ToolTipText)
                    ((ToolStripItem)@this).ToolTipText = (@this as ToolStripItem)?.Text;

                ((ToolStripItem)@this).Text = text;
                ((ToolStripItem)@this).Font = new Font(pictogram.FontFamily, size, ((ToolStripItem)@this).Font.Style, ((ToolStripItem)@this).Font.Unit);
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
            if (size == 0)
                size = (@this.ImageSize.Width + @this.ImageSize.Height) / 2;

            if (color == null)
                color = SystemColors.ControlText;

            if (brush == null)
                brush = new SolidBrush(color.Value);

            var image = pictogram.GetImage((int)type, size, brush);

            var hIcon = new Bitmap(image).GetHicon();
            var icon = Icon.FromHandle(hIcon);

            @this.Images.Add(icon);
        }

        #region Simplified

        public static void SetImage(this Control @this, object type, int size = 0, Color? color = null, Brush brush = null)
        {
            var declaringType = type.GetType().DeclaringType;
            var instance = Pictogram.GetInstance(declaringType);
            @this.SetImage(instance, type, size, color, brush);
        }

        public static void SetText(this Control @this, object type, float size = 0)
        {
            var declaringType = type.GetType().DeclaringType;
            var instance = Pictogram.GetInstance(declaringType);
            @this.SetText(instance, type, size);
        }

        public static void SetImage(this Component @this, object type, int size = 0, Color? color = null, Brush brush = null)
        {
            var declaringType = type.GetType().DeclaringType;
            var instance = Pictogram.GetInstance(declaringType);
            @this.SetImage(instance, type, size, color, brush);
        }

        public static void SetText(this Component @this, object type, float size = 0)
        {
            var declaringType = type.GetType().DeclaringType;
            var instance = Pictogram.GetInstance(declaringType);
            @this.SetText(instance, type, size);
        }

        public static void SetIcon(this NotifyIcon @this, object type, int size = 0, Color? color = null, Brush brush = null)
        {
            var declaringType = type.GetType().DeclaringType;
            var instance = Pictogram.GetInstance(declaringType);
            @this.SetIcon(instance, type, size, color, brush);
        }

        public static void SetIcon(this ImageList @this, object type, int size = 0, Color? color = null, Brush brush = null)
        {
            var declaringType = type.GetType().DeclaringType;
            var instance = Pictogram.GetInstance(declaringType);
            @this.SetIcon(instance, type, size, color, brush);
        }

        #endregion Simplified
    }
}