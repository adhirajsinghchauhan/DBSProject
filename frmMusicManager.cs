using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections;
using ShellID3Reader;
using System.Reflection;
using System.IO;
using System.Threading;
using ListViewSorter;
namespace MusicManager
{
    public partial class frmMusicManager : Form,IComparer<MMHistory.MusicRow>
    {
        public delegate void AddFileDelegate(string FileName, MP3File mp3File, string Status);
        public delegate void UpdateFileStatusDelegate(string key, string fileName,string Status);
        public delegate void StatusChangedDelegate(string Message);
        public delegate void FileProcessDelegate(int MaxValue,int currentIndex);
        public delegate void UpdateGroupDelegate(ListViewItem item);
        public delegate void InvokeMethodDelegate();
        public delegate void GetSelectedListDelegate(ArrayList list);
        
        private Hashtable mp3FileHash = new Hashtable();
        private FolderBrowserDialog folderBrowserDialog;
        private StringCollection dropFileList;
        private long totalFileSize;
        private ListViewColumnSorter lvwColumnSorter = null;
        private MMHistory.MusicRow drPlaying = null;
        private bool isPlaying = false;
        private MMHistory mmHistory;
        Random randomNumberGenreator = new Random();
        private double totalPlayCount=0;
        private ArrayList GenreList;
        private ArrayList artistList;
        private ArrayList albumList;
        private bool preventEvent = false;
        private List<MMHistory.MusicRow> musicList;
        private List<MMHistory.MusicRow> playedList;
		private int seconds, minutes;
		private static Image play = Image.FromFile("E:/IE CSE/Studios/Resources/Icons/Material Design/png/play106.png");
		private static Image pause = Image.FromFile("E:/IE CSE/Studios/Resources/Icons/Material Design/png/pause44.png");

		public frmMusicManager()
        {            
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
            totalFileSize = 0;
            lvwColumnSorter = new ListViewColumnSorter();
            MusicManagerHistory = new MMHistory();
            musicList=new List<MMHistory.MusicRow>();
            playedList = new List<MMHistory.MusicRow>();
        }

		private String formatTime(int milliseconds)
		{
			seconds = (milliseconds / 1000);
			minutes = seconds / 60;
			return String.Format("{00:00}", (float) minutes) + ":" + String.Format("{00:00}", (float) (seconds % 60));
		}


        private void EnabledDisabledAllOperation(bool flag)
        {
            this.loadButton.Enabled = flag;
            this.browseButton.Enabled = flag;
            this.contextMenuStrip1.Enabled = flag;
            this.contextMenuStrip2.Enabled = flag;
            this.menuStrip1.Enabled = flag;
            this.locationComboBox.Enabled = flag;
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dropFileList = Clipboard.GetFileDropList();
            if (dropFileList.Count == 0)
                return;
            EnabledDisabledAllOperation(false);
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = dropFileList.Count;
            Thread th = new Thread(new ThreadStart(PasteFromClipBoard));
            th.IsBackground = true;
            th.Start();
        }
        string RemoveInvalidChars(string fileName)
        {
            char[] InvalidPathChars = Path.GetInvalidPathChars();
            for (int i = 0; i < InvalidPathChars.Length; i++)
            {
                fileName.Replace(InvalidPathChars[i].ToString(), "_");
            }
            return fileName;
        }
        private void MusicManagerHistoryChanged()
        {
            playedList.Clear();
            preventEvent = true;
            GenreList = MusicManagerHistory.Music.GetGenreList();
            lbGenre.DataSource = GenreList;
            albumList = MusicManagerHistory.Music.GetAlbumList();
            lbAlbum.DataSource = albumList;
            artistList = MusicManagerHistory.Music.GetArtistList();
            lbArtist.DataSource = artistList;
            //this.Invoke(new InvokeMethodDelegate(StartReloadTimer));
            StartReloadTimer();
            preventEvent = false;
        }
        private void PasteFromClipBoard()
        {
            this.statusStrip.Invoke(new StatusChangedDelegate(StatusChanged), new object[] { "Please wait..." });
            foreach (string file in dropFileList)
            {
                FileInfo fi = new FileInfo(file);
                if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
                {
                    continue;
                }
                if (fi != null && fi.Extension.ToLower() == ".mp3")
                {
                    MP3File mp3File;
                    try
                    {
                        mp3File = ShellID3TagReader.ReadID3Tags(fi.FullName);
                    }
                    catch
                    {
                        continue;
                    }
                    this.Invoke(new AddFileDelegate(AddFile), new object[] { file, mp3File, "Queued" });
                }
                else if (fi != null && fi.Extension.ToLower() == ".wma")
                {
                    MP3File mp3File;
                    try
                    {
                        mp3File = ShellID3TagReader.ReadWMATags(fi.FullName);
                    }
                    catch
                    {
                        continue;
                    }
                    this.Invoke(new AddFileDelegate(AddFile), new object[] { file, mp3File, "Queued" });
                }
                else if (fi != null && fi.Extension.ToLower() == ".wpl")
                {
                    ReadPlaylist playList = new ReadPlaylist();
                    playList.playListPath = fi.FullName;
                    for (int i = 0; i < playList.PlayList.Count; i++)
                    {
                        string playListFile = playList.PlayList[i].ToString();
                        if (playListFile.IndexOf("..") == 0)
                        {
                            playListFile = fi.DirectoryName + "\\" + playListFile;
                        }
                        FileInfo fi2 = new FileInfo(playListFile);
                        if ((fi2.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
                        {
                            continue;
                        }
                        if (fi2 != null && fi2.Extension.ToLower() == ".mp3")
                        {
                            MP3File mp3File = null;
                            try
                            {
                                mp3File = ShellID3TagReader.ReadID3Tags(fi2.FullName);
                            }
                            catch
                            {
                                continue;
                            }
                            this.Invoke(new AddFileDelegate(AddFile), new object[] { fi2.FullName, mp3File, "Queued" });                            
                        }
                        else if (fi2 != null && fi2.Extension.ToLower() == ".wma")
                        {
                            MP3File mp3File = null;
                            try
                            {
                                mp3File = ShellID3TagReader.ReadWMATags(fi2.FullName);
                            }
                            catch
                            {
                                continue;
                            }
                            this.Invoke(new AddFileDelegate(AddFile), new object[] { fi2.FullName, mp3File, "Queued" });
                        }
                    }
                }
            }
            this.Invoke(new InvokeMethodDelegate(MusicManagerHistoryChanged));
            Thread.Sleep(500);
            int currentIndex = 0;
            foreach (string fileName in mp3FileHash.Keys)
            {
                this.statusStrip.Invoke(new StatusChangedDelegate(StatusChanged), new object[] { string.Format("Copying... {0}/{1}",currentIndex,mp3FileHash.Count) });
                this.Invoke(new UpdateFileStatusDelegate(UpdateFileStatus), new object[] { fileName,fileName, "Processing" });
                MMHistory.MusicRow dr = (MMHistory.MusicRow)mp3FileHash[fileName];
                FileInfo fi = new FileInfo(fileName);
                
                string artist = "";
                if (dr.Artist == "")
                    artist = "Unknown Artist";
                else
                    artist = dr.Artist;
                artist = RemoveInvalidChars(artist);

                string album = "";
                if (dr.Album == "")
                    album = "Unknown Album";
                else
                    album = dr.Album;
                album = RemoveInvalidChars(album);
                string dest = ToolsManager.GetManager().LastLocation + "\\" + ToolsManager.GetManager().FileFormat;
                dest = dest.Replace("{Album}", album);
                dest = dest.Replace("{Artist}", artist);
                dest = dest.Replace("{Title}", dr.Title + fi.Extension);
                //dest = dest.Replace("{Extention}", "mp3");
                dest = dest.Replace("{Genre}", dr.Genre);
                dest = dest.Replace("{FileName}", Path.GetFileName(fileName));
                if (Directory.Exists(Path.GetDirectoryName(dest)) == false)
                    Directory.CreateDirectory(Path.GetDirectoryName(dest));
                try
                {
                    if (File.Exists(dest) == false)
                    {
                        this.Invoke(new UpdateFileStatusDelegate(UpdateFileStatus), new object[] { fileName, dest, "Copying" });
                        File.Copy(fileName, dest, false);
                        this.Invoke(new UpdateFileStatusDelegate(UpdateFileStatus), new object[] { fileName, dest, "" });
                    }
                    else
                    {
                        //FileInfo fi = new FileInfo(fileName);
                        if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
                        {
                            continue;
                        }
                        totalFileSize-=fi.Length;
                        this.Invoke(new UpdateFileStatusDelegate(UpdateFileStatus), new object[] { fileName, dest, "Skiped" });
                    }

                }
                catch
                {
                    //FileInfo fi = new FileInfo(fileName);
                    if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
                    {
                        continue;
                    }
                    totalFileSize -= fi.Length;
                    this.Invoke(new UpdateFileStatusDelegate(UpdateFileStatus), new object[] { fileName,dest, "Failed" });
                }
                this.statusStrip.Invoke(new FileProcessDelegate(FileProcessUpdated), new object[] {mp3FileHash.Count, ++currentIndex });
            }
            this.Invoke(new InvokeMethodDelegate(MusicManagerHistoryChanged));
            this.statusStrip.Invoke(new StatusChangedDelegate(StatusChanged), new object[] { "Ready" });
        }
        private string GetFileSize(long length)
        {
            string fileSize=length+" Bytes";
            double dlength = (double)length;
            if (dlength >= 1024)
            {
                dlength = dlength / 1024;
                fileSize = string.Format("{0:#,0.##} KB", dlength);                                
            }
            if (dlength >= 1024)
            {
                dlength = dlength / 1024;
                fileSize = string.Format("{0:#,0.##} MB", dlength);
            }
            if (dlength >= 1024)
            {
                dlength = dlength / 1024;
                fileSize = string.Format("{0:#,0.##} GB", dlength);
            }
            return fileSize;
        }        

        private void AddFile(string FileName, MP3File mp3File, string Status)
        {
            if (mp3FileHash.ContainsKey(FileName) == false)
            {
                FileInfo fi = new FileInfo(FileName);
                if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
                {
                    return;
                }
                totalFileSize += fi.Length;
                MMHistory.MusicRow dr = null;
                string fileName = mp3File.FileFullPath;
                if (fileName.Length > Directory.GetCurrentDirectory().Length)
                {
                    string currentDir = Directory.GetCurrentDirectory();
                    fileName = fileName.Substring(currentDir.Length);
                    if (fileName.IndexOf("\\") == 0)
                        fileName = fileName.Substring(1);
                }
                dr = MusicManagerHistory.Music[fileName];
                bool isNewFile = true;
                if (dr != null)
                {
                    isNewFile = false;
                }
                if(isNewFile)
                    dr = MusicManagerHistory.Music.NewMusicRow();
                dr.Album = mp3File.AlbumName;
                dr.Artist = mp3File.ArtistName;
                dr.Filename = mp3File.FileName;
                dr.FullFilename = fileName;
                dr.Genre = mp3File.Genre;
                if (isNewFile)
                {
                    dr.PlayCount = 1;                    
                }
                dr.Size = (int)fi.Length;
                dr.Time = mp3File.Time;
                dr.Title = mp3File.SongTitle;
                dr.Track = mp3File.TrackNumber;
                dr.Status = Status;
                dr.MMProbability = 1;
                dr.CumulativeProbability = 1;
                if(isNewFile)
                    MusicManagerHistory.Music.AddMusicRow(dr);
                mp3FileHash.Add(FileName, dr);
                this.tssSongsCount.Text = MusicManagerHistory.Music.Rows.Count + " Songs";
                this.tssSize.Text = GetFileSize(totalFileSize);
            }
        }
        
        private void UpdateFileStatus(string Key, string fileName,string Status)
        {
            MMHistory.MusicRow dr = (MMHistory.MusicRow)mp3FileHash[Key];
            if (fileName.Length > Directory.GetCurrentDirectory().Length)
            {
                dr.FullFilename = fileName.Substring(Directory.GetCurrentDirectory().Length);
                if (dr.FullFilename.IndexOf("\\") == 0)
                    dr.FullFilename = dr.FullFilename.Substring(1);
            }
            dr.Status = Status;            
            DisplayFreeSpace();
        }
        private void StatusChanged(string Message)
        {
            if (Message == "Ready")
            {
                this.toolStripProgressBar1.Visible = false;
                mp3FileHash.Clear();
                SaveMMHistory();
                EnabledDisabledAllOperation(true);
            }
            else if (Message == "Please wait...")
                this.toolStripProgressBar1.Visible = true;

            this.toolStripStatusLabel1.Text = Message;
        }
        private void FileProcessUpdated(int MaxValue,int currentIndex)
        {
            this.toolStripProgressBar1.Maximum = MaxValue;
            if(this.toolStripProgressBar1.Maximum>currentIndex)
                this.toolStripProgressBar1.Value = currentIndex;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog.SelectedPath = ToolsManager.GetManager().LastLocation;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (locationComboBox.Text != folderBrowserDialog.SelectedPath)
                    {                        
                        locationComboBox.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public MMHistory MusicManagerHistory
        {
            get
            {
                if (mmHistory == null)
                    mmHistory = new MMHistory();
                return mmHistory;
            }
            set
            {
                mmHistory = value;
            }
        }
        private void DisplayMMHistory()
        {
            totalFileSize = 0;
            lbGenre.Items.Clear();
            lbAlbum.Items.Clear();
            lbArtist.Items.Clear();
            if (File.Exists(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh"))
            {
                MusicManagerHistory = new MMHistory();
                try
                {
                    LoadMMHistory();
                    MusicManagerHistory.ResetStatus();
                    totalPlayCount = MusicManagerHistory.GetTotalPlayCount();
                    totalFileSize = MusicManagerHistory.GetTotalFileSize();
                }
                catch
                {
                    File.Delete(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
                    return;
                }
                GenreList = MusicManagerHistory.Music.GetGenreList();
                lbGenre.DataSource = GenreList;
                albumList = MusicManagerHistory.Music.GetAlbumList();
                lbAlbum.DataSource = albumList;
                artistList = MusicManagerHistory.Music.GetArtistList();
                lbArtist.DataSource = artistList;
                //this.Invoke(new InvokeMethodDelegate(StartReloadTimer));
                StartReloadTimer();
            }
        }

        private void LoadMMHistory()
        {
            try
            {
                //MusicManagerHistory = (MMHistory) SerializeHelper.GetHelper().ReadFile(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
                MusicManagerHistory.ReadXml(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
            }
            catch
            {
                MessageBox.Show("Failed to load music manager history", "Fail to load",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (File.Exists(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh"))
                    File.Delete(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
                MusicManagerHistory = null;
            }
            //MusicManagerHistory.ReadXml(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
            //MusicManagerHistory=Ser
        }
        private void StartReloadTimer()
        {
            //tmrReload.Enabled=true;
            ReloadListView();
            //Thread th = new Thread(new ThreadStart(ReloadListView));
            //th.IsBackground = true;
            //th.Start();
        }
        private void DisplayFreeSpace()
        {
            string root = Directory.GetDirectoryRoot(ToolsManager.GetManager().LastLocation);
            DriveInfo di = new DriveInfo(root);
            tssFree.Text = GetFileSize(di.TotalFreeSpace)+ " Free";
        }
        private void frmMusicManager_Load(object sender, EventArgs e)
        {
            string[] argv = Environment.GetCommandLineArgs();
            
            LoadConfiguration();
            if (argv.Length > 0)
            {
                Open(argv[0]);
            }
            else
            {
                mmConfiguration.Locations.AddLocation(ToolsManager.GetManager().LastLocation);
                LoadLocationBox();
                this.locationComboBox.Text = ToolsManager.GetManager().LastLocation;
                Directory.SetCurrentDirectory(ToolsManager.GetManager().LastLocation);
                DisplayFreeSpace();
                DisplayMMHistory();
            }
        }
        const int WM_COPYDATA = 0x004A;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                string fileToOpen = CopyDataHelper.GetMsgString(m.LParam);
                if (fileToOpen != "" && fileToOpen != null)
                {
                    Open(fileToOpen);
                }
            }
            base.WndProc(ref m);
        }
        private void Open(string fileName)
        {            
            FileInfo fi = new FileInfo(fileName);
            if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
            {
                return;
            }
            if (fi.Extension.ToLower() == ".mmh")
            {
                if (Directory.Exists(fi.DirectoryName))
                {
                    ToolsManager.GetManager().LastLocation = fi.DirectoryName;
                    if (File.Exists(fi.FullName) && fi.Name != "MMHistory.mmh")
                    {
                        File.Copy(fi.FullName, ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
                    }
                }
            }
            //preventEvent = true;
            this.locationComboBox.Text = ToolsManager.GetManager().LastLocation;
            //////preventEvent = false;            
            Directory.SetCurrentDirectory(ToolsManager.GetManager().LastLocation);
            DisplayFreeSpace();
            DisplayMMHistory();
        }
        private void LoadExistingFiles(string folder)
        {
            string []files=Directory.GetFiles(folder);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed 
                    | FileAttributes.Device
                    | FileAttributes.Directory
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0 || (fi.Extension.ToUpper() != ".MP3" && fi.Extension.ToUpper() != ".WMA"))
                {
                    continue;
                }
                
                MP3File mp3File;
                try
                {
                    mp3File = ShellID3TagReader.ReadID3Tags(fi.FullName);
				}
                catch
                {
                    continue;
                }
                this.Invoke(new AddFileDelegate(AddFile), new object[] { file, mp3File, "" });
            }
            string[] folders = Directory.GetDirectories(folder);
            foreach (string subfolder in folders)
            {
                FileInfo fi = new FileInfo(subfolder);
                if ((fi.Attributes & (FileAttributes.System
                    | FileAttributes.Compressed
                    | FileAttributes.Device
                    | FileAttributes.Encrypted
                    | FileAttributes.Offline
                    )) != 0)
                {
                    continue;
                }
                LoadExistingFiles(subfolder);
            }
            this.tssSongsCount.Text = MusicManagerHistory.Music.Rows.Count + " Songs";
            this.tssSize.Text = GetFileSize(totalFileSize);
            
        }
        private void LoadExistingFiles()
        {
            if (MusicManagerHistory == null)
                MusicManagerHistory = new MMHistory();            
            totalFileSize = 0;
            LoadExistingFiles(ToolsManager.GetManager().LastLocation);
            preventEvent = true;
            GenreList = MusicManagerHistory.Music.GetGenreList();
            lbGenre.DataSource = GenreList;
            albumList = MusicManagerHistory.Music.GetAlbumList();
            lbAlbum.DataSource = albumList;
            artistList = MusicManagerHistory.Music.GetArtistList();
            lbArtist.DataSource = artistList;
            preventEvent = false;
            StartReloadTimer();
            ////mp3FileHash.Clear();
            ////this.Invoke(new InvokeMethodDelegate(MusicListChanged));
            this.statusStrip.Invoke(new StatusChangedDelegate(StatusChanged), new object[] { "Ready" });            
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            EnabledDisabledAllOperation(false);
            this.stopToolStripMenuItem_Click(sender, e);
            this.statusStrip.Invoke(new StatusChangedDelegate(StatusChanged), new object[] { "Loading..." });
            dgMusic.DataSource = null;
            if (musicList != null)
            {
                musicList.Clear();
                playedList.Clear();
            }
            //dgMusic.Rows.Clear();
            Thread th = new Thread(new ThreadStart(LoadExistingFiles));
            th.IsBackground = true;
            th.Start();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMusic.SelectedRows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dgMusic.SelectedRows.Count; i++)
            {
                if (dgMusic.SelectedRows[i].DataBoundItem == drPlaying)
                {
                    return;
                }
            }
            if (MessageBox.Show("Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<MMHistory.MusicRow> selectedMusic = new List<MMHistory.MusicRow>();
                for (int i = 0; i < dgMusic.SelectedRows.Count; i++)
                {
                    MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.SelectedRows[i].DataBoundItem;
                    selectedMusic.Add(dr);
                }                
                for (int i = selectedMusic.Count - 1; i >= 0; i--)
                {
                    MMHistory.MusicRow dr = selectedMusic[i];
                    if (dr.Status == "PLAYING")
                    {
                        continue;
                    }
                    if (File.Exists(dr.FullFilename))
                    {
                        FileInfo fi = new FileInfo(dr.FullFilename);
                        if ((fi.Attributes & (FileAttributes.System
                            | FileAttributes.Compressed
                            | FileAttributes.Device
                            | FileAttributes.Directory
                            | FileAttributes.Encrypted
                            | FileAttributes.Offline
                            )) != 0)
                        {
                            continue;
                        }
                        totalFileSize -= fi.Length;                        
                        try
                        {
                            File.Delete(dr.FullFilename);
                        }
                        catch
                        {
                        }
                        
                        if (fi.Directory.GetFiles().Length == 0)
                        {
                            DirectoryInfo parent= Directory.GetParent(fi.DirectoryName);
                            try
                            {
                                Directory.Delete(fi.DirectoryName);
                            }
                            catch
                            {
                            }
                            
                            if (parent.GetFiles().Length == 0 && parent.GetDirectories().Length == 0)
                            {
                                try
                                {
                                    parent.Delete();
                                }
                                catch
                                {
                                }
                            }
                        }
                        
                    }
                    musicList.Remove(dr);
                    if (playedList.Contains(dr))
                        playedList.Remove(dr);
                    dr.Delete();
                }
                DisplayFreeSpace();
                dgMusic.ClearSelection();
                MusicManagerHistoryChanged();
                this.tssSongsCount.Text = musicList.Count + " Songs";
                this.tssSize.Text = GetFileSize(totalFileSize);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            EnabledDisabledMenu();
        }
        
        private void EnabledDisabledMenu()
        {
            randomToolStripMenuItem.Checked = shaffleToolStripMenuItem.Checked = ToolsManager.GetManager().IsRandom;
            pasteToolStripMenuItem2.Enabled = pasteToolStripMenuItem1.Enabled = pasteToolStripMenuItem.Enabled = Clipboard.GetFileDropList().Count > 0;
            deleteToolStripMenuItem2.Enabled = deleteToolStripMenuItem1.Enabled = deleteToolStripMenuItem.Enabled = dgMusic.SelectedRows.Count > 0;
            pauseToolStripMenuItem2.Enabled = pauseToolStripMenuItem.Enabled = pauseToolStripMenuItem1.Enabled = false;
            //if(drPlaying!=null)
                //deleteToolStripMenuItem2.Enabled = deleteToolStripMenuItem1.Enabled = deleteToolStripMenuItem.Enabled = false;
            for (int i = 0; i < dgMusic.SelectedRows.Count; i++)
            {
                if (dgMusic.SelectedRows[i].DataBoundItem==drPlaying)
                {
                    deleteToolStripMenuItem2.Enabled = deleteToolStripMenuItem1.Enabled = deleteToolStripMenuItem.Enabled = false;
                }
            }
            copyToolStripMenuItem2.Enabled = copyToolStripMenuItem1.Enabled = copyToolStripMenuItem.Enabled = dgMusic.SelectedRows.Count > 0;
            playToolStripMenuItem2.Enabled = playToolStripMenuItem1.Enabled = playToolStripMenuItem.Enabled = dgMusic.SelectedRows.Count == 1 || (dgMusic.Rows.Count > 0 && ToolsManager.GetManager().IsRandom);

            clearToolStripMenuItem1.Enabled = clearToolStripMenuItem.Enabled = dgMusic.Rows.Count > 0;
            nextToolStripMenuItem1.Enabled = nextToolStripMenuItem.Enabled = dgMusic.Rows.Count > 0;
            previousToolStripMenuItem1.Enabled = previousToolStripMenuItem.Enabled = dgMusic.Rows.Count > 0 && shaffleToolStripMenuItem.Checked == false;
            if (drPlaying != null)
            {
                pauseToolStripMenuItem2.Enabled = pauseToolStripMenuItem.Enabled = pauseToolStripMenuItem1.Enabled = true;
                stopToolStripMenuItem2.Enabled = stopToolStripMenuItem1.Enabled = stopToolStripMenuItem.Enabled = true;
            }
            else
            {
                pauseToolStripMenuItem2.Enabled = pauseToolStripMenuItem.Enabled = pauseToolStripMenuItem1.Enabled = false;
                stopToolStripMenuItem2.Enabled = stopToolStripMenuItem1.Enabled = stopToolStripMenuItem.Enabled = false;
            }
        }
        
        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (dropFileList != null)
                dropFileList.Clear();
            else
                dropFileList = new StringCollection();

            dropFileList.AddRange(files);            
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = dropFileList.Count;
            Thread th = new Thread(new ThreadStart(PasteFromClipBoard));
            th.IsBackground = true;
            th.Start();
        }

        private void listViewFiles_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listViewFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string[] files=new string[dgMusic.SelectedRows.Count];
            for (int i = 0; i < dgMusic.SelectedRows.Count; i++)
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.SelectedRows[i].DataBoundItem;
                files[i] = dr.FullFilename;
            }
            if (files != null || files.Length>0)
            {
                DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] files = new string[dgMusic.SelectedRows.Count];
            for (int i = 0; i < dgMusic.SelectedRows.Count; i++)
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.SelectedRows[i].DataBoundItem;
                files[i] = ToolsManager.GetManager().LastLocation + "\\" + dr.FullFilename;
            }
            if (files != null || files.Length > 0)
            {
                StringCollection fileList = new StringCollection();
                fileList.AddRange(files);
                Clipboard.SetFileDropList(fileList);
            }
        }
        
        private void IncreasePlayCount(MMHistory.MusicRow musicRow)
        {
            if (musicRow == null )
                return;
            musicRow.PlayCount++;
            SaveMMHistory();
        }
        private void SaveMMHistory()
        {
            if (MusicManagerHistory != null)
                //SerializeHelper.GetHelper().SaveFile(MusicManagerHistory, ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
                MusicManagerHistory.WriteXml(ToolsManager.GetManager().LastLocation + "\\MMHistory.mmh");
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drPlaying != null&&Player.GetPlayer().IsPaused())
            {
                Player.GetPlayer().Play(false);
				playButton.BackgroundImage = pause;
				drPlaying.Status = Player.GetPlayer().Status().ToUpper();
                return;
            }
            if (dgMusic.SelectedRows.Count == 1)
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.SelectedRows[0].DataBoundItem;
                IncreasePlayCount(dr);
                Play(musicList.IndexOf(dr));
                playedList.Clear();
            }
            else if (dgMusic.Rows.Count > 0 && ToolsManager.GetManager().IsRandom)
            {                
                RandomPlay();
            }
        }
        private void CalculateNextProbability()
        {
            totalPlayCount = 0;
            totalFileSize = 0;
            for (int i = 0; i < musicList.Count; i++)
            {
                MMHistory.MusicRow dr = musicList[i];                
                dr.MMProbability = dr.PlayCount;
                if (drPlaying != null)
                {
                    if (dr.Genre != "" && dr.Genre == drPlaying.Genre)
                    {
                        dr.MMProbability += ToolsManager.GetManager().GenrePriority + MusicManagerHistory.Music.GetAveragePlayCountByGenre(dr.Genre);
                    }
                    if (dr.Album != "" && dr.Album == drPlaying.Album)
                    {
                        dr.MMProbability += ToolsManager.GetManager().AlbumPriority + MusicManagerHistory.Music.GetAveragePlayCountByAlbum(dr.Album);
                    }
                    if (dr.Artist != "" && dr.Artist == drPlaying.Artist)
                    {
                        dr.MMProbability += ToolsManager.GetManager().ArtistPriority + MusicManagerHistory.Music.GetAveragePlayCountByArtist(dr.Artist);
                    }
                }
                if (ToolsManager.GetManager().AllowRepeat == false && playedList.Contains(dr))
                {
                    dr.MMProbability = 0;
                }
                else
                {
                    if (ToolsManager.GetManager().UseRepeatPriority && playedList.Contains(dr))
                        dr.MMProbability = dr.MMProbability * ((double)ToolsManager.GetManager().RepeatPriority / (double)20);                    
                }
                totalPlayCount += dr.MMProbability;
                dr.CumulativeProbability = totalPlayCount;
                totalFileSize += dr.Size;
            }            
        }
        private void Play(int index)
        {
            if (index >= musicList.Count)
                return;
            if (drPlaying != null)
                drPlaying.Status = "";
            drPlaying = musicList[index];
            if (!playedList.Contains(drPlaying))
            {                
                if (playedList.Count + 1== musicList.Count)
                {
                    playedList.Clear();
                }
                playedList.Add(drPlaying);
            }
            Player.GetPlayer().Play(drPlaying.FullFilename);
            CalculateNextProbability();
            dgMusic.Refresh();
            isPlaying = true;
            tmrPlay.Enabled = isPlaying;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.GetPlayer().Close();
            if(drPlaying!=null)
                drPlaying.Status = "";
            dgMusic.Refresh();
            drPlaying = null;
            isPlaying = false;
            tmrPlay.Enabled = isPlaying;
			trackBar.Value = 0;
			currentTime.Text = "00:00";
        }

        private void tmrPlay_Tick(object sender, EventArgs e)
        {
            tmrPlay.Enabled = false;
            if (drPlaying != null)
            {
                string status = Player.GetPlayer().Status().ToUpper();
				if (status == "STOPPED" || status == "")
				{
					if (drPlaying != null)
					{
						drPlaying.Status = "";
						dgMusic.Refresh();
					}
					if (ToolsManager.GetManager().IsRandom == true)
					{
						IncreasePlayCount(drPlaying);
						RandomPlay();
						return;
					}
					else if (drPlaying != null && musicList.Count > musicList.IndexOf(drPlaying) + 1)
					{
						IncreasePlayCount(drPlaying);
						Play(musicList.IndexOf(drPlaying));
						return;
					}
					else
					{
						IncreasePlayCount(drPlaying);
						return;
					}
				}
				else if (status != drPlaying.Status)
				{
					if (drPlaying.Status != status)
					{
						drPlaying.Status = status;
						dgMusic.Refresh();
					}
				}
				else if (status == "PLAYING" && drPlaying != null)
				{
					Player player = Player.GetPlayer();
					currentTime.Text = formatTime(player.getCurrentPosition(drPlaying.FullFilename));
					totalTime.Text = formatTime(player.getSongLength(drPlaying.FullFilename));
					trackBar.Maximum = player.getSongLength(drPlaying.FullFilename);
					trackBar.Value = player.getCurrentPosition(drPlaying.FullFilename);
					currentArtist.Text = drPlaying.Artist;
					currentSong.Text = drPlaying.Title;
					progressBar.Maximum = player.getSongLength(drPlaying.FullFilename);
					progressBar.Value = player.getCurrentPosition(drPlaying.FullFilename);
				}
                tmrPlay.Enabled = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = previousWindowState;
            //if (this.Visible == false)
            //    this.Show();
            //this.Show();
        }
        //private bool isExit = false;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //isExit = true;
            SaveMMHistory();
            this.Close();
        }

        private void frmMusicManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isExit == false)
            //{
            //    e.Cancel = true;
            //    this.Hide();
            //}
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {           
            this.Show();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string oldGroup = ToolsManager.GetManager().GroupBy;
            frmOption frm = new frmOption();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CalculateNextProbability();
                dgMusic.Refresh();
            }
        }
        
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopToolStripMenuItem_Click(sender, e);
            if (MusicManagerHistory != null)
            {
                SaveMMHistory();
                MusicManagerHistory = null;
            }
            preventEvent = true;
            lbAlbum.DataSource = null;
            lbArtist.DataSource = null;
            lbGenre.DataSource = null;
            preventEvent = false;
            stopToolStripMenuItem_Click(sender, e);
            musicList = MusicManagerHistory.Music.GetMusic();
            playedList.Clear();
            dgMusic.DataSource = musicList;
            FillupMusicGrid();
            //dgMusic.DataSource = null;
            //if(musicList!=null)
            //    musicList.Clear();
            ////dgMusic.Rows.Clear();
            //dgMusic.Refresh();
            //musicList = null;
            totalPlayCount = 0;
            mp3FileHash.Clear();
            this.tssSongsCount.Text = "0 Songs";
            totalFileSize = 0;
            this.tssSize.Text = GetFileSize(totalFileSize);
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.GetPlayer().Pause();
			playButton.BackgroundImage = play;
		}

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnabledDisabledMenu();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnabledDisabledMenu();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToolsManager.GetManager().IsRandom == true)
                RandomPlay();
            else if (musicList != null && musicList.Count > 0)
            {
                int current = 0;
                if (drPlaying != null)
                {
                    current = musicList.IndexOf(drPlaying);
                }
                if (current < musicList.Count - 1)
                    Play(current + 1);
                else
                    Play(0);
            }
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToolsManager.GetManager().IsRandom == true)
                RandomPlay();
            else if (musicList != null && musicList.Count > 0)
            {
                int current = 0;
                if (drPlaying != null)
                {
                    current = musicList.IndexOf(drPlaying);
                }
                if (current > 0)
                    Play(current - 1);
                else
                    Play(musicList.Count - 1);
            }
        }

        private void RandomPlay()
        {

            double dRan = (double)(randomNumberGenreator.Next() % (int)(totalPlayCount+1));
            int index = 0;
            for (int i = 0; i < musicList.Count; i++)
            {
                MMHistory.MusicRow dr = musicList[i];
                if (i == 0 && dRan < dr.CumulativeProbability)
                    index = i;
                else if(i > 0&&dRan>=musicList[i-1].CumulativeProbability&&dRan<dr.CumulativeProbability)                
                    index = i;
                if (dr.CumulativeProbability > dRan)
                    break;
            }            
            Play(index);
            
            dgMusic.FirstDisplayedScrollingRowIndex = index;
            dgMusic.Refresh();
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            ToolsManager.GetManager().IsRandom = !ToolsManager.GetManager().IsRandom;
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Music Files(*.mp3,*.wma) |*.mp3;*.wma";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (dropFileList != null)
                    dropFileList.Clear();
                else
                    dropFileList = new StringCollection();

                dropFileList.AddRange(ofd.FileNames);
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = dropFileList.Count;
                Thread th = new Thread(new ThreadStart(PasteFromClipBoard));
                th.IsBackground = true;
                th.Start();
            }
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = ToolsManager.GetManager().LastLocation;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (dropFileList != null)
                        dropFileList.Clear();
                    else
                        dropFileList = new StringCollection();

                    dropFileList.AddRange(Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.mp3;*.wma"));
                    toolStripProgressBar1.Minimum = 0;
                    toolStripProgressBar1.Maximum = dropFileList.Count;
                    Thread th = new Thread(new ThreadStart(PasteFromClipBoard));
                    th.IsBackground = true;
                    th.Start();
                }                
            }
            catch { }
        }

        private void addFolderRecursivelyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = ToolsManager.GetManager().LastLocation;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (dropFileList != null)
                        dropFileList.Clear();
                    else
                        dropFileList = new StringCollection();

                    AddFolderRecursively(folderBrowserDialog.SelectedPath);
                    toolStripProgressBar1.Minimum = 0;
                    toolStripProgressBar1.Maximum = dropFileList.Count;
                    Thread th = new Thread(new ThreadStart(PasteFromClipBoard));
                    th.IsBackground = true;
                    th.Start();
                }
            }
            catch { }
        }
        private void AddFolderRecursively(string folder)
        {
            dropFileList.AddRange(Directory.GetFiles(folder, "*.mp3;*.wma"));
            string[] folders = Directory.GetDirectories(folder);
            foreach (string subfolder in folders)
            {
                AddFolderRecursively(subfolder);
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            EnabledDisabledMenu();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }
        private void GetSelectedGenreList(ArrayList GenreList)
        {
            if (lbGenre.Items.Count>0&&lbGenre.SelectedItems.Contains(lbGenre.Items[0]))
            {
                for (int i = 1; i < lbGenre.Items.Count; i++)
                {
                    GenreList.Add(lbGenre.Items[i].ToString());
                }
            }
            else
            {
                for (int i = 0; i < lbGenre.SelectedItems.Count; i++)
                {
                    GenreList.Add(lbGenre.SelectedItems[i].ToString());
                }
            }
        }
        private void GetSelectedAlbumList(ArrayList albumList)
        {
            if (lbAlbum.Items.Count > 0 && lbAlbum.SelectedItems.Contains(lbAlbum.Items[0]))
            {
                for (int i = 1; i < lbAlbum.Items.Count; i++)
                {
                    albumList.Add(lbAlbum.Items[i].ToString());
                }
            }
            else
            {
                for (int i = 0; i < lbAlbum.SelectedItems.Count; i++)
                {
                    albumList.Add(lbAlbum.SelectedItems[i].ToString());
                }
            }
        }
        private void GetSelectedArtistList(ArrayList artistList)
        {
            if (lbArtist.Items.Count > 0 && lbArtist.SelectedItems.Contains(lbArtist.Items[0]))
            {
                for (int i = 1; i < lbArtist.Items.Count; i++)
                {
                    artistList.Add(lbArtist.Items[i].ToString());
                }
            }
            else
            {
                for (int i = 0; i < lbArtist.SelectedItems.Count; i++)
                {
                    artistList.Add(lbArtist.SelectedItems[i].ToString());
                }
            }
        }
        private void ReloadListView()
        {
            //while (preventEvent) ;
            ArrayList GenreList=new ArrayList();
            lbGenre.Invoke(new GetSelectedListDelegate(GetSelectedGenreList), new object[] {GenreList });
            ArrayList artistList = new ArrayList();
            lbArtist.Invoke(new GetSelectedListDelegate(GetSelectedArtistList), new object[] { artistList });
            ArrayList albumList = new ArrayList();
            lbAlbum.Invoke(new GetSelectedListDelegate(GetSelectedAlbumList), new object[] { albumList });
            musicList = MusicManagerHistory.Music.GetMusic(GenreList, artistList, albumList);
            playedList.Clear();
            totalFileSize = 0;
            totalPlayCount = 0;
            //for (int i = 0; i < musicList.Count; i++)
            //{
            //    MMHistory.MusicRow dr = musicList[i];
            //    if (dr == null)
            //    {
            //        continue;
            //    }
            //    int tempPlaycount = 0;
            //    tempPlaycount += dr.PlayCount;
            //    if (drPlaying != null)
            //    {
            //        if (dr.Genre != "" && dr.Genre == drPlaying.Genre)
            //        {
            //            tempPlaycount += ToolsManager.GetManager().GenrePriority + MusicManagerHistory.Music.GetAveragePlayCountByGenre(dr.Genre);
            //        }
            //        if (dr.Album != "" && dr.Album == drPlaying.Album)
            //        {
            //            tempPlaycount += ToolsManager.GetManager().AlbumPriority + MusicManagerHistory.Music.GetAveragePlayCountByAlbum(dr.Album);
            //        }
            //        if (dr.Artist != "" && dr.Artist == drPlaying.Artist)
            //        {
            //            tempPlaycount += ToolsManager.GetManager().ArtistPriority + MusicManagerHistory.Music.GetAveragePlayCountByArtist(dr.Artist);
            //        }
            //    }
            //    if (ToolsManager.GetManager().AllowRepeat == false && playedList.Contains(dr))
            //    {
            //        dr.CumulativeProbability = 0;
            //    }
            //    else
            //    {
            //        totalPlayCount += tempPlaycount;
            //        dr.CumulativeProbability = totalPlayCount;
            //    }
            //    totalFileSize += dr.Size;
            //}
            CalculateNextProbability();
            this.Invoke(new InvokeMethodDelegate(MusicListChanged));
            
        }
        private void FillupMusicGrid()
        {
            
            if (dgMusic.DataSource != musicList)
            {                                                
                if (dgMusic.AutoGenerateColumns)
                {
                    dgMusic.Columns.Clear();
                    dgMusic.DataSource = musicList;
                    dgMusic.Columns["Filename"].HeaderText = "File Name";
                    dgMusic.Columns["Filename"].Width = 160;
                    dgMusic.Columns["Filename"].DisplayIndex = 0;
                    dgMusic.Columns["Title"].DisplayIndex = 1;
                    dgMusic.Columns["Title"].Width = 160;
                    dgMusic.Columns["Artist"].Width = 120;
                    dgMusic.Columns["Artist"].DisplayIndex = 2;
                    dgMusic.Columns["Album"].DisplayIndex = 3;
                    dgMusic.Columns["Album"].Width = 100;
                    dgMusic.Columns["Size"].DisplayIndex = 4;
                    dgMusic.Columns["Size"].Width = 90;
                    dgMusic.Columns["Genre"].DisplayIndex = 5;
                    dgMusic.Columns["Genre"].Width = 100;
                    dgMusic.Columns["Time"].DisplayIndex = 6;
                    dgMusic.Columns["Time"].Width = 90;
                    dgMusic.Columns["MMProbability"].HeaderText = "Probability";
                    dgMusic.Columns["MMProbability"].DisplayIndex = 7;
                    dgMusic.Columns["MMProbability"].Width = 100;
                    dgMusic.Columns["CumulativeProbability"].HeaderText = "Cumulative Probability";
                    dgMusic.Columns["CumulativeProbability"].DisplayIndex = 8;
                    dgMusic.Columns["CumulativeProbability"].Width = 120;
                    dgMusic.Columns["Status"].DisplayIndex = 9;
                    dgMusic.Columns["Status"].Width = 90;

                    dgMusic.Columns["Track"].Visible = false;
                    dgMusic.Columns["RowError"].Visible = false;
                    dgMusic.Columns["FullFilename"].Visible = false;
                    dgMusic.Columns["RowState"].Visible = false;
                    dgMusic.Columns["ID"].Visible = false;
                    dgMusic.Columns["Table"].Visible = false;
                    dgMusic.Columns["PlayCount"].Visible = false;
                    dgMusic.Columns["HasErrors"].Visible = false;
                    ResizeColumn();
                    dgMusic.AutoGenerateColumns = false;
                }
                else
                    dgMusic.DataSource = musicList;
            }

        }
        private void MusicListChanged()
        {
            bool playTimer = tmrPlay.Enabled;
            tmrPlay.Enabled = false;
            FillupMusicGrid();
            this.tssSongsCount.Text = musicList.Count + " Songs";
            this.tssSize.Text = GetFileSize(totalFileSize);
            tmrPlay.Enabled = playTimer;
        }
        private void lbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (preventEvent == false && MusicManagerHistory!=null)
            {
                preventEvent = true;
                ArrayList GenreList = new ArrayList();
                GetSelectedGenreList(GenreList);
                lbArtist.DataSource = MusicManagerHistory.Music.GetArtistList(GenreList);
                StartReloadTimer();
                preventEvent = false;
            }
        }
        
        private void lbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (preventEvent == true && MusicManagerHistory != null)
            {
                ArrayList GenreList = new ArrayList();
                GetSelectedGenreList(GenreList);
                ArrayList artistList = new ArrayList();
                GetSelectedArtistList(artistList);
                lbAlbum.DataSource = MusicManagerHistory.Music.GetAlbumList(GenreList, artistList);
            }
            else
            {
                if (MusicManagerHistory != null)
                {
                    preventEvent = true;
                    ArrayList GenreList = new ArrayList();
                    GetSelectedGenreList(GenreList);
                    ArrayList artistList = new ArrayList();
                    GetSelectedArtistList(artistList);
                    lbAlbum.DataSource = MusicManagerHistory.Music.GetAlbumList(GenreList, artistList);
                    StartReloadTimer();
                    preventEvent = false;
                }
            }
        }

        private void lbAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (preventEvent == false && MusicManagerHistory != null)
                StartReloadTimer();
        }
        string sortColumn = "Filename";
        private SortOrder sortOrder = SortOrder.None;

        #region IComparer<MusicRow> Members

        public int Compare(MMHistory.MusicRow x, MMHistory.MusicRow y)
        {
            if (x[sortColumn] is DBNull || y[sortColumn] is DBNull)
                return 0;
            if (sortColumn == "Size" || sortColumn == "Track")
            {
                int ix = (int)x[sortColumn];
                int iy = (int)y[sortColumn];
                if(sortOrder==SortOrder.Ascending)
                    return ix.CompareTo(iy);
                else
                    return iy.CompareTo(ix);
            }
            else
            {
                string sx = x[sortColumn].ToString();
                string sy = y[sortColumn].ToString();
                if (sortOrder == SortOrder.Ascending)
                    return sx.CompareTo(sy);
                else
                    return sy.CompareTo(sx);
            }
        }

        #endregion

        //private void tmrReload_Tick(object sender, EventArgs e)
        //{
        //    tmrReload.Enabled = false; ;
        //    ReloadListView();
        //}

        
        private void listViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&&e.KeyCode==Keys.A)
            {
                dgMusic.SelectAll();
            }
        }
        int endSelection = -1;
        int startSelection = -1;
        
        private void listViewFiles_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            startSelection = e.StartIndex;
            endSelection = e.EndIndex;
        }

        private void dgMusic_DoubleClick(object sender, EventArgs e)
        {
            if (dgMusic.SelectedRows.Count == 1)
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.SelectedRows[0].DataBoundItem;
                IncreasePlayCount(dr);
                Play(musicList.IndexOf(dr));
            }
        }

        private void dgMusic_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sortOrder == SortOrder.Ascending)
                sortOrder = SortOrder.Descending;
            else
                sortOrder = SortOrder.Ascending;
            sortColumn = dgMusic.Columns[e.ColumnIndex].Name;
            musicList.Sort(this);
            CalculateNextProbability();
            dgMusic.Refresh();
        }

        private void dgMusic_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgMusic.Columns[e.ColumnIndex].Name == "Size")
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.Rows[e.RowIndex].DataBoundItem;
                e.FormattingApplied = true;
                e.Value = GetFileSize(dr.Size);
            }
            else if (dgMusic.Columns[e.ColumnIndex].Name == "MMProbability")
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.Rows[e.RowIndex].DataBoundItem;
                //int mmRating = dr.PlayCount;
                //int additionalRating = 0;
                //if (drPlaying != null)
                //{
                //    if (dr.Genre != "" && dr.Genre == drPlaying.Genre)
                //    {
                //        additionalRating += ToolsManager.GetManager().GenrePriority + MusicManagerHistory.Music.GetAveragePlayCountByGenre(dr.Genre);
                //    }
                //    if (dr.Album != "" && dr.Album == drPlaying.Album)
                //    {
                //        additionalRating += ToolsManager.GetManager().AlbumPriority + MusicManagerHistory.Music.GetAveragePlayCountByAlbum(dr.Album);
                //    }
                //    if (dr.Artist != "" && dr.Artist == drPlaying.Artist)
                //    {
                //        additionalRating += ToolsManager.GetManager().ArtistPriority + MusicManagerHistory.Music.GetAveragePlayCountByArtist(dr.Artist);
                //    }
                //}
                //if (ToolsManager.GetManager().AllowRepeat == false && playedList.Contains(dr))
                //    mmRating = 0;
                //else
                //    mmRating += additionalRating;                
                double rating = dr.MMProbability;
                
                if (totalPlayCount != 0)
                {                    
                    rating = (double)rating / (double)(totalPlayCount);
                }
                e.Value = rating.ToString("0.#### %");
                //dgMusic.Rows[e.RowIndex].HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
            }
            else if (dgMusic.Columns[e.ColumnIndex].Name == "CumulativeProbability")
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.Rows[e.RowIndex].DataBoundItem;
                double rating = dr.CumulativeProbability;

                if (totalPlayCount != 0)
                {
                    rating = (double)rating / (double)(totalPlayCount);
                }
                e.Value = rating.ToString("0.#### %");
            }
            else if (dgMusic.Columns[e.ColumnIndex].Name == "Status")
            {
                MMHistory.MusicRow dr = (MMHistory.MusicRow)dgMusic.Rows[e.RowIndex].DataBoundItem;
                DataGridViewRow itm = dgMusic.Rows[e.RowIndex];
                switch (dr.Status)
                {
                    case "Queued":
                        itm.DefaultCellStyle.ForeColor = Color.Brown;
                        itm.DefaultCellStyle.SelectionForeColor = itm.DefaultCellStyle.ForeColor;
                        break;
                    case "Failed":
                        itm.DefaultCellStyle.ForeColor = Color.Red;
                        itm.DefaultCellStyle.SelectionForeColor = itm.DefaultCellStyle.ForeColor;
                        break;
                    case "Skiped":
                        itm.DefaultCellStyle.ForeColor = Color.Maroon;
                        itm.DefaultCellStyle.SelectionForeColor = itm.DefaultCellStyle.ForeColor;
                        break;
                    case "Copying":
                        itm.DefaultCellStyle.ForeColor = Color.Green;
                        itm.DefaultCellStyle.SelectionForeColor = itm.DefaultCellStyle.ForeColor;
                        break;
                    case "PLAYING":
                        itm.DefaultCellStyle.ForeColor = Color.Blue;
                        itm.DefaultCellStyle.SelectionForeColor = itm.DefaultCellStyle.ForeColor;
                        break;
                    default:
                        itm.DefaultCellStyle.ForeColor = Color.Black;
                        itm.DefaultCellStyle.SelectionForeColor = itm.DefaultCellStyle.ForeColor;
                        break;
                }
            }
        }

        private void dgMusic_Resize(object sender, EventArgs e)
        {
            ResizeColumn();
        }
        private void ResizeColumn()
        {
            int total = 0;
            for (int i = 0; i < dgMusic.Columns.Count; i++)
            {
                if (dgMusic.Columns[i].Visible)
                    total += dgMusic.Columns[i].Width;
            }
            total += 17;
            if (total < dgMusic.Width)
            {
                dgMusic.Columns["Filename"].Width += dgMusic.Width - total;
            }
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(locationComboBox.SelectedItem.ToString()))
            {
                locationComboBox.FindString(ToolsManager.GetManager().LastLocation);
            }
        }

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cmbLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbLocation_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbLocation_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(this.locationComboBox.Text))
            {
                if (this.locationComboBox.Text != ToolsManager.GetManager().LastLocation)
                {
                    SaveMMHistory();
                    clearToolStripMenuItem_Click(sender, e);
                    MusicManagerHistory = null;
                    Directory.SetCurrentDirectory(this.locationComboBox.Text);
                    ToolsManager.GetManager().LastLocation = this.locationComboBox.Text;
                    mmConfiguration.Locations.AddLocation(this.locationComboBox.Text);                    
                    totalFileSize = 0;                    
                    DisplayMMHistory();
                    DisplayFreeSpace();
                    SaveConfiguration();
                    LoadLocationBox();
                }
            }
            else
            {
                this.locationComboBox.Text = ToolsManager.GetManager().LastLocation;
            }
        }
        private void SaveConfiguration()
        {
            try
            {
                string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Configuration.xml";
                mmConfiguration.WriteXml(fileName);
            }
            catch
            {
            }
        }
        private void LoadConfiguration()
        {
            try
            {
                mmConfiguration = new MMConfiguration();
                string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Configuration.xml";
                if (File.Exists(fileName))
                {
                    mmConfiguration.ReadXml(fileName);
                    LoadLocationBox();
                }
            }
            catch
            {
            }
        }
        private void LoadLocationBox()
        {
            locationComboBox.Items.Clear();
            for (int i = mmConfiguration.Locations.Rows.Count-1; i >= 0; i--)
            {
                locationComboBox.Items.Add(mmConfiguration.Locations[i].Location);
            }
        }
        

        private void dgMusic_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = this.contextMenuStrip1;
        }

        private void volumControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVolumnController frm = new frmVolumnController();
            frm.ShowDialog();
        }

        private void dgMusic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMusicManager_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                previousWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else
                this.ShowInTaskbar = true;
        }
        private FormWindowState previousWindowState = FormWindowState.Normal;
        private void frmMusicManager_SizeChanged(object sender, EventArgs e)
        {

        }

        private void frmMusicManager_ResizeBegin(object sender, EventArgs e)
        {
            
        }

		private void playButton_Click(object sender, EventArgs e)
		{
			if (drPlaying != null && Player.GetPlayer().IsPaused())
			{
				playButton.BackgroundImage = pause;
				playToolStripMenuItem_Click(sender, e);
			}
			else
			{
				playButton.BackgroundImage = play;
				pauseToolStripMenuItem_Click(sender, e);
			}
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			nextToolStripMenuItem_Click(sender, e);
		}

		private void previousButton_Click(object sender, EventArgs e)
		{
			previousToolStripMenuItem_Click(sender, e);
		}

		private void volumeButton_Click(object sender, EventArgs e)
		{
			volumControllerToolStripMenuItem_Click(sender, e);
		}

		private void shuffleButton_Click(object sender, EventArgs e)
		{
			shuffleToolStripMenuItem_Click(sender, e);
		}

		private void repeatButton_Click(object sender, EventArgs e)
		{
			
		}

		private void playButton_MouseEnter(object sender, EventArgs e)
		{
			playButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void previousButton_MouseEnter(object sender, EventArgs e)
		{
			previousButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void nextButton_MouseEnter(object sender, EventArgs e)
		{
			nextButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void volumeButton_MouseEnter(object sender, EventArgs e)
		{
			volumeButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void shuffleButton_MouseEnter(object sender, EventArgs e)
		{
			shuffleButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void repeatButton_MouseEnter(object sender, EventArgs e)
		{
			repeatButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void repeatButton_MouseHover(object sender, EventArgs e)
		{
			repeatButton.BackColor = Color.FromArgb(10, Color.Black);
		}

		private void previousButton_MouseLeave(object sender, EventArgs e)
		{
			previousButton.BackColor = Color.FromArgb(0, Color.Black);
		}

		private void volumeButton_MouseLeave(object sender, EventArgs e)
		{
			volumeButton.BackColor = Color.FromArgb(0, Color.Black);
		}

		private void playButton_MouseLeave(object sender, EventArgs e)
		{
			playButton.BackColor = Color.FromArgb(0, Color.Black);
		}

		private void nextButton_MouseLeave(object sender, EventArgs e)
		{
			nextButton.BackColor = Color.FromArgb(0, Color.Black);
		}

		private void shuffleButton_MouseLeave(object sender, EventArgs e)
		{
			shuffleButton.BackColor = Color.FromArgb(0, Color.Black);
		}

		private void trackBar_MouseUp(object sender, MouseEventArgs e)
		{
			Player.GetPlayer().SetPosition(trackBar.Value);
		}

		private void repeatButton_MouseLeave(object sender, EventArgs e)
		{
			repeatButton.BackColor = Color.FromArgb(0, Color.Black);
		}
	}
}