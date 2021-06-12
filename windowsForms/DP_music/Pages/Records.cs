using DP_music.API.query;
using DP_music.Entities;
using DP_music.helpers;
using DP_music.SubPages.Albums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_music.Pages
{
    public partial class Records : Form
    {
        public mainForm parent;
        public Band band = null;
        public Genre genre = null;
        public Album album = null;
        public Record record = null;
        public List<Record> records = null;

        private string url = "http://164.90.166.133:7402/";

        public Records(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            labelRecord.Text = "АУДІО";
            buttonBack.Visible = false;
        }

        public Records(mainForm parent, Album album) : this(parent)
        {
            this.album = album;
            labelRecord.Text = "АЛЬБОМИ, ЩО ВІДНОСЯТЬСЯ ДО " + band.name.ToUpper();
            buttonBack.Visible = true;
        }

        public Records(mainForm parent, Album album, Band band) : this(parent, album)
        {
            this.band = band;
            labelRecord.Text = "АУДІО, ЯКІ ВІДНОСЯТЬСЯ ДО АЛЬБОМУ " + band.name.ToUpper();
            buttonBack.Visible = true;
        }
        public Records(mainForm parent, Album album, Band band, Genre genre) : this(parent, album, band)
        {
            this.genre = genre;
            labelRecord.Text = "АУДІО, ЯКІ ВІДНОСЯТЬСЯ ДО АЛЬБОМУ " + band.name.ToUpper();
            buttonBack.Visible = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (genre != null && band != null && album != null)
                parent.openChildForm(new AlbumDescription(parent, album, band, genre), parent.buttonGenres, parent.buttonGenresName);
            else if (band != null && album != null)
                parent.openChildForm(new AlbumDescription(parent, album, band), parent.buttonGenres, parent.buttonGenresName);
            else
                parent.openChildForm(new AlbumDescription(parent, album), parent.buttonGenres, parent.buttonGenresName);
        }

        private async void Records_Load(object sender, EventArgs e)
        {
            labelRecord.Location = new Point((panelHeader.Width - labelRecord.Width) / 2, (panelHeader.Height - labelRecord.Height) / 2);
            if (album != null && band !=null)
                records = await recordAPI.getRecords(album.id, band.id);
            else
                records = await recordAPI.getRecords();
            if (records != null)
            {
                int i = 0;

                records.ForEach((record) =>
                {
                    PictureBox pictureBoxRecord = addPictureBoxRecord(i, record.name);
                    PictureBox pictureBoxPlay = addPictureBoxPlay(pictureBoxRecord.Width + 35, i, record.filePath);
                    Label labelNameRecord = addLabelNameRecord(pictureBoxRecord.Width + 35, i, record.name);

                    panelContent.Controls.Add(pictureBoxRecord);
                    panelContent.Controls.Add(pictureBoxPlay);
                    panelContent.Controls.Add(labelNameRecord);

                    pictureBoxRecord.Click += pictureBoxRecord_Click;

                    i++;
                });
            }
            else
            {
                labelEmptyRecords.Visible = true;
                labelEmptyRecords.Location = new Point((panelContent.Width - labelEmptyRecords.Width) / 2, (panelContent.Height - labelEmptyRecords.Height) / 2);
            }
        }

        private void pictureBoxRecord_Click(object sender, EventArgs e)
        {
            PictureBox record = (PictureBox)sender;
            Record currentRecord = records.FirstOrDefault(e => e.id == record.AccessibleName);
            //parent.openChildForm(new AlbumDescription(parent, currentRecord, band, genre), parent.buttonAlbums, parent.buttonAlbumsName);
        }

        private PictureBox addPictureBoxRecord(int y, string recordName)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Size = new Size(85, 85);
            pictureBoxImg.Location = new Point(25, 25 * (y + 1) + pictureBoxImg.Width * y);
            pictureBoxImg.AccessibleName = recordName;

            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\windowsForms\DP_music\pictures\record.png";
            pictureBoxImg.Cursor = Cursors.Hand;

            //pictureBoxImg.BackColor = Color.White;
            return pictureBoxImg;
        }

        private Label addLabelNameRecord(int x, int y, string name)
        {
            Label labelName = new Label();
            labelName.Location = new Point(x, 25 * (y + 1) + 85 * y);
            labelName.Font = new Font(new FontFamily("Century Gothic"), 18, FontStyle.Bold);
            labelName.ForeColor = Color.FromArgb(41, 52, 117);
            labelName.Size = new Size(400, 35);
            labelName.Text = name.ToUpper();
            return labelName;
        }

        private PictureBox addPictureBoxPlay(int x, int y, string url)
        {
            PictureBox pictureBoxPlay = new PictureBox();
            pictureBoxPlay.Size = new Size(35, 35);
            pictureBoxPlay.Location = new Point(x, 75 * (y + 1) + 35 * y);
            pictureBoxPlay.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\windowsForms\DP_music\pictures\play.png";
            pictureBoxPlay.Cursor = Cursors.Hand;
            pictureBoxPlay.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPlay.BackColor = Color.Transparent;
            pictureBoxPlay.AccessibleName = url;
            pictureBoxPlay.Click += pictureBoxPlay_Click;

            return pictureBoxPlay;
        }

        public void pictureBoxPlay_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            WebClient Client = new WebClient();
            Client.DownloadFile(url + pb.AccessibleName, Directory.GetCurrentDirectory());

            return;
        }
    }
}
