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

namespace DP_music.SubPages.Genres
{
    public partial class GenreDescription : Form
    {
        public Genre genre;
        private mainForm parent;
        private string url = "http://164.90.166.133:7402/";

        public GenreDescription(Genre genre, mainForm parent)
        {
            this.parent = parent;
            this.genre = genre;
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            parent.buttonGenres_Click(this, new EventArgs());
        }

        private void GenreDescription_Load(object sender, EventArgs e)
        {
            labelGenreName.Text = genre.name.ToUpper();
            labelGenreName.Location = new Point((panelName.Width - labelGenreName.Width) / 2, (panelName.Height - labelGenreName.Height) / 2);
            pictureBoxImage.ImageLocation = url + genre.image;
            textBoxDescription.Text = genre.description;
        }

        private void buttonBands_Click(object sender, EventArgs e)
        {
            parent.openChildForm(new Pages.Bands(parent, genre), parent.buttonGroups, parent.buttonGroupsName);
        }
    }
}