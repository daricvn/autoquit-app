using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHook
{
    public class KeyHookEventArgs
    {
        public Keys Key { get; private set; }
        public KeyType Type { get; private set; }
        public KeyHookEventArgs(Keys key, KeyType type)
        {
            Key = key;
            Type = type;
        }
    }
    public enum KeyType
    {
        KEY_UP,
        KEY_DOWN,
        KEY_PRESS
    }
}
