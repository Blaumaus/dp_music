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
using DP_music.Entities;
using DP_music.Account.Registration;

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

        public mainForm parent;

        public AccountMain(mainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            panelChild.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelChild.Width, panelChild.Height, 25, 25));
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            parent.openChildForm(new SignUp(parent));
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            parent.openChildForm(new SignIn(parent));
        }

        Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
