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
using System.Reflection;
using System.Net;
using DP_music.API.query;

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
        private string url = "http://164.90.166.133:7402/";

        public Genres(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private async void Genres_Paint(object sender, PaintEventArgs e)
        {
            var responce = await genreAPI.GetAllGenres();
            if (responce != null)
            {
                genres = JsonConvert.DeserializeObject<List<Genre>>(responce);
            
                int x = 0;
                int y = 0;
                for(int i = 0; i < genres.Count; i++)
                {
                    x = i % 2;
                    y = i / 2;

                    PictureBox pbBorder = addBorderPictureBox(x, y, genres[i].image);
                    Panel panelGenre = AddNewPanel(pbBorder);

                    PictureBox pictureBoxGenre = addNewPictureBox(genres[i].id);
                    Label labelName = addNewLabel();
                    PictureBox pictureBoxDescription = addDescription(pictureBoxGenre, genres[i].id);
                    labelName.Text = genres[i].name.ToUpper();
                    labelName.BackColor = Color.Transparent;

                    pictureBoxGenre.ImageLocation = url + genres[i].image;
                    panelGenre.Controls.Add(pictureBoxDescription);
                    panelGenre.Controls.Add(pictureBoxGenre);
                    panelGenre.Controls.Add(labelName);
                    pbBorder.Controls.Add(panelGenre);
                    panelContent.Controls.Add(pbBorder);
                };
            }
            else
            {
                labelEmptyGanres.Visible = true;
                labelEmptyGanres.Location = new Point((panelContent.Width - labelEmptyGanres.Width) / 2, 
                    (panelContent.Height - labelEmptyGanres.Height) / 2);
            }
        }

        private Panel AddNewPanel(PictureBox parent)
        {
            Panel panelGenre = new Panel();
            panelGenre.Size = new Size(325, 304);
            panelGenre.Parent = parent;
            panelGenre.Location = new Point(0, 0);
            panelGenre.BackColor = Color.FromArgb(150, 41, 52, 117);

            return panelGenre;
        }

        private PictureBox addBorderPictureBox(int x, int y, string path)
        {
            PictureBox pbBorder = new PictureBox();
            pbBorder.Size = new Size(325, 304);
            pbBorder.Location = new Point(78 * (x + 1) + 325 * x, 304 * y + 30 * (y + 1));
            pbBorder.ImageLocation = url + path;
            pbBorder.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pbBorder.Width, pbBorder.Height, 10, 10));

            return pbBorder;
        }

        private PictureBox addNewPictureBox(string id)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.AccessibleName = id;
            pictureBoxImg.Location = new Point(40, 25);
            pictureBoxImg.Size = new Size(246,206);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.Cursor = Cursors.Hand;
            pictureBoxImg.Click += pictureBoxImg_Click;
            return pictureBoxImg;
        }

        private Label addNewLabel()
        {
            Label labelName = new Label();
            labelName.Location = new Point(40,250);
            labelName.Font = new Font(new FontFamily("Century Gothic"), 16, FontStyle.Bold);
            labelName.ForeColor = Color.White;
            labelName.Size = new Size(200, 27);
            return labelName;
        }

        private PictureBox addDescription(PictureBox parent, string id)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.AccessibleName = id;
            pictureBoxImg.Location = new Point(247,250);
            pictureBoxImg.Size = new Size(40, 32) ;
            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.Parent = parent;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.Cursor = Cursors.Hand;
            pictureBoxImg.ImageLocation = Path.GetFullPath(@"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\windowsForms\DP_music\pictures\description3.png");
            pictureBoxImg.Click += pictureBoxImg_Click;

            return pictureBoxImg;
        }

        private void pictureBoxImg_Click(object sender, EventArgs e)
        {
            PictureBox pB = (PictureBox)sender;
            var genre = genres.FirstOrDefault(e => e.id == pB.AccessibleName);
            parent.openChildForm(new GenreDescription(genre, parent), parent.buttonGenres, parent.buttonGenresName);
        }
    }
}
