using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
namespace MusicManager
{
    static class Program
    {
        [DllImport("user32.Dll")]
        private static extern int EnumWindows(EnumWinCallBack callBackFunc, int lParam);

        [DllImport("User32.Dll")]
        private static extern void GetWindowText(IntPtr hWnd, StringBuilder str, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        [DllImport("user32")]
        public static extern int SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);


        /// <summary>
        /// EnumWindowCallBack
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private static bool EnumWindowCallBack(int hwnd, int lParam)
        {
            windowHandle = (IntPtr)hwnd;
            StringBuilder sbuilder = new StringBuilder(256);
            GetWindowText(windowHandle, sbuilder, sbuilder.Capacity);
            string strTitle = sbuilder.ToString();
            if (strTitle == ApplicationTitle)
            {
                ShowWindow(windowHandle, 1);
                SetForegroundWindow(windowHandle);
                string[] argv = Environment.GetCommandLineArgs();
                if (argv.Length > 1)
                {
                    CopyDataHelper.SendMsgString(windowHandle, argv[1]);
                }
                return false;
            }
            return true;
        }//EnumWindowCallBack

        /// <summary>
        /// check if given exe already running or not
        /// </summary>
        /// <returns>returns true if already running</returns>
        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;

            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            mutex = new Mutex(true, sExeName);

            if (mutex.WaitOne(0, false))
            {
                return false;
            }
            return true;

        }

        static Mutex mutex;
        const int SW_RESTORE = 9;
        static string sTitle = "Music Manager";
        static IntPtr windowHandle;
        delegate bool EnumWinCallBack(int hwnd, int lParam);
        public static string ApplicationTitle
        {
            get
            {
                return sTitle;
            }
        }      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsAlreadyRunning())
            {
                EnumWindows(new EnumWinCallBack(EnumWindowCallBack), 0);
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Splash());
            }
            catch
            {

            }
        }

    }
}