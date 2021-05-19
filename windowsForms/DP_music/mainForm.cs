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

        public mainForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            buttonSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSearch.Width, buttonSearch.Height, 10, 10));
            textBoxSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBoxSearch.Width, textBoxSearch.Height, 10, 10));

            openChildForm(new Home());
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
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeButtonColor(Panel panel, Button btn, int r, int g, int b )
        {
            panel.Visible = true;
            panel.Height = btn.Height;
            panel.Top = btn.Top;
            panel.Left = btn.Left;
            btn.BackColor = Color.FromArgb(r, g, b);
        }

        #region btnClick
        private void buttonHome_Click(object sender, EventArgs e)
        {
            changeButtonColor(panelNav, buttonHome, 19, 24, 54);
            openChildForm(new Home());
        }
        private void buttonGroups_Click(object sender, EventArgs e)
        {
            changeButtonColor(panelNav, buttonGroups, 19, 24, 54);
            openChildForm(new Groups());
        }
        private void buttonGenres_Click(object sender, EventArgs e)
        {
            changeButtonColor(panelNav, buttonGenres, 19, 24, 54);
        }
        private void buttonComposition_Click(object sender, EventArgs e)
        {
            changeButtonColor(panelNav, buttonComposition, 19, 24, 54);
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            changeButtonColor(panelNav, buttonSettings, 19, 24, 54);
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            changeButtonColor(panelNav, buttonRecord, 19, 24, 54);
        }

        #endregion

        #region btnLeave
        private void buttonHome_Leave(object sender, EventArgs e)
        {
            buttonHome.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonGroups_Leave(object sender, EventArgs e)
        {
            buttonGroups.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonGenres_Leave(object sender, EventArgs e)
        {
            buttonGenres.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonComposition_Leave(object sender, EventArgs e)
        {
            buttonComposition.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonSettings_Leave(object sender, EventArgs e)
        {
            buttonSettings.BackColor = Color.FromArgb(41, 52, 117);
        }

        private void buttonRecord_Leave(object sender, EventArgs e)
        {
            buttonRecord.BackColor = Color.FromArgb(41, 52, 117);
        }
        #endregion
    }
}
