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

        public string inputText = "";

        public SignIn()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width, panelContent.Height, 25, 25));
            this.StartPosition = FormStartPosition.CenterScreen;
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
            string userLogin = customTextBoxLogin.Text;
            string userPass = customTextBoxPassword.Text;
            var userInfo = convertToJSON(userLogin, userPass);
            var loginStatus = await apiHelpers.IsLogin(userInfo);
            if (loginStatus.data == "false")
            {
                MessageBox.Show(loginStatus.errorMessage, "Error login", MessageBoxButtons.OK);
            }
            else
            {
                var user = await apiHelpers.GetUser(loginStatus.token);
                user.token = loginStatus.token;
                this.Close();
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
    }
}
