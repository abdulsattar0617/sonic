using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using Timer = System.Windows.Forms.Timer;

namespace Sonic_Music_Player
{
    internal class LibraryClass
    {
        // =====================================================================================
        // FIELDS  
        // =====================================================================================
        // MAX WIDTH FOR WINDOW
        internal static int MAX_SCREEN_WIDTH = 0;
        // MAX HEIGHT FOR WINDOW
        internal static int MAX_SCREEN_HEIGHT = 0;
        // Temporary use variables for each element 
        internal static float X_PERCENTAGE = 0, Y_PERCENTAGE = 0, WIDTH_PERCENTAGE = 0, HEIGHT_PERCENTAGE = 0;
        internal static int MAX_PANEL_WIDTH = 0, MAX_PANEL_HEIGHT = 0;

        [DllImport("winmm.dll")]
        internal static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("winmm.dll")]
        internal static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        // ATTRIBUTES 
        internal static List<string>  songDirectories = new List<string>();
        internal static string APP_DIR_PATH = "C:\\Sonic Music Player\\";
        internal static string SONG_DIRs_FILE_NAME = "song_directories.txt";
        internal static string SONG_FILE_NAME = "song_file.txt";
        internal static string PLAYLIST_FILE_NAME = "playlist_file.txt";

        internal static List<Song> MASTER_SONG_LIST = new List<Song>();
        internal static List<Playlist> MASTER_PLAYLIST = new List<Playlist>();

        // Song Header Fix left padding and top padding
        internal static int left_pad_song_header = 0, top_pad_song_header = 327;

        // Song Header's width and height 
        internal static int width_song_header = 652, height_song_header = 30; // old x:670 

        // Header Element fix top padding
        internal const int header_element_fix_ypad = 6;

        // Single Playlist Panel Measurements 
        internal static int height_playlist_header = 50;
        internal static int width_playlist_header = 300;
        internal static int x_pad_playlist_header = 0;
        internal static int y_pad_playlist_header = 0;
        internal static int left_pad_playlist_header = 0;
        internal static int top_pad_playlist_header = 0;

        // TIMER OBJECT 
        internal static Timer timer = new Timer();

        // PLAYLIST COLORS
        // BACKGROUND WHEN MOUSE ENTER
        internal static Color Playlist_BG_Color_On_Mouse_Enter = Color.FromArgb(26, 255, 255, 255);

        // SPOTIFY GREEN COLOR =  #1bd760

        // DEFAULT WHEN MOUSE LEAVE 
        internal static Color Playlist_BG_Color_On_Mouse_Leave = Color.Transparent;

        // PLAYABLE SONG INDEXES LIST 
        internal static List<int> SongIndexList = new List<int>();

        // SONG LIST FOR LISTING 
        internal static List<int> SongQueue = new List<int>();

        // CURRENT LOADED PLAYLIST INDEX 
        internal static int CURR_LOADED_PLAYLIST_INDEX = 0;

        // Last Greet Time 
        internal static DateTime Last_Greet_Time; 


        // =====================================================================================
        // METHODS 
        // =====================================================================================



        internal static int rangeConverter(uint originalValue, uint[] minMaxValue, uint[] newMinMaxValue)
        {
            double minValue = minMaxValue[0];
            double maxValue = minMaxValue[1];
            double newMinValue = newMinMaxValue[0];
            double newMaxValue = newMinMaxValue[1];

            double newValue = (originalValue - minValue) * (newMaxValue - newMinValue) / (maxValue - minValue) + newMinValue;

            return Convert.ToInt32(newValue);
        }

        internal static Song GetSong(int Song_ID)
        {
            try
            {
                var song = MASTER_SONG_LIST.FirstOrDefault(x => x.songId == Song_ID);

                
                return song;
            }
            catch
            {
                return null; 
            }

        }

        internal static bool storeSongDirPath(string dirPath)
        {
            try
            {
                string filePath = APP_DIR_PATH + SONG_DIRs_FILE_NAME;

                // IF directory does not exist 
                if (!Directory.Exists(APP_DIR_PATH))
                {
                    Directory.CreateDirectory(APP_DIR_PATH);
                }

                using (StreamWriter songDirFile = new StreamWriter(filePath, true))
                {
                    string line = $"{dirPath}";
                    songDirFile.WriteLine(line);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        internal static string getSongDuration(string path)
        {
            if (path == null)
            {
                return "0:00";
            }

            using (AudioFileReader audioFile = new AudioFileReader(path))
            {
                TimeSpan duration = audioFile.TotalTime;
                return duration.ToString(@"mm\:ss");
            }

        }

        internal static void ValidateSongFile()
        {
            // traverse each song path 
            // check the file of that path or not
            // if file not exist then remove that path from file 

            string song_file_path = APP_DIR_PATH + SONG_FILE_NAME;
            string temp_file_path = APP_DIR_PATH + "__temp_song_file.txt";

            if (File.Exists(temp_file_path))
            {
                File.Delete(temp_file_path);
            }

            using (StreamReader reader = new StreamReader(song_file_path))
            using (StreamWriter writer = new StreamWriter(temp_file_path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string song_path = line.Split(",").ToList()[2];

                    try
                    {
                        
                        // To find file exist or not 
                        AudioFileReader audioFile = new AudioFileReader(song_path);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    writer.WriteLine(line);

                    

                }
            }

            File.Delete(song_file_path);
            File.Move(temp_file_path, song_file_path);

        }

        internal static void UpdateSongFile()
        {
            ValidateSongFile();

            // MODIFY BELOW CODE TO STORE SONGS PATHS TO TEXT FILE 
            // file name : SONG_FILE_NAME 

            try
            {

                // Read songs from directories
                // DIR list = songDirectories 

                string song_dir_file_path = APP_DIR_PATH + SONG_DIRs_FILE_NAME;

                using (StreamReader song_dirs_file = new StreamReader(song_dir_file_path))
                {
                    while (true)
                    {
                        string single_dir_path = song_dirs_file.ReadLine();
                        if (single_dir_path == null)
                        {
                            break;
                        }
                        else
                        {
                            foreach (string file in Directory.GetFiles(single_dir_path))
                            {
                                // TASK : LATER ON ADD MORE SONG EXTENSIONS
                                if (file.EndsWith(".mp3") || file.EndsWith(".wav"))
                                {
                                    string song_file_path = APP_DIR_PATH + SONG_FILE_NAME;

                                    // IF FILE NOT EXIST, CREATE IT 
                                    if (!File.Exists(song_file_path))
                                    {
                                        File.Create(song_file_path).Close();
                                    }

                                    // IF SONG PATH NOT EXIST IN FILE THEN APPEND IT TO FILE 
                                    bool Path_Exist = File.ReadAllText(song_file_path).Contains(file);
                                    if (!Path_Exist)
                                    {
                                        int file_length = File.ReadAllLines(song_file_path).Count();
                                        using (StreamWriter song_file_writer = new StreamWriter(song_file_path, true))
                                        {
                                            int id = 1;

                                            if (file_length > 0)
                                            {
                                                id = file_length + 1;
                                            }

                                            byte is_Liked = 0;

                                            // STORE ID, PATH
                                            string line = $"{id}, {is_Liked}, {file} ";
                                            song_file_writer.WriteLine(line);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        internal static void UpdateSongFile(Song song)
        {
            // throw new NotImplementedException();

            string song_file_path = APP_DIR_PATH + SONG_FILE_NAME;

            string lineIdToUpdate = song.songId.ToString().Trim();
            bool is_Liked_flag = song.IS_LIKED;

            string temp_file_path = APP_DIR_PATH + "temporary_file.txt";

            using (StreamReader reader = new StreamReader(song_file_path))
            using (StreamWriter writer = new StreamWriter(temp_file_path, false))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] fields = line.Split(",");

                    string lineId = fields[0].Trim();

                    if (lineId == lineIdToUpdate)
                    {
                        fields[1] = is_Liked_flag ? "1" : "0";
                    }

                    writer.WriteLine(string.Join(",", fields));
                }
            }

            // Replace the original file with modified file 
            File.Delete(song_file_path);
            File.Move(temp_file_path, song_file_path);
        }

        internal static void addPlaylistToMasterPlaylistList()
        {
            try
            {
                // Clean the playlist list first 
                MASTER_PLAYLIST.Clear();

                // Read playlists from playlist file 
                // playlist file name = PLAYLIST_FILE_NAME

                string playlist_file_path = APP_DIR_PATH + PLAYLIST_FILE_NAME;

                using (StreamReader playlist_file_reader = new StreamReader(playlist_file_path))
                {
                    //int lineCount = File.ReadAllLines(playlist_file_path).Length; 

                    while (!playlist_file_reader.EndOfStream)
                    {
                        string line = playlist_file_reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        else
                        {
                            string[] fields = line.Split(",");
                            // id, name, total songs, song ids list(pipe separated) CoverImagePath
                            // 0    1         2             3                            4   
                            int id = Convert.ToInt32(fields[0]);
                            string name = fields[1];
                            //uint totalSongs = Convert.ToUInt32(fields[2]);
                            string songIds = fields[3];
                            List<int> songIdsList = new List<int>();
                            if (!string.IsNullOrWhiteSpace(songIds))
                            {
                                songIdsList = songIds.Split("|").ToList().Select(int.Parse).ToList();
                            }
                            string cover_image_path = fields[4].Trim();

                            // Add the playlist to playlistList
                            MASTER_PLAYLIST.Add(new Playlist(id, name, songIdsList, cover_image_path));
                        }

                    }
                }
            }
            catch
            {

            }
        }

        internal static void SetMeasurePercentage(float x, float y, float w, float h)
        {
            X_PERCENTAGE = x;
            Y_PERCENTAGE = y;
            WIDTH_PERCENTAGE = w;
            HEIGHT_PERCENTAGE = h;
        }

        internal static void PrepareSongQueue()
        {
            SongQueue.Clear();

            for (int i = 0; i < MASTER_SONG_LIST.Count; i++)
            {
                SongQueue.Add(i);
            }
        }

        internal static void CreatePlaylistInFile(string name, List<int> songIds, bool IsFirstPlaylist = false, string PlaylistCoverImagePath = "none")
        {
            // IF FILE NOT EXIST, CREATE ONE 
            string playlist_file_path = APP_DIR_PATH + PLAYLIST_FILE_NAME;

            if (!File.Exists(playlist_file_path))
            {
                File.Create(playlist_file_path).Close();
            }

            uint id;

            if (IsFirstPlaylist)
            {
                id = 0;
                
            }
            else
            {
                // Generate id for playlist
                id = 1;

                if (File.ReadAllLines(playlist_file_path).Count() > 1)
                {
                    id = Convert.ToUInt32(File.ReadAllLines(playlist_file_path).Count());
                }
            }

            if (id == 1 && PlaylistCoverImagePath == "none")
            {
                PlaylistCoverImagePath = "liked";
            }

            // playlist name 
            // calculate total songs to store in playlist
            int totalSongIds = songIds.Count();


            string line = $"{id}, {name}, {totalSongIds}, {string.Join("|", songIds)}, {PlaylistCoverImagePath}";

            // WRITE LINE TO PLAYLIST FILE 
            using (StreamWriter writer = new StreamWriter(playlist_file_path, true))
            {
                writer.WriteLine(line);
            }
        }

        internal static string getSongName(string path)
        {
            if (path == null)
            {
                return "";
            }

            string fileName = path.Split("\\").Last();

            fileName = fileName.Split(".")[0];

            return fileName;
        }

        internal static void UpdatePlaylistFile()
        {
            try
            {
                // Read songs from song file
                // song file name = SONG_FILE_NAME  

                string song_file_path = APP_DIR_PATH + SONG_FILE_NAME;
                //string songIds = string.Empty;
                //int totalSongs = 0;
                List<int> likedSongIdsList = new List<int>();
                List<int> allSongIdList = new List<int>();

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
                            int id = Convert.ToInt32(song_data.Split(",")[0]);

                            //int is_liked = int.Parse(song_data.Split(",")[1]);
                            if (int.Parse(song_data.Split(",")[1]) == 1)
                            {
                                //++totalSongs;
                                //songIds = songIds + id + "|";
                                likedSongIdsList.Add(id);

                            }

                            allSongIdList.Add(id);
                        }
                    }
                    //if (songIds.EndsWith("|"))
                    //{
                    //    songIds = songIds.Substring(0, songIds.Length - 1);
                    //}
                }

                UpdatePlaylist(0, "All songs", allSongIdList);
                UpdatePlaylist(1, "Liked Songs", likedSongIdsList);



            }
            catch
            {

            }
        }

        internal static void UpdatePlaylist(int playlist_id, string playlist_name, List<int> songIdList, string coverImagePath="none")
        {
            try
            {
                // Playlist file path
                string playlist_file_path = APP_DIR_PATH + PLAYLIST_FILE_NAME;

                // If file not exist, create it 
                if (!File.Exists(playlist_file_path))
                {
                    File.Create(playlist_file_path).Close();
                }

                if (File.ReadAllLines(playlist_file_path).Count() == 0)
                {
                    CreatePlaylistInFile("All Songs", songIdList, IsFirstPlaylist: true);
                }
                else
                {
                    // PLAYLIST FILE PATH 

                    // PLAYLIST ID TO UPDATE
                    string playlistIdToUpdate = playlist_id.ToString(); // liked songs playlist id is 1    
                    bool PlaylistExist = false;

                    // NEW TEMP FILE 
                    string temp_file_path = APP_DIR_PATH + "temporary_pl_file.txt";

                    using (StreamReader reader = new StreamReader(playlist_file_path))
                    using (StreamWriter writer = new StreamWriter(temp_file_path, false))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            string[] fields = line.Split(",");

                            string playlistId = fields[0].Trim();

                            if (playlistId == playlistIdToUpdate)
                            {
                                fields[2] = songIdList.Count.ToString();
                                fields[3] = string.Join("|", songIdList);
                                
                                if (File.Exists(coverImagePath))
                                {
                                    fields[4] = coverImagePath;
                                }
                                else if (playlist_id == 1)
                                {
                                    fields[4] = "liked";
                                }
                                else
                                {
                                    fields[4] = "none";
                                }
                                writer.WriteLine(string.Join(",", fields));
                                PlaylistExist = true;
                                //break;
                            }
                            else
                            {
                                writer.WriteLine(string.Join(",", fields));
                            }

                        }
                    }
                    if (PlaylistExist)
                    {
                        File.Delete(playlist_file_path);
                        File.Move(temp_file_path, playlist_file_path);

                    }
                    else
                    {
                        CreatePlaylistInFile(playlist_name, songIdList);
                        File.Delete(temp_file_path);
                    }
                }


            }
            catch
            {

            }
        }
    }

    internal class Song
    {

        // song ID
        public uint songId;

        // song liked or not 
        public bool IS_LIKED = false;

        // song name
        public string songName = string.Empty;

        // song file path
        public string songPath = string.Empty;

        // song duration
        public string songDuration = string.Empty;
        public Song()
        {

        }
        public Song(uint songId, string songName, string songPath, string songDuration = "0:00", bool iS_LIKED = false)
        {
            this.songId = songId;
            this.songName = songName;
            this.songPath = songPath;
            this.songDuration = songDuration;
            this.IS_LIKED = iS_LIKED;
        }
    }

    internal class Playlist
    {
        // playlist id 
        public int playlistId;

        // playlist name 
        public string playlistName = string.Empty;

        // Total songs in playlist 
        public int totalSongs = 0;

        // list of song ids
        public List<int> songIdList;

        public string CoverImagePath;

        public Playlist()
        {

        }

        public Playlist(int id, string name, List<int> songIds, string coverImagePath)
        {
            this.playlistId = id;
            this.playlistName = name;
            this.songIdList = songIds;

            this.totalSongs = this.songIdList.Count;
            CoverImagePath = coverImagePath;
        }
    }

    internal class SongPlayer
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        private static IWavePlayer waveOutDevice;
        private static AudioFileReader audioFile;
        private static long lastPosition = 0; // Store the last playback position

        public static bool songIsPlaying = false;
        public static int songIndex = 0;
        // Song Index List index
        public static int SIL_index = 0;
        // Master Song List index 
        public static int MSL_index = 0;
        public static bool SONG_CONTROLLER_ENABLED = false;
        public static bool VOLUME_CONTROLLER_ENABLED = false;

        const int WM_MOUSEWHEEL = 0x020A;
        const int WAVEOUT_SETVOLUME = 0x8006;


        // Testing Code variables
        public static int PlaylistIndex = -1;
        //// Playing Song's Index  (Song Queue Index) 
        //public static int SQ_Index = -1;

        //public static List<int> SongQueue = new List<int>();
        // end of otesting code variables


        public static void PlayAudio(string audioFilePath, int sil_index, int msl_index)
        {
            if (waveOutDevice != null)
            {
                // Remember the last playback position
                lastPosition = audioFile.Position;
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                audioFile.Dispose();
            }

            waveOutDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath);

            // Set the last position before resuming
            audioFile.Position = lastPosition;

            waveOutDevice.Init(audioFile);
            waveOutDevice.Play();
            songIsPlaying = true;
            SIL_index = sil_index;
            MSL_index = msl_index;
            SONG_CONTROLLER_ENABLED = true;
        }


        public static void ResetSongPlayer()
        {
            if (waveOutDevice != null)
            {
                lastPosition = 0;
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
        }

        public static void PauseAudio()
        {
            if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                // Remember the last playback position
                lastPosition = audioFile.Position;
                waveOutDevice.Pause();

                songIsPlaying = false;
            }
        }



        public static void PlayNextSong(List<Song> master_song_list, List<int> song_index_list)
        {
            if (waveOutDevice != null)
            {
                // Play next song
                if (song_index_list.Count > SIL_index + 1)
                {
                    ++SIL_index;
                    int songIndex = song_index_list[SIL_index];

                    SongPlayer.ResetSongPlayer();
                    SongPlayer.PlayAudio(master_song_list[songIndex].songPath, SIL_index, songIndex); // for 0 based indexing   
                }
                else
                {
                    int songIndex = song_index_list[0];

                    // WE ARE ON LAST SONG 
                    SongPlayer.PlayAudio(master_song_list[songIndex].songPath, 0, songIndex); // for 0 based indexing    
                }
            }
        }

        public static void PlayPreviousSong(List<Song> master_song_list, List<int> song_index_list)
        {
            if (waveOutDevice != null)
            {
                // Play next song
                if (SIL_index > 0)
                {
                    --SIL_index;
                    int songIndex = song_index_list[SIL_index];

                    SongPlayer.ResetSongPlayer();
                    SongPlayer.PlayAudio(master_song_list[songIndex].songPath, SIL_index, songIndex); // for 0 based indexing   
                }
                else
                {
                    // WE ARE ON FIRST SONG 
                    SIL_index = 0;
                    int songIndex = song_index_list[SIL_index];

                    SongPlayer.PlayAudio(master_song_list[songIndex].songPath, SIL_index, songIndex); // for 0 based indexing    
                }
            }
        }
        public static string GetSongPlayedTime()
        {
            if (waveOutDevice != null && audioFile != null)
            {
                TimeSpan playedTime = audioFile.CurrentTime;
                return string.Format("{0:mm\\:ss}", playedTime);
            }
            return "0:00";
        }

        public static int GetSongPlayedPercentage(Song playingSong)
        {
            if (waveOutDevice != null & audioFile != null)
            {
                TimeSpan totalDuration = TimeSpan.Parse(playingSong.songDuration);
                // TimeSpan playedTime = audioFile.CurrentTime;
                TimeSpan playedTime = TimeSpan.Parse(GetSongPlayedTime());


                if (totalDuration.TotalSeconds > 0)
                {
                    double percentage = (playedTime.TotalSeconds / totalDuration.TotalSeconds) * 100;


                    return (int)Math.Round(percentage);
                }

                return 0;
            }
            return 0;
        }

        public static int GetCurrentVolume()
        {
            using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
            {
                using (MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia))
                {
                    return Convert.ToInt32(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                }
            }
        }

        public static uint ChangeVolume(int delta)
        {
            // Get the current volume
            // Get the current volume
            uint currentVolume = 0;
            waveOutGetVolume(IntPtr.Zero, out currentVolume);

            // Calculate the new volume based on the mouse wheel delta
            //int delta = e.Delta;
            int maxVolume = 0xFFFF; // Max volume value
            int minVolume = 0x0000; // Min volume value
            int step = 30;
            int newVolume = (int)currentVolume + delta * step;
            newVolume = Math.Max(minVolume, Math.Min(maxVolume, newVolume)); // Ensure it's within the valid range

            // Set the new volume
            waveOutSetVolume(IntPtr.Zero, (uint)newVolume);

            // NOTE : BELOW CODE LAUNCHES A MessageBox THAT SHOWS THE MAX VOLUME (IF REACHED)
            uint volume;
            int result = waveOutGetVolume(IntPtr.Zero, out volume);

            return volume;
        }

    }

    public class RoundedPanel : Panel
    {
        private float topLeftRadiusPercent;
        private float topRightRadiusPercent;
        private float bottomRightRadiusPercent;
        private float bottomLeftRadiusPercent;

        // Constructor to set the corner radii during initialization
        public RoundedPanel(float topLeftRadius, float topRightRadius, float bottomRightRadius, float bottomLeftRadius)
        {
            topLeftRadiusPercent = topLeftRadius;
            topRightRadiusPercent = topRightRadius;
            bottomRightRadiusPercent = bottomRightRadius;
            bottomLeftRadiusPercent = bottomLeftRadius;
        }

        // Properties to set/get roundness values (percentage) for each corner
        public float TopLeftRadiusPercent
        {
            get { return topLeftRadiusPercent; }
            set
            {
                topLeftRadiusPercent = value;
                Refresh();
            }
        }

        public float TopRightRadiusPercent
        {
            get { return topRightRadiusPercent; }
            set
            {
                topRightRadiusPercent = value;
                Refresh();
            }
        }

        public float BottomRightRadiusPercent
        {
            get { return bottomRightRadiusPercent; }
            set
            {
                bottomRightRadiusPercent = value;
                Refresh();
            }
        }

        public float BottomLeftRadiusPercent
        {
            get { return bottomLeftRadiusPercent; }
            set
            {
                bottomLeftRadiusPercent = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();

            // Convert percentage values to pixel values for each corner
            float topLeftRadius = (topLeftRadiusPercent / 100) * Math.Min(Width, Height);
            float topRightRadius = (topRightRadiusPercent / 100) * Math.Min(Width, Height);
            float bottomRightRadius = (bottomRightRadiusPercent / 100) * Math.Min(Width, Height);
            float bottomLeftRadius = (bottomLeftRadiusPercent / 100) * Math.Min(Width, Height);

            // Create rounded rectangle path with specified corner roundness for each corner
            path.AddArc(0, 0, 2 * topLeftRadius, 2 * topLeftRadius, 180, 90);
            path.AddLine(topLeftRadius, 0, Width - topRightRadius, 0);
            path.AddArc(Width - 2 * topRightRadius, 0, 2 * topRightRadius, 2 * topRightRadius, 270, 90);
            path.AddLine(Width, topRightRadius, Width, Height - bottomRightRadius);
            path.AddArc(Width - 2 * bottomRightRadius, Height - 2 * bottomRightRadius, 2 * bottomRightRadius, 2 * bottomRightRadius, 0, 90);
            path.AddLine(Width - bottomRightRadius, Height, bottomLeftRadius, Height);
            path.AddArc(0, Height - 2 * bottomLeftRadius, 2 * bottomLeftRadius, 2 * bottomLeftRadius, 90, 90);
            path.AddLine(0, Height - bottomLeftRadius, 0, topLeftRadius);

            // Apply the rounded rectangle path to the panel
            this.Region = new Region(path);
        }
    }

    
}
