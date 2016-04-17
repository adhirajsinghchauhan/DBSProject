using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
namespace MusicManager
{
    public class ToolsManager
    {
        public const string REGISTRY_KEY = "SOFTWARE\\asc42\\MusicManager";
        private string fileFormat=@"{Album}\{Artist}\{FileName}";
        private static ToolsManager manager;
        private ToolsManager()
        {
            AllowRepeat = false;
        }
        public static ToolsManager GetManager()
        {
            if (manager == null)
                manager = new ToolsManager();
            return manager;
        }
        public string FileFormat
        {
            get
            {
                return fileFormat;
            }
            set
            {
                fileFormat = value;
            }
        }
        public bool IsRandom
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("IsRandom") != null)
                        return key.GetValue("IsRandom").ToString().ToLower()=="true";
                }
                return false;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("IsRandom", value.ToString());
                key2.Close();
            }
        }
        public string GroupBy
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("GroupBy") != null)
                        return key.GetValue("GroupBy").ToString();
                }
                return "Genre";
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("GroupBy", value);
                key2.Close();

            }
        }
        public string LastLocation
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                string location = "";
                if (key != null)
                {
                    if (key.GetValue("LastLocation") != null)
                        location = key.GetValue("LastLocation").ToString();
                }                
                if (!Directory.Exists(location))
                {
                    location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    LastLocation = location;
                }
                return location;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("LastLocation", value);
                key2.Close();

            }
        }
        public int GenrePriority
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("GenrePriority") != null)
                    {
                        int i = 0;
                        if (int.TryParse(key.GetValue("GenrePriority").ToString(), out i))
                            return i;
                    }
                }
                return 10;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("GenrePriority", value.ToString());
                key2.Close();

            }
        }
        public int ArtistPriority
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("ArtistPriority") != null)
                    {
                        int i = 0;
                        if (int.TryParse(key.GetValue("ArtistPriority").ToString(), out i))
                            return i;
                    }
                }
                return 7;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("ArtistPriority", value.ToString());
                key2.Close();

            }
        }
        public int AlbumPriority
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("AlbumPriority") != null)
                    {
                        int i = 0;
                        if (int.TryParse(key.GetValue("AlbumPriority").ToString(), out i))
                            return i;
                    }
                }
                return 5;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("AlbumPriority", value.ToString());
                key2.Close();

            }
        }
        public bool AllowRepeat
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("AllowRepeat") != null)
                    {
                        if (key.GetValue("AllowRepeat").ToString() == bool.TrueString)
                            return true;
                    }
                }
                return false;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("AllowRepeat", value.ToString());
                key2.Close();

            }
        }
        public bool UseRepeatPriority
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("UseRepeatPriority") != null)
                    {
                        if (key.GetValue("UseRepeatPriority").ToString() == bool.TrueString)
                            return true;
                    }
                }
                return false;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("UseRepeatPriority", value.ToString());
                key2.Close();

            }
        }
        public int RepeatPriority
        {
            get
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
                if (key != null)
                {
                    if (key.GetValue("RepeatPriority") != null)
                    {
                        int i = 0;
                        if (int.TryParse(key.GetValue("RepeatPriority").ToString(), out i))
                            return i;
                    }
                }
                return 5;
            }
            set
            {
                Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
                if (key2 == null)
                {
                    key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
                }
                key2.SetValue("RepeatPriority", value.ToString());
                key2.Close();

            }
        }

    }
}
