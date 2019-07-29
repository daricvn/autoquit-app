using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseHook
{
    public static class MouseHook
    {
        public delegate void MouseHookEventHandler(MouseHookEventArgs arg);
        public static event MouseHookEventHandler MouseAction;
        public static void Start()
        {
            _hookID = SetHook(_proc);


        }
        public static void Stop()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                  GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
          int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                //MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                bool shouldInvoke = false;
                MouseKey key= MouseKey.LEFT_UP;
                if (((MouseMessages)wParam) == (MouseMessages.WM_LBUTTONDOWN)){
                    shouldInvoke = true;
                    key = MouseKey.LEFT_DOWN;
                }
                if (((MouseMessages)wParam) == (MouseMessages.WM_LBUTTONUP)){
                    shouldInvoke = true;
                    key = MouseKey.LEFT_UP;
                }
                if (((MouseMessages)wParam) == MouseMessages.WM_LBUTTONDBLCLK)
                {
                    shouldInvoke = true;
                    key = MouseKey.LEFT_DBCLICK;
                }
                if (((MouseMessages)wParam) == (MouseMessages.WM_MBUTTONDOWN)) {
                    shouldInvoke = true;
                    key = MouseKey.MIDDLE_DOWN;
                }
                if (((MouseMessages)wParam) == (MouseMessages.WM_MBUTTONUP)) {
                    shouldInvoke = true;
                    key = MouseKey.MIDDLE_UP;
                }
                //if (((MouseMessages)wParam) == (MouseMessages.WM_MOUSEWHEEL)) {
                //    shouldInvoke = true;
                //    key = MouseKey.WHEEL;
                //}
                if (((MouseMessages)wParam) == (MouseMessages.WM_RBUTTONDOWN)) {
                    shouldInvoke = true;
                    key = MouseKey.RIGHT_DOWN;
                }
                if (((MouseMessages)wParam) == (MouseMessages.WM_RBUTTONUP)) {
                    shouldInvoke = true;
                    key = MouseKey.RIGHT_UP;
                }
                if (((MouseMessages)wParam) == (MouseMessages.WM_RBUTTONDBLCLK))
                {
                    shouldInvoke = true;
                    key = MouseKey.RIGHT_DBCLICK;
                }
                if (shouldInvoke)
                {
                    MouseAction?.Invoke(new MouseHookEventArgs()
                    {
                        Message=wParam,
                        Key=key
                    });
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        internal enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_LBUTTONDBLCLK= 0x0203,
            WM_MBUTTONDOWN= 0x0207,
            WM_MBUTTONUP= 0x0208,
            WM_RBUTTONDBLCLK= 0x0206
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        public static POINT GetCursorPosition()
        {
            GetCursorPos(out POINT cursor);
            return cursor;
        }

    }
}
