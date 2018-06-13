using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Pictograms;
using System.Windows.Forms;
using System.Windows.Forms.Pictograms;
using System.Threading.Tasks;
using System.Net;
using System.IO;

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

                    comboBoxFont.DisplayMember = "Key";
                    comboBoxFont.ValueMember = "Value";
                    comboBoxFont.DataSource = datasource;
                }));
            });
        }

        private async void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
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

                if (instance.FontFamily == null)
                {
                    var url = instance.GetUrl();

                    var fontCacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "fonts");
                    if (!Directory.Exists(fontCacheFolder))
                        Directory.CreateDirectory(fontCacheFolder);

                    var fileName = Path.Combine(fontCacheFolder, $"{instance.GetName().ToLower()}.ttf");

                    if (File.Exists(fileName) && new FileInfo(fileName).Length == 0)
                        File.Delete(fileName);

                    if (!File.Exists(fileName))
                    {
                        using (var wc = new WebClient())
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            wc.DownloadFile(url, fileName);
                        }
                    }

                    if (File.Exists(fileName))
                        instance.InitializeFont(File.ReadAllBytes(fileName));
                }

                listViewItems.Items.Clear();
                imageListIcons.Images.Clear();

                Task task = null;
                var TIcons = System.Drawing.Pictogram.GetIconTypes(TFont);
                if (TIcons != null)
                {
                    if (TIcons.IsEnum)
                    {
                        icons = Enum.GetNames(TIcons);
                        task = Task.Run(() =>
                        {
                            if (icons != null)
                                foreach (var item in icons)
                                {
                                    object icon = Enum.Parse(TIcons, item, true);
                                    var img = instance.GetImage((int)icon, 48);
                                    listViewItems.Invoke((MethodInvoker)delegate
                                    {
                                        imageListIcons.Images.Add(item, img);
                                        listViewItems.Items.Add(item, icons.IndexOf(item));
                                    });
                                };
                        });
                    }
                    else if (TIcons.BaseType == typeof(Tuple<int, int>))
                    {
                        var tuple = (Tuple<int, int>)Activator.CreateInstance(TIcons);
                        task = Task.Run(() =>
                        {
                            for (int i = tuple.Item1; i < tuple.Item2; i++)
                            {
                                var img = instance.GetImage(i, 48);
                                listViewItems.Invoke((MethodInvoker)delegate
                                {
                                    imageListIcons.Images.Add(i.ToString(), img);
                                    listViewItems.Items.Add(new ListViewItem(i.ToString()) { ImageKey = i.ToString() });
                                });
                            }
                        });
                    }
                }
                else
                {
                    task = Task.Run(() =>
                    {
                        for (int i = 0; i < 241; i++)
                        {
                            var img = instance.GetImage(i, 48);
                            listViewItems.Invoke((MethodInvoker)delegate
                            {
                                imageListIcons.Images.Add(i.ToString(), img);
                                listViewItems.Items.Add(i.ToString(), i);
                            });
                        }
                    });
                }
                if (task != null)
                    await task;
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
                if (TIcons != null && TIcons.IsEnum)
                    icon = Enum.Parse(TIcons, item, true);
                else
                    icon = int.Parse(listViewItems.SelectedItems[0].Text);

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