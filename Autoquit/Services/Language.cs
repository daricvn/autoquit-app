using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Services
{
    public static class Language
    {
        private static Dictionary<string, string> _lang=null;

        public static Dictionary<string, string> Text
        {
            get
            {
                if (_lang == null) return new Dictionary<string, string>();
                return _lang;
            }
        }
        public static string Get(string key)
        {
            if (Text.ContainsKey(key))
                return Text[key].Replace("\\n",Environment.NewLine);
            else return "";
        }

        public static bool Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                _lang = new Dictionary<string, string>();
                _lang = JsonConvert.DeserializeAnonymousType(text, _lang);
                return true;
            }
            return false;
        }
        public static bool ApplyLanguage(Control ctl)
        {
            if (ctl !=null && ctl.Controls != null && ctl.Controls.Count > 0)
                foreach (Control control in ctl.Controls)
                    ApplyLanguage(control);
            if (ctl != null ) {
                if (ctl.Text.StartsWith("@"))
                {
                    string key = ctl.Text.Substring(1);
                    if (Text.ContainsKey(key))
                        ctl.Text = Text[key];
                }
                if (ctl.Tag!=null && ctl.Tag.ToString().StartsWith("@"))
                {
                    string key = ctl.Tag.ToString().Substring(1);
                    if (Text.ContainsKey(key))
                        ctl.Tag = Text[key];
                }
                return true;
            }
            return false;
        }
    }
}
