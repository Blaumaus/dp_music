
namespace DP_music.Pages
{
    partial class Bands
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
            this.labelBands = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelEmptyBands = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.AutoSize = true;
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelHeader.Controls.Add(this.buttonBack);
            this.panelHeader.Controls.Add(this.labelBands);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(885, 70);
            this.panelHeader.TabIndex = 0;
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
            // labelBands
            // 
            this.labelBands.AutoSize = true;
            this.labelBands.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelBands.ForeColor = System.Drawing.Color.White;
            this.labelBands.Location = new System.Drawing.Point(137, 21);
            this.labelBands.Name = "labelBands";
            this.labelBands.Size = new System.Drawing.Size(633, 40);
            this.labelBands.TabIndex = 0;
            this.labelBands.Text = "ГУРТИ, ЯКІ ВІДНОСЯТЬСЯ ДО ЖАНРУ ";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.labelEmptyBands);
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(885, 440);
            this.panelContent.TabIndex = 1;
            // 
            // labelEmptyBands
            // 
            this.labelEmptyBands.AutoSize = true;
            this.labelEmptyBands.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmptyBands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.labelEmptyBands.Location = new System.Drawing.Point(43, 160);
            this.labelEmptyBands.Name = "labelEmptyBands";
            this.labelEmptyBands.Size = new System.Drawing.Size(809, 37);
            this.labelEmptyBands.TabIndex = 0;
            this.labelEmptyBands.Text = "НА ЖАЛЬ, В ЦЮ КАТЕГОРІЮ ЩЕ НІЧОГО НЕ ДОДАНО:(";
            this.labelEmptyBands.Visible = false;
            // 
            // Bands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bands";
            this.Text = "Groups";
            this.Load += new System.EventHandler(this.Bands_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelBands;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelEmptyBands;
    }
}