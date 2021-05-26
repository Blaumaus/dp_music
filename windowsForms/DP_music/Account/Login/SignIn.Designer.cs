
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.customTextBoxPassword = new DP_music.CustomItems.CustomTextBox();
            this.customTextBoxLogin = new DP_music.CustomItems.CustomTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.panelBackColor.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackColor
            // 
            this.panelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panelBackColor.Controls.Add(this.panelContent);
            this.panelBackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackColor.Location = new System.Drawing.Point(0, 0);
            this.panelBackColor.Name = "panelBackColor";
            this.panelBackColor.Size = new System.Drawing.Size(494, 608);
            this.panelBackColor.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.textBoxTest);
            this.panelContent.Controls.Add(this.buttonSignIn);
            this.panelContent.Controls.Add(this.customTextBoxPassword);
            this.panelContent.Controls.Add(this.customTextBoxLogin);
            this.panelContent.Controls.Add(this.button1);
            this.panelContent.Controls.Add(this.buttonBack);
            this.panelContent.Controls.Add(this.panel1);
            this.panelContent.Location = new System.Drawing.Point(30, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(427, 485);
            this.panelContent.TabIndex = 0;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.FlatAppearance.BorderSize = 0;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.buttonSignIn.Location = new System.Drawing.Point(38, 415);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(353, 54);
            this.buttonSignIn.TabIndex = 1;
            this.buttonSignIn.Text = "SIGN IN";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // customTextBoxPassword
            // 
            this.customTextBoxPassword.BackColor = System.Drawing.Color.White;
            this.customTextBoxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxPassword.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.customTextBoxPassword.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPassword.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxPassword.Location = new System.Drawing.Point(38, 342);
            this.customTextBoxPassword.Name = "customTextBoxPassword";
            this.customTextBoxPassword.Size = new System.Drawing.Size(353, 68);
            this.customTextBoxPassword.TabIndex = 2;
            this.customTextBoxPassword.TextInput = "";
            this.customTextBoxPassword.TextPreview = "Enter password";
            this.customTextBoxPassword.TextChanged += new System.EventHandler(this.customTextBoxPassword_TextChanged);
            // 
            // customTextBoxLogin
            // 
            this.customTextBoxLogin.BackColor = System.Drawing.Color.White;
            this.customTextBoxLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxLogin.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.customTextBoxLogin.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxLogin.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxLogin.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxLogin.Location = new System.Drawing.Point(38, 259);
            this.customTextBoxLogin.Name = "customTextBoxLogin";
            this.customTextBoxLogin.Size = new System.Drawing.Size(353, 68);
            this.customTextBoxLogin.TabIndex = 2;
            this.customTextBoxLogin.TextInput = "";
            this.customTextBoxLogin.TextPreview = "Enter login";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(387, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(0, 0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(40, 40);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(99, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 137);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "SIGN IN";
            // 
            // textBoxTest
            // 
            this.textBoxTest.Location = new System.Drawing.Point(73, 38);
            this.textBoxTest.Multiline = true;
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.Size = new System.Drawing.Size(303, 172);
            this.textBoxTest.TabIndex = 3;
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 608);
            this.Controls.Add(this.panelBackColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignIn";
            this.Text = "SignIn";
            this.panelBackColor.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBackColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private CustomItems.CustomTextBox customTextBoxLogin;
        private CustomItems.CustomTextBox customTextBoxPassword;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.TextBox textBoxTest;
    }
}