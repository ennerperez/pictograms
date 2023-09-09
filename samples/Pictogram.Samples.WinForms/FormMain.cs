using System;
using System.Linq;
using System.Collections.Generic;
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
                var fontsTypes = System.Reflection.Assembly.GetAssembly(typeof(System.Drawing.Pictogram))
                    ?.GetTypes()
                    .Where(t => t.BaseType == typeof(System.Drawing.Pictogram)).Select(t => System.Drawing.Pictogram.GetInstance(t));

                _fonts = fontsTypes.ToDictionary(k => k.GetName(), v => v);

                comboBoxFont.Invoke(() =>
                {
                    var datasource = _fonts.ToList();
                    datasource.Insert(0, new KeyValuePair<string, System.Drawing.Pictogram>(string.Empty, null));
                    datasource.Add(new KeyValuePair<string, System.Drawing.Pictogram>("Untitled", System.Drawing.Pictogram.GetInstance<Untitled>()));
                    datasource.Add(new KeyValuePair<string, System.Drawing.Pictogram>("Nucleo", System.Drawing.Pictogram.GetInstance<Nucleo>()));

                    comboBoxFont.DisplayMember = "Key";
                    comboBoxFont.ValueMember = "Value";
                    comboBoxFont.DataSource = datasource;
                });
            });
        }

        private async void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _instance = null;
            _icons = null;
            Clear();

            if (comboBoxFont.SelectedValue != null)
            {
                //var fontName = (comboBoxFont.SelectedValue as System.Drawing.Pictogram).GetName();
                var tfont = (comboBoxFont.SelectedValue as System.Drawing.Pictogram)?.GetType();
                _instance = System.Drawing.Pictogram.GetInstance(tfont);

                if (_instance.FontFamily == null)
                {
                    var url = _instance.GetUrl();

                    var fontCacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "fonts");
                    if (!Directory.Exists(fontCacheFolder))
                        Directory.CreateDirectory(fontCacheFolder);

                    var fileName = Path.Combine(fontCacheFolder, $"{_instance.GetName().ToLower()}.ttf");

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
                        _instance.InitializeFont(File.ReadAllBytes(fileName));
                }

                listViewItems.Items.Clear();
                imageListIcons.Images.Clear();

                Task task = null;
                var ticons = System.Drawing.Pictogram.GetIconTypes(tfont);
                if (ticons != null)
                {
                    if (ticons.IsEnum)
                    {
                        _icons = Enum.GetNames(ticons);
                        task = Task.Run(() =>
                        {
                            if (_icons != null)
                                foreach (var item in _icons)
                                {
                                    object icon = Enum.Parse(ticons, item, true);
                                    var img = _instance.GetImage((int)icon, 48);
                                    listViewItems.Invoke((MethodInvoker)delegate
                                    {
                                        imageListIcons.Images.Add(item, img);
                                        listViewItems.Items.Add(item, _icons.IndexOf(item));
                                        labelCounter.Text = string.Format(labelCounter.Tag.ToString(), listViewItems.Items.Count);
                                    });
                                }
                        });
                    }
                    else if (ticons.BaseType == typeof(Tuple<int, int>))
                    {
                        var tuple = (Tuple<int, int>)Activator.CreateInstance(ticons);
                        task = Task.Run(() =>
                        {
                            for (int i = tuple.Item1; i < tuple.Item2; i++)
                            {
                                var img = _instance.GetImage(i, 48);
                                var i1 = i;
                                listViewItems.Invoke((MethodInvoker)delegate
                                {
                                    imageListIcons.Images.Add(i1.ToString(), img);
                                    listViewItems.Items.Add(new ListViewItem(i1.ToString()) { ImageKey = i1.ToString() });
                                    labelCounter.Text = string.Format(labelCounter.Tag.ToString() ?? string.Empty, listViewItems.Items.Count);
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
                            var img = _instance.GetImage(i, 48);
                            var i1 = i;
                            listViewItems.Invoke((MethodInvoker)delegate
                            {
                                imageListIcons.Images.Add(i1.ToString(), img);
                                listViewItems.Items.Add(i1.ToString(), i1);
                                labelCounter.Text = string.Format(labelCounter.Tag.ToString() ?? string.Empty, listViewItems.Items.Count);
                            });
                        }
                    });
                }
                if (task != null)
                    await task;
            }

            Cursor = Cursors.Default;
        }

        private Dictionary<string, System.Drawing.Pictogram> _fonts;
        private IList<string> _icons;
        private System.Drawing.Pictogram _instance;

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                var item = listViewItems.SelectedItems[0].Text;
                var tfont = (comboBoxFont.SelectedValue as System.Drawing.Pictogram)?.GetType();

                var ticons = System.Drawing.Pictogram.GetIconTypes(tfont);
                object icon;
                if (ticons != null && ticons.IsEnum)
                    icon = Enum.Parse(ticons, item, true);
                else
                    icon = int.Parse(listViewItems.SelectedItems[0].Text);

                textBoxValue.Text = ((int)icon).ToString();

                pictureBoxPreview.Image = _instance.GetImage((int)icon, pictureBoxPreview.Width);
                buttonLiveDemo2.SetImage(_instance, icon, 24);
                buttonLiveDemo1.SetText(_instance, icon);

                toolStripButtonLiveDemo.SetImage(_instance, icon);
                toolStripDropDownButtonLiveDemo.SetImage(_instance, icon);
                toolStripMenuItemLiveDemoOption1.SetImage(_instance, icon);
                toolStripMenuItemLiveDemoOption2.SetImage(_instance, icon);
            }
            else
                Clear();
        }

        private void Clear()
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