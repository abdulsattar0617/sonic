using NAudio.CoreAudioApi;
using System.Drawing.Text;
using System.Windows.Forms;
using static Sonic_Music_Player.LibraryClass;

namespace Sonic_Music_Player
{
    partial class DashboardForm
    {
        // Custom Font File Path
        //string fontFilePath = "E:\\PROJECTS\\Sonic Music Player\\Fonts\\Roboto-Light.ttf";



        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            topLeftPanel = new Panel();
            HomeButtonPanel = new Panel();
            HomeLabel = new Label();
            HomeIconPB = new PictureBox();
            SearchButtonPanel = new Panel();
            searchLabel = new Label();
            searchIconPB = new PictureBox();
            middleLeftPanel = new Panel();
            libraryIconPB = new PictureBox();
            addPlaylistIconPB = new PictureBox();
            libPlaylistTagLabel = new Label();
            yourLibraryLabel = new Label();
            playlistListPanel = new Panel();
            middlePanel = new Panel();
            EditPlaylistPB = new PictureBox();
            addSongsPB = new PictureBox();
            playingPlaylistIconPB = new PictureBox();
            songListHeaderPanel = new Panel();
            horizontalLineLabel = new Label();
            songDurationLogoPB = new PictureBox();
            titleLabel = new Label();
            srNoLabel = new Label();
            dotLabel = new Label();
            playingPlaylistNameLabel = new Label();
            totalSongOfPlaylistLabel = new Label();
            playlistLabel = new Label();
            usernameLabel = new Label();
            playingSongsLabel = new Label();
            songProgressBar = new ProgressBar();
            songPlayedTime = new Label();
            songTotalTime = new Label();
            addFolderButton = new Button();
            greetLabel = new Label();
            playingSongImagePB = new PictureBox();
            playPauseButtonPB = new PictureBox();
            nextTrackPB = new PictureBox();
            previousTrackPB = new PictureBox();
            songNameTB = new TextBox();
            audioControllerPB = new PictureBox();
            volumeProgressPB = new ProgressBar();
            volumeControllerPanel = new Panel();
            songLikeButtonOfSCPB = new PictureBox();
            searchBarTB = new TextBox();
            topLeftPanel.SuspendLayout();
            HomeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HomeIconPB).BeginInit();
            SearchButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)searchIconPB).BeginInit();
            middleLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)libraryIconPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addPlaylistIconPB).BeginInit();
            middlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EditPlaylistPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addSongsPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playingPlaylistIconPB).BeginInit();
            songListHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)songDurationLogoPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playingSongImagePB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playPauseButtonPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nextTrackPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)previousTrackPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)audioControllerPB).BeginInit();
            volumeControllerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)songLikeButtonOfSCPB).BeginInit();
            SuspendLayout();
            // 
            // topLeftPanel
            // 
            topLeftPanel.BackColor = Color.FromArgb(18, 18, 18);
            topLeftPanel.Controls.Add(HomeButtonPanel);
            topLeftPanel.Controls.Add(SearchButtonPanel);
            topLeftPanel.Location = new Point(10, 10);
            topLeftPanel.Name = "topLeftPanel";
            topLeftPanel.Size = new Size(300, 82);
            topLeftPanel.TabIndex = 0;
            // 
            // HomeButtonPanel
            // 
            HomeButtonPanel.BackColor = Color.Transparent;
            HomeButtonPanel.Controls.Add(HomeLabel);
            HomeButtonPanel.Controls.Add(HomeIconPB);
            HomeButtonPanel.Location = new Point(0, 0);
            HomeButtonPanel.Name = "HomeButtonPanel";
            HomeButtonPanel.Size = new Size(200, 40);
            HomeButtonPanel.TabIndex = 13;
            HomeButtonPanel.Click += HomeButton_Click;
            HomeButtonPanel.MouseEnter += NavButton_MouseEnter;
            HomeButtonPanel.MouseLeave += NavButton_MouseLeave;
            // 
            // HomeLabel
            // 
            HomeLabel.AutoSize = true;
            HomeLabel.BackColor = Color.Transparent;
            HomeLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            HomeLabel.ForeColor = Color.Silver;
            HomeLabel.Location = new Point(60, 10);
            HomeLabel.Name = "HomeLabel";
            HomeLabel.Size = new Size(56, 21);
            HomeLabel.TabIndex = 16;
            HomeLabel.Text = "Home";
            HomeLabel.Click += HomeButton_Click;
            HomeLabel.MouseEnter += NavButtonLabel_MouseEnter;
            HomeLabel.MouseLeave += NavButtonLabel_MouseLeave;
            // 
            // HomeIconPB
            // 
            HomeIconPB.BackgroundImage = (Image)resources.GetObject("HomeIconPB.BackgroundImage");
            HomeIconPB.BackgroundImageLayout = ImageLayout.Stretch;
            HomeIconPB.Location = new Point(20, 8);
            HomeIconPB.Name = "HomeIconPB";
            HomeIconPB.Size = new Size(30, 25);
            HomeIconPB.TabIndex = 17;
            HomeIconPB.TabStop = false;
            HomeIconPB.Click += HomeButton_Click;
            // 
            // SearchButtonPanel
            // 
            SearchButtonPanel.BackColor = Color.Transparent;
            SearchButtonPanel.Controls.Add(searchLabel);
            SearchButtonPanel.Controls.Add(searchIconPB);
            SearchButtonPanel.Location = new Point(0, 40);
            SearchButtonPanel.Name = "SearchButtonPanel";
            SearchButtonPanel.Size = new Size(200, 40);
            SearchButtonPanel.TabIndex = 14;
            SearchButtonPanel.Click += SearchButton_Click;
            SearchButtonPanel.MouseEnter += NavButton_MouseEnter;
            SearchButtonPanel.MouseLeave += NavButton_MouseLeave;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.BackColor = Color.Transparent;
            searchLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            searchLabel.ForeColor = Color.Silver;
            searchLabel.Location = new Point(60, 10);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(61, 21);
            searchLabel.TabIndex = 15;
            searchLabel.Text = "Search";
            searchLabel.Click += SearchButton_Click;
            searchLabel.MouseEnter += NavButtonLabel_MouseEnter;
            searchLabel.MouseLeave += NavButtonLabel_MouseLeave;
            // 
            // searchIconPB
            // 
            searchIconPB.BackgroundImage = (Image)resources.GetObject("searchIconPB.BackgroundImage");
            searchIconPB.BackgroundImageLayout = ImageLayout.Stretch;
            searchIconPB.Location = new Point(20, 8);
            searchIconPB.Name = "searchIconPB";
            searchIconPB.Size = new Size(30, 25);
            searchIconPB.TabIndex = 15;
            searchIconPB.TabStop = false;
            searchIconPB.Click += SearchButton_Click;
            // 
            // middleLeftPanel
            // 
            middleLeftPanel.BackColor = Color.FromArgb(18, 18, 18);
            middleLeftPanel.Controls.Add(libraryIconPB);
            middleLeftPanel.Controls.Add(addPlaylistIconPB);
            middleLeftPanel.Controls.Add(libPlaylistTagLabel);
            middleLeftPanel.Controls.Add(yourLibraryLabel);
            middleLeftPanel.Controls.Add(playlistListPanel);
            middleLeftPanel.Location = new Point(10, 100);
            middleLeftPanel.Name = "middleLeftPanel";
            middleLeftPanel.Size = new Size(300, 340);
            middleLeftPanel.TabIndex = 0;
            // 
            // libraryIconPB
            // 
            libraryIconPB.BackColor = Color.Transparent;
            libraryIconPB.BackgroundImage = Properties.Resources.library_icon;
            libraryIconPB.BackgroundImageLayout = ImageLayout.Stretch;
            libraryIconPB.Cursor = Cursors.Hand;
            libraryIconPB.Location = new Point(20, 15);
            libraryIconPB.Name = "libraryIconPB";
            libraryIconPB.Size = new Size(30, 25);
            libraryIconPB.TabIndex = 9;
            libraryIconPB.TabStop = false;
            // 
            // addPlaylistIconPB
            // 
            addPlaylistIconPB.BackColor = Color.Transparent;
            addPlaylistIconPB.BackgroundImage = Properties.Resources.playlist_add_icon;
            addPlaylistIconPB.BackgroundImageLayout = ImageLayout.Stretch;
            addPlaylistIconPB.Cursor = Cursors.Hand;
            addPlaylistIconPB.Location = new Point(253, 15);
            addPlaylistIconPB.Name = "addPlaylistIconPB";
            addPlaylistIconPB.Size = new Size(30, 30);
            addPlaylistIconPB.TabIndex = 10;
            addPlaylistIconPB.TabStop = false;
            addPlaylistIconPB.Click += addPlaylistIconPB_Click;
            addPlaylistIconPB.MouseEnter += addPlaylistIconPB_MouseEnter;
            addPlaylistIconPB.MouseLeave += addPlaylistIconPB_MouseLeave;
            // 
            // libPlaylistTagLabel
            // 
            libPlaylistTagLabel.AutoSize = true;
            libPlaylistTagLabel.BackColor = Color.Transparent;
            libPlaylistTagLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            libPlaylistTagLabel.ForeColor = Color.White;
            libPlaylistTagLabel.Location = new Point(20, 60);
            libPlaylistTagLabel.Name = "libPlaylistTagLabel";
            libPlaylistTagLabel.Size = new Size(49, 13);
            libPlaylistTagLabel.TabIndex = 11;
            libPlaylistTagLabel.Text = "Playlists";
            // 
            // yourLibraryLabel
            // 
            yourLibraryLabel.AutoSize = true;
            yourLibraryLabel.BackColor = Color.Transparent;
            yourLibraryLabel.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            yourLibraryLabel.ForeColor = Color.Silver;
            yourLibraryLabel.Location = new Point(60, 20);
            yourLibraryLabel.Name = "yourLibraryLabel";
            yourLibraryLabel.Size = new Size(84, 17);
            yourLibraryLabel.TabIndex = 6;
            yourLibraryLabel.Text = "Your Library";
            // 
            // playlistListPanel
            // 
            playlistListPanel.AutoScroll = true;
            playlistListPanel.BackColor = Color.Transparent;
            playlistListPanel.Location = new Point(0, 120);
            playlistListPanel.Name = "playlistListPanel";
            playlistListPanel.Size = new Size(300, 230);
            playlistListPanel.TabIndex = 12;
            // 
            // middlePanel
            // 
            middlePanel.AutoScroll = true;
            middlePanel.BackColor = Color.FromArgb(128, 76, 255);
            middlePanel.Controls.Add(EditPlaylistPB);
            middlePanel.Controls.Add(addSongsPB);
            middlePanel.Controls.Add(playingPlaylistIconPB);
            middlePanel.Controls.Add(songListHeaderPanel);
            middlePanel.Controls.Add(dotLabel);
            middlePanel.Controls.Add(playingPlaylistNameLabel);
            middlePanel.Controls.Add(totalSongOfPlaylistLabel);
            middlePanel.Controls.Add(playlistLabel);
            middlePanel.Controls.Add(usernameLabel);
            middlePanel.Location = new Point(317, 100);
            middlePanel.Name = "middlePanel";
            middlePanel.Size = new Size(667, 340);
            middlePanel.TabIndex = 0;
            // 
            // EditPlaylistPB
            // 
            EditPlaylistPB.BackColor = Color.Transparent;
            EditPlaylistPB.BackgroundImage = Properties.Resources.edit_playlist_icon;
            EditPlaylistPB.BackgroundImageLayout = ImageLayout.Stretch;
            EditPlaylistPB.Cursor = Cursors.Hand;
            EditPlaylistPB.Location = new Point(620, 10);
            EditPlaylistPB.Name = "EditPlaylistPB";
            EditPlaylistPB.Size = new Size(40, 40);
            EditPlaylistPB.TabIndex = 13;
            EditPlaylistPB.TabStop = false;
            EditPlaylistPB.Tag = "-1";
            EditPlaylistPB.Click += EditPlaylistPB_Click;
            EditPlaylistPB.MouseEnter += AddSongsPB_MouseEnter;
            EditPlaylistPB.MouseLeave += AddSongsPB_MouseLeave;
            // 
            // addSongsPB
            // 
            addSongsPB.BackColor = Color.Transparent;
            addSongsPB.BackgroundImage = Properties.Resources.add_box_icon;
            addSongsPB.BackgroundImageLayout = ImageLayout.Stretch;
            addSongsPB.Cursor = Cursors.Hand;
            addSongsPB.Location = new Point(620, 56);
            addSongsPB.Name = "addSongsPB";
            addSongsPB.Size = new Size(40, 40);
            addSongsPB.TabIndex = 14;
            addSongsPB.TabStop = false;
            addSongsPB.Tag = "-1";
            addSongsPB.Click += addSongsPB_Click;
            // 
            // playingPlaylistIconPB
            // 
            playingPlaylistIconPB.BackgroundImage = (Image)resources.GetObject("playingPlaylistIconPB.BackgroundImage");
            playingPlaylistIconPB.BackgroundImageLayout = ImageLayout.Stretch;
            playingPlaylistIconPB.Location = new Point(20, 70);
            playingPlaylistIconPB.Name = "playingPlaylistIconPB";
            playingPlaylistIconPB.Size = new Size(150, 150);
            playingPlaylistIconPB.TabIndex = 0;
            playingPlaylistIconPB.TabStop = false;
            // 
            // songListHeaderPanel
            // 
            songListHeaderPanel.BackColor = Color.FromArgb(51, 51, 140);
            songListHeaderPanel.Controls.Add(horizontalLineLabel);
            songListHeaderPanel.Controls.Add(songDurationLogoPB);
            songListHeaderPanel.Controls.Add(titleLabel);
            songListHeaderPanel.Controls.Add(srNoLabel);
            songListHeaderPanel.Location = new Point(0, 247);
            songListHeaderPanel.Name = "songListHeaderPanel";
            songListHeaderPanel.Size = new Size(652, 80);
            songListHeaderPanel.TabIndex = 12;
            // 
            // horizontalLineLabel
            // 
            horizontalLineLabel.BackColor = Color.Gray;
            horizontalLineLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            horizontalLineLabel.ForeColor = Color.White;
            horizontalLineLabel.Location = new Point(24, 66);
            horizontalLineLabel.Name = "horizontalLineLabel";
            horizontalLineLabel.Size = new Size(600, 1);
            horizontalLineLabel.TabIndex = 11;
            // 
            // songDurationLogoPB
            // 
            songDurationLogoPB.BackgroundImage = (Image)resources.GetObject("songDurationLogoPB.BackgroundImage");
            songDurationLogoPB.BackgroundImageLayout = ImageLayout.Stretch;
            songDurationLogoPB.Location = new Point(580, 48);
            songDurationLogoPB.Name = "songDurationLogoPB";
            songDurationLogoPB.Size = new Size(15, 15);
            songDurationLogoPB.TabIndex = 10;
            songDurationLogoPB.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(75, 50);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(29, 13);
            titleLabel.TabIndex = 9;
            titleLabel.Text = "Title";
            // 
            // srNoLabel
            // 
            srNoLabel.AutoSize = true;
            srNoLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            srNoLabel.ForeColor = Color.White;
            srNoLabel.Location = new Point(40, 50);
            srNoLabel.Name = "srNoLabel";
            srNoLabel.Size = new Size(14, 13);
            srNoLabel.TabIndex = 8;
            srNoLabel.Text = "#";
            // 
            // dotLabel
            // 
            dotLabel.AutoSize = true;
            dotLabel.BackColor = Color.Transparent;
            dotLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            dotLabel.ForeColor = Color.White;
            dotLabel.Location = new Point(263, 206);
            dotLabel.Name = "dotLabel";
            dotLabel.Size = new Size(12, 13);
            dotLabel.TabIndex = 9;
            dotLabel.Text = "•";
            // 
            // playingPlaylistNameLabel
            // 
            playingPlaylistNameLabel.AutoSize = true;
            playingPlaylistNameLabel.BackColor = Color.Transparent;
            playingPlaylistNameLabel.Font = new Font("Leelawadee UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            playingPlaylistNameLabel.ForeColor = Color.White;
            playingPlaylistNameLabel.Location = new Point(176, 95);
            playingPlaylistNameLabel.Name = "playingPlaylistNameLabel";
            playingPlaylistNameLabel.Size = new Size(399, 86);
            playingPlaylistNameLabel.TabIndex = 6;
            playingPlaylistNameLabel.Text = "Liked Songs";
            // 
            // totalSongOfPlaylistLabel
            // 
            totalSongOfPlaylistLabel.AutoSize = true;
            totalSongOfPlaylistLabel.BackColor = Color.Transparent;
            totalSongOfPlaylistLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            totalSongOfPlaylistLabel.ForeColor = Color.White;
            totalSongOfPlaylistLabel.Location = new Point(274, 207);
            totalSongOfPlaylistLabel.Name = "totalSongOfPlaylistLabel";
            totalSongOfPlaylistLabel.Size = new Size(19, 13);
            totalSongOfPlaylistLabel.TabIndex = 10;
            totalSongOfPlaylistLabel.Text = "00";
            // 
            // playlistLabel
            // 
            playlistLabel.AutoSize = true;
            playlistLabel.BackColor = Color.Transparent;
            playlistLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            playlistLabel.ForeColor = Color.White;
            playlistLabel.Location = new Point(190, 82);
            playlistLabel.Name = "playlistLabel";
            playlistLabel.Size = new Size(44, 13);
            playlistLabel.TabIndex = 7;
            playlistLabel.Text = "Playlist";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(190, 207);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(75, 13);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Music Buddy";
            // 
            // playingSongsLabel
            // 
            playingSongsLabel.AutoSize = true;
            playingSongsLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            playingSongsLabel.ForeColor = Color.White;
            playingSongsLabel.Location = new Point(290, 206);
            playingSongsLabel.Name = "playingSongsLabel";
            playingSongsLabel.Size = new Size(38, 13);
            playingSongsLabel.TabIndex = 11;
            playingSongsLabel.Text = "songs";
            // 
            // songProgressBar
            // 
            songProgressBar.BackColor = Color.Gray;
            songProgressBar.Cursor = Cursors.Hand;
            songProgressBar.ForeColor = Color.White;
            songProgressBar.Location = new Point(363, 494);
            songProgressBar.Name = "songProgressBar";
            songProgressBar.Size = new Size(370, 2);
            songProgressBar.TabIndex = 3;
            // 
            // songPlayedTime
            // 
            songPlayedTime.AutoSize = true;
            songPlayedTime.ForeColor = Color.Gray;
            songPlayedTime.Location = new Point(318, 485);
            songPlayedTime.Name = "songPlayedTime";
            songPlayedTime.Size = new Size(26, 17);
            songPlayedTime.TabIndex = 4;
            songPlayedTime.Text = "-:--";
            // 
            // songTotalTime
            // 
            songTotalTime.AutoSize = true;
            songTotalTime.ForeColor = Color.Gray;
            songTotalTime.Location = new Point(739, 485);
            songTotalTime.Name = "songTotalTime";
            songTotalTime.Size = new Size(26, 17);
            songTotalTime.TabIndex = 5;
            songTotalTime.Text = "-:--";
            // 
            // addFolderButton
            // 
            addFolderButton.BackColor = Color.FromArgb(27, 215, 96);
            addFolderButton.FlatStyle = FlatStyle.Flat;
            addFolderButton.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            addFolderButton.ForeColor = Color.Black;
            addFolderButton.Location = new Point(828, 12);
            addFolderButton.Name = "addFolderButton";
            addFolderButton.Size = new Size(144, 35);
            addFolderButton.TabIndex = 6;
            addFolderButton.Text = "Add folder";
            addFolderButton.UseVisualStyleBackColor = false;
            addFolderButton.Click += addFolderButton_Click;
            // 
            // greetLabel
            // 
            greetLabel.AutoSize = true;
            greetLabel.Font = new Font("Leelawadee UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            greetLabel.ForeColor = Color.White;
            greetLabel.Location = new Point(318, 12);
            greetLabel.Name = "greetLabel";
            greetLabel.Size = new Size(160, 37);
            greetLabel.TabIndex = 5;
            greetLabel.Text = "Welcome ! ";
            // 
            // playingSongImagePB
            // 
            playingSongImagePB.BackgroundImage = Properties.Resources.song_playing_gif;
            playingSongImagePB.BackgroundImageLayout = ImageLayout.Zoom;
            playingSongImagePB.Image = Properties.Resources.song_playing_gif;
            playingSongImagePB.Location = new Point(30, 460);
            playingSongImagePB.Name = "playingSongImagePB";
            playingSongImagePB.Size = new Size(40, 40);
            playingSongImagePB.SizeMode = PictureBoxSizeMode.Zoom;
            playingSongImagePB.TabIndex = 7;
            playingSongImagePB.TabStop = false;
            playingSongImagePB.Visible = false;
            // 
            // playPauseButtonPB
            // 
            playPauseButtonPB.BackgroundImage = Properties.Resources.play_button_bp_icon;
            playPauseButtonPB.BackgroundImageLayout = ImageLayout.Stretch;
            playPauseButtonPB.Cursor = Cursors.Hand;
            playPauseButtonPB.Location = new Point(535, 460);
            playPauseButtonPB.Name = "playPauseButtonPB";
            playPauseButtonPB.Size = new Size(30, 25);
            playPauseButtonPB.TabIndex = 8;
            playPauseButtonPB.TabStop = false;
            playPauseButtonPB.Click += playPauseButtonPB_Click;
            // 
            // nextTrackPB
            // 
            nextTrackPB.BackgroundImage = (Image)resources.GetObject("nextTrackPB.BackgroundImage");
            nextTrackPB.BackgroundImageLayout = ImageLayout.Stretch;
            nextTrackPB.Cursor = Cursors.Hand;
            nextTrackPB.Location = new Point(590, 465);
            nextTrackPB.Name = "nextTrackPB";
            nextTrackPB.Size = new Size(15, 15);
            nextTrackPB.TabIndex = 9;
            nextTrackPB.TabStop = false;
            nextTrackPB.Click += nextTrackPB_Click;
            // 
            // previousTrackPB
            // 
            previousTrackPB.BackgroundImage = (Image)resources.GetObject("previousTrackPB.BackgroundImage");
            previousTrackPB.BackgroundImageLayout = ImageLayout.Stretch;
            previousTrackPB.Cursor = Cursors.Hand;
            previousTrackPB.Location = new Point(490, 465);
            previousTrackPB.Name = "previousTrackPB";
            previousTrackPB.Size = new Size(15, 15);
            previousTrackPB.TabIndex = 10;
            previousTrackPB.TabStop = false;
            previousTrackPB.Click += previousTrackPB_Click;
            // 
            // songNameTB
            // 
            songNameTB.BackColor = Color.Black;
            songNameTB.BorderStyle = BorderStyle.None;
            songNameTB.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            songNameTB.ForeColor = Color.White;
            songNameTB.Location = new Point(85, 465);
            songNameTB.Name = "songNameTB";
            songNameTB.Size = new Size(200, 22);
            songNameTB.TabIndex = 11;
            // 
            // audioControllerPB
            // 
            audioControllerPB.BackgroundImage = (Image)resources.GetObject("audioControllerPB.BackgroundImage");
            audioControllerPB.BackgroundImageLayout = ImageLayout.Stretch;
            audioControllerPB.Location = new Point(10, 10);
            audioControllerPB.Name = "audioControllerPB";
            audioControllerPB.Size = new Size(15, 15);
            audioControllerPB.TabIndex = 12;
            audioControllerPB.TabStop = false;
            // 
            // volumeProgressPB
            // 
            volumeProgressPB.BackColor = Color.Gray;
            volumeProgressPB.ForeColor = Color.White;
            volumeProgressPB.Location = new Point(30, 17);
            volumeProgressPB.Name = "volumeProgressPB";
            volumeProgressPB.Size = new Size(90, 2);
            volumeProgressPB.TabIndex = 13;
            volumeProgressPB.Value = 50;
            // 
            // volumeControllerPanel
            // 
            volumeControllerPanel.BackColor = Color.Transparent;
            volumeControllerPanel.Controls.Add(audioControllerPB);
            volumeControllerPanel.Controls.Add(volumeProgressPB);
            volumeControllerPanel.Cursor = Cursors.Hand;
            volumeControllerPanel.Location = new Point(859, 461);
            volumeControllerPanel.Name = "volumeControllerPanel";
            volumeControllerPanel.Size = new Size(129, 35);
            volumeControllerPanel.TabIndex = 1;
            volumeControllerPanel.MouseEnter += volumeControllerPanel_MouseEnter;
            volumeControllerPanel.MouseLeave += volumeControllerPanel_MouseLeave;
            volumeControllerPanel.MouseHover += volumeControllerPanel_MouseHover;
            volumeControllerPanel.MouseWheel += VolumeControllerPanel_MouseWheel;
            // 
            // songLikeButtonOfSCPB
            // 
            songLikeButtonOfSCPB.BackgroundImage = Properties.Resources.non_filled_heart_icon;
            songLikeButtonOfSCPB.BackgroundImageLayout = ImageLayout.Stretch;
            songLikeButtonOfSCPB.Cursor = Cursors.Hand;
            songLikeButtonOfSCPB.Location = new Point(290, 465);
            songLikeButtonOfSCPB.Name = "songLikeButtonOfSCPB";
            songLikeButtonOfSCPB.Size = new Size(20, 20);
            songLikeButtonOfSCPB.TabIndex = 14;
            songLikeButtonOfSCPB.TabStop = false;
            songLikeButtonOfSCPB.Visible = false;
            songLikeButtonOfSCPB.Click += SongLikeButtonOfSCPB_Click;
            songLikeButtonOfSCPB.MouseEnter += SongLikeButtonOfSCPB_MouseEnter;
            songLikeButtonOfSCPB.MouseLeave += SongLikeButtonOfSCPB_MouseLeave;
            // 
            // searchBarTB
            // 
            searchBarTB.BackColor = Color.FromArgb(18, 18, 18);
            searchBarTB.BorderStyle = BorderStyle.FixedSingle;
            searchBarTB.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchBarTB.ForeColor = Color.White;
            searchBarTB.Location = new Point(318, 59);
            searchBarTB.Name = "searchBarTB";
            searchBarTB.PlaceholderText = "      search song ...";
            searchBarTB.Size = new Size(517, 33);
            searchBarTB.TabIndex = 15;
            searchBarTB.Visible = false;
            searchBarTB.TextChanged += searchBarTB_TextChanged;
            searchBarTB.KeyDown += HideSearchBar;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(994, 511);
            Controls.Add(searchBarTB);
            Controls.Add(playingSongImagePB);
            Controls.Add(songLikeButtonOfSCPB);
            Controls.Add(songNameTB);
            Controls.Add(previousTrackPB);
            Controls.Add(nextTrackPB);
            Controls.Add(playPauseButtonPB);
            Controls.Add(addFolderButton);
            Controls.Add(songTotalTime);
            Controls.Add(greetLabel);
            Controls.Add(songPlayedTime);
            Controls.Add(songProgressBar);
            Controls.Add(volumeControllerPanel);
            Controls.Add(middlePanel);
            Controls.Add(topLeftPanel);
            Controls.Add(middleLeftPanel);
            Font = new Font("Leelawadee UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DashboardForm";
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            topLeftPanel.ResumeLayout(false);
            HomeButtonPanel.ResumeLayout(false);
            HomeButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HomeIconPB).EndInit();
            SearchButtonPanel.ResumeLayout(false);
            SearchButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)searchIconPB).EndInit();
            middleLeftPanel.ResumeLayout(false);
            middleLeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)libraryIconPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)addPlaylistIconPB).EndInit();
            middlePanel.ResumeLayout(false);
            middlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EditPlaylistPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)addSongsPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)playingPlaylistIconPB).EndInit();
            songListHeaderPanel.ResumeLayout(false);
            songListHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)songDurationLogoPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)playingSongImagePB).EndInit();
            ((System.ComponentModel.ISupportInitialize)playPauseButtonPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)nextTrackPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)previousTrackPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)audioControllerPB).EndInit();
            volumeControllerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)songLikeButtonOfSCPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void NavButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.ForeColor = Color.Silver;
            }
        }

        private void NavButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.ForeColor = Color.White;
            }
        }

        //internal void SetMeasurePercentage(float x, float y, float w, float h)
        //{
        //    X_PERCENTAGE = x;
        //    Y_PERCENTAGE = y;
        //    WIDTH_PERCENTAGE = w;
        //    HEIGHT_PERCENTAGE = h;
        //}

        internal void Resize_GlobalElements()
        {
            MAX_SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
            MAX_SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;

            int x = 0;
            int y = 0; 
            // 1. middlePanel // 31.48f, 17.81f, 66.33f, 63.63f     (calculated values)
            SetMeasurePercentage(30.85f, 17.81f, 68.5f, 63.63f);

            middlePanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            middlePanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 2. topLeftPanel //1.18f, 2.18f, 29.70f, 14.54f   (calculated values)
            SetMeasurePercentage(0.5f, 2.18f, 29.70f, 14.54f);

            topLeftPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            topLeftPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 3. middleLeftPanel //1.18f, 17.81f, 29.70f, 63.63f   (calculated values) 
            SetMeasurePercentage(0.5f, 17.81f, 29.70f, 63.63f);

            middleLeftPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            middleLeftPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 4. addFolderButton
            SetMeasurePercentage(81.98f, 2.18f, 14.25f, 6.63f);

            addFolderButton.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            addFolderButton.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 5. greetLabel
            SetMeasurePercentage(31.48f, 2.18f, 0f, 0f);

            greetLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 6. playingSongImagePB
            SetMeasurePercentage(2.97f, 83.63f, 3.96f, 7.27f);

            playingSongImagePB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            playingSongImagePB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 7. songNameTB
            SetMeasurePercentage(8.41f, 84.54f, 19.80f, 4.0f);

            songNameTB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            songNameTB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 8. songLikeButtonOfSCPB
            SetMeasurePercentage(28.71f, 84.54f, 1.98f, 3.63f);

            songLikeButtonOfSCPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            songLikeButtonOfSCPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 9. songProgressBar (Y = 89.81f) 
            SetMeasurePercentage(35.94f, 89.3f, 36.63f, 0.36f);

            songProgressBar.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            songProgressBar.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            //songProgressBar.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
            //                            2);

            // 10. songPlayedTime
            SetMeasurePercentage(31.48f, 88.18f, 0f, 0f);

            x = songProgressBar.Bounds.X - (Convert.ToInt32(Math.Round(1f / 100f * MAX_SCREEN_WIDTH)) + songPlayedTime.Width);

            songPlayedTime.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            //songPlayedTime.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 11. songTotalTime
            SetMeasurePercentage(73.16f, 88.18f, 0f, 0f);

            x = songProgressBar.Bounds.X + songProgressBar.Width + Convert.ToInt32(Math.Round(0.59f / 100f * MAX_SCREEN_WIDTH));

            songTotalTime.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            //songTotalTime.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));



            // 12. playPauseButtonPB
            SetMeasurePercentage(52.97f, 83.63f, 2.97f, 4.54f);

            // Size 
            playPauseButtonPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));


            // Location 
            x = songProgressBar.Bounds.X + ((songProgressBar.Width - playPauseButtonPB.Width) / 2);

            playPauseButtonPB.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            //playPauseButtonPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));


            // 13. nextTrackPB
            SetMeasurePercentage(58.41f, 84.54f, 1.48f, 2.72f);

            // Size
            nextTrackPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // Location 
            x = playPauseButtonPB.Bounds.X + playPauseButtonPB.Width + Convert.ToInt32(Math.Round(3f / 100f * MAX_SCREEN_WIDTH));

            nextTrackPB.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            //nextTrackPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // 14. previousTrackPB
            SetMeasurePercentage(48.51f, 84.54f, 1.48f, 2.72f);

            // Size 
            previousTrackPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // Location
            x = playPauseButtonPB.Bounds.X - (Convert.ToInt32(Math.Round(3f / 100f * MAX_SCREEN_WIDTH)) + previousTrackPB.Width);

            previousTrackPB.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            //previousTrackPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));


            // 15. volumeControllerPanel 
            SetMeasurePercentage(85.049f, 83.81f, 12.77f, 6.36f);

            volumeControllerPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            volumeControllerPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            // Elements of volume controller panel 
            Resize_volumeControllerPanel_Elements();

            // 16. searchBarTB 
            SetMeasurePercentage(30.85f, 15f, 40f, 60f);

            searchBarTB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_SCREEN_HEIGHT)));

            y = middlePanel.Bounds.Y - (searchBarTB.Height + 10); 

            searchBarTB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_SCREEN_WIDTH)), y);

        }

        internal void Resize_TopLeftPanel_Elements()
        {
            MAX_PANEL_WIDTH = topLeftPanel.Width;
            MAX_PANEL_HEIGHT = topLeftPanel.Height;
            // width = 300
            // height = 80 
            float width_percentage = 66.66f;
            float height_percentage = 50f;

            //=========================================================
            // LOCATION POINTS 
            // 1. SearchButtonPanel 
            SetMeasurePercentage(0f, height_percentage, width_percentage, height_percentage);

            SearchButtonPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 2. HomeButtonPanel 
            SetMeasurePercentage(0f, 0f, width_percentage, height_percentage);

            HomeButtonPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // SIZE 
            // 1. SearchButtonPanel
            SearchButtonPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                                    Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 2. HomeButtonPanel
            HomeButtonPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                                    Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // NESTED ELEMENT 
            // 1. SearchButtonPanel
            Resize_SearchButtonPanel_Elements();

            // 2.HomeButtonPanel
            Resize_HomeButtonPanel_Elements();


            //=========================================================
        }

        internal void Resize_HomeButtonPanel_Elements()
        {
            MAX_PANEL_WIDTH = HomeButtonPanel.Width;
            MAX_PANEL_HEIGHT = HomeButtonPanel.Height;
            // Width = 200      height = 40
            int y;
            // 1. HomeIconPB
            // x = 20   y = 8
            // w = 30   h = 25
            //                   10f, 20f, 15f, 62.5f       (calculated values)
            SetMeasurePercentage(10f, 20f, 10f, 50f);

            HomeIconPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                                    Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            y = (MAX_PANEL_HEIGHT - HomeIconPB.Height) / 2;

            HomeIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)), y);

            //HomeIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));



            // 2. HomeLabel
            // x = 60   y = 10
            SetMeasurePercentage(30f, y, 0f, 0f);

            y = (MAX_PANEL_HEIGHT - HomeLabel.Height) / 2;

            HomeLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)), y);

        }

        internal void Resize_SearchButtonPanel_Elements()
        {
            MAX_PANEL_WIDTH = SearchButtonPanel.Width;
            MAX_PANEL_HEIGHT = SearchButtonPanel.Height;
            // Width = 200      height = 40
            int y;
            // 1. searchIconPB
            // x = 20   y = 8
            // w = 30   h = 25

            //                   10f, 20f, 15f, 62.5f       (calculated values) 
            SetMeasurePercentage(10f, 20f, 10f, 50f);

            searchIconPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                                    Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            y = (MAX_PANEL_HEIGHT - searchIconPB.Height) / 2;

            searchIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)), y);


            // 2. searchLabel
            // x = 60   y = 10
            SetMeasurePercentage(30f, y, 0f, 0f);

            y = (MAX_PANEL_HEIGHT - searchLabel.Height) / 2;

            searchLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)), y);
        }

        internal void Resize_volumeControllerPanel_Elements()
        {
            MAX_PANEL_WIDTH = volumeControllerPanel.Width;
            MAX_PANEL_HEIGHT = volumeControllerPanel.Height;
            int height = 0;

            // 1. audioControllerPB 
            SetMeasurePercentage(7.75f, 28.57f, 11.62f, 42.85f);

            audioControllerPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            audioControllerPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                                    Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));


            // 2. volumeProgressPB
            SetMeasurePercentage(23.25f, 48.57f, 69.76f, 5.71f);

            volumeProgressPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            height = songProgressBar.Size.Height;

            volumeProgressPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)), height);

            //volumeProgressPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

        }

        internal void Resize_MiddleLeftPanel_Elements()
        {
            MAX_PANEL_WIDTH = middleLeftPanel.Width;
            MAX_PANEL_HEIGHT = middleLeftPanel.Height;

            // 1. libraryIconPB
            SetMeasurePercentage(6.66f, 4.28f, 10.0f, 7.14f);

            libraryIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            libraryIconPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 2. yourLibraryLabel
            SetMeasurePercentage(20.0f, 5.71f, 0f, 0f);

            yourLibraryLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));


            // 3. addPlaylistIconPB | 84.33f, 4.28f, 6.66f, 5.71f
            SetMeasurePercentage(84f, 5f, 9f, 7f);

            addPlaylistIconPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            addPlaylistIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //addPlaylistIconPB.Location = new Point(MAX_PANEL_WIDTH - (addPlaylistIconPB.Width + 0),
            //                                  MAX_PANEL_HEIGHT - (addPlaylistIconPB.Height + 0) );


            // 4. libPlaylistTagLabel
            SetMeasurePercentage(6.66f, 17.14f, 0f, 0f);

            libPlaylistTagLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 5. playlistListPanel 
            //SetMeasurePercentage(0f, 34.28f, 100.0f, 63.63f);
            SetMeasurePercentage(2f, 25f, 96.0f, 75.0f);

            playlistListPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            int height = MAX_PANEL_HEIGHT - Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));

            playlistListPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)), height);
            //playlistListPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                            Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

        }

        internal void Resize_MiddlePanel_Elements()
        {
            MAX_PANEL_WIDTH = middlePanel.Width;
            MAX_PANEL_HEIGHT = middlePanel.Height;

            int x = 0;
            int width = 0;

            // 1. playingPlaylistIconPB
            SetMeasurePercentage(2.98f, 20.0f, 22.38f, 42.85f);

            playingPlaylistIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            playingPlaylistIconPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 2. playlistLabel
            SetMeasurePercentage(28.35f, 23.42f, 0, 0);

            playlistLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 3. playingPlaylistNameLabel
            SetMeasurePercentage(26.26f, 27.14f, 0, 0);

            playingPlaylistNameLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 4. usernameLabel
            SetMeasurePercentage(28.35f, 59.14f, 0, 0);

            usernameLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 5. dotLabel
            SetMeasurePercentage(39.25f, 58.85f, 0, 0);

            x = usernameLabel.Bounds.X + usernameLabel.Width;

            dotLabel.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //dotLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 6. totalSongOfPlaylistLabel
            SetMeasurePercentage(40.89f, 59.14f, 0, 0);

            x = dotLabel.Bounds.X + dotLabel.Width;

            totalSongOfPlaylistLabel.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //totalSongOfPlaylistLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 7. playingSongsLabel
            SetMeasurePercentage(43.28f, 58.85f, 0, 0);

            x = totalSongOfPlaylistLabel.Bounds.X + totalSongOfPlaylistLabel.Width;

            playingSongsLabel.Location = new Point(x, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //playingSongsLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 8. songListHeaderPanel
            SetMeasurePercentage(0.0f, 70.57f, 97.13f, 22.85f);

            songListHeaderPanel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));
            width = MAX_PANEL_WIDTH - Convert.ToInt32(Math.Round(2 / 100f * MAX_PANEL_WIDTH));

            songListHeaderPanel.Size = new Size(width,
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //songListHeaderPanel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                            Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // Elements of song list header panel 
            Resize_songListHeaderPanel_Elements();

            // 9. songPanel 
            // songPanel is declared in the DashboardForm.cs file. 

            //10. EditPlaylistPB 92.53 2.85 5.97
            SetMeasurePercentage(94f, 10f, 6f, 11.42f);

            EditPlaylistPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //EditPlaylistPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 11. addSongsPB 
            SetMeasurePercentage(94f, 10f, 6f, 11.42f);

            addSongsPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                             (EditPlaylistPB.Bounds.Y + EditPlaylistPB.Height + 5));
        }

        internal void Resize_songListHeaderPanel_Elements()
        {
            MAX_PANEL_WIDTH = songListHeaderPanel.Width;
            MAX_PANEL_HEIGHT = songListHeaderPanel.Height;

            // 1. srNoLabel
            SetMeasurePercentage(6.13f, 62.50f, 0, 0);


            srNoLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 2. titleLabel
            SetMeasurePercentage(11.50f, 62.50f, 0, 0);

            titleLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));


            // 3. songDurationLogoPB
            SetMeasurePercentage(88.95f, 60f, 2.30f, 18.75f);

            songDurationLogoPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songDurationLogoPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 4. horizontalLineLabel
            SetMeasurePercentage(3.68f, 82.5f, 92.02f, 1.25f);

            horizontalLineLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            horizontalLineLabel.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

        }

        private void SongLikeButtonOfSCPB_MouseLeave(object sender, EventArgs e)
        {
            int songIndex = SongIndexList[SongPlayer.SIL_index];
            ToggleSongLikeIcon(sender, e, MASTER_SONG_LIST[songIndex], false);
        }

        private void SongLikeButtonOfSCPB_MouseEnter(object sender, EventArgs e)
        {
            int songIndex = SongIndexList[SongPlayer.SIL_index];
            ToggleSongLikeIcon(sender, e, MASTER_SONG_LIST[songIndex], true);
        }

        private void SongLikeButtonOfSCPB_Click(object sender, EventArgs e)
        {
            int songIndex = SongIndexList[SongPlayer.SIL_index];
            click_SongLikeButton(MASTER_SONG_LIST[songIndex]);
        }



        #endregion

        private Panel middlePanel;
        private Panel topLeftPanel;
        private Panel middleLeftPanel;
        // Below 3 lines implements custome rounded panels (replacement of above 3 lines) 
        //internal RoundedPanel topLeftPanel;
        //internal RoundedPanel middleLeftPanel;
        //internal RoundedPanel middlePanel;
        private ProgressBar songProgressBar;
        private Label songPlayedTime;
        private Label songTotalTime;
        private Button addFolderButton;
        private Label greetLabel;
        private PictureBox playingPlaylistIconPB;
        internal Label playingPlaylistNameLabel;
        private Label playlistLabel;
        private Label dotLabel;
        private Label usernameLabel;
        private Label playingSongsLabel;
        internal Label totalSongOfPlaylistLabel;
        private Panel songListHeaderPanel;
        private Label horizontalLineLabel;
        private PictureBox songDurationLogoPB;
        private Label titleLabel;
        private Label srNoLabel;
        private PictureBox playingSongImagePB;
        private PictureBox playPauseButtonPB;
        private PictureBox nextTrackPB;
        private PictureBox previousTrackPB;
        private TextBox songNameTB;
        private PictureBox audioControllerPB;
        private ProgressBar volumeProgressPB;
        private Panel volumeControllerPanel;
        private PictureBox songLikeButtonOfSCPB;
        private Label yourLibraryLabel;
        private PictureBox libraryIconPB;
        private Label libPlaylistTagLabel;
        private PictureBox addPlaylistIconPB;
        private Panel playlistListPanel;
        private PictureBox EditPlaylistPB;
        private Panel SearchButtonPanel;
        private PictureBox searchIconPB;
        private Panel HomeButtonPanel;
        private Label searchLabel;
        private Label HomeLabel;
        private PictureBox HomeIconPB;
        private TextBox searchBarTB;
        private PictureBox addSongsPB;

        //private RoundedTextBox searchBarTB; 

    }
}