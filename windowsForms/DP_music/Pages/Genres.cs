using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DP_music.helpers;
using DP_music.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.InteropServices;
using DP_music.staticData;
using DP_music.SubPages.Genres;

namespace DP_music.Pages
{
    public partial class Genres : Form
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

        private List<Genre> genres;
        private mainForm parent;

        public Genres(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        private async void Genres_Load(object sender, EventArgs e)
        {
            var responce = await apiHelpers.GetAllGenres();
            genres = JsonConvert.DeserializeObject<List<Genre>>(responce);
            //StaticData staticData = new StaticData();
            //List<Genre> genres = staticData.getStaticGenre();
            
            int i = 0;
            int x = 0;
            int y = 0;
            genres.ForEach((genre) =>
            {
                Panel panelGenre = AddNewPanel(x, y);
                PictureBox pictureBoxGenre = addNewPictureBox();
                Label labelName = addNewLabel();
                PictureBox pictureBoxDescription = addDescription(pictureBoxGenre, genre.id);
                labelName.Text = genre.name.ToUpper();

                string urlImage = "http://164.90.166.133/" + genre.image;
                pictureBoxGenre.ImageLocation = urlImage;
                panelGenre.Controls.Add(pictureBoxDescription);
                panelGenre.Controls.Add(pictureBoxGenre);
                panelGenre.Controls.Add(labelName);
                panelContent.Controls.Add(panelGenre);
                i++;
                x = i % 3;
                y = i / 3;

            });
            panelContent.Height = y < 1 ? 590 : 265 * (y+1) + 30 * (y + 2);
            //panelContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelContent.Width, panelContent.Height, 25, 25));
        }

        private Panel AddNewPanel(int x, int y)
        {
            Panel panelGenre = new Panel();
            panelGenre.Size = new Size(236, 265);
            panelGenre.Location = new Point(29 * (x+1) + 236 * x, 265 * y + 30 * (y+1));
            //panelGenre.BackColor = Color.White;
            panelGenre.BackColor = Color.FromArgb(82, 177, 250);
            panelGenre.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelGenre.Width, panelGenre.Height, 25, 25));

            return panelGenre;
        }

        private PictureBox addNewPictureBox()
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Location = new Point(18, 18);
            pictureBoxImg.Size = new Size(200,200);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.White;
            return pictureBoxImg;
        }

        private Label addNewLabel()
        {
            Label labelName = new Label();
            labelName.Location = new Point(18, 221);
            labelName.Font = new Font(new FontFamily("Century Gothic"), 14, FontStyle.Bold);
            //labelName.ForeColor = Color.White;
            labelName.ForeColor = Color.FromArgb(41, 52, 117);
            labelName.Size = new Size(200, 25);
            return labelName;
        }

        private PictureBox addDescription(PictureBox parent, string id)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.AccessibleName = id;
            pictureBoxImg.Location = new Point(179, 221);
            pictureBoxImg.Size = new Size(39,39) ;
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.Parent = parent;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.Cursor = Cursors.Hand;
            pictureBoxImg.ImageLocation = Path.GetFullPath(@"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\windowsForms\DP_music\pictures\description2.png");
            pictureBoxImg.Click += pictureBoxImg_Click;

            return pictureBoxImg;
        }

        private void pictureBoxImg_Click(object sender, EventArgs e)
        {
            PictureBox pB = (PictureBox)sender;
            var genre = genres.FirstOrDefault(e => e.id == pB.AccessibleName);
            parent.openChildForm(new GenreDescription(genre, parent));
        }


    }
}
