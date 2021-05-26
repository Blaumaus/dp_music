using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DP_music.Account.Login;


namespace DP_music.Account
{
    public partial class AccountMain : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthElipse,
            int nHeightElipse
        );
        private Form enableForm;

        public AccountMain(Form enableForm)
        {
            this.enableForm = enableForm;
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width, panelContent.Height, 25, 25));
            buttonLogIn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonLogIn.Width, buttonLogIn.Height, 25, 25));
            buttonSignIn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSignIn.Width, buttonSignIn.Height, 25, 25));
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            enableForm.Enabled = true;
            this.Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {

        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }
    }
}
