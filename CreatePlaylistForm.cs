using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sonic_Music_Player.LibraryClass; 

namespace Sonic_Music_Player
{
    public partial class CreatePlaylistForm : Form
    {
        /// <summary>
        /// Playlist Cover Image Path
        /// </summary>
        public string COVER_IMAGE_PATH = string.Empty;

        /// <summary>
        /// Playlist name
        /// </summary>
        public string PLAYLIST_NAME = string.Empty;


        public CreatePlaylistForm()
        {
            InitializeComponent();
        }


        private void playlistCoverImagePB_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(COVER_IMAGE_PATH))
            {
                playlistCoverImagePB.Image = Image.FromFile(COVER_IMAGE_PATH);
            }
            else
            {
                playlistCoverImagePB.Image = Properties.Resources.playlist_cover_image;
            }

            choosePictureLabel.Visible = false;
        }

        private void playlistCoverImagePB_MouseEnter(object sender, EventArgs e)
        {
            //playlistCoverImagePB.Image = Image.FromFile("D:\\admin\\Desktop\\Project 3\\Page Designs\\icons\\Edit_pencil_image.png");
            playlistCoverImagePB.Image = Properties.Resources.Edit_pencil_image;
            choosePictureLabel.Visible = true;
        }

        private bool ValidateFormFields()
        {
            if (playlistNameTB.Text.Length == 0)
            {
                warningMessageLabel.Text = "Enter playlist name !";
                warningMessageLabel.Visible = true;
                return false;
            }
            if (string.IsNullOrWhiteSpace(playlistNameTB.Text))
            {
                warningMessageLabel.Text = "Enter playlist name !";
                warningMessageLabel.Visible = true;
                return false;
            }
            if (playlistNameTB.Text.Contains(","))
            {
                warningMessageLabel.Text = "You can't use comma ','";
                warningMessageLabel.Visible = true;
                return false;
            }

            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // validate fields
            ValidateFormFields();

            // 1. playlist name 
            PLAYLIST_NAME = playlistNameTB.Text.Trim();

            // 2. cover image path 
            // call create playlist method

            if (!(COVER_IMAGE_PATH.Length == 0))
            {
                // cover image path is specified

                // Call DashboardMethod() from the instance of DashboardForm
                CreatePlaylistInFile(PLAYLIST_NAME, new List<int>(), false, COVER_IMAGE_PATH);

            }
            else
            {
                // cover image path not specified
                CreatePlaylistInFile(PLAYLIST_NAME, new List<int>(), IsFirstPlaylist: false);

            }


            Close();
        }

        private void playlistCoverImagePB_Click(object sender, EventArgs e)
        {
            // Open file explorer 
            // select cover image
            // store cover image path 

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set the file dialog properties
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Filter for image files
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.Multiselect = false; // Allow only one file selection

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedImagePath = openFileDialog1.FileName;
                COVER_IMAGE_PATH = selectedImagePath.Trim();


                playlistCoverImagePB.Image = Image.FromFile(COVER_IMAGE_PATH);

                // Use the selectedImagePath as needed
                //MessageBox.Show("Selected Image Path: " + selectedImagePath);
            }
        }

        private void playlistNameTB_TextChanged(object sender, EventArgs e)
        {
            if (warningMessageLabel.Visible)
            {
                warningMessageLabel.Visible = false;
            }
        }

    }
}
