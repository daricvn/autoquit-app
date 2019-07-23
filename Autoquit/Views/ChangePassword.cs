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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            Language.ApplyLanguage(this);
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ScriptGrid.Script?.Password))
            {
                txtOld.Visible = false;
                lbOld.Visible = false;
            }
            else
            {
                txtOld.Visible = true;
                lbOld.Visible = true;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNew.Text) ||
                string.IsNullOrEmpty(txtRepeat.Text))
            {
                MessageBox.Show(Language.Get("msg_empty_pass"),
                    Language.Get("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtNew.Text.Equals(txtRepeat.Text))
            {
                MessageBox.Show(Language.Get("msg_notmatch_pass"),
                    Language.Get("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNew.Focus();
                return;
            }
            if (txtNew.Text.Length<Constant.AppConstant.MinPasswordLength)
            {
                MessageBox.Show(
                    string.Format(Language.Get("msg_short_pass"), AppConstant.MinPasswordLength),
                    Language.Get("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNew.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(ScriptGrid.Script?.Password)) {
                var bytes = Encoding.UTF8.GetBytes(txtOld.Text);
                var str = ScriptContent.ComputeSha256Hash(Convert.ToBase64String(bytes));
                if (str != ScriptGrid.Script.Password)
                {
                    MessageBox.Show(Language.Get("msg_wrong_pass"),
                        Language.Get("error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOld.Focus();
                    return;
                }
            }
            var newBytes = Encoding.UTF8.GetBytes(txtNew.Text);
            ScriptGrid.Script.Password = ScriptContent.ComputeSha256Hash(Convert.ToBase64String(newBytes));
            MessageBox.Show(Language.Get("msg_success_pass"),
                Language.Get("info"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtOld.Text = "";
            txtNew.Text = "";
            txtRepeat.Text = "";
            this.Close();
        }

        private void TxtOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                txtNew.Focus();
        }

        private void TxtNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRepeat.Focus();
        }

        private void TxtRepeat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnAccept_Click(null, null);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
