using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Services
{
    public static class KeyMapper
    {
        private static char[] _symbol = null;
        private static char[] CharSymbol
        {
            get
            {
                if (_symbol == null)
                    _symbol = new char[] { ')','!','@','#','$','%','^','&','*','(' };
                return _symbol;
            }
        }
        public static Keys Get(char key, out bool shift)
        {
            int charIndex = 0;
            if (char.IsDigit(key))
            {
                shift = false;
                return (Keys)Enum.Parse(typeof(Keys), "D" + key);
            }
            if ((charIndex = Array.IndexOf(CharSymbol, key)) >= 0)
            {
                shift = true;
                return (Keys)Enum.Parse(typeof(Keys), "D" + charIndex);
            }
            if (key == '/' || key == '?')
            {
                shift = key == '?';
                return Keys.Oem2;
            }
            if (key == ',' || key == '<')
            {
                shift = key == '<';
                return Keys.Oemcomma;
            }
            if (key == '.' || key == '>')
            {
                shift = key == '>';
                return Keys.OemPeriod;
            }
            if (key == ';' || key == ':')
            {
                shift = key == ':';
                return Keys.OemSemicolon;
            }
            if (key == '\'' || key == '"')
            {
                shift = key == '"';
                return Keys.OemQuotes;
            }
            if (key == '\\' || key == '|')
            {
                shift = key == '|';
                return Keys.OemPipe;
            }
            if (key == '[' || key == '{')
            {
                shift = key == '{';
                return Keys.Oem4;
            }
            if (key == ']' || key == '}')
            {
                shift = key == '}';
                return Keys.Oem6;
            }
            if (key == '-' || key == '_')
            {
                shift = key == '_';
                return Keys.OemMinus;
            }
            if (key == '=' || key == '+')
            {
                shift = key == '+';
                return Keys.Oemplus;
            }
            if (key == '`' || key == '~')
            {
                shift = key == '~';
                return Keys.Oemtilde;
            }
            if (key==' ')
            {
                shift = false;
                return Keys.Space;
            }
            shift = char.IsUpper(key);
            return (Keys) Enum.Parse(typeof(Keys),key.ToString().ToUpper());
        }
    }
}
