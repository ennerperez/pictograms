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
            button1.Image = FontAwesome.GetImage(FontAwesome.IconType.Windows, (int)button1.Font.Size);
            button2.Image = Foundation.GetImage(Foundation.IconType.Calendar, (int)button2.Font.Size);
            button3.Image = LinearIcons.GetImage(LinearIcons.IconType.smile, (int)button3.Font.Size);

            button4.Text= FontAwesome.GetText(FontAwesome.IconType.Windows);
            button5.Text = Foundation.GetText(Foundation.IconType.Calendar);
            button6.Text = LinearIcons.GetText(LinearIcons.IconType.smile);

            button4.Font = FontAwesome.GetFont(button4.Font.Size);
            button5.Font = Foundation.GetFont(button5.Font.Size);
            button6.Font = LinearIcons.GetFont(button6.Font.Size);

        }
    }
}
