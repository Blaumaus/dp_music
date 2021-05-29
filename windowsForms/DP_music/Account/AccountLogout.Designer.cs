
namespace DP_music.Account
{
    partial class AccountLogout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountLogout));
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.labelText);
            this.panelContent.Controls.Add(this.buttonSignIn);
            this.panelContent.Controls.Add(this.pictureBox1);
            this.panelContent.Location = new System.Drawing.Point(40, 26);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(825, 457);
            this.panelContent.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(157, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(509, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(92)))), ((int)(((byte)(182)))));
            this.buttonSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSignIn.FlatAppearance.BorderSize = 0;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSignIn.ForeColor = System.Drawing.Color.White;
            this.buttonSignIn.Location = new System.Drawing.Point(157, 389);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(509, 49);
            this.buttonSignIn.TabIndex = 2;
            this.buttonSignIn.Text = "LOG OUT";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(92)))), ((int)(((byte)(182)))));
            this.labelText.Location = new System.Drawing.Point(257, 334);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(319, 37);
            this.labelText.TabIndex = 3;
            this.labelText.Text = "COME BACK FASTER! ";
            // 
            // AccountLogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountLogout";
            this.Text = "AccountLogout";
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button buttonSignIn;
    }
}