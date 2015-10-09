namespace TicTacToe
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b1 = new System.Windows.Forms.PictureBox();
            this.b2 = new System.Windows.Forms.PictureBox();
            this.b3 = new System.Windows.Forms.PictureBox();
            this.b6 = new System.Windows.Forms.PictureBox();
            this.b5 = new System.Windows.Forms.PictureBox();
            this.b4 = new System.Windows.Forms.PictureBox();
            this.b9 = new System.Windows.Forms.PictureBox();
            this.b8 = new System.Windows.Forms.PictureBox();
            this.b7 = new System.Windows.Forms.PictureBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbGameBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbP2 = new System.Windows.Forms.GroupBox();
            this.gbP1 = new System.Windows.Forms.GroupBox();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.pbTurn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.b1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b7)).BeginInit();
            this.gbGameBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbP2.SuspendLayout();
            this.gbP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b1.Location = new System.Drawing.Point(14, 19);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(57, 55);
            this.b1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b1.TabIndex = 0;
            this.b1.TabStop = false;
            this.b1.Tag = "0";
            this.b1.Click += new System.EventHandler(this.b_Click);
            // 
            // b2
            // 
            this.b2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b2.Location = new System.Drawing.Point(87, 19);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(57, 55);
            this.b2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b2.TabIndex = 1;
            this.b2.TabStop = false;
            this.b2.Tag = "1";
            this.b2.Click += new System.EventHandler(this.b_Click);
            // 
            // b3
            // 
            this.b3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b3.Location = new System.Drawing.Point(160, 18);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(57, 55);
            this.b3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b3.TabIndex = 2;
            this.b3.TabStop = false;
            this.b3.Tag = "2";
            this.b3.Click += new System.EventHandler(this.b_Click);
            // 
            // b6
            // 
            this.b6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b6.Location = new System.Drawing.Point(160, 79);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(57, 55);
            this.b6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b6.TabIndex = 5;
            this.b6.TabStop = false;
            this.b6.Tag = "5";
            this.b6.Click += new System.EventHandler(this.b_Click);
            // 
            // b5
            // 
            this.b5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b5.Location = new System.Drawing.Point(87, 80);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(57, 55);
            this.b5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b5.TabIndex = 4;
            this.b5.TabStop = false;
            this.b5.Tag = "4";
            this.b5.Click += new System.EventHandler(this.b_Click);
            // 
            // b4
            // 
            this.b4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b4.Location = new System.Drawing.Point(14, 80);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(57, 55);
            this.b4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b4.TabIndex = 3;
            this.b4.TabStop = false;
            this.b4.Tag = "3";
            this.b4.Click += new System.EventHandler(this.b_Click);
            // 
            // b9
            // 
            this.b9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b9.Location = new System.Drawing.Point(160, 140);
            this.b9.Name = "b9";
            this.b9.Size = new System.Drawing.Size(57, 55);
            this.b9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b9.TabIndex = 8;
            this.b9.TabStop = false;
            this.b9.Tag = "8";
            this.b9.Click += new System.EventHandler(this.b_Click);
            // 
            // b8
            // 
            this.b8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b8.Location = new System.Drawing.Point(87, 141);
            this.b8.Name = "b8";
            this.b8.Size = new System.Drawing.Size(57, 55);
            this.b8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b8.TabIndex = 7;
            this.b8.TabStop = false;
            this.b8.Tag = "7";
            this.b8.Click += new System.EventHandler(this.b_Click);
            // 
            // b7
            // 
            this.b7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.b7.Location = new System.Drawing.Point(14, 141);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(57, 55);
            this.b7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b7.TabIndex = 6;
            this.b7.TabStop = false;
            this.b7.Tag = "6";
            this.b7.Click += new System.EventHandler(this.b_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(154, 172);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // gbGameBox
            // 
            this.gbGameBox.Controls.Add(this.b2);
            this.gbGameBox.Controls.Add(this.b1);
            this.gbGameBox.Controls.Add(this.b9);
            this.gbGameBox.Controls.Add(this.b3);
            this.gbGameBox.Controls.Add(this.b8);
            this.gbGameBox.Controls.Add(this.b4);
            this.gbGameBox.Controls.Add(this.b7);
            this.gbGameBox.Controls.Add(this.b5);
            this.gbGameBox.Controls.Add(this.b6);
            this.gbGameBox.Location = new System.Drawing.Point(12, 12);
            this.gbGameBox.Name = "gbGameBox";
            this.gbGameBox.Size = new System.Drawing.Size(228, 208);
            this.gbGameBox.TabIndex = 10;
            this.gbGameBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pbTurn);
            this.groupBox2.Controls.Add(this.gbP2);
            this.groupBox2.Controls.Add(this.gbP1);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Location = new System.Drawing.Point(247, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 208);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // gbP2
            // 
            this.gbP2.Controls.Add(this.lblP2);
            this.gbP2.Location = new System.Drawing.Point(124, 19);
            this.gbP2.Name = "gbP2";
            this.gbP2.Size = new System.Drawing.Size(108, 100);
            this.gbP2.TabIndex = 2;
            this.gbP2.TabStop = false;
            // 
            // gbP1
            // 
            this.gbP1.Controls.Add(this.lblP1);
            this.gbP1.Location = new System.Drawing.Point(6, 18);
            this.gbP1.Name = "gbP1";
            this.gbP1.Size = new System.Drawing.Size(108, 100);
            this.gbP1.TabIndex = 1;
            this.gbP1.TabStop = false;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "circle.png");
            this.imgList.Images.SetKeyName(1, "cross.png");
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1.Location = new System.Drawing.Point(3, 25);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(105, 55);
            this.lblP1.TabIndex = 0;
            this.lblP1.Text = "100";
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2.Location = new System.Drawing.Point(3, 25);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(105, 55);
            this.lblP2.TabIndex = 1;
            this.lblP2.Text = "100";
            // 
            // pbTurn
            // 
            this.pbTurn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTurn.Location = new System.Drawing.Point(6, 140);
            this.pbTurn.Name = "pbTurn";
            this.pbTurn.Size = new System.Drawing.Size(57, 55);
            this.pbTurn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTurn.TabIndex = 9;
            this.pbTurn.TabStop = false;
            this.pbTurn.Tag = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Turn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 229);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbGameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "TicTacToe";
            ((System.ComponentModel.ISupportInitialize)(this.b1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b7)).EndInit();
            this.gbGameBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbP2.ResumeLayout(false);
            this.gbP2.PerformLayout();
            this.gbP1.ResumeLayout(false);
            this.gbP1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox b1;
        private System.Windows.Forms.PictureBox b2;
        private System.Windows.Forms.PictureBox b3;
        private System.Windows.Forms.PictureBox b6;
        private System.Windows.Forms.PictureBox b5;
        private System.Windows.Forms.PictureBox b4;
        private System.Windows.Forms.PictureBox b9;
        private System.Windows.Forms.PictureBox b8;
        private System.Windows.Forms.PictureBox b7;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox gbGameBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbP2;
        private System.Windows.Forms.GroupBox gbP1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbTurn;
    }
}

