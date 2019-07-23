using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquit.Constant
{
    static internal class AppConstant
    {
        public static string[] SupportedEvents = new string[] {
            "LEFT_CLICK",
            "RIGHT_CLICK",
            "LEFT_DOWN",
            "RIGHT_DOWN",
            "LEFT_UP",
            "RIGHT_UP",
            "KEY_PRESS",
            "KEY_DOWN",
            "KEY_UP",
            "ENTER_TEXT",
            "RANDOM_TEXT",
            "DO_NOTHING"
        };
        public static string[] SupportedCondition = new string[]
        {
            "BY_COUNT",
            "BY_HOUR",
            "BY_MINUTE",
            "BY_SECOND"
        };
        public static char[] ShiftNumberConversion = new char[] { ')', '!', '@', '#', '$', '%', '^', '&', '*', '(' };
        public const string appSettings = "settings.json";
    }
}
