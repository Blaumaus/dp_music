﻿using DP_music.Entities;
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


namespace DP_music.SubPages.Bands
{
    public partial class bandDescription : Form
    {
        private mainForm parent;
        private Band band;
        private Genre genre;
        private string url = "http://164.90.166.133:7402/";

        public bandDescription(mainForm parent, Band band)
        {
            this.parent = parent;
            this.band = band;
            InitializeComponent();
            initialize();
        }

        public bandDescription(mainForm parent, Band band, Genre genre):this(parent, band)
        {
            this.genre = genre;
        }

        private async void initialize()
        {
            pictureBoxImage.ImageLocation = url + band.image;
            //pictureBoxImage.ImageLocation = @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\" + band.image;
            labelBandName.Text = band.name.ToUpper();
            labelBandCountry.Text = band.countryCode.ToUpper();
            labelBandDate.Text = band.foundationData.ToString().Substring(0,10).ToUpper();
            pictureBoxFlag.ImageLocation = "https://www.countryflags.io/" + band.countryCode + "/shiny/64.png";
            var genre = await apiHelpers.GetGenre(band.genreId);
            labelBandGenre.Text = genre.name.ToUpper();
            textBoxDescription.Text = band.description;
            labelBandName.Location = new Point((panelName.Width - labelBandName.Width) / 2,
                (panelName.Height - labelBandName.Height) / 2);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(genre != null)
                parent.openChildForm(new Pages.Bands(parent, genre), parent.buttonGroups, parent.buttonGroupsName);
            else
                parent.openChildForm(new Pages.Bands(parent), parent.buttonGroups, parent.buttonGroupsName);
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            parent.openChildForm(new Pages.Albums(parent, band, genre), parent.buttonAlbums, parent.buttonAlbumsName);

        }
    }
}