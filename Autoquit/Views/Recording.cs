using Autoquit.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Views
{
    public partial class Recording : Form
    {
        private int effectTime = 2000;
        private int currentOffset = 0;
        private int maxOpa = 80;
        private int minOpa = 40;
        private bool exit = false;
        private double currentOpa = 0;
        public Recording()
        {
            InitializeComponent();
            Language.ApplyLanguage(this);
            this.BackColor = Color.DarkRed;
            this.TransparencyKey = Color.DarkRed;
        }

        private void Recording_Load(object sender, EventArgs e)
        {
            int initialStyle = WinProcess.GetWindowLong(this.Handle, -20);
            WinProcess.SetWindowLong(this.Handle, -20, (uint)(initialStyle | 0x80000 | 0x20 | 0x00000080));
        }

        public void Show()
        {
            base.Show();
            exit = false;
            effectTimer.Enabled = true;

        }
        public void Hide()
        {
            exit = true;
        }

        public void FullWidth()
        {
            var x = Screen.PrimaryScreen.Bounds.Width;
            this.Size = new Size(x, this.Height);
            this.topLine.Size = new Size(x+5, this.topLine.Height);
        }

        private void EffectTimer_Tick(object sender, EventArgs e)
        {
            int opaGap = Math.Abs(maxOpa - minOpa);
            currentOffset += effectTimer.Interval;
            if (currentOffset >= effectTime)
                currentOffset = 0;
            var ratio = currentOffset / (float) effectTime;
            if (exit)
            {
                currentOpa -= 8;
                if (currentOpa <= 0)
                {
                    currentOpa = 0;
                    base.Hide();
                    effectTimer.Enabled = false;
                }
            }
            else
            {
                currentOpa = maxOpa - (opaGap * Math.Sin(Math.PI * ratio));
            }
            if (currentOpa > 100)
                currentOpa = 100;
            this.Opacity = currentOpa/100;
        }
    }
}
