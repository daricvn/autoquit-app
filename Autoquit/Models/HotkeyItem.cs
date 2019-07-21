using MouseHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Models
{
    internal class HotkeyItem
    {
        public int id;
        public Keys key;
        public KeyModifier modifier;
        public bool active;
        public string event_name;
    }
}
