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
    public partial class Message : Form
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

        public bool pressOk = false;
        public bool pressCancel = false;
        private Form parent;

        public Message(Form parent, string message, bool buttonOk, bool buttonCancel)
        {
            InitializeComponent();
            textBoxMessage.BringToFront();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            textBoxMessage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBoxMessage.Width, textBoxMessage.Height, 25, 25));
            if (!buttonOk)
                buttonOK.Visible = false;
            if (!buttonCancel)
                buttonCANCEL.Visible = false;
            textBoxMessage.Text = message;
            this.parent = parent;
            parent.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowDialog();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            pressOk = true;
            parent.Enabled = true;
            this.Close();
        }

        private void buttonCANCEL_Click(object sender, EventArgs e)
        {
            pressCancel = true;
            parent.Enabled = true;
            this.Close();
        }
    }
}
