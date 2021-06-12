using DP_music.API.query;
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

namespace DP_music.SubPages.Albums
{
    public partial class AlbumDescription : Form
    {
        private mainForm parent;
        private Band band;
        private Genre genre;
        private Album album;
        private string url = "http://164.90.166.133:7402/";
        public AlbumDescription()
        {
            InitializeComponent();
        }

        public AlbumDescription(mainForm parent, Album album)
        {
            this.parent = parent;
            this.album = album;
            InitializeComponent();
            initialize();
        }

        public AlbumDescription(mainForm parent, Album album, Band band) : this(parent, album)
        {
            this.band = band;
        }

        public AlbumDescription(mainForm parent, Album album, Band band, Genre genre) : this(parent, album, band)
        {
            this.genre = genre;
        }

        private async void initialize()
        {

            pictureBoxImage.ImageLocation = url + album.image;
            //pictureBoxImage.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + band.image;
            labelAlbumName.Text = album.name.ToUpper();
            labelAlbumYear.Text = album.year.ToString().ToUpper();
            //var band_ = await bandAPI.getBand(album.bandId);
            //labelAlbumBand.Text = band_.name.ToUpper();
            textBoxDescription.Text = album.description;
            labelAlbumName.Location = new Point((panelName.Width - labelAlbumName.Width) / 2,
                (panelName.Height - labelAlbumName.Height) / 2);
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            parent.openChildForm(new Pages.Records(parent, album, band, genre), parent.buttonRecord, parent.buttonRecordName);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (genre != null && band != null)
                parent.openChildForm(new Pages.Albums(parent, band, genre), parent.buttonGroups, parent.buttonGroupsName);
            else if (band != null)
                parent.openChildForm(new Pages.Albums(parent, band), parent.buttonGroups, parent.buttonGroupsName);
            else
                parent.openChildForm(new Pages.Albums(parent), parent.buttonGroups, parent.buttonGroupsName);
        }
    }
}
