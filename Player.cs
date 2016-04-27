using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MusicManager
{
    public class Player
    {

        private string Pcommand;
        private bool isOpen;

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        private static Player player;
        private int baseVolume;
        private int trebleVolume;
        private int leftVolume;
        private int rightVolume;
        private int masterVolume;
		public int nowPlaying;

        public Player()
        {
            this.Bass = 5 * 100;
            this.LeftVolume = 5 * 100;
            this.MasterVolume = 5 * 100;
            this.RightVolume = 5 * 100;
            this.Treble = 5 * 100;
        }
        public static Player GetPlayer()
        {
            if (player == null)
                player = new Player();
            return player;
        }
        public void Close()
        {
            Pcommand = "close MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }


        public void Open(string sFileName)
        {
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }

		public int getSongLength(string sFilename)
		{
			if (!IsPaused())
			{
				Pcommand = "status MediaFile length";
				StringBuilder stringBuilder = new StringBuilder(128);
				mciSendString(Pcommand, stringBuilder, 128, IntPtr.Zero);
				return Convert.ToInt32(stringBuilder.ToString());
			}
			else
			{
				return 0;
			}
		}

		public int getCurrentPosition(string sFilename)
		{
			Pcommand = "status MediaFile position";
			StringBuilder stringBuilder = new StringBuilder(128);
			mciSendString(Pcommand, stringBuilder, 128, IntPtr.Zero);
			return Convert.ToInt32(stringBuilder.ToString());
		}

		public void SetPosition(long milliseconds)
		{
			if (!IsPaused())
			{
				Pcommand = "play MediaFile from " + milliseconds.ToString();
				mciSendString(Pcommand, null, 0, IntPtr.Zero);
			}
			else
			{
				Pcommand = "seek MediaFile to " + milliseconds.ToString();
				mciSendString(Pcommand, null, 0, IntPtr.Zero);
			}
		}


		public void Play(bool loop)
        {
            if (isOpen)
            {
                Pcommand = "play MediaFile";
                if (loop)
                    Pcommand += " REPEAT";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
                this.Bass = this.Bass;
                this.LeftVolume = this.LeftVolume;
                this.MasterVolume = this.MasterVolume;
                this.RightVolume = this.RightVolume;
                this.Treble = this.Treble;
            }
        }
        public void Play(string FileName)
        {
            if (isOpen == true)
                Close();
            Open(FileName);
            Play(false);
        }
        /// <summary>
        /// Pauses currently playing audio file
        /// </summary>
        public void Pause()
        {
            Pcommand = "pause MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
        }

        public bool IsPaused()
        {
            return Pcommand == "pause MediaFile";
        }

        /// <summary>
        /// Returns the current status player: playing,paused,stopped etc.
        /// </summary>
        public string Status()
        {
            int i = 128;
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(i);
            mciSendString("status MediaFile mode", stringBuilder, i, IntPtr.Zero);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Get/Set Lelf Volume Factor
        /// </summary>
        public int LeftVolume
        {
            get
            {
                return leftVolume;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile left volume to ", value), null, 0, IntPtr.Zero);
                leftVolume = value;
            }
        }

        /// <summary>
        /// Get/Set Right Volume Factor
        /// </summary>
        public int RightVolume
        {
            get
            {
                return rightVolume;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile right volume to ", value), null, 0, IntPtr.Zero);
                rightVolume = value;
            }
        }

        /// <summary>
        /// Get/Set Main Volume Factor
        /// </summary>
        public int MasterVolume
        {
            get
            {
                return masterVolume;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile volume to ", value), null, 0, IntPtr.Zero);
                masterVolume = value;
            }
        }

        /// <summary>
        /// Get/Set Bass Volume Factor
        /// </summary>
        public int Bass
        {
            get
            {
                return baseVolume;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile bass to ", value), null, 0, IntPtr.Zero);
                baseVolume = value;
            }
        }

        /// <summary>
        /// Get/Set Treble Volume Factor
        /// </summary>
        public int Treble
        {
            get
            {
                return trebleVolume;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile treble to ", value), null, 0, IntPtr.Zero);
                trebleVolume = value;
            }
        }

    }

}
