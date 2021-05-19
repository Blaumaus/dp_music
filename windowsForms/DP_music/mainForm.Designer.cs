
namespace DP_music
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panelBar = new System.Windows.Forms.Panel();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.panelNav = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonComposition = new System.Windows.Forms.Button();
            this.buttonGenres = new System.Windows.Forms.Button();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelBar.Controls.Add(this.buttonRecord);
            this.panelBar.Controls.Add(this.panelNav);
            this.panelBar.Controls.Add(this.buttonSettings);
            this.panelBar.Controls.Add(this.buttonComposition);
            this.panelBar.Controls.Add(this.buttonGenres);
            this.panelBar.Controls.Add(this.buttonGroups);
            this.panelBar.Controls.Add(this.buttonHome);
            this.panelBar.Controls.Add(this.panel1);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(245, 577);
            this.panelBar.TabIndex = 0;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRecord.FlatAppearance.BorderSize = 0;
            this.buttonRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecord.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonRecord.Image = ((System.Drawing.Image)(resources.GetObject("buttonRecord.Image")));
            this.buttonRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRecord.Location = new System.Drawing.Point(0, 327);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonRecord.Size = new System.Drawing.Size(245, 48);
            this.buttonRecord.TabIndex = 4;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            this.buttonRecord.Leave += new System.EventHandler(this.buttonRecord_Leave);
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.panelNav.Location = new System.Drawing.Point(0, 189);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(5, 150);
            this.panelNav.TabIndex = 3;
            this.panelNav.Visible = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSettings.Location = new System.Drawing.Point(0, 529);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonSettings.Size = new System.Drawing.Size(245, 48);
            this.buttonSettings.TabIndex = 1;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            this.buttonSettings.Leave += new System.EventHandler(this.buttonSettings_Leave);
            // 
            // buttonComposition
            // 
            this.buttonComposition.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonComposition.FlatAppearance.BorderSize = 0;
            this.buttonComposition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComposition.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonComposition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonComposition.Image = ((System.Drawing.Image)(resources.GetObject("buttonComposition.Image")));
            this.buttonComposition.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonComposition.Location = new System.Drawing.Point(0, 279);
            this.buttonComposition.Name = "buttonComposition";
            this.buttonComposition.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonComposition.Size = new System.Drawing.Size(245, 48);
            this.buttonComposition.TabIndex = 1;
            this.buttonComposition.Text = "Composition";
            this.buttonComposition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonComposition.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonComposition.UseVisualStyleBackColor = true;
            this.buttonComposition.Click += new System.EventHandler(this.buttonComposition_Click);
            this.buttonComposition.Leave += new System.EventHandler(this.buttonComposition_Leave);
            // 
            // buttonGenres
            // 
            this.buttonGenres.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGenres.FlatAppearance.BorderSize = 0;
            this.buttonGenres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenres.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGenres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonGenres.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenres.Image")));
            this.buttonGenres.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenres.Location = new System.Drawing.Point(0, 231);
            this.buttonGenres.Name = "buttonGenres";
            this.buttonGenres.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonGenres.Size = new System.Drawing.Size(245, 48);
            this.buttonGenres.TabIndex = 1;
            this.buttonGenres.Text = "Genres";
            this.buttonGenres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenres.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGenres.UseVisualStyleBackColor = true;
            this.buttonGenres.Click += new System.EventHandler(this.buttonGenres_Click);
            this.buttonGenres.Leave += new System.EventHandler(this.buttonGenres_Leave);
            // 
            // buttonGroups
            // 
            this.buttonGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGroups.FlatAppearance.BorderSize = 0;
            this.buttonGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroups.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGroups.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonGroups.Image = ((System.Drawing.Image)(resources.GetObject("buttonGroups.Image")));
            this.buttonGroups.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGroups.Location = new System.Drawing.Point(0, 183);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonGroups.Size = new System.Drawing.Size(245, 48);
            this.buttonGroups.TabIndex = 1;
            this.buttonGroups.Text = "Groups";
            this.buttonGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGroups.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            this.buttonGroups.Leave += new System.EventHandler(this.buttonGroups_Leave);
            // 
            // buttonHome
            // 
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonHome.Image")));
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHome.Location = new System.Drawing.Point(0, 135);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonHome.Size = new System.Drawing.Size(245, 48);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "Home";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            this.buttonHome.Leave += new System.EventHandler(this.buttonHome_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelUserInfo);
            this.panel1.Controls.Add(this.labelUserName);
            this.panel1.Controls.Add(this.pictureBoxAvatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 135);
            this.panel1.TabIndex = 0;
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(54)))));
            this.labelUserInfo.Location = new System.Drawing.Point(113, 55);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(91, 21);
            this.labelUserInfo.TabIndex = 2;
            this.labelUserInfo.Text = "User   Info";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.labelUserName.Location = new System.Drawing.Point(111, 33);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(107, 22);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "User Name";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAvatar.Image")));
            this.pictureBoxAvatar.Location = new System.Drawing.Point(10, 22);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(95, 95);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 0;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.Location = new System.Drawing.Point(933, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(35, 43);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "x";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelProjectName.Location = new System.Drawing.Point(261, 22);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(166, 40);
            this.labelProjectName.TabIndex = 2;
            this.labelProjectName.Text = "DP Music";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxSearch.Location = new System.Drawing.Point(608, 24);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(224, 31);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.Text = "  Search...";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(838, 24);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(46, 31);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelChildForm.Location = new System.Drawing.Point(245, 68);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(725, 509);
            this.panelChildForm.TabIndex = 5;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(970, 577);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelProjectName);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.panelBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panelBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button buttonComposition;
        private System.Windows.Forms.Button buttonGenres;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelChildForm;
    }
}

