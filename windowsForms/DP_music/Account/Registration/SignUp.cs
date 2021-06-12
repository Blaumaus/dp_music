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
using System.Text.RegularExpressions;
using DP_music.helpers;
using DP_music.API;
using Newtonsoft.Json;
using DP_music.Entities;
using DP_music.API.query;

namespace DP_music.Account.Registration
{
    public partial class SignUp : Form
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
        string regEmail = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
        Message message;

        public SignUp(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            panelChild.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelChild.Width, panelChild.Height, 25, 25));
            labelNameValid.Visible = false;
            labelEmailValid.Visible = false;
            labelPasswordValid.Visible = false;
            labelPasswordRepeatValid.Visible = false;
        }

        private async void buttonSignUp_Click(object sender, EventArgs e)
        {
            string name = customTextBoxName.Text;
            string email = customTextBoxEmail.Text;
            string password = customTextBoxPassword.Text;
            string passwordSubmit = customTextBoxPasswordSubmit.Text;
            if (!checkTextBox(name, email, password, passwordSubmit))
                return;
            if (password == passwordSubmit)
            {
                var validName = await userAPI.ValidateUserName(name);
                var validEmail = await userAPI.ValidateEmail(customTextBoxEmail.Text);
                if (Regex.IsMatch(email, regEmail))
                {
                    if (validName.data == "true")
                    {
                        if (validEmail.data == "true")
                        {
                            bool isRegistred = await userAPI.Registration(ConvertToRegistration(name, email, password));
                            if (isRegistred)
                            {
                                var userInfo = convertToJSON(name, password);
                                var loginStatus = await userAPI.IsLogin(userInfo);
                                if (loginStatus.data != "false")
                                {
                                    parent.user = await userAPI.GetUser(loginStatus.token);
                                    parent.user.token = loginStatus.token;
                                    parent.userName.Text = parent.user.login;
                                    parent.activeForm = new Home();
                                    parent.openChildForm(new Home(), parent.buttonHome, parent.buttonHomeName);
                                    this.Close();
                                }
                                else
                                    //MessageBox.Show(loginStatus.errorMessage, "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    new Message(parent, loginStatus.errorMessage, true, false);

                                parent.openChildForm(new Home(), parent.buttonHome, parent.buttonHomeName);
                                this.Close();
                            }
                        }
                        else
                        {
                            new Message(parent, "Така пошта вже зареєстрована!", true, false);
                        }
                        //MessageBox.Show("Таке ім'я вже зареєстрована!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    //MessageBox.Show("Таке ім'я вже зареєстрован!е", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    {
                        new Message(parent, "Користувач з таким іменем вже зареєстрований!", true, false);
                    }
                }
                else
                // MessageBox.Show("Не валідна пошта!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    new Message(parent, "Не валідна пошта!", true, false);
                }   
            }
            else
                //MessageBox.Show("Паролі не збігаються!", "Різні паролі", MessageBoxButtons.OK, MessageBoxIcon.Error);
            {
                new Message(parent, "Паролі не збігаються!", true, false);
            }
        }

        private string convertToJSON(string userLogin, string userPass)
        {
            var content = new Dictionary<string, string>()
            {
                {"login", userLogin },
                {"password", userPass }
            };
            return JsonConvert.SerializeObject(content);
        }

        private string ConvertToRegistration(string name, string email, string password)
        {
            var userInfo = new Dictionary<string, string>
            {
                { "userName", name },
                { "email", email },
                { "password", password }
            };
            return JsonConvert.SerializeObject(userInfo);
        }

        private bool checkTextBox(string name, string email, string password, string passwordRepeat)
        {
            bool valid = true;
            if(string.IsNullOrWhiteSpace(name))
            {
                labelNameValid.Visible = true;
                valid = false;
            }
            else
                labelNameValid.Visible = false;
            if (string.IsNullOrWhiteSpace(email))
            {
                labelEmailValid.Visible = true;
                valid = false;
            }
            else
                labelEmailValid.Visible = false;
            if (string.IsNullOrWhiteSpace(password))
            {
                labelPasswordValid.Visible = true;
                valid = false;
            }
            else
                labelPasswordValid.Visible = false;
            if (string.IsNullOrWhiteSpace(passwordRepeat))
            {
                labelPasswordRepeatValid.Visible = true;
                valid = false;
            }
            else
                labelPasswordRepeatValid.Visible = false;
            return valid;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customTextBoxName.Text) && string.IsNullOrWhiteSpace(customTextBoxEmail.Text) 
                && string.IsNullOrWhiteSpace(customTextBoxPassword.Text) && string.IsNullOrWhiteSpace(customTextBoxPasswordSubmit.Text))
            {
                AccountMain account = new AccountMain(parent);
                parent.openChildForm(account, parent.buttonAccount, parent.buttonAccountName);
                return;
            }
            //DialogResult result = MessageBox.Show("Ваші дані буде втрачено. Ви хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            message = new Message(parent, "Ваші дані буде втрачено. Ви хочете вийти?", true, true);
            if (message.pressOk)
            {
                AccountMain account = new AccountMain(parent);
                parent.openChildForm(account, parent.buttonAccount, parent.buttonAccountName);
            }
        }
    }
}
