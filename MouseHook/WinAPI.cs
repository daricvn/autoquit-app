using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseHook.MouseHook;

namespace MouseHook
{
    public class WinAPI
    {
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        private static int MakeLParam(int LoWord, int HiWord)
        {
            return (int)((HiWord << 16) | (LoWord & 0xFFFF));
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

        public static void SendKeyboard(IntPtr windows, KeyType type, Keys key)
        {
            if (type == KeyType.KEY_PRESS)
            {
                PostMessage(windows, KeyboardHook.WM_KEYUP, (int)key, 0);
            }
            if (type == KeyType.KEY_DOWN)
                PostMessage(windows, 256, (int)key, 0);
            if (type == KeyType.KEY_UP)
                SendMessage(windows, 257, (int)key, 65539);
        }
        public static void SendMouseEx(IntPtr windows, MouseKey type, int x, int y)
        {
            if (type == MouseKey.LEFT_CLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONDOWN, (int)Keys.LButton,
                    MakeLParam(x, y));
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONUP, (int)Keys.LButton,
                    MakeLParam(x, y));
            }
            if (type == MouseKey.LEFT_DBCLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONDBLCLK, 0,
                    MakeLParam(x, y));
            }
            if (type == MouseKey.LEFT_DOWN)
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONDOWN, (int)Keys.LButton,
                    MakeLParam(x, y));
            if (type == MouseKey.LEFT_UP)
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONUP, (int)Keys.LButton,
                    MakeLParam(x , y ));
            if (type == MouseKey.RIGHT_CLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONDOWN, (int)Keys.RButton,
                    MakeLParam(x , y));
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONUP, (int)Keys.RButton,
                    MakeLParam(x, y ));
            }
            if (type == MouseKey.RIGHT_DBCLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONDBLCLK, 0,
                    MakeLParam(x, y));
            }
            if (type == MouseKey.RIGHT_DOWN)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONDOWN, (int)Keys.RButton,
                    MakeLParam(x, y));
            }
            if (type == MouseKey.RIGHT_UP)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONUP, (int)Keys.RButton,
                    MakeLParam(x , y));
            }
        }
        public static string RetrieveCoord(IntPtr windows)
        {
            POINT point = GetCursorPosition();
            MouseHook.ScreenToClient(windows, ref point);
            return string.Format("{0}:{1}", point.x, point.y);
        }
        public static bool PointToScreen(IntPtr windows, ref int x, ref int y)
        {
            POINT p = new POINT();
            p.x = x;
            p.y = y;
            var result=MouseHook.ClientToScreen(windows, ref p);
            x = p.x;
            y = p.y;
            return result;
        }
        public static void SendMouse(IntPtr windows, MouseKey type, int x, int y)
        {
            Rect rct = new Rect();
            if (!GetWindowRect(windows, ref rct))
            {
                return;
            }
            if (type == MouseKey.LEFT_CLICK)
            {
                PostMessage(windows, (uint) MouseHook.MouseMessages.WM_LBUTTONDOWN, (int) Keys.LButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONUP, (int)Keys.LButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
            }
            if (type == MouseKey.LEFT_DBCLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONDBLCLK,0,
                    MakeLParam(x - rct.Left, y - rct.Top));
            }
            if (type==MouseKey.LEFT_DOWN)
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONDOWN, (int)Keys.LButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
            if (type == MouseKey.LEFT_UP)
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_LBUTTONUP, (int)Keys.LButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
            if (type == MouseKey.RIGHT_CLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONDOWN, (int)Keys.RButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONUP, (int)Keys.RButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
            }
            if (type == MouseKey.RIGHT_DBCLICK)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONDBLCLK, 0,
                    MakeLParam(x - rct.Left, y - rct.Top));
            }
            if (type == MouseKey.RIGHT_DOWN)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONDOWN, (int)Keys.RButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
            }
            if (type == MouseKey.RIGHT_UP)
            {
                PostMessage(windows, (uint)MouseHook.MouseMessages.WM_RBUTTONUP, (int)Keys.RButton,
                    MakeLParam(x - rct.Left, y - rct.Top));
            }
        }
    }
}
