using Autoquit.Constant;
using Autoquit.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Views
{
    public partial class Settings : Form
    {
        private const string languageINI = "resources/language.ini";
        private const string languageFolder = "resources";
        public Settings()
        {
            InitializeComponent();
            Language.ApplyLanguage(this);
        }

        public Form Invoker { get; set; }

        private void Settings_Load(object sender, EventArgs e)
        {
            ttGeneric.SetToolTip(chkNoInput, Language.Get("noinput_mode_tooltip"));
            txtPlayScript.Text = SharedProperty.appSettings.PlayHotKey;
            txtStartRecording.Text = SharedProperty.appSettings.RecordHotKey;
            if (SharedProperty.appSettings.PlayModifier != null)
            {
                var index = cbModifiers.Items.IndexOf(SharedProperty.appSettings.PlayModifier);
                if (index >= 0)
                    cbModifiers.SelectedIndex = index;
                else cbModifiers.SelectedIndex = 0;
            }
            else cbModifiers.SelectedIndex = 0;
            LoadListLanguage();
        }

        private void LoadListLanguage()
        {
            cbLanguage.Items.Clear();
            if (File.Exists(languageINI))
            {
                var fileList=File.ReadAllLines(languageINI);
                foreach (string file in fileList)
                    if (File.Exists(Path.Combine(languageFolder, file)))
                    {
                        cbLanguage.Items.Add(file.ToLower());
                        if (SharedProperty.appSettings.Language.ToLower() == file.ToLower())
                            cbLanguage.SelectedIndex = cbLanguage.Items.Count - 1;
                    }

            }
        }

        private void TxtStartRecording_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Alt &&
                e.KeyCode != Keys.LWin && e.KeyCode != Keys.RWin && e.KeyCode!=Keys.ShiftKey)
            {
                (sender as TextBox).Text = Enum.GetName(typeof(Keys), (e.KeyCode));
            }
            e.SuppressKeyPress = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SharedProperty.appSettings.PlayHotKey = txtPlayScript.Text;
            SharedProperty.appSettings.RecordHotKey = txtStartRecording.Text;
            var modifierText = cbModifiers.SelectedItem?.ToString();
            if (modifierText!=null)
                SharedProperty.appSettings.PlayModifier = modifierText.Trim();
            if (cbLanguage.SelectedItem != null && !SharedProperty.appSettings.Language.ToLower().Equals(cbLanguage.SelectedItem))
            {
                SharedProperty.appSettings.Language = cbLanguage.SelectedItem.ToString().ToLower();
                MessageBox.Show(Language.Get("msg_language_changed"), Language.Get("info"));
            }
            SharedProperty.appSettings.Save(AppConstant.appSettings);
            SharedProperty.ToggleHotkey(this.Invoker,true);
            SharedProperty.UpdateHotkeys();
            SharedProperty.ToggleHotkey(this.Invoker);
            this.Close();
        }
    }
}
