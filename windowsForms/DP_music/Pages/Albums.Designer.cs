
namespace DP_music.Pages
{
    partial class Albums
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelAlbums = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelEmptyAlbums = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.AutoSize = true;
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelHeader.Controls.Add(this.buttonBack);
            this.panelHeader.Controls.Add(this.labelAlbums);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(905, 70);
            this.panelHeader.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(47, 47);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "←";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelAlbums
            // 
            this.labelAlbums.AutoSize = true;
            this.labelAlbums.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAlbums.ForeColor = System.Drawing.Color.White;
            this.labelAlbums.Location = new System.Drawing.Point(137, 21);
            this.labelAlbums.Name = "labelAlbums";
            this.labelAlbums.Size = new System.Drawing.Size(581, 40);
            this.labelAlbums.TabIndex = 0;
            this.labelAlbums.Text = "АЛЬБОМИ, ЩО ВІДНОСЯТЬСЯ ДО";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.labelEmptyAlbums);
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(905, 440);
            this.panelContent.TabIndex = 2;
            // 
            // labelEmptyAlbums
            // 
            this.labelEmptyAlbums.AutoSize = true;
            this.labelEmptyAlbums.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmptyAlbums.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.labelEmptyAlbums.Location = new System.Drawing.Point(43, 160);
            this.labelEmptyAlbums.Name = "labelEmptyAlbums";
            this.labelEmptyAlbums.Size = new System.Drawing.Size(809, 37);
            this.labelEmptyAlbums.TabIndex = 0;
            this.labelEmptyAlbums.Text = "НА ЖАЛЬ, В ЦЮ КАТЕГОРІЮ ЩЕ НІЧОГО НЕ ДОДАНО:(";
            this.labelEmptyAlbums.Visible = false;
            // 
            // Albums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Albums";
            this.Text = "Albums";
            this.Load += new System.EventHandler(this.Albums_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelAlbums;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelEmptyAlbums;
    }
}