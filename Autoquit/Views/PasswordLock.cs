using Autoquit.Constant;
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
    public partial class PasswordLock : Form
    {
        public PasswordLock()
        {
            InitializeComponent();
            Language.ApplyLanguage(this);
        }

        public bool Success { get; set; } = false;
        public void ShowDialog()
        {
            Success = false;
            txtPassword.Text = "";
            try
            {
                base.ShowDialog();
            }
            catch (Exception) { }
        }

        private void Validate()
        {
            var bytes = Encoding.UTF8.GetBytes(txtPassword.Text);
            var hash = ScriptContent.ComputeSha256Hash(Convert.ToBase64String(bytes));
            if (hash.Equals(ScriptGrid.Script?.Password))
            {
                if (chkClearPass.Checked)
                    hash.Equals(ScriptGrid.Script.Password = "");
                Success = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(Language.Get("msg_wrong_pass"),
                    Language.Get("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text) && e.KeyCode == Keys.Enter)
                Validate();
        }

        private void PasswordLock_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordLock_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
