using MouseHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseHook.WinAPI;

namespace Autoquit.Views
{
    public partial class MouseCoord : Form
    {
        private MouseHook.MouseHook.POINT currentPoint;
        private IntPtr targetWindows = IntPtr.Zero;
        public MouseCoord()
        {
            InitializeComponent();
            this.BackColor = Color.DarkMagenta;
            this.TransparencyKey = Color.DarkMagenta;
        }

        private void MouseCoord_Load(object sender, EventArgs e)
        {
            int initialStyle = WinProcess.GetWindowLong(this.Handle, -20);
            WinProcess.SetWindowLong(this.Handle, -20, (uint)(initialStyle | 0x80000 | 0x20 | 0x00000080));
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(0, 0);
            xLine.Size= new Size(Screen.PrimaryScreen.Bounds.Width, 1);
            yLine.Size = new Size(1, Screen.PrimaryScreen.Bounds.Height);
        }

        public void Show(IntPtr target)
        {
            base.Show();
            timeTicker.Enabled = true;
            targetWindows = target;
        }
        public void Hide()
        {
            timeTicker.Enabled = false;
            base.Hide();
        }

        private void TimeTicker_Tick(object sender, EventArgs e)
        {
            currentPoint = MouseHook.MouseHook.GetCursorPosition();
            xLine.Location = new Point(0, currentPoint.y);
            yLine.Location = new Point(currentPoint.x, 0);
            try
            {
                if (targetWindows != IntPtr.Zero && 
                    MouseHook.MouseHook.ScreenToClient(targetWindows, ref currentPoint))
                {
                }
            }
            catch (Exception)
            {
                this.Hide();
            }
            lbMousecoord.Text = string.Format("{0}:{1}", currentPoint.x, currentPoint.y);
        }
    }
}
