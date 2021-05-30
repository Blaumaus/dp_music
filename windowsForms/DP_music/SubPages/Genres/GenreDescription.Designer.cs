
namespace DP_music.SubPages.Genres
{
    partial class GenreDescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenreDescription));
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelGenreName = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonBands = new System.Windows.Forms.Button();
            this.customTextBoxBorder = new DP_music.CustomItems.CustomTextBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panelName = new System.Windows.Forms.Panel();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panelBorder.SuspendLayout();
            this.panelName.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(0, 0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(51, 44);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelGenreName
            // 
            this.labelGenreName.AutoSize = true;
            this.labelGenreName.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGenreName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.labelGenreName.Location = new System.Drawing.Point(131, 20);
            this.labelGenreName.Name = "labelGenreName";
            this.labelGenreName.Size = new System.Drawing.Size(236, 40);
            this.labelGenreName.TabIndex = 1;
            this.labelGenreName.Text = "GENRE NAME";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.pictureBox1);
            this.panelContent.Controls.Add(this.textBoxDescription);
            this.panelContent.Controls.Add(this.buttonBack);
            this.panelContent.Controls.Add(this.buttonBands);
            this.panelContent.Controls.Add(this.customTextBoxBorder);
            this.panelContent.Controls.Add(this.pictureBoxImage);
            this.panelContent.Controls.Add(this.panelBorder);
            this.panelContent.Location = new System.Drawing.Point(35, 35);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(835, 440);
            this.panelContent.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.textBoxDescription.Location = new System.Drawing.Point(323, 153);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(491, 263);
            this.textBoxDescription.TabIndex = 6;
            // 
            // buttonBands
            // 
            this.buttonBands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.buttonBands.FlatAppearance.BorderSize = 0;
            this.buttonBands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBands.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBands.ForeColor = System.Drawing.Color.White;
            this.buttonBands.Location = new System.Drawing.Point(26, 385);
            this.buttonBands.Name = "buttonBands";
            this.buttonBands.Size = new System.Drawing.Size(266, 44);
            this.buttonBands.TabIndex = 5;
            this.buttonBands.Text = "БЕНДИ";
            this.buttonBands.UseVisualStyleBackColor = false;
            // 
            // customTextBoxBorder
            // 
            this.customTextBoxBorder.BackColor = System.Drawing.Color.White;
            this.customTextBoxBorder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxBorder.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxBorder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxBorder.FontTextPreview = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxBorder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.customTextBoxBorder.Location = new System.Drawing.Point(311, 115);
            this.customTextBoxBorder.Name = "customTextBoxBorder";
            this.customTextBoxBorder.Size = new System.Drawing.Size(514, 314);
            this.customTextBoxBorder.TabIndex = 4;
            this.customTextBoxBorder.TextInput = "";
            this.customTextBoxBorder.TextPreview = "ОПИС";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(26, 128);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(266, 239);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 3;
            this.pictureBoxImage.TabStop = false;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.panelBorder.Controls.Add(this.panelName);
            this.panelBorder.Location = new System.Drawing.Point(311, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(524, 93);
            this.panelBorder.TabIndex = 2;
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.White;
            this.panelName.Controls.Add(this.labelGenreName);
            this.panelName.Location = new System.Drawing.Point(12, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(512, 80);
            this.panelName.TabIndex = 0;
            // 
            // GenreDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenreDescription";
            this.Text = "GenreDescription";
            this.Load += new System.EventHandler(this.GenreDescription_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.panelBorder.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelGenreName;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Button buttonBands;
        private CustomItems.CustomTextBox customTextBoxBorder;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}