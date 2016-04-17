using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Xml;

namespace MusicManager
{
    public class ReadPlaylist
    {
        public ReadPlaylist()
        {

        }
        private ArrayList name = new ArrayList();
        private string m_xmlFile;

        /// <summary>
        /// The Windows Media Playlist Path xxx.wpl file
        /// </summary>
        public string playListPath
        {
            get
            {
                return m_xmlFile;
            }
            set
            {
                m_xmlFile = value;
                Makeplaylist();
            }
        }

        /// <summary>
        /// Return an Arraylist of file found in Windows Media Playlist file
        /// </summary>
        public ArrayList PlayList
        {
            get
            {
                return name;
            }
        }
        
        /// <summary>
        /// Fills up an Arraylist with titles found in the Windows Media Playlist file.
        /// Using XmlTextReader
        /// </summary>
        private void Makeplaylist()
        {
            XmlTextReader readList = new XmlTextReader(m_xmlFile);
            while (readList.Read())
            {
                if (readList.NodeType == XmlNodeType.Element)
                {
                    if (readList.LocalName.Equals("media"))
                    {
                        name.Add(readList.GetAttribute(0).ToString());
                    }
                }
            }
        }
    }
}
