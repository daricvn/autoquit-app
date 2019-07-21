using Autoquit.Models;
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
    public partial class ChangeName : Form
    {
        public ChangeName()
        {
            InitializeComponent();
            Language.ApplyLanguage(this);
        }
        public Form Invoker
        {
            get;set;
        }

        private void TxtScriptName_TextChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = !string.IsNullOrWhiteSpace(txtScriptName.Text);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ScriptGrid.Script.Name = txtScriptName.Text;
            if (Invoker != null)
                Invoker.Text = string.Format("{0} - {1}", Program.AppName, txtScriptName.Text);
            this.Close();
        }

        private void ChangeName_Load(object sender, EventArgs e)
        {
            txtScriptName.Text = ScriptGrid.Script.Name;
        }

        private void TxtScriptName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnAccept_Click(null, null);
        }
    }
}
