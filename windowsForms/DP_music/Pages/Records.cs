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
        public static Panel currentRecord = null;

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
        #region constructors
        public Records(mainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            labelRecord.Text = "АУДІО";
            labelRecord.Font = new Font(new FontFamily("Century Gothic"), 18, FontStyle.Bold);
            buttonBack.Visible = false;
        }

        public Records(mainForm parent, Album album) : this(parent)
        {
            this.album = album;
            labelRecord.Text = "АУДІО, ЯКІ ВІДНОСЯТЬСЯ ДО АЛЬБОМУ " + album.name.ToUpper();
            labelRecord.Font = new Font(new FontFamily("Century Gothic"), 14, FontStyle.Bold);
            labelRecord.Location = new Point((panelHeader.Width - labelRecord.Width) / 2,
                (panelHeader.Height - labelRecord.Height) / 2);
            buttonBack.Visible = true;
        }

        public Records(mainForm parent, Album album, Band band) : this(parent, album)
        {
            this.band = band;
        }
        public Records(mainForm parent, Album album, Band band, Genre genre) : this(parent, album, band)
        {
            this.genre = genre;
        }
        #endregion

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (genre != null && band != null && album != null)
                parent.openChildForm(new AlbumDescription(parent, album, band, genre), parent.buttonAlbums, parent.buttonAlbumsName);
            else if (band != null && album != null)
                parent.openChildForm(new AlbumDescription(parent, album, band), parent.buttonAlbums, parent.buttonAlbumsName);
            else
                parent.openChildForm(new AlbumDescription(parent, album), parent.buttonAlbums, parent.buttonAlbumsName);
        }

        private async void Records_Load(object sender, EventArgs e)
        {
            labelRecord.Location = new Point((panelHeader.Width - labelRecord.Width) / 2, 
                (panelHeader.Height - labelRecord.Height) / 2);
            if (album != null)
                records = await recordAPI.getRecords(album.id);
            else
                records = await recordAPI.getRecords();
            if (records != null && records.Count != 0)
            {
                int i = 0;
                int y = 0;
                int x = 0;

                records.ForEach((record) =>
                {
                    Panel panelRecord = addPanel(x, y, panelContent, record.filePath);
                    PictureBox pictureBoxRecord = addPictureBoxRecord(record.name);
                    Button buttonPlay = addButtonPlay(record.filePath);
                    PictureBox pictureBoxPause = addPictureBoxPause(record.filePath);
                    Label labelNameRecord = addLabelNameRecord(record.name);

                    if (currentRecord != null  && panelRecord.AccessibleName == currentRecord.AccessibleName)
                    {
                        panelRecord.BackColor = Color.FromArgb(50, 41, 52, 117);
                        currentRecord = panelRecord;
                    }

                    panelRecord.Controls.Add(pictureBoxRecord);
                    panelRecord.Controls.Add(buttonPlay);
                    panelRecord.Controls.Add(pictureBoxPause);
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
                labelEmptyRecords.Location = new Point((panelContent.Width - labelEmptyRecords.Width) / 2, 
                    (panelContent.Height - labelEmptyRecords.Height) / 2);
            }
        }

        private Panel addPanel(int x, int y, Panel parent, string record)
        {
            Panel panelRecord = new Panel();
            panelRecord.AccessibleName = record;
            panelRecord.Size = new Size(407, 103);
            panelRecord.Parent = parent;
            panelRecord.Location = new Point(30 * (x + 1) + 407 * x, 103 * y + 30 * (y + 1));
            panelRecord.BackColor = Color.Transparent;
            panelRecord.Parent = parent;
            panelRecord.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelRecord.Width, panelRecord.Height, 10, 10));
            
            return panelRecord;
        }

        private void pictureBoxRecord_Click(object sender, EventArgs e)
        {
            PictureBox record = (PictureBox)sender;
            Record currentRecord = records.FirstOrDefault(e => e.id == record.AccessibleName);
        }

        private PictureBox addPictureBoxRecord(string recordName)
        {
            PictureBox pictureBoxImg = new PictureBox();
            pictureBoxImg.Size = new Size(93, 93);
            pictureBoxImg.Location = new Point(5, 5);
            pictureBoxImg.AccessibleName = recordName;

            pictureBoxImg.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImg.BackColor = Color.Transparent;
            pictureBoxImg.ImageLocation = Path.GetFullPath(@"..\..\..\pictures\record_icon(orig).png");
            pictureBoxImg.Cursor = Cursors.Hand;

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

        private static MediaFoundationReader recordUrl;
        private static WaveOut output;

        public void buttonPlay_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(output != null)
            {
                if (currentRecord.AccessibleName != button.AccessibleName)
                {
                    output.Stop();
                    currentRecord.BackColor = Color.Transparent;
                    PlayMp3FromUrl((Panel)button.Parent);
                }
                else if (output.PlaybackState == PlaybackState.Paused)
                {
                    output.Play();
                }
            }
            else
            {
                PlayMp3FromUrl((Panel)button.Parent);
            }
        }

        public void pictureBoxPause_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if(pb.AccessibleName == currentRecord.AccessibleName)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    output.Pause();
                }
            }
        }

        public static void PlayMp3FromUrl(Panel currentPanel)
        {
            recordUrl = new MediaFoundationReader("http://164.90.166.133:7402/" + currentPanel.AccessibleName);
            currentRecord = currentPanel;
            currentRecord.BackColor = Color.FromArgb(50, 41, 52, 117);

            output = new WaveOut();
            output.Init(recordUrl);
            output.Play();
        }
    }
}
