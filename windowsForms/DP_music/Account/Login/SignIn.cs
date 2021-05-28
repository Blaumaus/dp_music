using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DP_music.Account;
using System.Runtime.InteropServices;
using DP_music.helpers;
using Newtonsoft.Json;
using DP_music.API;
using DP_music.Entities;

namespace DP_music.Account.Login
{
    public partial class SignIn : Form
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

        public User user;
        public mainForm parent;
        public SignIn(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            panelChild.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelChild.Width, panelChild.Height, 25, 25));
            //this.user = userMain;
            user = new User();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customTextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void buttonSignIn_Click(object sender, EventArgs e)
        {
            if(user.login == "guest")
            {
                string userLogin = customTextBoxLogin.Text;
                string userPass = customTextBoxPassword.Text;
                if(userLogin != "" && userPass != "")
                {
                    var userInfo = convertToJSON(userLogin, userPass);
                    var loginStatus = await apiHelpers.IsLogin(userInfo);
                    if (loginStatus.data != "false")
                    {
                        user = await apiHelpers.GetUser(loginStatus.token);
                        user.token = loginStatus.token;
                        parent.userName.Text = user.login;
                        parent.user = user;
                        parent.activeForm = new Home();
                        parent.buttonHome_Click(this, new EventArgs());
                        this.Close();
                    }
                    else
                        MessageBox.Show(loginStatus.errorMessage, "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string convertToJSON(string userLogin, string userPass)
        {
            var content =  new Dictionary<string, string>()
            {
                {"login", userLogin },
                {"password", userPass }
            };
            return JsonConvert.SerializeObject(content);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваші дані буде втрачено. Ви хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                AccountMain account= new AccountMain(parent);
                parent.activeForm = account;
                parent.buttonAccount_Click(this, new EventArgs());
            }
        }
    }
}
