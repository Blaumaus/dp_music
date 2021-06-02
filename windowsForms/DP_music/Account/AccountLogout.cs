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
using DP_music.Entities;
using DP_music.helpers;

namespace DP_music.Account
{
    public partial class AccountLogout : Form
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

        mainForm parent;

        public AccountLogout(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width, panelContent.Height, 25, 25));
        }

        private async void buttonLogOut_Click(object sender, EventArgs e)
        {
            if(await apiHelpers.deleteAccount(parent.user.token))
            {
                parent.user = new User();
                parent.userName.Text = parent.user.login;
            }
            else
            {
                var message = new Message(parent, "Упс.. Спробуйте вийти ще раз!", true, false);
            }
            AccountMain account = new AccountMain(parent);
            parent.openChildForm(account, parent.buttonAccount, parent.buttonAccountName);


        }
    }
}
