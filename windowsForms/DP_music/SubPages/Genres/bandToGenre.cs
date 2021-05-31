using DP_music.Entities;
using DP_music.helpers;
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

namespace DP_music.SubPages.Genres
{
    public partial class bandToGenre : Form
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
        public Genre genre;

        public bandToGenre(mainForm parent, Genre genre)
        {
            this.parent = parent;
            this.genre = genre;
            InitializeComponent();
            labelGenreBande.Text += genre.name.ToUpper();
            labelGenreBande.Location = new Point((panelBandToGenre.Width - labelGenreBande.Width) / 2, (panelBandToGenre.Height - labelGenreBande.Height) / 2);
        }

        private async void bandToGenre_Load(object sender, EventArgs e)
        {
            var bands = await apiHelpers.getBand(genre.id);

            int i = 0;
            int x = 0;
            int y = 0;

            bands.ForEach((band) =>
            {
                PictureBox pictureBoxBorder = addPictureBoxBorder(x, y, band.image);
                PictureBox pictureBoxBand = addPictureBoxBand(band.image);

                Panel panelBorder = addPanelBorder(pictureBoxBorder);
                Label labelNameBand = addLabelNameBand(x, y, band.name);
                PictureBox pictureBoxFlag = pictureBoxCountryFlag(x, y, band.countryCode);

                panelBorder.Controls.Add(pictureBoxBand);
                pictureBoxBorder.Controls.Add(panelBorder);
                panelContent.Controls.Add(pictureBoxBorder);
                panelContent.Controls.Add(pictureBoxFlag);
                panelContent.Controls.Add(labelNameBand);

                i++;
                x = i % 3;
                y = i / 3;
            });
        }

        private PictureBox addPictureBoxBorder(int x, int y, string path)
        {
            PictureBox pbBorder = new PictureBox();
            pbBorder.Size = new Size(240, 240);
            pbBorder.Location = new Point(41 * (x + 1) + 240 * x, 240 * y + 30 * (y+1));
            pbBorder.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + path;
            //pbBorder.ImageLocation = " http://164.90.166.133/" + path;
            pbBorder.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pbBorder.Width, pbBorder.Height, 15, 15));

            return pbBorder;
        }

        private PictureBox addPictureBoxBand(string path)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Location = new Point(20, 20);
            pictureBoxImg.Size = new Size(200, 200);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + path;
            //pictureBoxImg.ImageLocation = "http://164.90.166.133/" + path;

            //pictureBoxImg.BackColor = Color.White;
            return pictureBoxImg;
        }

        private Panel addPanelBorder(PictureBox parent)
        {
            Panel panelGenre = new Panel();
            panelGenre.Size = new Size(240,240);
            panelGenre.Parent = parent;
            panelGenre.Location = new Point(0, 0);
            panelGenre.BackColor = Color.FromArgb(150, 41, 52, 117);

            return panelGenre;
        }

        private Label addLabelNameBand(int x, int y, string name)
        {
            Label labelName = new Label();
            labelName.Location = new Point(41 * (x + 1) + 240 * x, 270 * (y + 1));
            labelName.Font = new Font(new FontFamily("Century Gothic"), 16, FontStyle.Bold);
            labelName.ForeColor = Color.FromArgb(41, 52, 117);
            labelName.Size = new Size(190, 30);
            labelName.Text = name.ToUpper();
            return labelName;
        }

        private PictureBox pictureBoxCountryFlag(int x, int y, string countryCode)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Location = new Point(281 * x + 240, 270 * (y + 1));
            pictureBoxImg.Size = new Size(46, 27) ;
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.ImageLocation = "https://www.countryflags.io/" + countryCode + "/shiny/64.png"; ;

            return pictureBoxImg;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            parent.buttonGroups_Leave(this, new EventArgs());
            parent.buttonGenres_Click(this, new EventArgs());
            parent.openChildForm(new GenreDescription(genre, parent));
        }
    }
}
