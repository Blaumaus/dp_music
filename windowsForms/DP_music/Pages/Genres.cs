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

namespace DP_music.Pages
{
    public partial class Genres : Form
    {
        public Genres()
        {
            InitializeComponent();
        }
        private async void Genres_Load(object sender, EventArgs e)
        {
            var responce = await apiHelpers.GetAll();
            List<Genre> genre = new List<Genre>();
            genre = JsonConvert.DeserializeObject<List<Genre>>(responce);
            genre.ForEach((genre)=>
            {
                labelName.Text = genre.name.ToUpper();
                textBoxDescription.Text = genre.description;
                //string url = Path.GetFullPath(@"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\wwwroot\Images\" + genre.image);
                pictureBoxGenre.SizeMode = PictureBoxSizeMode.Zoom;
                string url = "https://localhost:44304/" + genre.image;
                pictureBoxGenre.ImageLocation = url;
            });
        }
    }
}
