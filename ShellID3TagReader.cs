using System;
namespace ShellID3Reader
{
	public struct ShellID3TagReader
	{
		public static string[] tags;
		public static MP3File ReadID3Tags(string FileFullPath){
			MP3File mp3File = new MP3File();
            
			//parse file name
			string fileName = FileFullPath.Substring(FileFullPath.LastIndexOf("\\")+1);
			//parse file path
			string filePath = FileFullPath.Substring(0,FileFullPath.LastIndexOf("\\"));
			//create shell instance
			Shell32.Shell shell  = new Shell32.ShellClass();
			//set the namespace to file path
			Shell32.Folder folder = shell.NameSpace(filePath);
			//get ahandle to the file
			Shell32.FolderItem folderItem = folder.ParseName(fileName);
			//did we get a handle ?
			if (folderItem !=null){
				mp3File.FileName = fileName.Trim();
				//query information from shell regarding file
                mp3File.ArtistName = folder.GetDetailsOf(folderItem, 20).Trim();
                mp3File.AlbumName = folder.GetDetailsOf(folderItem, 14).Trim();
                mp3File.SongTitle = folder.GetDetailsOf(folderItem, 21).Trim();
                mp3File.Genre = folder.GetDetailsOf(folderItem, 16).Trim();
                mp3File.Time = folder.GetDetailsOf(folderItem, 27).Trim();
                tags = new string[28];
                for (int i = 0; i < 28; i++)
                {
                    try
                    {
                        tags[i] = folder.GetDetailsOf(folderItem, i);
                    }
                    catch
                    {
                    }
                }
                mp3File.FileFullPath = FileFullPath.Trim();
				try
				{
					mp3File.TrackNumber = Int32.Parse(folder.GetDetailsOf(folderItem,19));
				}
				catch
				{
				}
			}
			//clean up
			folderItem = null;
			folder = null;
			shell = null;
			//return mp3File instance
			return mp3File;
		}
        public static MP3File ReadWMATags(string FileFullPath)
        {
            MP3File mp3File = new MP3File();

            //parse file name
            string fileName = FileFullPath.Substring(FileFullPath.LastIndexOf("\\") + 1);
            //parse file path
            string filePath = FileFullPath.Substring(0, FileFullPath.LastIndexOf("\\"));
            //create shell instance
            Shell32.Shell shell = new Shell32.ShellClass();
            //set the namespace to file path
            Shell32.Folder folder = shell.NameSpace(filePath);
            //get ahandle to the file
            Shell32.FolderItem folderItem = folder.ParseName(fileName);
            //did we get a handle ?
            if (folderItem != null)
            {
                mp3File.FileName = fileName.Trim();
                //query information from shell regarding file

                string[] allDetails = new string[34];

                for (int index = 0; index < 34; index++)
                {
                    try
                    {
                        allDetails[index] = folder.GetDetailsOf(folderItem, index).Trim();
                    }
                    catch
                    {
                        continue;
                    }
                }

                mp3File.ArtistName = folder.GetDetailsOf(folderItem, 16).Trim();
                mp3File.AlbumName = folder.GetDetailsOf(folderItem, 17).Trim();
                mp3File.SongTitle = folder.GetDetailsOf(folderItem, 10).Trim();
                mp3File.Genre = folder.GetDetailsOf(folderItem, 20).Trim();
                mp3File.Time = folder.GetDetailsOf(folderItem, 21).Trim();
                string[] tags = new string[25];
                for (int i = 0; i < 25; i++)
                {
                    try
                    {
                        tags[i] = folder.GetDetailsOf(folderItem, i);
                    }
                    catch
                    {
                    }
                }
                mp3File.FileFullPath = FileFullPath.Trim();
                try
                {
                    mp3File.TrackNumber = Int32.Parse(folder.GetDetailsOf(folderItem, 19));
                }
                catch
                {
                }
            }
            //clean up
            folderItem = null;
            folder = null;
            shell = null;
            //return mp3File instance
            return mp3File;
        }

	}
}
