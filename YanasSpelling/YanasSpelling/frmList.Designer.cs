namespace YanasSpelling
{
    partial class frmList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstList
            // 
            this.lstList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstList.FormattingEnabled = true;
            this.lstList.Location = new System.Drawing.Point(0, 0);
            this.lstList.Name = "lstList";
            this.lstList.Size = new System.Drawing.Size(322, 261);
            this.lstList.TabIndex = 0;
            this.lstList.DoubleClick += new System.EventHandler(this.lstList_DoubleClick);
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 261);
            this.Controls.Add(this.lstList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstList;
    }
}