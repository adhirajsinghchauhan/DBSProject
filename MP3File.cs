using System;
namespace ShellID3Reader {
	public class MP3File {
		private string fileName;
        private string fileFullPath;
		private string artistName;
		private string albumName;
		private int trackNumber;
		private string songTitle;
        private string time;
        private string genre;

		public string FileName {
		 	get{return this.fileName;}
			set{this.fileName = value;}
		}
		public string ArtistName {
			get{return this.artistName;}
			set{this.artistName = value;}
		}
		public string AlbumName {
			get{return this.albumName;}
			set{this.albumName = value;}
		}
		public int TrackNumber {
		 	get{return this.trackNumber;}
			set{this.trackNumber = value;}
		}
		public string SongTitle {
		 	get{return this.songTitle;}
			set{this.songTitle = value;}
		}
        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
        public string Genre
        {
            get { return this.genre; }
            set { this.genre = value; }
        }
        public string FileFullPath
        {
            get
            {
                return fileFullPath;
            }
            set
            {
                fileFullPath = value;
            }
        }
		public MP3File() {
		}
	}
}