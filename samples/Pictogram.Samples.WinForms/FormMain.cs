using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Pictograms;
using System.Windows.Forms;
using System.Windows.Forms.Pictograms;
using System.Threading.Tasks;

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

        private async void FormMain_Shown(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                var fontsTypes = System.Reflection.Assembly.GetAssembly(typeof(System.Drawing.Pictogram)).GetTypes()
                    .Where(t => t.BaseType == typeof(System.Drawing.Pictogram)).Select(t => System.Drawing.Pictogram.GetInstance(t));

                fonts = fontsTypes.ToDictionary(k => k.GetName(), v => v);

                comboBoxFont.Invoke(new Action(() =>
                {
                    var datasource = fonts.ToList();
                    datasource.Insert(0, new KeyValuePair<string, System.Drawing.Pictogram>(string.Empty, null));
                    datasource.Add(new KeyValuePair<string, System.Drawing.Pictogram>("Untitled", System.Drawing.Pictogram.GetInstance<Untitled>()));
                    datasource.Add(new KeyValuePair<string, System.Drawing.Pictogram>("Nucleo", System.Drawing.Pictogram.GetInstance<Nucleo>()));

                    System.Drawing.Pictogram.Download<Nucleo>();

                    comboBoxFont.DisplayMember = "Key";
                    comboBoxFont.ValueMember = "Value";
                    comboBoxFont.DataSource = datasource;
                }));
            });
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            instance = null;
            icons = null;
            clear();

            if (comboBoxFont.SelectedValue != null)
            {

                var fontName = (comboBoxFont.SelectedValue as System.Drawing.Pictogram).GetName();
                var TFont = (comboBoxFont.SelectedValue as System.Drawing.Pictogram).GetType();
                instance = (System.Drawing.Pictogram)System.Drawing.Pictogram.GetInstance(TFont);

                listViewItems.Items.Clear();
                imageListIcons.Images.Clear();

                var TIcons = System.Drawing.Pictogram.GetIconTypes(TFont);
                if (TIcons != null)
                {
                    icons = Enum.GetNames(TIcons);
                    if (icons != null)
                        foreach (var item in icons)
                        {
                            object icon = Enum.Parse(TIcons, item, true);
                            var img = instance.GetImage((int)icon, 48);
                            imageListIcons.Images.Add(item, img);
                            listViewItems.Items.Add(item, icons.IndexOf(item));
                        };
                }
                else
                {
                    for (int i = 0; i < 241; i++)
                    {
                        var img = instance.GetImage(i, 48);
                        imageListIcons.Images.Add(i.ToString(), img);
                        listViewItems.Items.Add(i.ToString(), i);
                    }
                }

            }

            Cursor = Cursors.Default;

        }

        private Dictionary<string, System.Drawing.Pictogram> fonts;
        private IList<string> icons;
        private System.Drawing.Pictogram instance;

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems != null && listViewItems.SelectedItems.Count > 0)
            {
                var item = listViewItems.SelectedItems[0].Text;
                var TFont = (comboBoxFont.SelectedValue as System.Drawing.Pictogram).GetType();

                var TIcons = System.Drawing.Pictogram.GetIconTypes(TFont);
                object icon = null;
                if (TIcons != null)
                    icon = Enum.Parse(TIcons, item, true);
                else
                    icon = int.Parse( listViewItems.SelectedItems[0].Text);

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

        private void openFileDialogCustom_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //instance = new System.Drawing.Pictogram(openFileDialogCustom.FileName);
        }
    }
}