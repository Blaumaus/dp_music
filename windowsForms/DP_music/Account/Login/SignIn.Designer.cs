
namespace DP_music.Account.Login
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.panelBackColor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMainBorder = new System.Windows.Forms.Panel();
            this.panelChild = new System.Windows.Forms.Panel();
            this.labelPasswordValid = new System.Windows.Forms.Label();
            this.labelLoginValid = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.customTextBoxPassword = new DP_music.CustomItems.CustomTextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panelInside = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.customTextBoxLogin = new DP_music.CustomItems.CustomTextBox();
            this.panelBackColor.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelMainBorder.SuspendLayout();
            this.panelChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelBorder.SuspendLayout();
            this.panelInside.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackColor
            // 
            this.panelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelBackColor.Controls.Add(this.label2);
            this.panelBackColor.Controls.Add(this.panelContent);
            this.panelBackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackColor.Location = new System.Drawing.Point(0, 0);
            this.panelBackColor.Name = "panelBackColor";
            this.panelBackColor.Size = new System.Drawing.Size(905, 510);
            this.panelBackColor.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(168, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "DP \"MUSIC\"";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.panelMainBorder);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(905, 510);
            this.panelContent.TabIndex = 0;
            // 
            // panelMainBorder
            // 
            this.panelMainBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.panelMainBorder.Controls.Add(this.panelChild);
            this.panelMainBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBorder.Location = new System.Drawing.Point(0, 0);
            this.panelMainBorder.Name = "panelMainBorder";
            this.panelMainBorder.Size = new System.Drawing.Size(905, 510);
            this.panelMainBorder.TabIndex = 4;
            // 
            // panelChild
            // 
            this.panelChild.BackColor = System.Drawing.Color.White;
            this.panelChild.Controls.Add(this.labelPasswordValid);
            this.panelChild.Controls.Add(this.labelLoginValid);
            this.panelChild.Controls.Add(this.pictureBox);
            this.panelChild.Controls.Add(this.buttonExit);
            this.panelChild.Controls.Add(this.customTextBoxPassword);
            this.panelChild.Controls.Add(this.buttonSignIn);
            this.panelChild.Controls.Add(this.panelBorder);
            this.panelChild.Controls.Add(this.customTextBoxLogin);
            this.panelChild.Location = new System.Drawing.Point(40, 26);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(825, 457);
            this.panelChild.TabIndex = 4;
            // 
            // labelPasswordValid
            // 
            this.labelPasswordValid.AutoSize = true;
            this.labelPasswordValid.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPasswordValid.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordValid.Location = new System.Drawing.Point(461, 345);
            this.labelPasswordValid.Name = "labelPasswordValid";
            this.labelPasswordValid.Size = new System.Drawing.Size(106, 17);
            this.labelPasswordValid.TabIndex = 5;
            this.labelPasswordValid.Text = "Введіть пароль!";
            this.labelPasswordValid.Visible = false;
            // 
            // labelLoginValid
            // 
            this.labelLoginValid.AutoSize = true;
            this.labelLoginValid.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLoginValid.ForeColor = System.Drawing.Color.Red;
            this.labelLoginValid.Location = new System.Drawing.Point(461, 249);
            this.labelLoginValid.Name = "labelLoginValid";
            this.labelLoginValid.Size = new System.Drawing.Size(90, 17);
            this.labelLoginValid.TabIndex = 5;
            this.labelLoginValid.Text = "Введіть логін!";
            this.labelLoginValid.Visible = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(58, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(350, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(9, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 43);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // customTextBoxPassword
            // 
            this.customTextBoxPassword.BackColor = System.Drawing.Color.White;
            this.customTextBoxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxPassword.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.customTextBoxPassword.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPassword.FontTextPreview = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxPassword.Location = new System.Drawing.Point(461, 273);
            this.customTextBoxPassword.Name = "customTextBoxPassword";
            this.customTextBoxPassword.Size = new System.Drawing.Size(339, 68);
            this.customTextBoxPassword.TabIndex = 2;
            this.customTextBoxPassword.TextInput = "";
            this.customTextBoxPassword.TextPreview = "ВВЕДІТЬ ПАРОЛЬ";
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSignIn.FlatAppearance.BorderSize = 0;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.buttonSignIn.Location = new System.Drawing.Point(461, 365);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(339, 54);
            this.buttonSignIn.TabIndex = 1;
            this.buttonSignIn.Text = "УВІЙТИ";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.panelBorder.Controls.Add(this.panelInside);
            this.panelBorder.Location = new System.Drawing.Point(436, 19);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(389, 137);
            this.panelBorder.TabIndex = 0;
            // 
            // panelInside
            // 
            this.panelInside.BackColor = System.Drawing.Color.White;
            this.panelInside.Controls.Add(this.label1);
            this.panelInside.Location = new System.Drawing.Point(7, 7);
            this.panelInside.Name = "panelInside";
            this.panelInside.Size = new System.Drawing.Size(382, 123);
            this.panelInside.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.label1.Location = new System.Drawing.Point(97, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "УВІЙТИ";
            // 
            // customTextBoxLogin
            // 
            this.customTextBoxLogin.BackColor = System.Drawing.Color.White;
            this.customTextBoxLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxLogin.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.customTextBoxLogin.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxLogin.FontTextPreview = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxLogin.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxLogin.Location = new System.Drawing.Point(461, 178);
            this.customTextBoxLogin.Name = "customTextBoxLogin";
            this.customTextBoxLogin.Size = new System.Drawing.Size(339, 68);
            this.customTextBoxLogin.TabIndex = 2;
            this.customTextBoxLogin.TextInput = "";
            this.customTextBoxLogin.TextPreview = "ВВЕДІТЬ ЛОГІН";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelBackColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignIn";
            this.Text = "SignIn";
            this.panelBackColor.ResumeLayout(false);
            this.panelBackColor.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelMainBorder.ResumeLayout(false);
            this.panelChild.ResumeLayout(false);
            this.panelChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelBorder.ResumeLayout(false);
            this.panelInside.ResumeLayout(false);
            this.panelInside.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBackColor;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Label label1;
        private CustomItems.CustomTextBox customTextBoxLogin;
        private CustomItems.CustomTextBox customTextBoxPassword;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelInside;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panelMainBorder;
        private System.Windows.Forms.Panel panelChild;
        private System.Windows.Forms.Label labelPasswordValid;
        private System.Windows.Forms.Label labelLoginValid;
    }
}