using DP_music.API.query;
using DP_music.Entities;
using DP_music.helpers;
using DP_music.SubPages.Albums;
using NAudio.Wave;
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
using System.Runtime.InteropServices;

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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthElipse,
            int nHeightElipse
        );

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
                int y = 0;
                int x = 0;
                panelContent.Width = records.Count * 103 + 30 * (records.Count + 1);

                records.ForEach((record) =>
                {
                    Panel panelRecord = addPanel(x, y, panelContent, record.filePath);
                    PictureBox pictureBoxRecord = addPictureBoxRecord(record.name);
                    Button buttonPlay = addButtonPlay(record.filePath);
                    PictureBox pictureBoxPause = addPictureBoxPause(record.filePath);
                    Button pictureBoxMinus = addButtonMinus();
                    Label labelNameRecord = addLabelNameRecord(record.name);

                    panelRecord.Controls.Add(pictureBoxRecord);
                    panelRecord.Controls.Add(buttonPlay);
                    panelRecord.Controls.Add(pictureBoxPause);
                    panelRecord.Controls.Add(pictureBoxMinus);
                    panelRecord.Controls.Add(labelNameRecord);
                    panelContent.Controls.Add(panelRecord);

                    pictureBoxRecord.Click += pictureBoxRecord_Click;

                    i++;
                    x = i % 2;
                    y = i / 2;
                });
            }
            else
            {
                labelEmptyRecords.Visible = true;
                labelEmptyRecords.Location = new Point((panelContent.Width - labelEmptyRecords.Width) / 2, (panelContent.Height - labelEmptyRecords.Height) / 2);
            }
        }

        private Panel addPanel(int x, int y, Panel parent, string record)
        {
            Panel panelRecord = new Panel();
            panelRecord.Size = new Size(407, 103);
            panelRecord.Parent = parent;
            panelRecord.Location = new Point(30 * (x + 1) + 407 * x, 103 * y + 30 * (y + 1));
            panelRecord.BackColor = Color.Transparent;
            panelRecord.Parent = parent;
            panelRecord.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelRecord.Width, panelRecord.Height, 10, 10));
            if(currentRecord != null && currentRecord == record)
                panelRecord.BackColor = Color.FromArgb(50, 41, 52, 117);
            return panelRecord;
        }

        private void pictureBoxRecord_Click(object sender, EventArgs e)
        {
            PictureBox record = (PictureBox)sender;
            Record currentRecord = records.FirstOrDefault(e => e.id == record.AccessibleName);
            //parent.openChildForm(new AlbumDescription(parent, currentRecord, band, genre), parent.buttonAlbums, parent.buttonAlbumsName);
        }

        private PictureBox addPictureBoxRecord(string recordName)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Size = new Size(93, 93);
            pictureBoxImg.Location = new Point(5, 5);
            pictureBoxImg.AccessibleName = recordName;

            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.ImageLocation = Path.GetFullPath(@"..\..\..\pictures\record_blue.png");
            pictureBoxImg.Cursor = Cursors.Hand;

            //pictureBoxImg.BackColor = Color.White;
            return pictureBoxImg;
        }

        private Label addLabelNameRecord(string name)
        {
            Label labelName = new Label();
            labelName.Location = new Point(103, 0);
            labelName.Font = new Font(new FontFamily("Century Gothic"), 18, FontStyle.Bold);
            labelName.ForeColor = Color.FromArgb(41, 52, 117);
            labelName.Size = new Size(304, 35);
            labelName.Text = name.ToUpper();
            labelName.BackColor = Color.Transparent;
            return labelName;
        }

        private Button addButtonPlay(string urlRecord)
        {
            Button buttonPlay = new Button();
            buttonPlay.Size = new Size(50, 50);
            buttonPlay.Location = new Point(103, 48);
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.FlatAppearance.BorderSize = 0;
            buttonPlay.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\pictures\play.png"));
            buttonPlay.Cursor = Cursors.Hand;
            buttonPlay.BackColor = Color.Transparent;
            buttonPlay.AccessibleName = urlRecord;
            buttonPlay.Click += buttonPlay_Click;
            buttonPlay.Leave += buttonPlay_MouseLeave;

            return buttonPlay;
        }

        private PictureBox addPictureBoxPause(string urlRecord)
        {
            PictureBox pictureBoxPause = new PictureBox();
            pictureBoxPause.Size = new Size(50, 50);
            pictureBoxPause.Location = new Point(160, 48);
            pictureBoxPause.ImageLocation = Path.GetFullPath(@"..\..\..\pictures\pause.png");
            pictureBoxPause.Cursor = Cursors.Hand;
            pictureBoxPause.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPause.BackColor = Color.Transparent;
            pictureBoxPause.AccessibleName = urlRecord;
            pictureBoxPause.Click += pictureBoxPause_Click;

            return pictureBoxPause;
        }

        private Button addButtonMinus()
        {
            Button buttonMinus = new Button();
            buttonMinus.Size = new Size(50, 50);
            buttonMinus.Location = new Point(217, 48);
            buttonMinus.FlatStyle = FlatStyle.Flat;
            buttonMinus.FlatAppearance.BorderSize = 0;
            buttonMinus.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\pictures\minus_volume.png"));
            buttonMinus.Cursor = Cursors.Hand;
            buttonMinus.BackColor = Color.Transparent;
            buttonMinus.Click += pictureBoxMinusVolume_Click;

            return buttonMinus;
        }

        private void pictureBoxMinusVolume_Click(object sender, EventArgs e)
        {
            if(output != null && output.Volume > 0.2F)
            {
                output.Volume -= 0.2F;
            }
        }

        private static MediaFoundationReader recordUrl;
        private static WaveOut output;
        private static string currentRecord;
        private static float volume = 1F;

        public void buttonPlay_Click(object sender, EventArgs e)
        {
            Button pb = (Button)sender;

            if(output != null)
            {
                if (currentRecord != pb.AccessibleName)
                {
                    output.Stop();
                    PlayMp3FromUrl(pb.AccessibleName);
                    pb.Parent.BackColor = Color.FromArgb(50, 41, 52, 117);
                }
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                {
                    output.Play();
                }
            }
            else
            {
                PlayMp3FromUrl(pb.AccessibleName);
                pb.Parent.BackColor = Color.FromArgb(50, 41, 52, 117);
            }
        }

        public void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            Button pb = (Button)sender;
            pb.Parent.BackColor = Color.Transparent;
        }

        public void pictureBoxPause_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if(pb.AccessibleName == currentRecord)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    output.Pause();
                }
            }
        }

        public static void PlayMp3FromUrl(string audioName)
        {
            recordUrl = new MediaFoundationReader("http://164.90.166.133:7402/" + audioName);
            currentRecord = audioName;
            if (output != null)
                volume = output.Volume;

            output = new WaveOut();
            output.Volume = volume;
            output.Init(recordUrl);
            output.Play();
        }
    }
}
