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
using DP_music.SubPages.Bands;
using DP_music.helpers;

namespace DP_music.Pages
{
    public partial class Albums : Form
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
        public Band band = null;
        public Genre genre = null;
        private List<Album> albums;
        private string url = "http://164.90.166.133:7402/";

        public Albums(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            labelAlbums.Text = "АЛЬБОМИ";
            buttonBack.Visible = false;
        }

        public Albums(mainForm parent, Band band) : this(parent)
        {
            this.band = band;
            labelAlbums.Text = "АЛЬБОМИ, ЩО ВІДНОСЯТЬСЯ ДО " + band.name.ToUpper();
            buttonBack.Visible = true;
        }

        public Albums(mainForm parent, Band band, Genre genre) : this(parent, band)
        {
            this.band = band;
            this.genre = genre;
            labelAlbums.Text = "АЛЬБОМИ, ЩО ВІДНОСЯТЬСЯ ДО " + band.name.ToUpper();
            buttonBack.Visible = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(genre != null)
                parent.openChildForm(new bandDescription(parent, band, genre), parent.buttonGenres, parent.buttonGenresName);
            else
                parent.openChildForm(new bandDescription(parent, band), parent.buttonGenres, parent.buttonGenresName);
        }

        private async void Albums_Load(object sender, EventArgs e)
        {
            labelAlbums.Location = new Point((panelHeader.Width - labelAlbums.Width) / 2, (panelHeader.Height - labelAlbums.Height) / 2);
            if(band != null)
                albums = await apiHelpers.getAlbums(band.id);
            else
                albums = await apiHelpers.getAlbums();
            if (albums != null)
            {
                int i = 0;
                int x = 0;
                int y = 0;

                albums.ForEach((album) =>
                {
                    PictureBox pictureBoxBorder = addPictureBoxBorder(x, y, album.image);
                    PictureBox pictureBoxAlbum = addPictureBoxAlbum(album.image, album.id);

                    Panel panelBorder = addPanelBorder(pictureBoxBorder);
                    Label labelNameBand = addLabelNameAlbum(x, y, album.name);
                    labelNameBand.Location = new Point(labelNameBand.Location.X + (panelBorder.Width - labelNameBand.Width) / 2,
                        labelNameBand.Location.Y);

                    panelBorder.Controls.Add(pictureBoxAlbum);
                    pictureBoxBorder.Controls.Add(panelBorder);
                    panelContent.Controls.Add(pictureBoxBorder);
                    panelContent.Controls.Add(labelNameBand);

                    pictureBoxAlbum.Click += pictureBoxBand_Click;

                    i++;
                    x = i % 3;
                    y = i / 3;
                });
            }
            else
            {
                labelEmptyAlbums.Visible = true;
                labelEmptyAlbums.Location = new Point((panelContent.Width - labelEmptyAlbums.Width) / 2, (panelContent.Height - labelEmptyAlbums.Height) / 2);
            }
        }

        private PictureBox addPictureBoxBorder(int x, int y, string path)
        {
            PictureBox pbBorder = new PictureBox();
            pbBorder.Size = new Size(240, 240);
            pbBorder.Location = new Point(41 * (x + 1) + 240 * x, 240 * y + 40 * (y + 1));
            //pbBorder.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + path;
            pbBorder.ImageLocation = url + path;
            pbBorder.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pbBorder.Width, pbBorder.Height, pbBorder.Width, pbBorder.Width));

            return pbBorder;
        }

        private void pictureBoxBand_Click(object sender, EventArgs e)
        {
            PictureBox album = (PictureBox)sender;
            Album currentAlbum = albums.FirstOrDefault(e => e.id == album.AccessibleName);
            //if (band != null)
                //parent.openChildForm(new bandDescription(parent, currentAlbum, band), parent.buttonGroups, parent.buttonGroupsName);
            //else
                //parent.openChildForm(new bandDescription(parent, currentBand), parent.buttonGroups, parent.buttonGroupsName);
        }

        private PictureBox addPictureBoxAlbum(string path, string albumId)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.AccessibleName = albumId;
            pictureBoxImg.Location = new Point(45, 45);
            pictureBoxImg.Size = new Size(150, 150);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            //pictureBoxImg.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + path;
            pictureBoxImg.Cursor = Cursors.Hand;
            pictureBoxImg.ImageLocation = url + path;
            pictureBoxImg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBoxImg.Width, pictureBoxImg.Height, 
                pictureBoxImg.Width, pictureBoxImg.Width));

            //pictureBoxImg.BackColor = Color.White;
            return pictureBoxImg;
        }

        private Panel addPanelBorder(PictureBox parent)
        {
            Panel panelGenre = new Panel();
            panelGenre.Size = new Size(240, 240);
            panelGenre.Parent = parent;
            panelGenre.Location = new Point(0, 0);
            panelGenre.BackColor = Color.FromArgb(90, 255, 255, 255);

            return panelGenre;
        }

        private Label addLabelNameAlbum(int x, int y, string name)
        {
            Label labelName = new Label();
            labelName.Location = new Point(41 * (x + 1) + 240 * x, 280 * (y + 1));
            labelName.Font = new Font(new FontFamily("Century Gothic"), 16, FontStyle.Bold);
            labelName.ForeColor = Color.FromArgb(41, 52, 117);
            labelName.Size = new Size(190, 30);
            labelName.Text = name.ToUpper();
            return labelName;
        }
    }
}
