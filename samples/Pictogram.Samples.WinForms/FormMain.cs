using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Pictograms;
using System.Windows.Forms;
using System.Windows.Forms.Pictograms;

namespace Pictogram.Samples.WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {

            var fontsTypes = System.Reflection.Assembly.GetAssembly(typeof(System.Drawing.Pictogram)).GetTypes()
                .Where(t => t.BaseType == typeof(System.Drawing.Pictogram)).Select(t => Activator.CreateInstance(t, true));

            fonts = new List<string> { string.Empty };
            (fonts as List<string>).AddRange(fontsTypes.Select(m => (m as System.Drawing.Pictogram).FontFamily.Name).ToArray());
            comboBoxFont.DataSource = fonts;
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            instance = null;
            icons = null;
            clear();

            if (comboBoxFont.SelectedItem.ToString() == fonts[1])
            {
                instance = FontAwesome.Instance;
                icons = Enum.GetNames(typeof(FontAwesome.IconType));
            }
            else if (comboBoxFont.SelectedItem.ToString() == fonts[2])
            {
                instance = Foundation.Instance;
                icons = Enum.GetNames(typeof(Foundation.IconType));
            }
            else if (comboBoxFont.SelectedItem.ToString() == fonts[3])
            {
                instance = LinearIcons.Instance;
                icons = Enum.GetNames(typeof(LinearIcons.IconType));
            }
            else if (comboBoxFont.SelectedItem.ToString() == fonts[4])
            {
                instance = MaterialDesign.Instance;
                icons = Enum.GetNames(typeof(MaterialDesign.IconType));
            }

            listViewItems.Items.Clear();
            imageListIcons.Images.Clear();

            if (icons != null)
                foreach (var item in icons)
                {
                    object icon = null;
                    if (comboBoxFont.SelectedItem.ToString() == fonts[1])
                        icon = Enum.Parse(typeof(FontAwesome.IconType), item, true);
                    else if (comboBoxFont.SelectedItem.ToString() == fonts[2])
                        icon = Enum.Parse(typeof(Foundation.IconType), item, true);
                    else if (comboBoxFont.SelectedItem.ToString() == fonts[3])
                        icon = Enum.Parse(typeof(LinearIcons.IconType), item, true);
                    else if (comboBoxFont.SelectedItem.ToString() == fonts[4])
                        icon = Enum.Parse(typeof(MaterialDesign.IconType), item, true);

                    var img = instance.GetImage((int)icon, 48);
                    imageListIcons.Images.Add(item, img);
                    listViewItems.Items.Add(item, icons.IndexOf(item));
                };
        }

        private IList<string> fonts;
        private IList<string> icons;
        private System.Drawing.Pictogram instance;

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems != null && listViewItems.SelectedItems.Count > 0)
            {
                var item = listViewItems.SelectedItems[0].Text;
                object icon = null;
                if (comboBoxFont.SelectedItem.ToString() == fonts[1])
                    icon = Enum.Parse(typeof(FontAwesome.IconType), item, true);
                else if (comboBoxFont.SelectedItem.ToString() == fonts[2])
                    icon = Enum.Parse(typeof(Foundation.IconType), item, true);
                else if (comboBoxFont.SelectedItem.ToString() == fonts[3])
                    icon = Enum.Parse(typeof(LinearIcons.IconType), item, true);
                else if (comboBoxFont.SelectedItem.ToString() == fonts[4])
                    icon = Enum.Parse(typeof(MaterialDesign.IconType), item, true);

                textBoxValue.Text = ((int)icon).ToString();

                pictureBoxPreview.Image = instance.GetImage((int)icon, pictureBoxPreview.Width);
                buttonLiveDemo2.SetImage(instance, icon, 24);
                buttonLiveDemo1.SetText(instance, icon);

                toolStripButtonLiveDemo.SetImage(instance, icon);
                toolStripDropDownButtonLiveDemo.SetImage(instance, icon);
                toolStripMenuItemLiveDemoOption1.SetImage(instance, icon);
                toolStripMenuItemLiveDemoOption2.SetImage(instance, icon);
            }
            else
                clear();
        }
        private void clear()
        {
            textBoxValue.Text = string.Empty;

            pictureBoxPreview.Image = null;
            buttonLiveDemo2.Image = null;
            buttonLiveDemo1.Text = buttonLiveDemo1.Name;

            toolStripButtonLiveDemo.Image = null;
            toolStripDropDownButtonLiveDemo.Image = null;
            toolStripMenuItemLiveDemoOption1.Image = null;
            toolStripMenuItemLiveDemoOption2.Image = null;
        }

    }
}