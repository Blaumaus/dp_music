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
using DP_music.Pages;
using DP_music.Account;
using DP_music.Entities;

namespace DP_music
{
    public partial class mainForm : Form
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
        public User user { get; set; }
        public Button userName
        {
            get => buttonAccountName;
            set => buttonAccountName.Text = value.ToString();
        }

        public Form activeForm = null;
        private Button activeButton = null;
        private Button subActiveButton = null;

        public mainForm()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            openChildForm(new Home(), buttonHome, buttonHomeName);
            panelHeader.BringToFront();
            panelBar.Size = new Size(0, panelBar.Height);
            panelChildForm.Size = panelContent.Size;
            user = new User();
            buttonAccountName.Text = user.login;
            buttonHome_Click(this, new EventArgs());
        }

        public void openChildForm(Form childForm, Button active, Button subActive)
        {
            if (activeForm != null)
            {
                if(activeForm.Name == "SignIn" || activeForm.Name == "SignUp")
                {
                    //DialogResult result = MessageBox.Show("Ваші дані буде втрачено. Ви хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    var message = new Message(this, "Ваші дані буде втрачено. Ви хочете вийти?", true, true);
                    if (message.pressOk)
                    {
                        activeForm.Close();
                    }
                    else
                    {
                        return;
                    }
                }
                activeForm.Close();
            }
            clickButton(active, subActive);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Tag = this;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void clickButton(Button active, Button subActive)
        {
            if (activeButton != null && subActiveButton != null)
            {
                panelNav.Visible = false;
                activeButton.BackColor = Color.FromArgb(63, 81, 181);
                subActiveButton.BackColor = Color.FromArgb(63, 81, 181);
                activeButton = active;
                subActiveButton = subActive;
            }
            else
            {
                activeButton = buttonHome;
                subActiveButton = buttonHomeName;
            }
            changeButtonColor(panelNav, activeButton, 41, 52, 117);
            changeButtonColor(panelNav, subActiveButton, 41, 52, 117);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeButtonColor(Panel panel, Button btn, int r, int g, int b)
        {
            panel.Visible = true;
            panel.Height = btn.Height;
            panel.Top = btn.Top;
            panel.Left = btn.Left;
            btn.BackColor = Color.FromArgb(r, g, b);
        }

        #region btnClick
        public void buttonHome_Click(object sender, EventArgs e)
        {
            openChildForm(new Home(), buttonHome, buttonHomeName);
            if(panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }
        public void buttonGroups_Click(object sender, EventArgs e)
        {
            openChildForm(new Bands(this), buttonGroups, buttonGroupsName);
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }
        public void buttonGenres_Click(object sender, EventArgs e)
        {
            openChildForm(new Genres(this), buttonGenres, buttonGenresName);
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }
        public void buttonAlbums_Click(object sender, EventArgs e)
        {
            openChildForm(new Albums(this), buttonAlbums, buttonAlbumsName);
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }

        public void buttonRecord_Click(object sender, EventArgs e)
        {
            openChildForm(new Record(), buttonRecord, buttonRecordName);
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }

        public void buttonAccount_Click(object sender, EventArgs e)
        {
            if( user.login == "ГІСТЬ")
            {
                openChildForm(new AccountMain(this), buttonAccount, buttonAccountName);
            }
            else
                openChildForm(new AccountLogout(this), buttonAccount, buttonAccountName);
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }

        private void buttonHomeName_Click(object sender, EventArgs e)
        {
            buttonHome_Click(buttonHome, new EventArgs());
            timerClosePanelBar.Enabled = true;
        }

        private void buttonGroupsName_Click(object sender, EventArgs e)
        {
            buttonGroups_Click(buttonGroups, new EventArgs());
            timerClosePanelBar.Enabled = true;
        }

        private void buttonGenresName_Click(object sender, EventArgs e)
        {
            buttonGenres_Click(buttonGenres, new EventArgs());
            timerClosePanelBar.Enabled = true;
        }

        private void buttonAlbumsName_Click(object sender, EventArgs e)
        {
            buttonAlbums_Click(buttonAlbums, new EventArgs());
            timerClosePanelBar.Enabled = true;
        }

        private void buttonRecordName_Click(object sender, EventArgs e)
        {
            buttonRecord_Click(buttonRecord, new EventArgs());
            timerClosePanelBar.Enabled = true;
        }

        private void buttonAccountName_Click(object sender, EventArgs e)
        {
            buttonAccount_Click(buttonAccount, new EventArgs());
            timerClosePanelBar.Enabled = true;
        }

        #endregion

        private void timerOpenPanelBar_Tick(object sender, EventArgs e)
        {
            if (timerClosePanelBar.Enabled)
            {
                timerClosePanelBar.Enabled = false;
            }

            if (panelBar.Width < 184)
            {
                panelBar.BringToFront();
                int panelWidth = panelBar.Width;
                panelWidth += 16;
                panelBar.Size = new Size(panelWidth, panelBar.Height);
            }
            else
            {
                timerOpenPanelBar.Enabled = false;
            }
        }

        private void timerClosePanelBar_Tick(object sender, EventArgs e)
        {
            if(timerOpenPanelBar.Enabled)
            {
                timerOpenPanelBar.Enabled = false;
            }
            if (panelBar.Width > 0)
            {
                int panelWidth = panelBar.Width;
                panelWidth -= 16;
                panelBar.Size = new Size(panelWidth, panelBar.Height);
            }
            else
                timerClosePanelBar.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panelBar.Width == 0)
            {
                panelBar.Visible = true;
                timerOpenPanelBar.Enabled = true;
                activeForm.Enabled = false;
                //activeForm.BackColor = Color.FromArgb(225, 225, 225);
            }
            else
            {
                timerClosePanelBar.Enabled = true;
                activeForm.Enabled = true;
                //activeForm.BackColor = Color.White;
            }
        }

        
    }
}
