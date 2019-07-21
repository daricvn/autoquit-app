using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit
{
    static class Program
    {
        public const string AppName = "Autoquit";
        private static Icon _defaultIcon=null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static internal string AppVersion
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.FileVersion;
            }
        }
        public static Icon DefaultFormIcon
        {
            get
            {
                if (_defaultIcon == null)
                    _defaultIcon = global::Autoquit.Properties.Resources._default;
                return _defaultIcon;
            }
        }
    }
}
