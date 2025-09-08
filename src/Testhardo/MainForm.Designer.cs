namespace Testhardo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            crownStatusStrip1 = new ReaLTaiizor.Controls.CrownStatusStrip();
            ImportButton = new ReaLTaiizor.Controls.CrownButton();
            SuspendLayout();
            // 
            // crownStatusStrip1
            // 
            crownStatusStrip1.AutoSize = false;
            crownStatusStrip1.BackColor = Color.FromArgb(60, 63, 65);
            crownStatusStrip1.ForeColor = Color.FromArgb(220, 220, 220);
            crownStatusStrip1.Location = new Point(0, 616);
            crownStatusStrip1.Name = "crownStatusStrip1";
            crownStatusStrip1.Padding = new Padding(0, 5, 0, 3);
            crownStatusStrip1.Size = new Size(1323, 24);
            crownStatusStrip1.SizingGrip = false;
            crownStatusStrip1.TabIndex = 0;
            crownStatusStrip1.Text = "crownStatusStrip1";
            // 
            // ImportButton
            // 
            ImportButton.Image = Properties.Resources.Download_1;
            ImportButton.ImagePadding = 0;
            ImportButton.Location = new Point(42, 36);
            ImportButton.Name = "ImportButton";
            ImportButton.Padding = new Padding(5);
            ImportButton.Size = new Size(153, 23);
            ImportButton.TabIndex = 1;
            ImportButton.Text = "Import";
            ImportButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 640);
            Controls.Add(ImportButton);
            Controls.Add(crownStatusStrip1);
            Name = "MainForm";
            Text = "Testhardo!";
            TransparencyKey = Color.Fuchsia;
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CrownStatusStrip crownStatusStrip1;
        private ReaLTaiizor.Controls.CrownButton ImportButton;
    }
}
