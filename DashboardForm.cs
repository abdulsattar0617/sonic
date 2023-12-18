using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Sonic_Music_Player.LibraryClass;

using TextBox = System.Windows.Forms.TextBox;

namespace Sonic_Music_Player
{
    public partial class DashboardForm : Form
    {

        // METHODS 
        public DashboardForm()
        {
            MAX_SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
            MAX_SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;

            //topLeftPanel = new RoundedPanel(10, 10, 10, 10);
            //middleLeftPanel = new RoundedPanel(2, 2, 2, 2);
            //middlePanel = new RoundedPanel(1, 1, 1, 1);

            InitializeComponent();
            Resize_GlobalElements();
            Resize_MiddleLeftPanel_Elements();
            Resize_MiddlePanel_Elements();
            Resize_TopLeftPanel_Elements();
            GreetUser();

            // Initialize timer (helps to calculate song played time)  
            initTimer();
        }

        private void initTimer()
        {
            timer.Interval = 1000; // 1 Second
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // IF SONG IS PLAYING 
            if (SongPlayer.songIsPlaying)
            {
                // UDPATE SONG PROGRESS
                // - SONG PLAYED TIME   
                // - SONG DURATION 
                UpdateSongProgress();
            }

            // Greet user, at every 3 hours
            GreetUser();

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            bool systemDataChecked = CheckSystemData();
            if (systemDataChecked)
            {
                LoadApp();

            }
            else
            {
                MessageBox.Show("Something went wrong ! can't load the app");
            }
        }

        private void GreetUser()
        {
            DateTime currTimeStamp = DateTime.Now;
            if ( DateTime.Compare(currTimeStamp, Last_Greet_Time.AddHours(3)) > 0) 
            {
                int currentTime = Convert.ToInt16(currTimeStamp.ToString("HH"));
                if (currentTime < 12 && currentTime > 3)
                {
                    greetLabel.Text = "Hello, Good morning !";
                }
                else if (currentTime < 18 && currentTime > 12)
                {
                    greetLabel.Text = "Hello, Good afternoon !";
                }
                else if ((currentTime < 24 && currentTime > 18) || currentTime < 3)
                {
                    greetLabel.Text = "Hello, Good evening !";
                }

                Last_Greet_Time = currTimeStamp;
            }
        }

        private bool CheckSystemData()
        {

            try
            {
                // app directory
                if (!Directory.Exists(APP_DIR_PATH))
                {
                    var d = Directory.CreateDirectory(APP_DIR_PATH);
                }

                // song directory file 
                if (!(File.Exists(APP_DIR_PATH + SONG_DIRs_FILE_NAME)))
                {
                    FileStream f = File.Create(APP_DIR_PATH + SONG_DIRs_FILE_NAME);
                    f.Close();
                }

                // song file
                if (!(File.Exists(APP_DIR_PATH + SONG_FILE_NAME)))
                {
                    FileStream f = File.Create(APP_DIR_PATH + SONG_FILE_NAME);
                    f.Close();
                }

                // playlist file
                if (!(File.Exists(APP_DIR_PATH + PLAYLIST_FILE_NAME)))
                {
                    FileStream f = File.Create(APP_DIR_PATH + PLAYLIST_FILE_NAME);
                    f.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void LoadApp()
        {
            // List all the songs from all available directories(folders)
            // 1. Read & store songs from directories to song file 
            UpdateSongFile();

            // 2. store liked songs ids to liked playlist in playlist file  
            UpdatePlaylistFile();

            // 3. Read songs from song file 
            this.addSongToMasterSongList();

            // 4. Add all songs to song list panel   
            PrepareSongQueue();
            //this.addSongListToSongListPanel(0);

            // 5. Add Playlists from file to playlistList 
            addPlaylistToMasterPlaylistList();

            // 6. Add Playlist List to Playlist Panel 
            this.addPlaylistListToPlaylistPanel();


            LoadPlaylist(0);
        }

        private void addPlaylistListToPlaylistPanel()
        {
            // Clear playlist list panel 
            playlistListPanel.Controls.Clear();

            int playlistIndex = 0;
            if (MASTER_PLAYLIST.Count() > 0)
            {
                foreach (Playlist playlist in MASTER_PLAYLIST)
                {
                    addPlaylistToPlaylistPanel(playlist, playlistIndex);
                    ++playlistIndex;
                }
            }


        }

        private void addPlaylistToPlaylistPanel(Playlist playlist, int playlist_index)
        {
            // 
            // playlistIconPB
            // 
            PictureBox playlistIconPB = new PictureBox();

            if (playlist.CoverImagePath.Equals("liked"))
            {
                playlistIconPB.BackgroundImage = Properties.Resources.liked_song_logo;
            }
            else if (playlist.CoverImagePath.Equals("none"))
            {
                playlistIconPB.BackgroundImage = Properties.Resources.playlist_cover_image;
            }
            else
            {
                playlistIconPB.BackgroundImage = Image.FromFile(playlist.CoverImagePath.Trim());
            }

            playlistIconPB.BackgroundImageLayout = ImageLayout.Stretch;
            playlistIconPB.Location = new Point(10, 5);
            playlistIconPB.Name = "playlistIconPB" + (playlist_index + 1);
            playlistIconPB.Size = new Size(40, 40);
            playlistIconPB.TabIndex = 2;
            playlistIconPB.TabStop = false;
            playlistIconPB.BackColor = Color.Transparent;

            // 
            // playlistNameLabel
            // 
            Label playlistNameLabel = new Label();
            playlistNameLabel.AutoSize = true;
            playlistNameLabel.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            playlistNameLabel.ForeColor = Color.White;
            playlistNameLabel.Location = new Point(60, 10);
            playlistNameLabel.Name = "playlistNameLabel" + (playlist_index + 1);
            playlistNameLabel.Size = new Size(82, 17);
            playlistNameLabel.TabIndex = 7;
            playlistNameLabel.Text = playlist.playlistName.Trim();
            playlistNameLabel.BackColor = Color.Transparent;

            // 
            // playlistTagLineLabel
            // 
            Label playlistTagLineLabel = new Label();
            playlistTagLineLabel.AutoSize = true;
            playlistTagLineLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            playlistTagLineLabel.ForeColor = Color.DimGray;
            playlistTagLineLabel.Location = new Point(60, 30);
            playlistTagLineLabel.Name = "playlistTagLineLabel" + (playlist_index + 1);
            playlistTagLineLabel.Size = new Size(44, 13);
            playlistTagLineLabel.TabIndex = 8;
            playlistTagLineLabel.Text = "Playlist";
            playlistTagLineLabel.BackColor = Color.Transparent;

            // 
            // playlistDotLabel
            // 
            Label playlistDotLabel = new Label();
            playlistDotLabel.AutoSize = true;
            playlistDotLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            playlistDotLabel.ForeColor = Color.DimGray;
            playlistDotLabel.Location = new Point(103, 29);
            playlistDotLabel.Name = "playlistDotLabel" + (playlist_index + 1);
            playlistDotLabel.Size = new Size(12, 13);
            playlistDotLabel.TabIndex = 10;
            playlistDotLabel.Text = "•";
            playlistDotLabel.BackColor = Color.Transparent;

            // 
            // playlistTotalSongsLabel
            // 
            Label playlistTotalSongsLabel = new Label();
            playlistTotalSongsLabel.AutoSize = true;
            playlistTotalSongsLabel.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            playlistTotalSongsLabel.ForeColor = Color.DimGray;
            playlistTotalSongsLabel.Location = new Point(111, 30);
            playlistTotalSongsLabel.Name = "playlistTotalSongsLabel" + (playlist_index + 1);
            playlistTotalSongsLabel.Size = new Size(21, 13);
            playlistTotalSongsLabel.TabIndex = 12;
            playlistTotalSongsLabel.Text = $"{playlist.totalSongs} songs";
            playlistTotalSongsLabel.BackColor = Color.Transparent;


            int x_playlistTotalSongsLabel = playlistTotalSongsLabel.Location.X;
            int width_playlistTotalSongsLabel = playlistTotalSongsLabel.Width;


            // 
            // playlistSongsLabel
            // 
            //Label playlistSongsLabel = new Label();
            //playlistSongsLabel.AutoSize = true;
            //playlistSongsLabel.Font = new Font("Leelawadee UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            //playlistSongsLabel.ForeColor = Color.DimGray;
            //int x_playlistSongsLabel = (x_playlistTotalSongsLabel + width_playlistTotalSongsLabel) - 2;
            //playlistSongsLabel.Location = new Point(x_playlistSongsLabel, 30);
            //playlistSongsLabel.Name = "playlistSongsLabel" + (playlist_index + 1);
            //playlistSongsLabel.Size = new Size(38, 13);
            //playlistSongsLabel.TabIndex = 13;
            //playlistSongsLabel.Text = "songs";



            //
            // PlaylistMenu
            //
            ContextMenuStrip PlaylistMenu = new ContextMenuStrip();

            PlaylistMenu.BackColor = Color.FromArgb(18, 18, 18);
            //PlaylistMenu.Text = "Playlist Options";

            ToolStripMenuItem Option_1 = new ToolStripMenuItem();
            Option_1.Text = "Delete playlist";
            Option_1.Font = new Font("Leelawadee UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Option_1.ForeColor = Color.Red;
            Option_1.BackColor = Color.FromArgb(18, 18, 18);
            Option_1.Image = Properties.Resources.wrong_icon;
            Option_1.Click += (s, args) => DeleteIcon_Click(s, args, playlist_index);

            PlaylistMenu.Items.Add(Option_1);


            // 
            // playlistPanel
            // 
            //Panel playlistPanel = new Panel();
            RoundedPanel playlistPanel = new RoundedPanel(10, 10, 10, 10);
            y_pad_playlist_header = top_pad_playlist_header + (height_playlist_header * playlist_index);
            playlistPanel.Location = new Point(x_pad_playlist_header, y_pad_playlist_header);
            playlistPanel.Name = "playlistPanel" + (playlist_index + 1);
            playlistPanel.Size = new Size(width_playlist_header, height_playlist_header);
            playlistPanel.Controls.Add(playlistIconPB);
            playlistPanel.Controls.Add(playlistNameLabel);
            playlistPanel.Controls.Add(playlistTagLineLabel);
            playlistPanel.Controls.Add(playlistDotLabel);
            playlistPanel.Controls.Add(playlistTotalSongsLabel);
            //playlistPanel.Controls.Add(DeletePLIconPB);
            //playlistPanel.Controls.Add(PlaylistMenu); 
            //playlistPanel.Controls.Add(IamButton);
            //playlistPanel.Controls.Add(playlistSongsLabel);
            playlistPanel.BackColor = Color.Transparent;





            playlistPanel.Cursor = Cursors.Hand;


            //songPanel.MouseEnter += SongPanel_MouseEnter; 
            //songPanel.MouseHover += SongPanel_MouseHover;
            //songPanel.MouseLeave += SongPanel_MouseLeave;

            //songPanel.Tag = songNumber;  // set song serial number here
            //songPanel.Click += (s, args) => playSong(s, args, (int)songPanel.Tag);

            // Playlist Click 
            // 1. Attach playlist number with playlistPanel
            //      Pass tag to a method that loads the playlist
            // 2. load playlist songs in playing area



            // Playlist Name Transitions
            // 1. Underline it when mouse enters
            // 2. Remove underline when mouse leave

            // Playlist panel Background Transisition
            // On Mouse Enter
            playlistPanel.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(ref playlistPanel, playlist_index, ref playlistNameLabel);
            playlistIconPB.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(ref playlistPanel, playlist_index, ref playlistNameLabel);
            playlistNameLabel.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(ref playlistPanel, playlist_index, ref playlistNameLabel);
            playlistTotalSongsLabel.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(ref playlistPanel, playlist_index, ref playlistNameLabel);
            //playlistSongsLabel.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(s, args, ref playlistPanel);
            playlistTagLineLabel.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(ref playlistPanel, playlist_index, ref playlistNameLabel);
            playlistDotLabel.MouseEnter += (s, args) => Mouse_Enter_On_PlaylistPanel(ref playlistPanel, playlist_index, ref playlistNameLabel);

            // On Mouse Leave 
            playlistPanel.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(ref playlistPanel, ref playlistNameLabel);
            playlistIconPB.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(ref playlistPanel, ref playlistNameLabel);
            playlistNameLabel.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(ref playlistPanel, ref playlistNameLabel);
            playlistTotalSongsLabel.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(ref playlistPanel, ref playlistNameLabel);
            //playlistSongsLabel.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(s, args, ref playlistPanel);
            playlistTagLineLabel.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(ref playlistPanel, ref playlistNameLabel);
            playlistDotLabel.MouseLeave += (s, args) => Mouse_Leave_On_PlaylistPanel(ref playlistPanel, ref playlistNameLabel);

            // Mouse Click Event
            //playlistPanel.Click += (s, args) => LoadPlaylist(playlist_index);
            playlistPanel.Click += (s, args) => PlaylistPanel_Click(s, args, ref playlistPanel, ref PlaylistMenu, playlist_index);



            // =============================================================================================
            
            // BELOW CODE IS USED TO RESIZE THE playlistPanel 
            MAX_PANEL_WIDTH = playlistListPanel.Width;
            MAX_PANEL_HEIGHT = playlistListPanel.Height;

            //// RESET LOCATION AND SIZE OF playlistPanel
            //// Size 
            //WIDTH_PERCENTAGE = 100.0f;
            //HEIGHT_PERCENTAGE = 21.73f;
            SetMeasurePercentage(0, 0, 92.0f, 21.73f);

            width_playlist_header = Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH));
            height_playlist_header = Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));

            playlistPanel.Size = new Size(width_playlist_header, height_playlist_header);

            //// Location 
            SetMeasurePercentage(0, 0, 0, 0);

            height_playlist_header = playlistPanel.Height;

            top_pad_playlist_header = Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));
            x_pad_playlist_header = Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH));

            y_pad_playlist_header = top_pad_playlist_header + (height_playlist_header * playlist_index);
            playlistPanel.Location = new Point(x_pad_playlist_header, y_pad_playlist_header);

            //// =============================================================================================

            //// =============================================================================================
            //// RESET LOCATION AND SIZE OF playlistPanel Elements
            //// =============================================================================================
            MAX_PANEL_WIDTH = playlistPanel.Width;
            MAX_PANEL_HEIGHT = playlistPanel.Height;

            ////1. playlistIconPB (actual height = 80.0f)
            SetMeasurePercentage(3.33f, 10.0f, 13.33f, 70.0f);

            playlistIconPB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            playlistIconPB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //// 2. playlistNameLabel
            SetMeasurePercentage(20.0f, 20.0f, 0f, 0f);

            playlistNameLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //// 3. playlistTagLineLabel
            SetMeasurePercentage(20.0f, 60.0f, 0, 0);

            playlistTagLineLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //// 4. playlistDotLabel

            SetMeasurePercentage(34.33f, 57.99f, 0, 0);

            int x_pltTaglbl = playlistTagLineLabel.Bounds.X;
            int width_pltTaglbl = playlistTagLineLabel.Width;

            playlistDotLabel.Location = new Point(x_pltTaglbl + width_pltTaglbl, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //playlistDotLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //// 5. playlistTotalSongsLabel
            SetMeasurePercentage(37.0f, 60.0f, 0, 0);

            int x_plt_dot = playlistTagLineLabel.Bounds.X;
            int width_plt_dot = playlistTagLineLabel.Width + Convert.ToInt32(Math.Round(2.66f / 100f * MAX_PANEL_WIDTH));

            playlistTotalSongsLabel.Location = new Point(x_plt_dot + width_plt_dot, Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //playlistTotalSongsLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
            //                                  Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            //// 6. playlistSongsLabel 
            //Y_PERCENTAGE = 60.0f;
            SetMeasurePercentage(0, 60.0f, 0, 0);

            x_playlistTotalSongsLabel = playlistTotalSongsLabel.Location.X;
            width_playlistTotalSongsLabel = playlistTotalSongsLabel.Width;

            //x_playlistSongsLabel = (x_playlistTotalSongsLabel + width_playlistTotalSongsLabel) - (int)Math.Round(0.66f / 100f * MAX_PANEL_WIDTH);
            //playlistSongsLabel.Location = new Point(x_playlistSongsLabel,
            //Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));


            // =============================================================================================
            // =============================================================================================

            // Add playlist panel to playlist List Panel 
            playlistListPanel.Controls.Add(playlistPanel);
        }

        private void PlaylistPanel_Click(object? sender, EventArgs e, ref RoundedPanel panel, ref ContextMenuStrip Menu, int plIndex)
        {
            MouseEventArgs MouseEvent = e as MouseEventArgs;

            if (MouseEvent != null && MouseEvent.Button == MouseButtons.Right)
            {
                // SKIP THE PLAYLISTS - "ALL SONGS" & "LIKED SONGS" 
                // They can't be deleted. 
                if (plIndex != 0 && plIndex != 1)
                {
                    // show menu
                    Menu.Show(panel, MouseEvent.Location);
                }
            }
            else
            {
                // Load playlist
                LoadPlaylist(plIndex);

            }
        }


        private void DeleteIcon_Click(object? sender, EventArgs e, int playlistIndexToDel)
        {
            try
            {
                
                DialogResult dialogResult = MessageBox.Show($"Do you want to delete the playlist \"{MASTER_PLAYLIST[playlistIndexToDel].playlistName}\" ?", "Sonic Music Player", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int Playlist_ID_ToDelete = MASTER_PLAYLIST[playlistIndexToDel].playlistId;

                    // remove entry of playlist from playlist file 
                    string PlaylistFilePath = APP_DIR_PATH + PLAYLIST_FILE_NAME;
                    string tempFilePath = APP_DIR_PATH + "__tempPL_File.txt";

                    using (StreamReader reader = new StreamReader(PlaylistFilePath))
                    using (StreamWriter writer = new StreamWriter(tempFilePath))
                    {
                        int line_id = 0;
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] fields = line.Split(',');

                            int ID_ToCompare = int.Parse(fields[0]);

                            if (!(Playlist_ID_ToDelete == ID_ToCompare))
                            {
                                // Write Playlist entries except the Deleting playlist 
                                fields[0] = line_id + "";

                                writer.WriteLine(string.Join(",", fields));

                                ++line_id;
                            }
                        }
                    }

                    File.Delete(PlaylistFilePath);
                    File.Move(tempFilePath, PlaylistFilePath);

                    // delete from master playlist list 
                    MASTER_PLAYLIST.RemoveAt(playlistIndexToDel);

                    // Reload the playlist list panel 
                    addPlaylistListToPlaylistPanel();

                    // IF delted playlist was the current loaded playlist, then load the "All songs" (index 0) playlist
                    if (playlistIndexToDel == CURR_LOADED_PLAYLIST_INDEX)
                    {
                        LoadPlaylist(0);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            catch
            {

            }
        }


        private void LoadMiddlePanelComponents()
        {
            // Edit playlist icon 
            middlePanel.Controls.Add(EditPlaylistPB);
            // Add Songs Icon
            middlePanel.Controls.Add(addSongsPB);
            // Playlist Icon
            middlePanel.Controls.Add(playingPlaylistIconPB);
            // Playlist name label
            middlePanel.Controls.Add(playingPlaylistNameLabel);
            // playlist label
            middlePanel.Controls.Add(playlistLabel);
            // user name
            middlePanel.Controls.Add(usernameLabel);
            // total songs 
            middlePanel.Controls.Add(totalSongOfPlaylistLabel);
            // songs label 
            middlePanel.Controls.Add(playingSongsLabel);
            // dot label
            middlePanel.Controls.Add(dotLabel);
            // song list header panel
            middlePanel.Controls.Add(songListHeaderPanel);

        }

        private void LoadPlaylist(int playlist_index)
        {
            // Set vertical scroll to beginning (ensuring that all new component should add from start)
            middlePanel.VerticalScroll.Value = 0;


            SongQueue.Clear();
            SongQueue.AddRange(Get_Song_Indexes(MASTER_PLAYLIST[playlist_index].songIdList));



            // Add songs to Song List Panel
            //addSongListToSongListPanel(SongIndexList);
            addSongListToSongListPanel(playlist_index);

            // Change Name label value To playlist name 
            playingPlaylistNameLabel.Text = MASTER_PLAYLIST[playlist_index].playlistName.Trim();
            //playingPlaylistNameLabel.ForeColor = ColorTranslator.FromHtml("#1bd760");

            // Change Total songs label value of playlist
            totalSongOfPlaylistLabel.Text = MASTER_PLAYLIST[playlist_index].totalSongs.ToString();

            // Change Playlist Icon
            if (MASTER_PLAYLIST[playlist_index].CoverImagePath == "liked")
            {
                playingPlaylistIconPB.BackgroundImage = Properties.Resources.liked_song_logo;
            }
            else if (MASTER_PLAYLIST[playlist_index].CoverImagePath == "none")
            {
                playingPlaylistIconPB.BackgroundImage = Properties.Resources.playlist_cover_image;
            }
            else
            {
                playingPlaylistIconPB.BackgroundImage = Image.FromFile(MASTER_PLAYLIST[playlist_index].CoverImagePath.Trim());
            }

            // Change Playlist Index in AddSongsPB Tag (it can be used for adding songs in playlist)
            CURR_LOADED_PLAYLIST_INDEX = playlist_index;

            if (CURR_LOADED_PLAYLIST_INDEX == 0)
            {
                // This is all songs playlist 
                // make invisible AddSongsPB element 
                EditPlaylistPB.Visible = false;
                addSongsPB.Visible = false;
                //EditPlaylistPB.Click -= EditPlaylistPB_Click;
                //addSongsPB.Click -= addSongsPB_Click; 
                HomeLabel.ForeColor = Color.White;
            }
            else if (CURR_LOADED_PLAYLIST_INDEX == 1)
            {
                EditPlaylistPB.Visible = false;
                addSongsPB.Visible = true;
                //EditPlaylistPB.Click -= EditPlaylistPB_Click;
                //addSongsPB.Click += addSongsPB_Click;

                HomeLabel.ForeColor = Color.Silver;
            }
            else
            {
                EditPlaylistPB.Visible = true;
                addSongsPB.Visible = true;

                //EditPlaylistPB.Click += EditPlaylistPB_Click;
                //addSongsPB.Click += addSongsPB_Click;

                HomeLabel.ForeColor = Color.Silver;
            }
        }

        internal List<int> Get_Song_Indexes(List<int> SongIdList)
        {
            // Clean list first
            List<int> SongIndexes = new List<int>();

            // Sort Playlist Song list
            SongIdList.Sort();

            // Traverse the Master Song List To compare for Id of each song 
            for (int song_index = 0; song_index < MASTER_SONG_LIST.Count; song_index++)
            {
                // Song Id To compare 
                uint songIdToCompare = MASTER_SONG_LIST[song_index].songId;

                // Start Index For Song Ids List of playlist 
                int st = 0;

                // End Index For Song Ids List of playlist 
                int en = SongIdList.Count - 1;

                // Search Song Until start is less than end index 
                while (st <= en)
                {
                    // Check is song present on first index 
                    if (songIdToCompare == SongIdList[st])
                    {
                        SongIndexes.Add(song_index);
                        break;
                    }
                    // Check is song present on last index
                    else if (songIdToCompare == SongIdList[en])
                    {
                        SongIndexes.Add(song_index);
                        break;
                    }
                    // Ensure that song id should be in between,
                    // Min_song_id_value <= songIdToCompare <= Max_song_id_value
                    else if (songIdToCompare > SongIdList[st] && songIdToCompare < SongIdList[en])
                    {
                        // calculate middle index for song id list 
                        int mid = (st + en) / 2;
                        // check is song present on middle index value
                        if (songIdToCompare == SongIdList[mid])
                        {
                            SongIndexes.Add(song_index);
                            break;
                        }
                        // check is song id is greater than middle index value 
                        else if (songIdToCompare > SongIdList[mid])
                        {
                            st = mid + 1;
                        }
                        // check is song id is less than middle index value 
                        else if (songIdToCompare < SongIdList[mid])
                        {
                            en = mid - 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // Check whether the count of playlist (total songs in playlist) is equal to song index list 
                // in that case we have found all the indexes of songs that are present in playlist
                if (SongIndexes.Count == SongIdList.Count)
                {
                    // PLAYLIST SONGS COMPARISON IS DONE 
                    break;
                }

            }

            return SongIndexes;
        }

        private void Mouse_Enter_On_PlaylistPanel(ref RoundedPanel panel, int playlist_index, ref Label playlistName)
        {
            // Change color to dark grey 
            panel.BackColor = Playlist_BG_Color_On_Mouse_Enter;
            playlistName.ForeColor = ColorTranslator.FromHtml("#1bd760");

        }

        private void Mouse_Enter_On_PlaylistPanel(ref Panel panel, int playlist_index, ref Label playlistName)
        {
            // Change color to dark grey 
            panel.BackColor = Playlist_BG_Color_On_Mouse_Enter;
            playlistName.ForeColor = ColorTranslator.FromHtml("#1bd760");

        }

        private void Mouse_Leave_On_PlaylistPanel(ref Panel panel, ref Label playlistName)
        {
            // LATER ON MODIFY COLOR 
            panel.BackColor = Playlist_BG_Color_On_Mouse_Leave;
            playlistName.ForeColor = Color.White;

        }

        private void Mouse_Leave_On_PlaylistPanel(ref RoundedPanel panel, ref Label playlistName)
        {
            // LATER ON MODIFY COLOR 
            panel.BackColor = Playlist_BG_Color_On_Mouse_Leave;
            playlistName.ForeColor = Color.White;

        }

        private void addSongListToSongListPanel(int playlist_index)
        {
            // Clear the middle panel
            middlePanel.Controls.Clear();
            // Add default components 
            LoadMiddlePanelComponents();


            if (SongQueue.Count() > 0)
            {
                int songNumber = 0;
                for (int sq_index = 0; sq_index < SongQueue.Count; sq_index++)
                {
                    ++songNumber;
                    int songIndex = SongQueue[sq_index];
                    addSongToSongListPanel(MASTER_SONG_LIST[songIndex], songNumber, sq_index, playlist_index);
                }

                // add bottom panel 
                Panel SongListBottomPanel = new Panel();
                //SongListBottomPanel.BackColor = Color.FromArgb(97, 66, 219);
                SongListBottomPanel.BackColor = Color.FromArgb(51, 51, 140);
                SongListBottomPanel.Location = new Point(left_pad_song_header, top_pad_song_header + (height_song_header * SongQueue.Count));
                SongListBottomPanel.Size = new Size(width_song_header, height_song_header * 1);

                middlePanel.Controls.Add(SongListBottomPanel);

                // visible the song header 
                songListHeaderPanel.Visible = true;
            }
            else
            {
                // invisible the song header 
                //songListHeaderPanel.Visible = false; 

                // add no music image 
                PictureBox NoMusicPB = new PictureBox();
                NoMusicPB.Image = Properties.Resources.no_music;
                NoMusicPB.Size = new Size(360, 360);
                NoMusicPB.Location = new Point((middlePanel.Width - NoMusicPB.Width) / 2, top_pad_song_header + songListHeaderPanel.Height + (height_song_header * SongQueue.Count));

                middlePanel.Controls.Add(NoMusicPB);


            }

        }

        private void addSongToSongListPanel(Song song, int songNumber, int sq_index, int playlist_index)
        {
            // 
            // songSerialNo 
            // 
            Label songSerialNo = new Label();
            songSerialNo.AutoSize = true;
            //songSerialNo.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            songSerialNo.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songSerialNo.ForeColor = Color.White;
            songSerialNo.Location = new Point(30, header_element_fix_ypad); // xpad = 30 (fix) 
            songSerialNo.Size = new Size(16, 17);
            songSerialNo.Text = songNumber.ToString();
            songSerialNo.Name = "songSerialNo" + songNumber.ToString();
            songSerialNo.Visible = true;

            PictureBox songPlayButton = new PictureBox();
            // songPlayButton.BackgroundImage = (Image)resources.GetObject("samplePlayPB.BackgroundImage");
            songPlayButton.BackgroundImage = Properties.Resources.play_button_icon;
            songPlayButton.BackgroundImageLayout = ImageLayout.Stretch;
            songPlayButton.Location = new Point(60, 5);
            songPlayButton.Name = "samplePlayPB";
            songPlayButton.Size = new Size(20, 20);
            //songPlayButton.TabIndex = 14;
            songPlayButton.TabStop = false;
            songPlayButton.Click += (s, args) => SongPanel_Click(sq_index, playlist_index);
            songPlayButton.Cursor = Cursors.Hand;
            // songPlayButton.Visible = true;
            songPlayButton.Visible = false;

            // 
            // songNameTB
            // 
            TextBox songNameTB = new TextBox();
            songNameTB.BackColor = Color.FromArgb(51, 51, 140);
            songNameTB.BorderStyle = BorderStyle.None;
            //songNameTB.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            songNameTB.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songNameTB.ForeColor = Color.White;
            songNameTB.Location = new Point(90, header_element_fix_ypad); // xpad = 90 (fix) 
            songNameTB.Name = "songNameLabel" + songNumber.ToString();
            songNameTB.Size = new Size(420, 18);
            songNameTB.Text = song.songName;
            songNameTB.ReadOnly = true;
            songNameTB.Cursor = Cursors.Hand;
            songNameTB.TabStop = false;

            songNameTB.Click += (s, args) => SongPanel_Click(sq_index, playlist_index);
            //songNameTB.Click += (s, args) => playSong(sil_index, playlist_index);


            // 
            // songLikeButton
            // 
            PictureBox songLikeButton = new PictureBox();
            songLikeButton.BackgroundImageLayout = ImageLayout.Stretch;
            songLikeButton.Location = new Point(540, 6);
            songLikeButton.Name = "songLikeButton" + songNumber.ToString();
            songLikeButton.Size = new Size(20, 20);
            songLikeButton.TabIndex = 17;
            songLikeButton.TabStop = false;
            songLikeButton.Click += (s, args) => songLikeButton_Click(s, args, song);
            songLikeButton.MouseEnter += (s, args) => ToggleSongLikeIcon(s, args, song, true);
            songLikeButton.MouseLeave += (s, args) => ToggleSongLikeIcon(s, args, song, false);
            if (song.IS_LIKED)
            {
                songLikeButton.BackgroundImage = Properties.Resources.filled_heart_icon;
            }
            else
            {
                songLikeButton.BackgroundImage = Properties.Resources.non_filled_heart_icon;
            }

            // 
            // songDurationLabel 
            // 
            Label songDurationLabel = new Label();
            songDurationLabel.AutoSize = true;
            //songDurationLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            songDurationLabel.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songDurationLabel.ForeColor = Color.White;
            songDurationLabel.Location = new Point(580, header_element_fix_ypad); // xpad = 580 (fix) 
            songDurationLabel.Name = "songDurationLabel" + songNumber.ToString();
            songDurationLabel.Size = new Size(27, 17);
            songDurationLabel.Text = song.songDuration;



            // 
            // songPanel
            // 
            Panel songPanel = new Panel();
            songPanel.BackColor = Color.FromArgb(51, 51, 140);
            songPanel.Controls.Add(songSerialNo);
            songPanel.Controls.Add(songPlayButton);
            songPanel.Controls.Add(songNameTB);
            songPanel.Controls.Add(songLikeButton);
            songPanel.Controls.Add(songDurationLabel);
            songPanel.Location = new Point(left_pad_song_header, top_pad_song_header + (height_song_header * (songNumber - 1)));
            songPanel.Name = "songPanel" + songNumber.ToString();
            songPanel.Size = new Size(width_song_header, height_song_header);
            //songPanel.TabIndex = 13;
            songPanel.Cursor = Cursors.Hand;
            songPanel.MouseEnter += SongPanel_MouseEnter;
            songPanel.MouseHover += SongPanel_MouseHover;
            songPanel.MouseLeave += SongPanel_MouseLeave;

            songPanel.Click += (s, args) => SongPanel_Click(sq_index, playlist_index);

            // SONG NAME SETTING
            // Visible play button when mouse enter / hover
            songNameTB.MouseEnter += (s, args) => SongNameTB_MouseEnter(s, args, songPanel);
            songNameTB.MouseLeave += (s, args) => SongNameTB_MouseLeave(s, args, songPanel);

            // ======================================================================================================
            // Resize the songPanel 
            MAX_PANEL_WIDTH = middlePanel.Width;
            MAX_PANEL_HEIGHT = middlePanel.Height;

            SetMeasurePercentage(0.0f, 93.42f, 97.31f, 8.57f);

            /// SIZE 
            width_song_header = MAX_PANEL_WIDTH - Convert.ToInt32(Math.Round(2 / 100f * MAX_PANEL_WIDTH));
            //width_song_header = songListHeaderPanel.Width; 
            //width_song_header = Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)); 
            height_song_header = Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));

            songPanel.Size = new Size(width_song_header, height_song_header);

            /// LOCATION
            left_pad_song_header = 0;
            top_pad_song_header = Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));
            height_song_header = songPanel.Height;

            songPanel.Location = new Point(left_pad_song_header, top_pad_song_header + (height_song_header * (songNumber - 1)));

            // ======================================================================================================

            // ======================================================================================================
            // Resize the elements of songPanel 
            MAX_PANEL_WIDTH = songPanel.Width;
            MAX_PANEL_HEIGHT = songPanel.Height;

            // 1. songSerialNo 4.60 20
            SetMeasurePercentage(4.60f, 20f, 0, 0);


            songSerialNo.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));


            // 2. songPlayButton (Y = 16.66f)
            SetMeasurePercentage(9.20f, 10f, 3.06f, 66.66f);

            songPlayButton.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songPlayButton.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 3. songNameTB
            SetMeasurePercentage(13.80f, 20f, 64.41f, 60f);

            songNameTB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songNameTB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 4. songLikeButton (Y = 20f)
            SetMeasurePercentage(82.82f, 5f, 3.06f, 66.66f);

            songLikeButton.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songLikeButton.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 5. songDurationLabel 
            SetMeasurePercentage(88.95f, 20f, 0, 0);

            songDurationLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // ======================================================================================================

            // Add song panel to middle panel (song list)
            middlePanel.Controls.Add(songPanel);
        }

        private void SongPanel_Click(int sq_index, int playlist_index)
        {
            if (SongPlayer.PlaylistIndex != playlist_index)
            {
                // update song index list 
                // copy elements of song queue to song index list
                SongIndexList.Clear();

                SongIndexList.AddRange(SongQueue);
                SongPlayer.PlaylistIndex = playlist_index;

                SongPlayer.ResetSongPlayer();

            }

            playSong(sq_index);
        }

        private void songLikeButton_Click(object? sender, EventArgs e, Song song)
        {
            click_SongLikeButton(song);
        }

        internal void click_SongLikeButton(Song song)
        {
            // UPDATE SONG CLASS OBJECT
            if (song.IS_LIKED)
            {
                // Mark song as unliked
                song.IS_LIKED = false;
            }
            else
            {
                // Mark song as liked
                song.IS_LIKED = true;
            }

            // UPDATE SONG FILE 
            UpdateSongFile(song);


            // UPDATE PLAYLIST FILE 
            UpdateLikedPlayList(MASTER_PLAYLIST[1], song);

            // Reset total songs label
            addPlaylistListToPlaylistPanel();
        }



        internal void UpdateLikedPlayList(Playlist playlist, Song song)
        {
            // Song Id 
            int songId = Convert.ToInt32(song.songId);
            bool addToPlaylist = song.IS_LIKED;

            if (addToPlaylist)
            {
                // add song id to songIdList (playlist)
                playlist.songIdList.Add(songId);
            }
            else
            {
                // remove song id from songIdList (playlist) 
                playlist.songIdList.Remove(songId);
            }


            MASTER_PLAYLIST[1].totalSongs = playlist.songIdList.Count;
            UpdatePlaylist(playlist.playlistId, playlist.playlistName, playlist.songIdList);

        }

        internal void ToggleSongLikeIcon(object? sender, EventArgs e, Song song, bool FILLED_ICON)
        {
            // TIP: LATER ON ADD A PARENT CONDITION STATEMENT THAT MATCHES ABOVE CONDITION
            if (!song.IS_LIKED)
            {
                if (FILLED_ICON)
                {
                    // MOUSE ENTER EVENT 
                    PictureBox icon = sender as PictureBox;
                    if (icon != null)
                    {
                        icon.BackgroundImage = Properties.Resources.filled_heart_icon;
                    }
                }
                else
                {
                    // MOUSE LEAVE EVENT 
                    PictureBox icon = sender as PictureBox;
                    if (icon != null)
                    {
                        icon.BackgroundImage = Properties.Resources.non_filled_heart_icon;
                    }
                }
            }
        }

        private void SongNameTB_MouseLeave(object? sender, EventArgs e, Panel panel)
        {
            ToggleSongPlayButtonVisibility(panel, false);
        }

        private void SongNameTB_MouseEnter(object? sender, EventArgs e, Panel panel)
        {
            ToggleSongPlayButtonVisibility(panel, true);
        }

        private void SongPanel_MouseLeave(object? sender, EventArgs e)
        {
            //ToggleSongPlayButtonVisibility(sender, false);
            ToggleSongPlayButtonVisibility(sender as Panel, false);
        }

        private void SongPanel_MouseHover(object? sender, EventArgs e)
        {
            //ToggleSongPlayButtonVisibility(sender, true);
            ToggleSongPlayButtonVisibility(sender as Panel, true);
        }

        private void ToggleSongPlayButtonVisibility(Panel panel, bool visibility)
        {
            if (panel != null)
            {
                PictureBox associatedPlayButton = panel.Controls.OfType<PictureBox>().FirstOrDefault();

                if (associatedPlayButton != null)
                {
                    associatedPlayButton.Visible = visibility;
                }
            }
        }
        private void SongPanel_MouseEnter(object? sender, EventArgs e)
        {
            //ToggleSongPlayButtonVisibility(sender, true);
            ToggleSongPlayButtonVisibility(sender as Panel, true);
        }



        private void addSongToMasterSongList()
        {
            try
            {
                // Clean the song list first 
                MASTER_SONG_LIST.Clear();

                // Read songs from song file
                // song file name = SONG_FILE_NAME  

                string song_file_path = APP_DIR_PATH + SONG_FILE_NAME;

                using (StreamReader song_file_reader = new StreamReader(song_file_path))
                {
                    while (true)
                    {
                        string song_data = song_file_reader.ReadLine();
                        if (song_data == null)
                        {
                            break;
                        }
                        else
                        {
                            uint id = Convert.ToUInt32(song_data.Split(",")[0]);
                            bool is_LIKED = false;
                            if (int.Parse(song_data.Split(",")[1]) == 1)
                            {
                                is_LIKED = true;
                            }

                            byte delimeter_first_occ = Convert.ToByte(song_data.IndexOf(','));

                            // note: by adding 1 in delimeter_first_occ we point to next index of delimeter character
                            byte pathStartIndex = Convert.ToByte(song_data.IndexOf(',', delimeter_first_occ + 1) + 1);



                            // song path 
                            string path = song_data.Substring(pathStartIndex);

                            string songName = getSongName(path);
                            // Calculate song path
                            // string songPath = song_dir_path + "\\" + file;

                            // Calculate song total duration 
                            string songDuration = getSongDuration(path);

                            // Add the song to the song list
                            MASTER_SONG_LIST.Add(new Song(id, songName, path, songDuration, is_LIKED));

                        }
                    }
                }

                // SET TOTAL SONGS VALUE
                totalSongOfPlaylistLabel.Text = MASTER_SONG_LIST.Count().ToString();
            }
            catch
            {

            }
        }



        private bool readSongDirPath()
        {
            try
            {
                // FILE PATH 
                string filePath = APP_DIR_PATH + SONG_DIRs_FILE_NAME;

                // IF directory does not exist 
                if (!Directory.Exists(APP_DIR_PATH))
                {
                    Directory.CreateDirectory(APP_DIR_PATH);
                }

                // IF File does not exist
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                // SEARCH FILE AND READ IT 
                using (StreamReader songDirFile = new StreamReader(filePath))
                {
                    while (true)
                    {
                        string line = songDirFile.ReadLine();
                        if (line != null)
                        {
                            songDirectories.Add(line);
                        }
                        else
                        {
                            break;
                        }
                    }

                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        private void addFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            // folder path
            string selectedFolderPath = string.Empty;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedFolderPath = folderDlg.SelectedPath.ToString();
                Environment.SpecialFolder root = folderDlg.RootFolder;

                // Store the folder path 
                storeSongDirPath(selectedFolderPath);
            }

            // reload the application 
            LoadApp();
        }



        private void playSong(int sil_index)
        {
            if (SongPlayer.songIsPlaying)
            {
                if (SongPlayer.SIL_index == sil_index)
                {
                    // PAUSE THE SONG
                    SongPlayer.PauseAudio();

                    // SET PLAY LABEL (indicates that user can play it)
                    playPauseButtonPB.BackgroundImage = Properties.Resources.play_button_bp_icon;

                    // stop GIF animation
                    playingSongImagePB.Image = null;
                }
                else
                {
                    int songIndex = SongIndexList[sil_index];
                    SongPlayer.ResetSongPlayer();
                    SongPlayer.PlayAudio(MASTER_SONG_LIST[songIndex].songPath, sil_index, songIndex); // for 0 based indexing 

                    // SET PAUSE LABEL (indicates that user can pause it)
                    playPauseButtonPB.BackgroundImage = Properties.Resources.pause_button_bp_icon;

                    // start GIF animation
                    playingSongImagePB.Image = Properties.Resources.song_playing_gif;
                }
            }
            else
            {
                // PLAY/RESUME THE SONG 
                int songIndex = SongIndexList[sil_index];
                if (SongPlayer.SIL_index == sil_index)
                {

                    SongPlayer.PlayAudio(MASTER_SONG_LIST[songIndex].songPath, sil_index, songIndex); // for 0 based indexing
                }
                else
                {
                    SongPlayer.ResetSongPlayer();
                    SongPlayer.PlayAudio(MASTER_SONG_LIST[songIndex].songPath, sil_index, songIndex); // for 0 based indexing 
                }

                // SET PAUSE LABEL (indicates that user can pause it)
                playPauseButtonPB.BackgroundImage = Properties.Resources.pause_button_bp_icon;

                // start GIF animation
                playingSongImagePB.Image = Properties.Resources.song_playing_gif;
            }

            // Update bottom song controller fields
            UpdateSongController();

            // 


        }

        private void UpdateSongController()
        {
            /*: SET THE SONG CONTROLLER 
             *  - song name
             *  - song duration
             *  - Visible song image 
             *  - song total time played (running time)
             *  - Update Song Pregress Bar
             */

            if (SongPlayer.SONG_CONTROLLER_ENABLED)
            {
                //int songIndex = SongPlayer.SongQueue[SongPlayer.SQ_Index];
                Song playingSong = MASTER_SONG_LIST[SongPlayer.MSL_index];
                // SONG NAME 
                songNameTB.Text = playingSong.songName;

                // SONG TOTAL TIME - DURATION
                songTotalTime.Text = playingSong.songDuration;

                // VISIBLE SONG IMAGE (Default)
                playingSongImagePB.Visible = true;

                // VISIBLE SONG LIKE BUTTON OF SONG CONTROLLER (BOTTOM) 
                songLikeButtonOfSCPB.Visible = true;

                // Song liked or not 
                if (playingSong.IS_LIKED)
                {
                    // Fill the heart 
                    songLikeButtonOfSCPB.BackgroundImage = Properties.Resources.filled_heart_icon;
                }
                else
                {
                    // Unfill the heart 
                    songLikeButtonOfSCPB.BackgroundImage = Properties.Resources.non_filled_heart_icon;
                }

            }
            //else
            //{
            //    // SONG NAME 
            //    songNameTB.Text = "";

            //    // SONG TOTAL TIME - DURATION
            //    songTotalTime.Text = "-:--"; 

            //    // VISIBLE SONG IMAGE (Default)
            //    playingSongImagePB.Visible = false;

            //    // VISIBLE SONG LIKE BUTTON OF SONG CONTROLLER (BOTTOM) 
            //    songLikeButtonOfSCPB.Visible = false;
            //}
        }

        private void UpdateSongProgress()
        {
            if (SongPlayer.SONG_CONTROLLER_ENABLED)
            {
                songProgressBar.Minimum = 0;
                songProgressBar.Maximum = 100;

                // UDPATE PLAYED TIME
                songPlayedTime.Text = SongPlayer.GetSongPlayedTime();

                // UPDATE PROGRESS
                //int songIndex = SongIndexList[SongPlayer.SIL_index];
                //songProgressBar.Value = SongPlayer.GetSongPlayedPercentage(MASTER_SONG_LIST[songIndex]);
                int volume = SongPlayer.GetSongPlayedPercentage(MASTER_SONG_LIST[SongPlayer.MSL_index]);
                if (volume >= 100)
                {

                    songProgressBar.Value = songProgressBar.Maximum;
                }
                else
                {
                    songProgressBar.Value = volume;
                }

                if (songProgressBar.Value == songProgressBar.Maximum)
                {
                    // SongPlayer.PlayNextSong(MASTER_SONG_LIST);
                    //SongPlayer.PlayNextSong(MASTER_SONG_LIST, SongIndexList);
                    //SongPlayer.PlayNextSong(MASTER_SONG_LIST);
                    nextTrackPB_Click(this, EventArgs.Empty); 
                }

            }
        }

        private void playPauseButtonPB_Click(object sender, EventArgs e)
        {
            if (SongPlayer.SONG_CONTROLLER_ENABLED)
            {
                // Change status of image (change it to pause state, that means user can pause it if the song is playing, else play a new song)
                if (SongPlayer.songIsPlaying)
                {
                    // PLAYING STATE 
                    // Pause it

                    // SET PLAY LABEL (indicates that user can play it)
                    playPauseButtonPB.BackgroundImage = Properties.Resources.play_button_bp_icon;

                    // Start GIF animation
                    playingSongImagePB.Image = null;

                    // Pause song
                    SongPlayer.PauseAudio();

                }
                else
                {
                    // NON PLAYING STATE 
                    // RESUME / PLAY song

                    // SET PAUSE LABEL (indicates that user can pause it)
                    playPauseButtonPB.BackgroundImage = Properties.Resources.pause_button_bp_icon;

                    // Start GIF animation 
                    playingSongImagePB.Image = Properties.Resources.song_playing_gif;

                    // RESUME / PLAY SONG 
                    //int songIndex = SongPlayer.SongQueue[SongPlayer.SQ_Index];
                    //SongPlayer.PlayAudio(MASTER_SONG_LIST[songIndex].songPath); // for 0 based indexing  

                    int songIndex = SongIndexList[SongPlayer.SIL_index];
                    SongPlayer.PlayAudio(MASTER_SONG_LIST[songIndex].songPath, SongPlayer.SIL_index, songIndex); // for 0 based indexing  


                    //SongPlayer.PlayAudio(MASTER_SONG_LIST[SongPlayer.songIndex].songPath, SongPlayer.SIL_index, SongPlayer.songIndex); // for 0 based indexing  
                }


            }
        }

        private void nextTrackPB_Click(object sender, EventArgs e)
        {
            if (SongPlayer.SONG_CONTROLLER_ENABLED)
            {
                // PLAY NEXT SONG
                //SongPlayer.PlayNextSong(MASTER_SONG_LIST);
                SongPlayer.PlayNextSong(MASTER_SONG_LIST, SongIndexList); // old code line 

                // UPDATE BOTTOM SONG CONTROLLER
                UpdateSongController();

                // SET PAUSE LABEL (indicates that user can pause it)
                playPauseButtonPB.BackgroundImage = Properties.Resources.pause_button_bp_icon;

                // start GIF animation 
                playingSongImagePB.Image = Properties.Resources.song_playing_gif;
            }
        }

        private void previousTrackPB_Click(object sender, EventArgs e)
        {
            if (SongPlayer.SONG_CONTROLLER_ENABLED)
            {
                // PLAY NEXT SONG
                //SongPlayer.PlayPreviousSong(MASTER_SONG_LIST);
                SongPlayer.PlayPreviousSong(MASTER_SONG_LIST, SongIndexList);     // old code line 

                // UPDATE BOTTOM SONG CONTROLLER
                UpdateSongController();

                // SET PAUSE LABEL (indicates that user can pause it)
                playPauseButtonPB.BackgroundImage = Properties.Resources.pause_button_bp_icon;

                // start GIF animation 
                playingSongImagePB.Image = Properties.Resources.song_playing_gif;
            }
        }

        private void volumeControllerPanel_MouseHover(object sender, EventArgs e)
        {
            // LISTEN MOUSE SCROLL EVENT TO ADJUST THE VOLUME
            SongPlayer.VOLUME_CONTROLLER_ENABLED = true;
        }

        private void volumeControllerPanel_MouseLeave(object sender, EventArgs e)
        {
            SongPlayer.VOLUME_CONTROLLER_ENABLED = false;
        }

        private void volumeControllerPanel_MouseEnter(object sender, EventArgs e)
        {
            SongPlayer.VOLUME_CONTROLLER_ENABLED = true;
        }

        private void VolumeControllerPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            // Take the current volume of device (within, 0 - 65535) after changing it 
            uint volume = SongPlayer.ChangeVolume(e.Delta);

            /* NOTE:
             * SongPlayer.ChangeVolume() method will return a volume (uint type) within the range from 0 to 2^16 (0 - 65535),
             * To set the progress bar value we need a value within the range 0 to 100, so we need to convert
             * the current volume to a newVolume value.
             */

            
            volumeProgressPB.Minimum = 0;
            volumeProgressPB.Maximum = 100;

            // Take newVolume value from rangeConverter 
            int newVolume = rangeConverter(volume, new uint[] { 0, 65535 }, new uint[] { 0, 100 });
            volumeProgressPB.Value = newVolume;

        }



        private void addPlaylistIconPB_Click(object sender, EventArgs e)
        {
            // initiate create playlist form

            using (CreatePlaylistForm Create_PL_Form = new CreatePlaylistForm())
            {
                int previousLineCount = File.ReadAllLines(APP_DIR_PATH + PLAYLIST_FILE_NAME).Length;

                Create_PL_Form.ShowDialog();

                int CurrentLineCount = File.ReadAllLines(APP_DIR_PATH + PLAYLIST_FILE_NAME).Length;

                bool isPlaylistCreated = (CurrentLineCount > previousLineCount) ? true : false;

                if (isPlaylistCreated)
                {

                    // reload playlist list panel 
                    // Add Playlists from file to playlistList 
                    addPlaylistToMasterPlaylistList();

                    // Add Playlist List to Playlist Panel 
                    addPlaylistListToPlaylistPanel();
                }
            }
        }

        private void AddSongsPB_MouseEnter(object sender, EventArgs e)
        {
            EditPlaylistPB.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AddSongsPB_MouseLeave(object sender, EventArgs e)
        {
            EditPlaylistPB.BorderStyle = BorderStyle.None;
        }

        internal void EditPlaylistPB_Click(object sender, EventArgs e)
        {
            // Open Edit playlist form 
            EditPlaylistForm Edit_window = new EditPlaylistForm();

            Edit_window.ShowDialog();


            // refresh the app 
            RefreshApp();

        }

        private void RefreshApp()
        {
            LoadPlaylist(CURR_LOADED_PLAYLIST_INDEX);
            addPlaylistListToPlaylistPanel();


            if (SongPlayer.PlaylistIndex == CURR_LOADED_PLAYLIST_INDEX)
            {
                // update song index list 
                // copy elements of song queue to song index list
                SongIndexList.Clear();

                // Error:  WE STORE INDEX IN SONG INDEX LIST, NOT THE IDS, 
                // BELOW LINE IS LOGICAL ERROR !!!
                //SongIndexList.AddRange(MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList);

                // TEST CODE BELOW ONE LINE 
                SongIndexList.AddRange(Get_Song_Indexes(MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList));

                SongPlayer.ResetSongPlayer();

                SongPlayer.SIL_index = 0;
                SongPlayer.songIsPlaying = false;
                SongPlayer.MSL_index = SongIndexList[SongPlayer.SIL_index];

                SongPlayer.ResetSongPlayer();
                SongPlayer.PlayAudio(MASTER_SONG_LIST[SongPlayer.MSL_index].songPath, SongPlayer.SIL_index, SongPlayer.MSL_index);

                // SET PAUSE LABEL (indicates that user can pause it)
                playPauseButtonPB.BackgroundImage = Properties.Resources.pause_button_bp_icon;

                // start GIF animation
                playingSongImagePB.Image = Properties.Resources.song_playing_gif;

                UpdateSongController();
            }
        }

        private void addPlaylistIconPB_MouseEnter(object sender, EventArgs e)
        {
            addPlaylistIconPB.BorderStyle = BorderStyle.FixedSingle;
        }

        private void addPlaylistIconPB_MouseLeave(object sender, EventArgs e)
        {
            addPlaylistIconPB.BorderStyle = BorderStyle.None;
        }

        private void HomeButton_Click(object? sender, EventArgs e)
        {
            if (MASTER_PLAYLIST.Count > 0)
            {
                LoadPlaylist(0);
            }

            searchBarTB.Visible = false;
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            // toggle search bar visibility 
            ToggleSearchBarVsb();
            searchBarTB.Text = string.Empty;

            searchBarTB_TextChanged(this, EventArgs.Empty);
        }

        private void ToggleSearchBarVsb()
        {
            // toggle search bar visibility 
            if (searchBarTB.Visible)
            {
                searchBarTB.Visible = false;
            }
            else
            {
                searchBarTB.Visible = true;
            }
        }

        private void NavButton_MouseEnter(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                Label label = panel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                {
                    label.ForeColor = Color.White;
                }
            }

        }

        private void NavButton_MouseLeave(object? sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                Label label = panel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                {
                    label.ForeColor = Color.Silver;
                }
            }

            if (CURR_LOADED_PLAYLIST_INDEX == 0)
            {
                HomeLabel.ForeColor = Color.White;
            }
        }

        private void searchBarTB_TextChanged(object sender, EventArgs e)
        {
            
            // Clear the middle panel
            middlePanel.Controls.Clear();

            // collect the text from textbox 
            string searchQuery = searchBarTB.Text.Trim();

            // filter the songs based on search
            List<Song> filteredSongList = MASTER_SONG_LIST.Where(song => song.songName.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            // add top panel (as margin)  
            if (filteredSongList.Count > 0)
            {
                Panel SongListBottomPanel = new Panel();
                //SongListBottomPanel.BackColor = Color.FromArgb(97, 66, 219);
                SongListBottomPanel.BackColor = Color.FromArgb(51, 51, 140);
                SongListBottomPanel.Location = new Point(left_pad_song_header, 0);
                SongListBottomPanel.Size = new Size(width_song_header, height_song_header * 1);

                middlePanel.Controls.Add(SongListBottomPanel);

                // list songs 

                PrepareSongQueue();

                int songCount = 0;

                for (int i = 0; i < SongQueue.Count; i++)
                {
                    if (filteredSongList.Any(song => MASTER_SONG_LIST[SongQueue[i]].songId == song.songId))
                    {
                        ++songCount;
                        addSongToSearchPanel(MASTER_SONG_LIST[SongQueue[i]], songCount, i);
                    }
                }
            }
            else
            {
                // add no music image 
                PictureBox NoMusicPB = new PictureBox();
                NoMusicPB.Image = Properties.Resources.no_music;
                NoMusicPB.Size = new Size(360, 360);
                NoMusicPB.Location = new Point((middlePanel.Width - NoMusicPB.Width) / 2, (middlePanel.Height - NoMusicPB.Height) / 2);

                middlePanel.Controls.Add(NoMusicPB);
            }




        }

        private void addSongToSearchPanel(Song song, int songNumber, int sq_index, int playlist_index = 0)
        {
            // 
            // songSerialNo 
            // 
            Label songSerialNo = new Label();
            songSerialNo.AutoSize = true;
            //songSerialNo.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            songSerialNo.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songSerialNo.ForeColor = Color.White;
            songSerialNo.Location = new Point(30, header_element_fix_ypad); // xpad = 30 (fix) 
            songSerialNo.Size = new Size(16, 17);
            songSerialNo.Text = songNumber.ToString();
            songSerialNo.Name = "songSerialNo" + songNumber.ToString();
            songSerialNo.Visible = true;

            PictureBox songPlayButton = new PictureBox();
            // songPlayButton.BackgroundImage = (Image)resources.GetObject("samplePlayPB.BackgroundImage");
            songPlayButton.BackgroundImage = Properties.Resources.play_button_icon;
            songPlayButton.BackgroundImageLayout = ImageLayout.Stretch;
            songPlayButton.Location = new Point(60, 5);
            songPlayButton.Name = "samplePlayPB";
            songPlayButton.Size = new Size(20, 20);
            //songPlayButton.TabIndex = 14;
            songPlayButton.TabStop = false;
            songPlayButton.Click += (s, args) => SongPanel_Click(sq_index, playlist_index);
            songPlayButton.Cursor = Cursors.Hand;
            // songPlayButton.Visible = true;
            songPlayButton.Visible = false;

            // 
            // songNameTB
            // 
            TextBox songNameTB = new TextBox();
            songNameTB.BackColor = Color.FromArgb(51, 51, 140);
            songNameTB.BorderStyle = BorderStyle.None;
            //songNameTB.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            songNameTB.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songNameTB.ForeColor = Color.White;
            songNameTB.Location = new Point(90, header_element_fix_ypad); // xpad = 90 (fix) 
            songNameTB.Name = "songNameLabel" + songNumber.ToString();
            songNameTB.Size = new Size(420, 18);
            songNameTB.Text = song.songName;
            songNameTB.ReadOnly = true;
            songNameTB.Cursor = Cursors.Hand;
            songNameTB.TabStop = false;

            songNameTB.Click += (s, args) => SongPanel_Click(sq_index, playlist_index);
            //songNameTB.Click += (s, args) => playSong(sil_index, playlist_index);


            // 
            // songLikeButton
            // 
            PictureBox songLikeButton = new PictureBox();
            songLikeButton.BackgroundImageLayout = ImageLayout.Stretch;
            songLikeButton.Location = new Point(540, 6);
            songLikeButton.Name = "songLikeButton" + songNumber.ToString();
            songLikeButton.Size = new Size(20, 20);
            songLikeButton.TabIndex = 17;
            songLikeButton.TabStop = false;
            songLikeButton.Click += (s, args) => songLikeButton_Click(s, args, song);
            songLikeButton.MouseEnter += (s, args) => ToggleSongLikeIcon(s, args, song, true);
            songLikeButton.MouseLeave += (s, args) => ToggleSongLikeIcon(s, args, song, false);
            if (song.IS_LIKED)
            {
                songLikeButton.BackgroundImage = Properties.Resources.filled_heart_icon;
            }
            else
            {
                songLikeButton.BackgroundImage = Properties.Resources.non_filled_heart_icon;
            }

            // 
            // songDurationLabel 
            // 
            Label songDurationLabel = new Label();
            songDurationLabel.AutoSize = true;
            //songDurationLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            songDurationLabel.Font = new Font("Leelawadee UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songDurationLabel.ForeColor = Color.White;
            songDurationLabel.Location = new Point(580, header_element_fix_ypad); // xpad = 580 (fix) 
            songDurationLabel.Name = "songDurationLabel" + songNumber.ToString();
            songDurationLabel.Size = new Size(27, 17);
            songDurationLabel.Text = song.songDuration;



            // 
            // songPanel
            // 
            Panel songPanel = new Panel();
            songPanel.BackColor = Color.FromArgb(51, 51, 140);
            songPanel.Controls.Add(songSerialNo);
            songPanel.Controls.Add(songPlayButton);
            songPanel.Controls.Add(songNameTB);
            songPanel.Controls.Add(songLikeButton);
            songPanel.Controls.Add(songDurationLabel);
            songPanel.Location = new Point(left_pad_song_header, top_pad_song_header + (height_song_header * (songNumber - 1)));
            songPanel.Name = "songPanel" + songNumber.ToString();
            songPanel.Size = new Size(width_song_header, height_song_header);
            //songPanel.TabIndex = 13;
            songPanel.Cursor = Cursors.Hand;
            songPanel.MouseEnter += SongPanel_MouseEnter;
            songPanel.MouseHover += SongPanel_MouseHover;
            songPanel.MouseLeave += SongPanel_MouseLeave;

            songPanel.Click += (s, args) => SongPanel_Click(sq_index, playlist_index);

            // SONG NAME SETTING
            // Visible play button when mouse enter / hover
            songNameTB.MouseEnter += (s, args) => SongNameTB_MouseEnter(s, args, songPanel);
            songNameTB.MouseLeave += (s, args) => SongNameTB_MouseLeave(s, args, songPanel);

            // ======================================================================================================
            // Resize the songPanel 
            MAX_PANEL_WIDTH = middlePanel.Width;
            MAX_PANEL_HEIGHT = middlePanel.Height;

            SetMeasurePercentage(0.0f, 93.42f, 97.31f, 8.57f);

            /// SIZE 
            width_song_header = MAX_PANEL_WIDTH - Convert.ToInt32(Math.Round(2 / 100f * MAX_PANEL_WIDTH));
            //width_song_header = songListHeaderPanel.Width; 
            //width_song_header = Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)); 
            height_song_header = Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));

            songPanel.Size = new Size(width_song_header, height_song_header);

            /// LOCATION
            left_pad_song_header = 0;
            top_pad_song_header = Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT));
            height_song_header = songPanel.Height;

            songPanel.Location = new Point(left_pad_song_header, height_song_header + (height_song_header * (songNumber - 1))); // 0 can be modified for top margin(y) 
            //songPanel.Location = new Point(left_pad_song_header, top_pad_song_header + (height_song_header * (songNumber - 1)));

            // ======================================================================================================

            // ======================================================================================================
            // Resize the elements of songPanel 
            MAX_PANEL_WIDTH = songPanel.Width;
            MAX_PANEL_HEIGHT = songPanel.Height;

            // 1. songSerialNo 4.60 20
            SetMeasurePercentage(4.60f, 20f, 0, 0);


            songSerialNo.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));


            // 2. songPlayButton (Y = 16.66f)
            SetMeasurePercentage(9.20f, 10f, 3.06f, 66.66f);

            songPlayButton.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songPlayButton.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 3. songNameTB
            SetMeasurePercentage(13.80f, 20f, 64.41f, 60f);

            songNameTB.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songNameTB.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 4. songLikeButton (Y = 20f)
            SetMeasurePercentage(82.82f, 5f, 3.06f, 66.66f);

            songLikeButton.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            songLikeButton.Size = new Size(Convert.ToInt32(Math.Round(WIDTH_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                        Convert.ToInt32(Math.Round(HEIGHT_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // 5. songDurationLabel 
            SetMeasurePercentage(88.95f, 20f, 0, 0);

            songDurationLabel.Location = new Point(Convert.ToInt32(Math.Round(X_PERCENTAGE / 100f * MAX_PANEL_WIDTH)),
                                              Convert.ToInt32(Math.Round(Y_PERCENTAGE / 100f * MAX_PANEL_HEIGHT)));

            // ======================================================================================================

            // Add song panel to middle panel (song list)
            middlePanel.Controls.Add(songPanel);
        }

        private void HideSearchBar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // invisible search bar 
                searchBarTB.Visible = false;

                // go to home screen 
                HomeButton_Click(this, EventArgs.Empty);
            }
        }

        private void addSongsPB_Click(object sender, EventArgs e)
        {
            // Open Song List form 
            SongListForm Song_List = new SongListForm();
            Song_List.ShowDialog();


            // Refresh app 
            RefreshApp(); 
        }
    }


}
