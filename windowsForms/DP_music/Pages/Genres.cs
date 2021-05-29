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

        public Genres()
        {
            InitializeComponent();
        }
        private async void Genres_Load(object sender, EventArgs e)
        {
            var responce = await apiHelpers.GetAllGenres();
            List<Genre> genre = new List<Genre>();
            genre = JsonConvert.DeserializeObject<List<Genre>>(responce);
            //StaticData staticData = new StaticData();
            //List<Genre> genre = staticData.getStaticGenre();
            int i = 0;
            genre.ForEach((genre)=>
            {
                Panel panelGenre = AddNewPanel(i);
                PictureBox pictureBoxGenre = addNewPictureBox(i);
                Label labelName = addNewLabel();
                labelName.Text = genre.name.ToUpper();
                TextBox textBoxDescription = addNewTextBox();
                textBoxDescription.Text = genre.description;

                //string url = Path.GetFullPath(@"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\wwwroot\Images\" + genre.image);
                string urlImage = "http://164.90.166.133/" + genre.image;
                pictureBoxGenre.ImageLocation = urlImage;
                panelGenre.Controls.Add(pictureBoxGenre);
                panelGenre.Controls.Add(labelName);
                panelGenre.Controls.Add(textBoxDescription);
                this.Controls.Add(panelGenre);
                i++;
            });
        }

        private Panel AddNewPanel(int i)
        {
            Panel panelGenre = new Panel();
            panelGenre.Size = new Size(845, 190);
            panelGenre.Location = new Point(20, 189 * i + 20 * (i+1));
            panelGenre.BackColor = Color.FromArgb(58, 150, 194);
            panelGenre.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 845, 189, 25, 25));

            return panelGenre;
        }

        private PictureBox addNewPictureBox(int i)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Location = new Point(20, 20);
            pictureBoxImg.Size = new Size(150,150);
            pictureBoxImg.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxImg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 150, 150, 50, 50));
            return pictureBoxImg;
        }

        private Label addNewLabel()
        {
            Label labelName = new Label();
            labelName.Location = new Point(199, 20);
            labelName.Font = new Font( new FontFamily("Century Gothic"), 14, FontStyle.Bold);
            labelName.ForeColor = Color.White;
            labelName.Size = new Size(433, 25);
            return labelName;
        }

        private TextBox addNewTextBox()
        {
            TextBox textBoxDescription = new TextBox();
            textBoxDescription.Location = new Point(200, 61);
            textBoxDescription.Multiline = true;
            textBoxDescription.Size = new Size(620, 110);
            textBoxDescription.ReadOnly = true;
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.ForeColor = Color.Black;
            textBoxDescription.Font = new Font(new FontFamily("Century Gothic"), 12);
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 620, 110, 10, 10));
            textBoxDescription.BorderStyle = BorderStyle.None;

            return textBoxDescription;
        }
    }
}
