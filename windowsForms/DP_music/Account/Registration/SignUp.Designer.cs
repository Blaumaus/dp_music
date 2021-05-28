
namespace DP_music.Account.Registration
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.panelMainBorder = new System.Windows.Forms.Panel();
            this.panelChild = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPasswordRepeatValid = new System.Windows.Forms.Label();
            this.labelPasswordValid = new System.Windows.Forms.Label();
            this.labelEmailValid = new System.Windows.Forms.Label();
            this.labelNameValid = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.customTextBoxEmail = new DP_music.CustomItems.CustomTextBox();
            this.customTextBoxPasswordSubmit = new DP_music.CustomItems.CustomTextBox();
            this.customTextBoxPassword = new DP_music.CustomItems.CustomTextBox();
            this.customTextBoxName = new DP_music.CustomItems.CustomTextBox();
            this.panelMainBorder.SuspendLayout();
            this.panelChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMainBorder
            // 
            this.panelMainBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.panelMainBorder.Controls.Add(this.panelChild);
            this.panelMainBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBorder.Location = new System.Drawing.Point(0, 0);
            this.panelMainBorder.Name = "panelMainBorder";
            this.panelMainBorder.Size = new System.Drawing.Size(905, 510);
            this.panelMainBorder.TabIndex = 0;
            // 
            // panelChild
            // 
            this.panelChild.BackColor = System.Drawing.Color.White;
            this.panelChild.Controls.Add(this.buttonExit);
            this.panelChild.Controls.Add(this.label1);
            this.panelChild.Controls.Add(this.labelPasswordRepeatValid);
            this.panelChild.Controls.Add(this.labelPasswordValid);
            this.panelChild.Controls.Add(this.labelEmailValid);
            this.panelChild.Controls.Add(this.labelNameValid);
            this.panelChild.Controls.Add(this.pictureBox1);
            this.panelChild.Controls.Add(this.buttonSignUp);
            this.panelChild.Controls.Add(this.customTextBoxEmail);
            this.panelChild.Controls.Add(this.customTextBoxPasswordSubmit);
            this.panelChild.Controls.Add(this.customTextBoxPassword);
            this.panelChild.Controls.Add(this.customTextBoxName);
            this.panelChild.Location = new System.Drawing.Point(40, 26);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(825, 457);
            this.panelChild.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(0, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 43);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.label1.Location = new System.Drawing.Point(91, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "SIGN UP";
            // 
            // labelPasswordRepeatValid
            // 
            this.labelPasswordRepeatValid.AutoSize = true;
            this.labelPasswordRepeatValid.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPasswordRepeatValid.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordRepeatValid.Location = new System.Drawing.Point(411, 373);
            this.labelPasswordRepeatValid.Name = "labelPasswordRepeatValid";
            this.labelPasswordRepeatValid.Size = new System.Drawing.Size(222, 17);
            this.labelPasswordRepeatValid.TabIndex = 4;
            this.labelPasswordRepeatValid.Text = "Поле обов\'язкове для зповнення!";
            // 
            // labelPasswordValid
            // 
            this.labelPasswordValid.AutoSize = true;
            this.labelPasswordValid.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPasswordValid.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordValid.Location = new System.Drawing.Point(411, 283);
            this.labelPasswordValid.Name = "labelPasswordValid";
            this.labelPasswordValid.Size = new System.Drawing.Size(222, 17);
            this.labelPasswordValid.TabIndex = 4;
            this.labelPasswordValid.Text = "Поле обов\'язкове для зповнення!";
            // 
            // labelEmailValid
            // 
            this.labelEmailValid.AutoSize = true;
            this.labelEmailValid.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmailValid.ForeColor = System.Drawing.Color.Red;
            this.labelEmailValid.Location = new System.Drawing.Point(411, 193);
            this.labelEmailValid.Name = "labelEmailValid";
            this.labelEmailValid.Size = new System.Drawing.Size(222, 17);
            this.labelEmailValid.TabIndex = 4;
            this.labelEmailValid.Text = "Поле обов\'язкове для зповнення!";
            // 
            // labelNameValid
            // 
            this.labelNameValid.AutoSize = true;
            this.labelNameValid.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameValid.ForeColor = System.Drawing.Color.Red;
            this.labelNameValid.Location = new System.Drawing.Point(411, 102);
            this.labelNameValid.Name = "labelNameValid";
            this.labelNameValid.Size = new System.Drawing.Size(222, 17);
            this.labelNameValid.TabIndex = 4;
            this.labelNameValid.Text = "Поле обов\'язкове для зповнення!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 207);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(389, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSignUp.FlatAppearance.BorderSize = 0;
            this.buttonSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignUp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSignUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.buttonSignUp.Location = new System.Drawing.Point(411, 393);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(389, 54);
            this.buttonSignUp.TabIndex = 2;
            this.buttonSignUp.Text = "SIGN UP";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // customTextBoxEmail
            // 
            this.customTextBoxEmail.BackColor = System.Drawing.Color.White;
            this.customTextBoxEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxEmail.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxEmail.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxEmail.FontTextPreview = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxEmail.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxEmail.Location = new System.Drawing.Point(411, 117);
            this.customTextBoxEmail.Name = "customTextBoxEmail";
            this.customTextBoxEmail.Size = new System.Drawing.Size(389, 73);
            this.customTextBoxEmail.TabIndex = 0;
            this.customTextBoxEmail.TextInput = "";
            this.customTextBoxEmail.TextPreview = "EMAIL";
            // 
            // customTextBoxPasswordSubmit
            // 
            this.customTextBoxPasswordSubmit.BackColor = System.Drawing.Color.White;
            this.customTextBoxPasswordSubmit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxPasswordSubmit.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxPasswordSubmit.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPasswordSubmit.FontTextPreview = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPasswordSubmit.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxPasswordSubmit.Location = new System.Drawing.Point(411, 297);
            this.customTextBoxPasswordSubmit.Name = "customTextBoxPasswordSubmit";
            this.customTextBoxPasswordSubmit.Size = new System.Drawing.Size(389, 73);
            this.customTextBoxPasswordSubmit.TabIndex = 0;
            this.customTextBoxPasswordSubmit.TextInput = "";
            this.customTextBoxPasswordSubmit.TextPreview = "REPEAT PASSWORD";
            // 
            // customTextBoxPassword
            // 
            this.customTextBoxPassword.BackColor = System.Drawing.Color.White;
            this.customTextBoxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxPassword.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxPassword.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPassword.FontTextPreview = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxPassword.Location = new System.Drawing.Point(411, 207);
            this.customTextBoxPassword.Name = "customTextBoxPassword";
            this.customTextBoxPassword.Size = new System.Drawing.Size(389, 73);
            this.customTextBoxPassword.TabIndex = 0;
            this.customTextBoxPassword.TextInput = "";
            this.customTextBoxPassword.TextPreview = "PASSWORD";
            // 
            // customTextBoxName
            // 
            this.customTextBoxName.BackColor = System.Drawing.Color.White;
            this.customTextBoxName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(52)))), ((int)(((byte)(117)))));
            this.customTextBoxName.BorderColorNotActive = System.Drawing.Color.Gray;
            this.customTextBoxName.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxName.FontTextPreview = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customTextBoxName.ForeColor = System.Drawing.Color.Black;
            this.customTextBoxName.Location = new System.Drawing.Point(411, 26);
            this.customTextBoxName.Name = "customTextBoxName";
            this.customTextBoxName.Size = new System.Drawing.Size(389, 73);
            this.customTextBoxName.TabIndex = 0;
            this.customTextBoxName.TextInput = "";
            this.customTextBoxName.TextPreview = "YOUR NAME";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 510);
            this.Controls.Add(this.panelMainBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.panelMainBorder.ResumeLayout(false);
            this.panelChild.ResumeLayout(false);
            this.panelChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainBorder;
        private System.Windows.Forms.Panel panelChild;
        private CustomItems.CustomTextBox customTextBoxName;
        private CustomItems.CustomTextBox customTextBoxEmail;
        private CustomItems.CustomTextBox customTextBoxPasswordSubmit;
        private CustomItems.CustomTextBox customTextBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Label labelNameValid;
        private System.Windows.Forms.Label labelPasswordRepeatValid;
        private System.Windows.Forms.Label labelPasswordValid;
        private System.Windows.Forms.Label labelEmailValid;
        private System.Windows.Forms.Button buttonExit;
    }
}