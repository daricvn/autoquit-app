using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHook
{
    public class MouseHookEventArgs
    {
        public MouseKey Key { get; set; }
        public IntPtr Message { get; set; }
    }
    public enum MouseKey
    {
        LEFT_DOWN,
        LEFT_UP,
        LEFT_DBCLICK,
        RIGHT_DOWN,
        RIGHT_UP,
        RIGHT_DBCLICK,
        MIDDLE_DOWN,
        MIDDLE_UP,
        MIDDLE_DBCLICK,
        WHEEL,
        LEFT_CLICK,
        RIGHT_CLICK,
        MIDDLE_CLICK,
    }
}
