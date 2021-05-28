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

        public mainForm()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            buttonSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSearch.Width, buttonSearch.Height, 10, 10));
            textBoxSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBoxSearch.Width, textBoxSearch.Height, 10, 10));
            openChildForm(new Home());
            panelHeader.BringToFront();
            panelBar.Size = new Size(0, panelBar.Height);
            panelChildForm.Size = panelContent.Size;
            user = new User();
            buttonAccountName.Text = user.login;
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                if(activeForm.Name == "SignIn")
                {
                    DialogResult result = MessageBox.Show("Ваші дані буде втрачено. Ви хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
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
            openChildForm(new Home());
            if(activeForm.Name == "Home")
            {
                changeButtonColor(panelNav, buttonHome, 19, 24, 54);
                buttonHomeName.BackColor = Color.FromArgb(19, 24, 54);
            }
            if(panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }
        private void buttonGroups_Click(object sender, EventArgs e)
        {
            openChildForm(new Groups());
            if (activeForm.Name == "Groups")
            {
                changeButtonColor(panelNav, buttonGroups, 19, 24, 54);
                buttonGroupsName.BackColor = Color.FromArgb(19, 24, 54);
            }
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }
        private void buttonGenres_Click(object sender, EventArgs e)
        {
            openChildForm(new Genres());
            if (activeForm.Name == "Genres")
            {
                changeButtonColor(panelNav, buttonGenres, 19, 24, 54);
                buttonGenresName.BackColor = Color.FromArgb(19, 24, 54);
            }
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }
        private void buttonComposition_Click(object sender, EventArgs e)
        {
            openChildForm(new Composition());
            if (activeForm.Name == "Composition")
            {
                changeButtonColor(panelNav, buttonComposition, 19, 24, 54);
                buttonCompositionName.BackColor = Color.FromArgb(19, 24, 54);
            }
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            openChildForm(new Record());
            if (activeForm.Name == "Record")
            {
                changeButtonColor(panelNav, buttonRecord, 19, 24, 54);
                buttonRecordName.BackColor = Color.FromArgb(19, 24, 54);
            }
            if (panelBar.Width > 0)
            {
                timerClosePanelBar.Enabled = true;
            }
        }

        public void buttonAccount_Click(object sender, EventArgs e)
        {
            if( user.login == "Guest")
            {
                openChildForm(new AccountMain(this));
                if (activeForm.Name == "Composition")
                {
                    changeButtonColor(panelNav, buttonAccount, 19, 24, 54);
                    buttonAccountName.BackColor = Color.FromArgb(19, 24, 54);
                }
                
            }
            else
                openChildForm(new AccountLogout(this));
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

        private void buttonCompositionName_Click(object sender, EventArgs e)
        {
            buttonComposition_Click(buttonComposition, new EventArgs());
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

        #region btnLeave
        private void buttonHome_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonHome.BackColor = Color.FromArgb(41, 52, 117);
            buttonHomeName.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonGroups_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonGroups.BackColor = Color.FromArgb(41, 52, 117);
            buttonGroupsName.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonGenres_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonGenres.BackColor = Color.FromArgb(41, 52, 117);
            buttonGenresName.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonComposition_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonComposition.BackColor = Color.FromArgb(41, 52, 117);
            buttonCompositionName.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonSettings_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonSettings.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonRecord_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonRecord.BackColor = Color.FromArgb(41, 52, 117);
            buttonRecordName.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonAccount_Leave(object sender, EventArgs e)
        {
            panelNav.Visible = false;
            buttonAccount.BackColor = Color.FromArgb(41, 52, 117);
            buttonAccountName.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonHomeName_Leave(object sender, EventArgs e)
        {
            buttonHome_Leave(buttonHome, new EventArgs());
        }

        private void buttonGroupsName_Leave(object sender, EventArgs e)
        {
            buttonGroups_Leave(buttonGroups, new EventArgs());
        }

        private void buttonGenresName_Leave(object sender, EventArgs e)
        {
            buttonGenres_Leave(buttonGenres, new EventArgs());
        }

        private void buttonCompositionName_Leave(object sender, EventArgs e)
        {
            buttonComposition_Leave(buttonComposition, new EventArgs());
        }

        private void buttonRecordName_Leave(object sender, EventArgs e)
        {
            buttonRecord_Leave(buttonRecord, new EventArgs());
        }

        private void buttonAccountName_Leave(object sender, EventArgs e)
        {
            buttonAccount_Leave(buttonRecord, new EventArgs());

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
                activeForm.BackColor = Color.FromArgb(225, 225, 225);
            }
            else
            {
                timerClosePanelBar.Enabled = true;
                activeForm.Enabled = true;
                activeForm.BackColor = Color.White;
            }
        }

        
    }
}
