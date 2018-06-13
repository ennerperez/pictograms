namespace Pictogram.Samples.WinForms
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelFont = new System.Windows.Forms.Label();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonLiveDemo2 = new System.Windows.Forms.Button();
            this.buttonLiveDemo1 = new System.Windows.Forms.Button();
            this.panelLiveDemo = new System.Windows.Forms.Panel();
            this.toolStripLiveDemo = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLiveDemo = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonLiveDemo = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemLiveDemoOption1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLiveDemoOption2 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.listViewItems = new System.Windows.Forms.ListView();
            this.labelInformation = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.openFileDialogCustom = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panelLiveDemo.SuspendLayout();
            this.toolStripLiveDemo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(12, 9);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(31, 13);
            this.labelFont.TabIndex = 0;
            this.labelFont.Text = "&Font:";
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(15, 25);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(389, 21);
            this.comboBoxFont.TabIndex = 1;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxFont_SelectedIndexChanged);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(410, 51);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxPreview.TabIndex = 10;
            this.pictureBoxPreview.TabStop = false;
            // 
            // buttonLiveDemo2
            // 
            this.buttonLiveDemo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLiveDemo2.Location = new System.Drawing.Point(12, 28);
            this.buttonLiveDemo2.Name = "buttonLiveDemo2";
            this.buttonLiveDemo2.Size = new System.Drawing.Size(106, 33);
            this.buttonLiveDemo2.TabIndex = 1;
            this.buttonLiveDemo2.Text = "button1";
            this.buttonLiveDemo2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLiveDemo2.UseVisualStyleBackColor = true;
            // 
            // buttonLiveDemo1
            // 
            this.buttonLiveDemo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLiveDemo1.Location = new System.Drawing.Point(12, 67);
            this.buttonLiveDemo1.Name = "buttonLiveDemo1";
            this.buttonLiveDemo1.Size = new System.Drawing.Size(106, 33);
            this.buttonLiveDemo1.TabIndex = 2;
            this.buttonLiveDemo1.Text = "button2";
            this.buttonLiveDemo1.UseVisualStyleBackColor = true;
            // 
            // panelLiveDemo
            // 
            this.panelLiveDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLiveDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLiveDemo.Controls.Add(this.buttonLiveDemo1);
            this.panelLiveDemo.Controls.Add(this.toolStripLiveDemo);
            this.panelLiveDemo.Controls.Add(this.buttonLiveDemo2);
            this.panelLiveDemo.Location = new System.Drawing.Point(410, 185);
            this.panelLiveDemo.Name = "panelLiveDemo";
            this.panelLiveDemo.Size = new System.Drawing.Size(128, 128);
            this.panelLiveDemo.TabIndex = 15;
            // 
            // toolStripLiveDemo
            // 
            this.toolStripLiveDemo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLiveDemo,
            this.toolStripDropDownButtonLiveDemo});
            this.toolStripLiveDemo.Location = new System.Drawing.Point(0, 0);
            this.toolStripLiveDemo.Name = "toolStripLiveDemo";
            this.toolStripLiveDemo.Size = new System.Drawing.Size(126, 25);
            this.toolStripLiveDemo.TabIndex = 0;
            this.toolStripLiveDemo.Text = "toolStrip1";
            // 
            // toolStripButtonLiveDemo
            // 
            this.toolStripButtonLiveDemo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLiveDemo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLiveDemo.Image")));
            this.toolStripButtonLiveDemo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLiveDemo.Name = "toolStripButtonLiveDemo";
            this.toolStripButtonLiveDemo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLiveDemo.Text = "toolStripButton1";
            // 
            // toolStripDropDownButtonLiveDemo
            // 
            this.toolStripDropDownButtonLiveDemo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLiveDemoOption1,
            this.toolStripMenuItemLiveDemoOption2});
            this.toolStripDropDownButtonLiveDemo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonLiveDemo.Image")));
            this.toolStripDropDownButtonLiveDemo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonLiveDemo.Name = "toolStripDropDownButtonLiveDemo";
            this.toolStripDropDownButtonLiveDemo.Size = new System.Drawing.Size(78, 22);
            this.toolStripDropDownButtonLiveDemo.Text = "Options";
            // 
            // toolStripMenuItemLiveDemoOption1
            // 
            this.toolStripMenuItemLiveDemoOption1.Name = "toolStripMenuItemLiveDemoOption1";
            this.toolStripMenuItemLiveDemoOption1.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItemLiveDemoOption1.Text = "Option 1";
            // 
            // toolStripMenuItemLiveDemoOption2
            // 
            this.toolStripMenuItemLiveDemoOption2.Name = "toolStripMenuItemLiveDemoOption2";
            this.toolStripMenuItemLiveDemoOption2.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItemLiveDemoOption2.Text = "Option  2";
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListIcons.ImageSize = new System.Drawing.Size(48, 48);
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewItems
            // 
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.LargeImageList = this.imageListIcons;
            this.listViewItems.Location = new System.Drawing.Point(15, 52);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(389, 261);
            this.listViewItems.TabIndex = 2;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.SelectedIndexChanged += new System.EventHandler(this.listViewItems_SelectedIndexChanged);
            // 
            // labelInformation
            // 
            this.labelInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(407, 9);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(62, 13);
            this.labelInformation.TabIndex = 3;
            this.labelInformation.Text = "&Information:";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxValue.Location = new System.Drawing.Point(410, 25);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.Size = new System.Drawing.Size(128, 20);
            this.textBoxValue.TabIndex = 4;
            // 
            // openFileDialogCustom
            // 
            this.openFileDialogCustom.DefaultExt = "ttf";
            this.openFileDialogCustom.Filter = "TrueType Font|*.ttf";
            this.openFileDialogCustom.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogCustom_FileOk);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 328);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.panelLiveDemo);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.comboBoxFont);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelFont);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pictograms";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panelLiveDemo.ResumeLayout(false);
            this.panelLiveDemo.PerformLayout();
            this.toolStripLiveDemo.ResumeLayout(false);
            this.toolStripLiveDemo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button buttonLiveDemo2;
        private System.Windows.Forms.Button buttonLiveDemo1;
        private System.Windows.Forms.Panel panelLiveDemo;
        private System.Windows.Forms.ToolStrip toolStripLiveDemo;
        private System.Windows.Forms.ToolStripButton toolStripButtonLiveDemo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonLiveDemo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLiveDemoOption1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLiveDemoOption2;
        public System.Windows.Forms.ImageList imageListIcons;
        public System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.OpenFileDialog openFileDialogCustom;
    }
}

