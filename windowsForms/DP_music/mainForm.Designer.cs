﻿
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panelBar = new System.Windows.Forms.Panel();
            this.buttonAccountName = new System.Windows.Forms.Button();
            this.buttonRecordName = new System.Windows.Forms.Button();
            this.buttonAlbumsName = new System.Windows.Forms.Button();
            this.buttonGenresName = new System.Windows.Forms.Button();
            this.buttonGroupsName = new System.Windows.Forms.Button();
            this.buttonHomeName = new System.Windows.Forms.Button();
            this.panelNav = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.panelBarMini = new System.Windows.Forms.Panel();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonAlbums = new System.Windows.Forms.Button();
            this.buttonGenres = new System.Windows.Forms.Button();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.timerOpenPanelBar = new System.Windows.Forms.Timer(this.components);
            this.timerClosePanelBar = new System.Windows.Forms.Timer(this.components);
            this.panelBar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            this.panelBarMini.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelBar.Controls.Add(this.buttonAccountName);
            this.panelBar.Controls.Add(this.buttonRecordName);
            this.panelBar.Controls.Add(this.buttonAlbumsName);
            this.panelBar.Controls.Add(this.buttonGenresName);
            this.panelBar.Controls.Add(this.buttonGroupsName);
            this.panelBar.Controls.Add(this.buttonHomeName);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(197, 510);
            this.panelBar.TabIndex = 0;
            this.panelBar.Visible = false;
            // 
            // buttonAccountName
            // 
            this.buttonAccountName.FlatAppearance.BorderSize = 0;
            this.buttonAccountName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.buttonAccountName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAccountName.Location = new System.Drawing.Point(0, 439);
            this.buttonAccountName.Name = "buttonAccountName";
            this.buttonAccountName.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonAccountName.Size = new System.Drawing.Size(197, 48);
            this.buttonAccountName.TabIndex = 4;
            this.buttonAccountName.Text = "АКАУНТ";
            this.buttonAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccountName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonAccountName.UseVisualStyleBackColor = true;
            this.buttonAccountName.Click += new System.EventHandler(this.buttonAccountName_Click);
            // 
            // buttonRecordName
            // 
            this.buttonRecordName.FlatAppearance.BorderSize = 0;
            this.buttonRecordName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecordName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRecordName.ForeColor = System.Drawing.Color.White;
            this.buttonRecordName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRecordName.Location = new System.Drawing.Point(0, 312);
            this.buttonRecordName.Name = "buttonRecordName";
            this.buttonRecordName.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonRecordName.Size = new System.Drawing.Size(197, 48);
            this.buttonRecordName.TabIndex = 4;
            this.buttonRecordName.Text = "ЗАПИСИ";
            this.buttonRecordName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRecordName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonRecordName.UseVisualStyleBackColor = true;
            this.buttonRecordName.Click += new System.EventHandler(this.buttonRecordName_Click);
            // 
            // buttonAlbumsName
            // 
            this.buttonAlbumsName.FlatAppearance.BorderSize = 0;
            this.buttonAlbumsName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlbumsName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAlbumsName.ForeColor = System.Drawing.Color.White;
            this.buttonAlbumsName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAlbumsName.Location = new System.Drawing.Point(0, 234);
            this.buttonAlbumsName.Name = "buttonAlbumsName";
            this.buttonAlbumsName.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonAlbumsName.Size = new System.Drawing.Size(197, 48);
            this.buttonAlbumsName.TabIndex = 1;
            this.buttonAlbumsName.Text = "АЛЬБОМИ";
            this.buttonAlbumsName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAlbumsName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonAlbumsName.UseVisualStyleBackColor = true;
            this.buttonAlbumsName.Click += new System.EventHandler(this.buttonAlbumsName_Click);
            // 
            // buttonGenresName
            // 
            this.buttonGenresName.FlatAppearance.BorderSize = 0;
            this.buttonGenresName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenresName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGenresName.ForeColor = System.Drawing.Color.White;
            this.buttonGenresName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenresName.Location = new System.Drawing.Point(0, 78);
            this.buttonGenresName.Name = "buttonGenresName";
            this.buttonGenresName.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonGenresName.Size = new System.Drawing.Size(197, 48);
            this.buttonGenresName.TabIndex = 1;
            this.buttonGenresName.Text = "ЖАНРИ";
            this.buttonGenresName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenresName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGenresName.UseVisualStyleBackColor = true;
            this.buttonGenresName.Click += new System.EventHandler(this.buttonGenresName_Click);
            // 
            // buttonGroupsName
            // 
            this.buttonGroupsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.buttonGroupsName.FlatAppearance.BorderSize = 0;
            this.buttonGroupsName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroupsName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGroupsName.ForeColor = System.Drawing.Color.White;
            this.buttonGroupsName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGroupsName.Location = new System.Drawing.Point(0, 156);
            this.buttonGroupsName.Name = "buttonGroupsName";
            this.buttonGroupsName.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonGroupsName.Size = new System.Drawing.Size(197, 48);
            this.buttonGroupsName.TabIndex = 1;
            this.buttonGroupsName.Text = "ГУРТИ";
            this.buttonGroupsName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGroupsName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGroupsName.UseVisualStyleBackColor = false;
            this.buttonGroupsName.Click += new System.EventHandler(this.buttonGroupsName_Click);
            // 
            // buttonHomeName
            // 
            this.buttonHomeName.FlatAppearance.BorderSize = 0;
            this.buttonHomeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHomeName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHomeName.ForeColor = System.Drawing.Color.White;
            this.buttonHomeName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHomeName.Location = new System.Drawing.Point(0, 0);
            this.buttonHomeName.Name = "buttonHomeName";
            this.buttonHomeName.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.buttonHomeName.Size = new System.Drawing.Size(197, 48);
            this.buttonHomeName.TabIndex = 1;
            this.buttonHomeName.Text = "ГОЛОВНА";
            this.buttonHomeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHomeName.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonHomeName.UseVisualStyleBackColor = true;
            this.buttonHomeName.Click += new System.EventHandler(this.buttonHomeName_Click);
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(150)))), ((int)(((byte)(194)))));
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(5, 400);
            this.panelNav.TabIndex = 3;
            this.panelNav.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(930, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(40, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "x";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProjectName.ForeColor = System.Drawing.Color.White;
            this.labelProjectName.Location = new System.Drawing.Point(63, 10);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(215, 49);
            this.labelProjectName.TabIndex = 2;
            this.labelProjectName.Text = "DP MUSIC";
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChildForm.Location = new System.Drawing.Point(197, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(708, 510);
            this.panelChildForm.TabIndex = 5;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelHeader.Controls.Add(this.pictureBoxMenu);
            this.panelHeader.Controls.Add(this.buttonClose);
            this.panelHeader.Controls.Add(this.labelProjectName);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(970, 71);
            this.panelHeader.TabIndex = 10;
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMenu.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMenu.Image")));
            this.pictureBoxMenu.Location = new System.Drawing.Point(15, 18);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMenu.TabIndex = 5;
            this.pictureBoxMenu.TabStop = false;
            this.pictureBoxMenu.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelBarMini
            // 
            this.panelBarMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelBarMini.Controls.Add(this.panelNav);
            this.panelBarMini.Controls.Add(this.buttonAccount);
            this.panelBarMini.Controls.Add(this.buttonRecord);
            this.panelBarMini.Controls.Add(this.buttonAlbums);
            this.panelBarMini.Controls.Add(this.buttonGenres);
            this.panelBarMini.Controls.Add(this.buttonGroups);
            this.panelBarMini.Controls.Add(this.buttonHome);
            this.panelBarMini.Location = new System.Drawing.Point(0, 67);
            this.panelBarMini.Name = "panelBarMini";
            this.panelBarMini.Size = new System.Drawing.Size(66, 510);
            this.panelBarMini.TabIndex = 7;
            // 
            // buttonAccount
            // 
            this.buttonAccount.FlatAppearance.BorderSize = 0;
            this.buttonAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccount.Image = ((System.Drawing.Image)(resources.GetObject("buttonAccount.Image")));
            this.buttonAccount.Location = new System.Drawing.Point(0, 439);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonAccount.Size = new System.Drawing.Size(65, 48);
            this.buttonAccount.TabIndex = 1;
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.FlatAppearance.BorderSize = 0;
            this.buttonRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecord.Image = ((System.Drawing.Image)(resources.GetObject("buttonRecord.Image")));
            this.buttonRecord.Location = new System.Drawing.Point(1, 312);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonRecord.Size = new System.Drawing.Size(65, 48);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonAlbums
            // 
            this.buttonAlbums.FlatAppearance.BorderSize = 0;
            this.buttonAlbums.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlbums.Image = ((System.Drawing.Image)(resources.GetObject("buttonAlbums.Image")));
            this.buttonAlbums.Location = new System.Drawing.Point(0, 234);
            this.buttonAlbums.Name = "buttonAlbums";
            this.buttonAlbums.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonAlbums.Size = new System.Drawing.Size(65, 48);
            this.buttonAlbums.TabIndex = 1;
            this.buttonAlbums.UseVisualStyleBackColor = true;
            this.buttonAlbums.Click += new System.EventHandler(this.buttonAlbums_Click);
            // 
            // buttonGenres
            // 
            this.buttonGenres.FlatAppearance.BorderSize = 0;
            this.buttonGenres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenres.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenres.Image")));
            this.buttonGenres.Location = new System.Drawing.Point(1, 78);
            this.buttonGenres.Name = "buttonGenres";
            this.buttonGenres.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonGenres.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonGenres.Size = new System.Drawing.Size(65, 48);
            this.buttonGenres.TabIndex = 1;
            this.buttonGenres.UseVisualStyleBackColor = true;
            this.buttonGenres.Click += new System.EventHandler(this.buttonGenres_Click);
            // 
            // buttonGroups
            // 
            this.buttonGroups.FlatAppearance.BorderSize = 0;
            this.buttonGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroups.Image = ((System.Drawing.Image)(resources.GetObject("buttonGroups.Image")));
            this.buttonGroups.Location = new System.Drawing.Point(1, 156);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonGroups.Size = new System.Drawing.Size(65, 48);
            this.buttonGroups.TabIndex = 1;
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonHome.Image")));
            this.buttonHome.Location = new System.Drawing.Point(0, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(65, 48);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelContent);
            this.panel3.Controls.Add(this.panelHeader);
            this.panel3.Controls.Add(this.panelBarMini);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(970, 577);
            this.panel3.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelChildForm);
            this.panelContent.Controls.Add(this.panelBar);
            this.panelContent.Location = new System.Drawing.Point(65, 67);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(905, 510);
            this.panelContent.TabIndex = 11;
            // 
            // timerOpenPanelBar
            // 
            this.timerOpenPanelBar.Interval = 7;
            this.timerOpenPanelBar.Tick += new System.EventHandler(this.timerOpenPanelBar_Tick);
            // 
            // timerClosePanelBar
            // 
            this.timerClosePanelBar.Interval = 7;
            this.timerClosePanelBar.Tick += new System.EventHandler(this.timerClosePanelBar_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(970, 577);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelBar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            this.panelBarMini.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
        public System.Windows.Forms.Button buttonAlbumsName;
        public System.Windows.Forms.Button buttonGenresName;
        public System.Windows.Forms.Button buttonGroupsName;
        public System.Windows.Forms.Button buttonHomeName;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button buttonClose;
        public System.Windows.Forms.Button buttonRecordName;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBarMini;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button buttonHome;
        public System.Windows.Forms.Button buttonAlbums;
        public System.Windows.Forms.Button buttonGenres;
        public System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Timer timerOpenPanelBar;
        private System.Windows.Forms.Timer timerClosePanelBar;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
        public System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.Button buttonAccount;
        public System.Windows.Forms.Button buttonAccountName;
    }
}
