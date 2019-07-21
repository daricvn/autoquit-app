using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoquit
{
    public static class WinProcess
    {
        internal delegate bool WindowEnumProc(IntPtr hWnd, IntPtr lParam);
        public static Process[] RunningProcesses{
            get
            {
                var notepad = Process.GetProcessesByName("notepad")?.AsEnumerable();
                return Process.GetProcesses().Concat(notepad).ToArray();
            }
        }
        const UInt32 WS_MAXIMIZE = 365887488;
        const int GWL_STYLE = -16;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr wHnd, int cmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, WindowEnumProc callback, IntPtr lParam);

        public static void BringProcessToFront(Process proc)
        {
            int style = GetWindowLong(proc.MainWindowHandle, GWL_STYLE);
            ShowWindow(proc.MainWindowHandle,
                (style & WS_MAXIMIZE) == WS_MAXIMIZE ? 3 : 9);
            SetForegroundWindow(proc.MainWindowHandle);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int size);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        public static List<IntPtr> GetAllChildHandles(IntPtr mainHandle)
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                WindowEnumProc childProc = new WindowEnumProc(EnumWindow);
                EnumChildWindows(mainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        public static string GetWindowTitle(IntPtr handle)
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            GetWindowText(handle, stringBuilder, stringBuilder.Capacity);
            return stringBuilder.ToString();
        }
        public static string GetWindowName(IntPtr handle)
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            GetClassName(handle, stringBuilder, stringBuilder.Capacity);
            return stringBuilder.ToString();
        }

        private static bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }
    }

}
