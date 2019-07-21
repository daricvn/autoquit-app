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
    public partial class About : Form
    {
        private const string website = "https://daricvn.github.io/autoquit";
        public About()
        {
            InitializeComponent();
            linkDownload.Text = website;
            this.versionLabel.Text = string.Format(this.versionLabel.Text, Program.AppVersion);
        }
        private void About_Load(object sender, EventArgs e)
        {
            this.descLabel.Text = "Autoquit is an open-source Windows Application written by Darick Nguyen." + Environment.NewLine;
            this.descLabel.Text += "You can use this app to manipulate your Windows Application, automatically, by prepared script." + Environment.NewLine;
            this.descLabel.Text += "The app offers No-input Mode, with allow user to auto-click an application, without bringing it to foreground, and allow you to run many instance of Autoquit as you like. However, some application may not support No-input mode." + Environment.NewLine;
            this.descLabel.Text += "- Requirement: .NET 4.5.2 or above." + Environment.NewLine;
        }
        public Form Invoker
        {
            get; set;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Invoker.Show();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(website);
        }
    }
}
