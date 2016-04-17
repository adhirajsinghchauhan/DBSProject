using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
namespace MusicManager
{


    partial class MMHistory
    {
        public int GetTotalPlayCount()
        {
            int total = 0;
            foreach (MMHistory.MusicRow dr in Music.Rows)
            {
                total += dr.PlayCount;
            }
            return total;
        }
        public void ResetStatus()
        {
            foreach (MMHistory.MusicRow dr in Music.Rows)
            {
                dr.Status = "";
            }
        }
        public int GetTotalFileSize()
        {
            int total = 0;
            foreach (MMHistory.MusicRow dr in Music.Rows)
            {
                total += dr.Size;
            }
            return total;
        }
        partial class MusicDataTable
        {
            public MMHistory.MusicRow this[string FullFileName]
            {
                get
                {
                    MMHistory.MusicRow[] drs = (MMHistory.MusicRow[])this.Select("FullFilename='" + FullFileName.Replace("'", "''") + "'");
                    if (drs.Length > 0)
                        return drs[0];
                    else
                        return null;
                }
            }
            public int GetAveragePlayCount(string filter)
            {
                MMHistory.MusicRow[] drs = (MMHistory.MusicRow[])this.Select(filter);
                if (drs.Length == 0)
                    return 0;
                int total = 0;
                for (int i = 0; i < drs.Length; i++)
                {
                    try
                    {
                        total += drs[i].PlayCount;
                    }
                    catch
                    {

                    }
                }
                return total / drs.Length;

            }
            public int GetAveragePlayCountByGenre(string Genre)
            {
                return GetAveragePlayCount("Genre='" + Genre.Replace("'", "''") + "'");
            }
            public int GetAveragePlayCountByAlbum(string Album)
            {
                return GetAveragePlayCount("Album='" + Album.Replace("'", "''") + "'");
            }
            public int GetAveragePlayCountByArtist(string Artist)
            {
                return GetAveragePlayCount("Artist='" + Artist.Replace("'", "''") + "'");
            }
            public ArrayList GetGenreList()
            {
                ArrayList generList = new ArrayList();

                foreach (MusicRow dr in Rows)
                {
                    string Genre = dr.Genre;
                    if (Genre.Trim() == "")
                        Genre = "Unknown";
                    if (generList.Contains(Genre) == false)
                        generList.Add(Genre);
                }
                generList.Sort();
                if (generList.Count > 0)
                {
                    generList.Insert(0, string.Format("All Genres({0})", generList.Count));
                    return generList;
                }
                return null;
            }
            public ArrayList GetArtistList()
            {
                ArrayList strList = new ArrayList();
                foreach (MusicRow dr in Rows)
                {
                    string artist = dr.Artist;
                    if (artist.Trim() == "")
                        artist = "Unknown";
                    if (strList.Contains(artist) == false)
                        strList.Add(artist);
                }
                strList.Sort();
                if (strList.Count > 0)
                {
                    strList.Insert(0, string.Format("All Artists({0})", strList.Count));
                    return strList;
                }
                return null;
            }
            public ArrayList GetArtistList(ArrayList GenreList)
            {
                ArrayList strList = new ArrayList();
                foreach (MusicRow dr in Rows)
                {
                    string artist = dr.Artist;
                    if (artist.Trim() == "")
                        artist = "Unknown";
                    string Genre = dr.Genre;
                    if (Genre.Trim() == "")
                        Genre = "Unknown";
                    if (strList.Contains(artist) == false && GenreList.Contains(Genre))
                        strList.Add(artist);
                }
                strList.Sort();
                if (strList.Count > 0)
                {
                    strList.Insert(0, string.Format("All Artists({0})", strList.Count));
                    return strList;
                }
                return null;
            }
            public ArrayList GetAlbumList()
            {
                ArrayList strList = new ArrayList();
                foreach (MusicRow dr in Rows)
                {
                    string album = dr.Album;
                    if (album.Trim() == "")
                        album = "Unknown";
                    if (strList.Contains(album) == false)
                        strList.Add(album);
                }
                strList.Sort();
                if (strList.Count > 0)
                {
                    strList.Insert(0, string.Format("All Albums({0})", strList.Count));
                    return strList;
                }
                return null;
            }
            public ArrayList GetAlbumList(ArrayList GenreList, ArrayList artistList)
            {
                ArrayList strList = new ArrayList();
                foreach (MusicRow dr in Rows)
                {
                    string artist = dr.Artist;
                    if (artist.Trim() == "")
                        artist = "Unknown";
                    string Genre = dr.Genre;
                    if (Genre.Trim() == "")
                        Genre = "Unknown";
                    string album = dr.Album;
                    if (album.Trim() == "")
                        album = "Unknown";
                    if (strList.Contains(album) == false && GenreList.Contains(Genre) && artistList.Contains(artist))
                        strList.Add(album);
                }
                strList.Sort();
                if (strList.Count > 0)
                {
                    strList.Insert(0, string.Format("All Albums({0})", strList.Count));
                    return strList;
                }
                return null;
            }
            public List<MusicRow> GetMusic(ArrayList GenreList, ArrayList artistList, ArrayList albumList)
            {
                List<MusicRow> musicList = new List<MusicRow>();
                foreach (MusicRow dr in Rows)
                {
                    string artist = dr.Artist;
                    if (artist.Trim() == "")
                        artist = "Unknown";
                    string Genre = dr.Genre;
                    if (Genre.Trim() == "")
                        Genre = "Unknown";
                    string album = dr.Album;
                    if (album.Trim() == "")
                        album = "Unknown";

                    if ((GenreList.Count == 0 || artistList.Count == 0 || albumList.Count == 0) || GenreList.Contains(Genre) && artistList.Contains(artist) && albumList.Contains(album))
                        musicList.Add(dr);
                }
                return musicList;
            }
            public List<MusicRow> GetMusic()
            {
                List<MusicRow> musicList = new List<MusicRow>();
                foreach (MusicRow dr in Rows)
                {
                    string artist = dr.Artist;
                    if (artist.Trim() == "")
                        artist = "Unknown";
                    string Genre = dr.Genre;
                    if (Genre.Trim() == "")
                        Genre = "Unknown";
                    string album = dr.Album;
                    if (album.Trim() == "")
                        album = "Unknown";
                    musicList.Add(dr);
                }
                return musicList;
            }
        }
    }
}
