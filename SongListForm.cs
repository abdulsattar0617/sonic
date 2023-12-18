using System.Xml.Linq;
using static Sonic_Music_Player.LibraryClass;
namespace Sonic_Music_Player
{
    public partial class SongListForm : Form
    {
        int GAP_HEIGHT = 10;
        int MAX_CHARS = 45;
        List<int> Selected_Song_Ids_List = new List<int>();
        List<CheckBox> CheckBoxes_Reference = new List<CheckBox>();

        public SongListForm()
        {
            InitializeComponent();
        }

        private void SongListForm_Load(object sender, EventArgs e)
        {
            if (MASTER_PLAYLIST.Count > 0)
            {
                this.Text = MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].playlistName;
                //this.Text = MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].playlistName + " Playlist";
            }

            // list song name as checkboxes 
            AddSongListTo_SSL_Panel();

            // TEST CODE 
            //AddSongTo_SSL_Panel(new Song(1, "Alan Walker", "D:\\"), 1);
            //AddSongTo_SSL_Panel(new Song(2, "Blan Walker", "D:\\"), 2);
            //AddSongTo_SSL_Panel(new Song(3, "Clan Walker", "D:\\"), 3);
            //AddSongTo_SSL_Panel(new Song(4, "Dlan Walker", "D:\\"), 4);
            //AddSongTo_SSL_Panel(new Song(5, "Elan Walker", "D:\\"), 5);
            //AddSongTo_SSL_Panel(new Song(6, "Flan Walker", "D:\\"), 6);
            //AddSongTo_SSL_Panel(new Song(7, "Glan Walker", "D:\\"), 7);
            //AddSongTo_SSL_Panel(new Song(8, "Hlan Walker", "D:\\"), 8);
            //AddSongTo_SSL_Panel(new Song(9, "Ilan Walker", "D:\\"), 9);
            //AddSongTo_SSL_Panel(new Song(10, "KKlan Walker", "D:\\"), 10);
            // END TEST CODE 

        }

        private void AddSongListTo_SSL_Panel()
        {
            if (MASTER_SONG_LIST.Count > 0)
            {
                // loop throw each song and pass it to the method

                for (int index = 0; index < MASTER_SONG_LIST.Count; index++)
                {
                    AddSongTo_SSL_Panel(MASTER_SONG_LIST[index], index + 1);
                }
            }
            else
            {
                // add an element for empty list
                // something that should be animated and relative 
            }

            // Check whether all checkboxes are marks ?
            bool ALL_CHECKED = !CheckBoxes_Reference.Any(x => x.Checked == false);
            if (ALL_CHECKED)
            {
                // automatically set checked for "select all" checkbox 
                selectAllCB.Checked = true;
            }
            else
            {
                // automatically set unchecked for "select all" checkbox 
                selectAllCB.Checked = false;
            }
        }

        private void AddSongTo_SSL_Panel(Song song, int song_number)
        {
            // 1. SERIAL NUMBER
            // 2. NAME OF SONG (CHECK BOX)
            // 3. ADD REFERENCE OF CHECKBOX IN THE LIST OF REFERENCE CHECK BOX 
            // 4. HORIZONTAL LINE
            // 5. ADD ALL ELEMENTS TO SONG SELECTION LIST PANEL 



            // 
            // 1. songNumber_lbl 
            // 
            //Label songNumber_lbl = new Label();
            //songNumber_lbl.AutoSize = true;
            //songNumber_lbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            //songNumber_lbl.Location = new Point(16, 27 + GAP_HEIGHT + (29 * (song_number - 1)));
            //songNumber_lbl.Name = "songNumber_lbl" + song_number;
            //songNumber_lbl.Size = new Size(13, 17);
            //songNumber_lbl.TabIndex = 11;
            //songNumber_lbl.Text = song_number.ToString();

            // 
            // 2. songName_cb
            // 
            CheckBox songName_cb = new CheckBox();
            songName_cb.AutoSize = true;
            songName_cb.CheckAlign = ContentAlignment.MiddleLeft;
            songName_cb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            songName_cb.Location = new Point(16, 27 + GAP_HEIGHT + (29 * (song_number - 1)));
            //songName_cb.Location = new Point(50, 27 + GAP_HEIGHT + (29 * (song_number - 1)));
            songName_cb.Name = "songName_cb" + song_number;
            songName_cb.Size = new Size(281, 25);
            songName_cb.TabIndex = 0;
            if (song.songName.Length >= MAX_CHARS)
            {
                songName_cb.Text = song.songName.Substring(0, MAX_CHARS - 3);
                songName_cb.Text = songName_cb.Text + "...";

            }
            else
            {
                songName_cb.Text = song.songName.PadRight(MAX_CHARS, ' ');
            }
            songName_cb.UseVisualStyleBackColor = true;
            songName_cb.CheckedChanged += (s, args) => SongName_cb_CheckedChanged(s, args, (int)song.songId);

            // 3. Adding refernce to checkbox list 
            CheckBoxes_Reference.Add(songName_cb);
            if (MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList.Any(x => x == song.songId))
            {
                songName_cb.Checked = true;
            }

            // 
            // 4. songSepLine_lbl 
            // 
            Label songSepLine_lbl = new Label();
            songSepLine_lbl.BorderStyle = BorderStyle.FixedSingle;
            songSepLine_lbl.FlatStyle = FlatStyle.Flat;
            songSepLine_lbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            songSepLine_lbl.Location = new Point(16, GAP_HEIGHT + 28 + 27 + (29 * (song_number - 1)));
            songSepLine_lbl.Name = "songSepLine_lbl" + song_number;
            songSepLine_lbl.Size = new Size(318, 1);
            songSepLine_lbl.TabIndex = 6;


            // 5. Add components to panel 
            //songSelectListPanel.Controls.Add(songNumber_lbl);
            songSelectListPanel.Controls.Add(songName_cb);
            songSelectListPanel.Controls.Add(songSepLine_lbl);

        }

        private void SongName_cb_CheckedChanged(object? sender, EventArgs e, int SONG_ID)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        // Add song id to list
                        Selected_Song_Ids_List.Add(SONG_ID);
                    }
                    else
                    {
                        // Remove song id from list, if existed already
                        Selected_Song_Ids_List.Remove(SONG_ID);
                    }

                    // Modify the select all checkbox 
                    bool ALL_CHECKED = !CheckBoxes_Reference.Any(x => x.Checked == false);
                    if (ALL_CHECKED)
                    {
                        selectAllCB.Checked = true;
                    }
                    else
                    {
                        selectAllCB.Checked = false;
                    }
                }
            }
            catch
            {

            }

        }

        private void selectAllCB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectAllCB.Checked)
                {
                    // check all songs 
                    for (int index = 0; index < CheckBoxes_Reference.Count; index++)
                    {
                        CheckBoxes_Reference[index].Checked = true;
                    }
                }
                else
                {
                    // uncheck all songs if all songs are checked already
                    bool ALL_CHECKED = !CheckBoxes_Reference.Any(x => x.Checked == false);

                    if (ALL_CHECKED)
                    {
                        for (int index = 0; index < CheckBoxes_Reference.Count; index++)
                        {
                            CheckBoxes_Reference[index].Checked = false;
                        }
                    }
                }

            }
            catch
            {

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            

            if (SetPlaylistCB.Checked)
            {
                // MARK ALL SONGS AS UN-LIKED 
                // ONLY FOR LIKED SONG PLAYLIST 
                if (CURR_LOADED_PLAYLIST_INDEX == 1)
                {
                    // liked songs playlist 
                    foreach (int ID in MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList.Except(Selected_Song_Ids_List))
                    {
                        // Iterating the Union of Liked Playlist and Selected Songs
                        // Liked Playlist's Songs ids that don't appear in Selected_Song_Ids_List 
                        Song song = GetSong(ID);
                        song.IS_LIKED = false;

                        UpdateSongFile(song);
                    }
                }

                // Reset Playlist Song Ids List
                MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList.Clear();
                // Reset Total Songs attribute  
                MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].totalSongs = 0;

            }

            if (Selected_Song_Ids_List.Count > 0)
            {
                // 1. append ids to playlist
                foreach (int ID in Selected_Song_Ids_List)
                {
                    // UDPATE MASTER PLAYLIST 
                    if (!MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList.Contains(ID))
                    {
                        // Add ID to the list 
                        MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].songIdList.Add(ID);
                        ++MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX].totalSongs;
                    }

                    if (CURR_LOADED_PLAYLIST_INDEX == 1)
                    {
                        Song song = GetSong(ID);
                        song.IS_LIKED = true;

                        UpdateSongFile(song);
                    }
                }

                

                // 2. update playlist file 
                if (CURR_LOADED_PLAYLIST_INDEX > 0)     // 0 index playlist is "All Songs" playlist 
                {
                    Playlist pl = MASTER_PLAYLIST[CURR_LOADED_PLAYLIST_INDEX];
                    UpdatePlaylist(pl.playlistId, pl.playlistName, pl.songIdList);

                }
            }

            // 3. Close the Form 
            this.Close();
        }
    }
}
