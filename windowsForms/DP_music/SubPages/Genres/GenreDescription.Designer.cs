
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.customTextBoxBorder = new DP_music.CustomItems.CustomTextBox();
            this.buttonBands = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelName = new System.Windows.Forms.Panel();
            this.labelGenreName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panelName.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(30, 108);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(322, 260);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 3;
            this.pictureBoxImage.TabStop = false;
            // 
            // customTextBoxBorder
            // 
            this.customTextBoxBorder.BackColor = System.Drawing.Color.White;
            this.customTextBoxBorder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxBorder.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxBorder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxBorder.FontTextPreview = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxBorder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.customTextBoxBorder.Location = new System.Drawing.Point(374, 95);
            this.customTextBoxBorder.Name = "customTextBoxBorder";
            this.customTextBoxBorder.Size = new System.Drawing.Size(504, 388);
            this.customTextBoxBorder.TabIndex = 4;
            this.customTextBoxBorder.TextInput = "";
            this.customTextBoxBorder.TextPreview = "ОПИС";
            // 
            // buttonBands
            // 
            this.buttonBands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.buttonBands.FlatAppearance.BorderSize = 0;
            this.buttonBands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBands.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBands.ForeColor = System.Drawing.Color.White;
            this.buttonBands.Location = new System.Drawing.Point(30, 389);
            this.buttonBands.Name = "buttonBands";
            this.buttonBands.Size = new System.Drawing.Size(322, 44);
            this.buttonBands.TabIndex = 5;
            this.buttonBands.Text = "ГУРТИ";
            this.buttonBands.UseVisualStyleBackColor = false;
            this.buttonBands.Click += new System.EventHandler(this.buttonBands_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.textBoxDescription.Location = new System.Drawing.Point(392, 124);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(471, 332);
            this.textBoxDescription.TabIndex = 6;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(30, 439);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(322, 44);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.Text = "←";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelName.Controls.Add(this.labelGenreName);
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(906, 70);
            this.panelName.TabIndex = 0;
            // 
            // labelGenreName
            // 
            this.labelGenreName.AutoSize = true;
            this.labelGenreName.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGenreName.ForeColor = System.Drawing.Color.White;
            this.labelGenreName.Location = new System.Drawing.Point(313, 10);
            this.labelGenreName.Name = "labelGenreName";
            this.labelGenreName.Size = new System.Drawing.Size(236, 40);
            this.labelGenreName.TabIndex = 1;
            this.labelGenreName.Text = "GENRE NAME";
            // 
            // GenreDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonBands);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.customTextBoxBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenreDescription";
            this.Opacity = 0D;
            this.Text = "GenreDescription";
            this.Load += new System.EventHandler(this.GenreDescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private CustomItems.CustomTextBox customTextBoxBorder;
        private System.Windows.Forms.Button buttonBands;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Label labelGenreName;
    }
}