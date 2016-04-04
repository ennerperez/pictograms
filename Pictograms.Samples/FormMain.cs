using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Pictograms;

namespace System.Drawing.Pictograms.Samples
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            button11.Image = FontAwesome.GetImage(FontAwesome.IconType.windows, (int)button11.Font.Size);
            button12.Image = Foundation.GetImage(Foundation.IconType.calendar, (int)button12.Font.Size);
            button13.Image = LinearIcons.GetImage(LinearIcons.IconType.smile, (int)button13.Font.Size);
            button14.Image = MaterialDesign.GetImage(MaterialDesign.IconType.android, (int)button14.Font.Size);

            button21.Text= FontAwesome.GetText(FontAwesome.IconType.windows);
            button22.Text = Foundation.GetText(Foundation.IconType.calendar);
            button23.Text = LinearIcons.GetText(LinearIcons.IconType.smile);
            button24.Text = MaterialDesign.GetText(MaterialDesign.IconType.android);

            button21.Font = FontAwesome.GetFont(button21.Font.Size);
            button22.Font = Foundation.GetFont(button22.Font.Size);
            button23.Font = LinearIcons.GetFont(button23.Font.Size);
            button24.Font = MaterialDesign.GetFont(button24.Font.Size);

        }
    }
}
