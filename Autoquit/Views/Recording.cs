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
        public Recording()
        {
            InitializeComponent();
            int initialStyle = WinProcess.GetWindowLong(this.Handle, -20);
            WinProcess.SetWindowLong(this.Handle, -20, (uint) (initialStyle | 0x80000 | 0x20));
        }

        private void Recording_Load(object sender, EventArgs e)
        {

        }
    }
}
