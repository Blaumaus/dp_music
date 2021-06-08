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
using DP_music.SubPages.Genres;
using DP_music.SubPages.Bands;

namespace DP_music.Pages
{
    public partial class Bands : Form
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
        public Genre genre = null;
        private List<Band> bands;
        private string url = "http://164.90.166.133:7402/";

        public Bands(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            labelBands.Text = "ГУРТИ";
            buttonBack.Visible = false;
        }

        public Bands(mainForm parent, Genre genre): this(parent)
        {
            this.genre = genre;
            labelBands.Text = "ГУРТИ, ЯКІ ВІДНОСЯТЬСЯ ДО ЖАНРУ " + genre.name.ToUpper();
            buttonBack.Visible = true;
        }

        private async void Bands_Load(object sender, EventArgs e)
        {
            labelBands.Location = new Point((panelHeader.Width - labelBands.Width) / 2, (panelHeader.Height - labelBands.Height) / 2);
            if (genre != null)
                bands = await apiHelpers.getBands(genre.id);
            else
                //Повертає всі групи, але без айді жанрів
                bands = await apiHelpers.getBands("8158cc6f-aebb-418d-9b0a-e0acc3f443a3");
            if (bands != null)
            {
                int i = 0;
                int x = 0;
                int y = 0;

                bands.ForEach((band) =>
                {
                    PictureBox pictureBoxBorder = addPictureBoxBorder(x, y, band.image);
                    PictureBox pictureBoxBand = addPictureBoxBand(band.image, band.id);

                    Panel panelBorder = addPanelBorder(pictureBoxBorder);
                    Label labelNameBand = addLabelNameBand(x, y, band.name);
                    PictureBox pictureBoxFlag = pictureBoxCountryFlag(x, y, band.countryCode);

                    panelBorder.Controls.Add(pictureBoxBand);
                    pictureBoxBorder.Controls.Add(panelBorder);
                    panelContent.Controls.Add(pictureBoxBorder);
                    panelContent.Controls.Add(pictureBoxFlag);
                    panelContent.Controls.Add(labelNameBand);

                    pictureBoxBand.Click += pictureBoxBand_Click;

                    i++;
                    x = i % 3;
                    y = i / 3;
                });
            }
            else
            {
                labelEmptyBands.Visible = true;
                labelEmptyBands.Location = new Point((panelContent.Width - labelEmptyBands.Width) / 2, (panelContent.Height - labelEmptyBands.Height) / 2);
            }
        }

        private PictureBox addPictureBoxBorder(int x, int y, string path)
        {
            PictureBox pbBorder = new PictureBox();
            pbBorder.Size = new Size(240, 240);
            pbBorder.Location = new Point(41 * (x + 1) + 240 * x, 240 * y + 30 * (y + 1));
            //pbBorder.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + path;
            pbBorder.ImageLocation = url + path;
            pbBorder.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pbBorder.Width, pbBorder.Height, 15, 15));

            return pbBorder;
        }

        private void pictureBoxBand_Click(object sender, EventArgs e)
        {
            PictureBox band = (PictureBox)sender;
            Band currentBand = bands.FirstOrDefault(e => e.id == band.AccessibleName);
            if(genre != null)
                parent.openChildForm(new bandDescription(parent, currentBand, genre), parent.buttonGroups, parent.buttonGroupsName);
            else
                parent.openChildForm(new bandDescription(parent, currentBand), parent.buttonGroups, parent.buttonGroupsName);
        }

        private PictureBox addPictureBoxBand(string path, string bandId)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.AccessibleName = bandId;
            pictureBoxImg.Location = new Point(20, 20);
            pictureBoxImg.Size = new Size(200, 200);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            //pictureBoxImg.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + path;
            pictureBoxImg.Cursor = Cursors.Hand;
            pictureBoxImg.ImageLocation = url + path;

            //pictureBoxImg.BackColor = Color.White;
            return pictureBoxImg;
        }

        private Panel addPanelBorder(PictureBox parent)
        {
            Panel panelGenre = new Panel();
            panelGenre.Size = new Size(240, 240);
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
            pictureBoxImg.Size = new Size(46, 27);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.ImageLocation = "https://www.countryflags.io/" + countryCode + "/shiny/64.png";

            return pictureBoxImg;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            parent.openChildForm(new GenreDescription(genre, parent), parent.buttonGenres, parent.buttonGenresName);
        }
    }
}
