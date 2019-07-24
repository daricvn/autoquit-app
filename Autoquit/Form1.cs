using Autoquit.Constant;
using SimpleControl;
using Autoquit.Models;
using Autoquit.Services;
using Autoquit.Views;
using MouseHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using static MouseHook.WinAPI;

namespace Autoquit
{
    public partial class Form1 : Form
    {
        private long TotalInterval { get; set; } = 0;
        private long TimeOffset { get; set; } = 0;
        private long TimeCount { get; set; } = 0;
        private const string languageFolder = "resources";
        private const string defaultPath = "scripts";
        private const string defaultLanguage = "en-us.json";
        private const int limitRecord = 512;
        private decimal remainingLoop = -1;
        private int currentRndSpeed = 0;
        private bool firstTime = false;
        private bool isSettingOpen = false;
        private InputSimulator _inputSender;
        private HashSet<WindowsInput.Native.VirtualKeyCode> keySet;
        private HashSet<MouseKey> mouseSet;
        private Recording _recordForm;
        private SystemKeyHold SysKey = new SystemKeyHold();
        private Random rnd = new Random();
        private PasswordLock _locker;
        private bool IsErrorDisplayed { get; set; }

        public Form1()
        {
            if (!System.IO.File.Exists(AppConstant.appSettings))
            {
                SharedProperty.appSettings = new Models.Settings();
                SharedProperty.appSettings.Language = defaultLanguage;
                SharedProperty.appSettings.Save(AppConstant.appSettings);
                SharedProperty.UpdateHotkeys(1000);
                firstTime = true;
            }
            else
            {
                SharedProperty.appSettings = new Models.Settings();
                var success=SharedProperty.appSettings.Read(AppConstant.appSettings);
                if (!success)
                {
                    SharedProperty.appSettings.Language = defaultLanguage;
                    SharedProperty.appSettings.Save(AppConstant.appSettings);
                }
                SharedProperty.UpdateHotkeys(1000);
                SharedProperty.ToggleHotkey(this);
            }
            string lang = System.IO.Path.Combine(languageFolder, SharedProperty.appSettings.Language);
            if (System.IO.File.Exists(lang))
                Language.Load(lang);
            else
            {
                MessageBox.Show("No localization file found. Cannot start the program.", "FATAL ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            InitializeComponent();
            Language.ApplyLanguage(this);

            versionLabel.Text = string.Format(versionLabel.Text, Autoquit.Program.AppVersion);
        }

        private WindowsInput.InputSimulator InputSender
        {
            get
            {
                if (keySet == null)
                    keySet = new HashSet<WindowsInput.Native.VirtualKeyCode>();
                if (mouseSet == null)
                    mouseSet = new HashSet<MouseKey>();
                if (_inputSender == null)
                    _inputSender = new WindowsInput.InputSimulator();
                return _inputSender;
            }
        }
        private Recording RecordingIndicator
        {
            get
            {
                if (_recordForm == null)
                    _recordForm = new Recording();
                return _recordForm;
            }
        }
        private PasswordLock Locker
        {
            get
            {
                if (_locker == null)
                    _locker = new PasswordLock();
                return _locker;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MouseHook.MouseHook.Start();
            MouseHook.KeyboardHook.Start();
            SetTooltip();
            MouseHook.MouseHook.MouseAction += MouseHook_MouseAction;
            MouseHook.KeyboardHook.KeyAction += KeyboardHook_KeyAction;
            LoadProcesses();
            ScriptGrid.Register(scriptGrid, new Script());
            List<string> eventType = new List<string>();
            ScriptGrid.BindColumnToList("EventType", LocalizationList.Create(AppConstant.SupportedEvents), "Value","Text");
            if (ScriptGrid.Column("SendInput") != null)
                ScriptGrid.Column("SendInput").Visible = SharedProperty.appSettings.AllowInputMode;
            CheckScriptFolder();
            UpdateRemainingText();
            cbPlaybackSpeed.SelectedIndex = 2;
            if (firstTime)
            {
                About ab = new About();
                ab.Invoker = this;
                this.Hide();
                ab.ShowDialog();
            }
        }

        private void Save(string path)
        {
            ScriptGrid.Script.LoopType = rdLoopByTime.Checked ? 1 : 0;
            if (rdLoopByTime.Checked)
            {
                ScriptGrid.Script.LoopCount = (int)txtTimeCount.Value;
                ScriptGrid.Script.LoopTimeType = cbTimeType.SelectedIndex;
            }
            ScriptContent.Write(path, ScriptGrid.Script);
        }

        private void SetTooltip()
        {
            ttGeneric.SetToolTip(btnAdd, Language.Get("add"));
            ttGeneric.SetToolTip(btnSave, Language.Get("save"));
            ttGeneric.SetToolTip(btnSaveAs, Language.Get("saveas"));
            ttGeneric.SetToolTip(btnChangeName, Language.Get("change_script_name"));
            ttGeneric.SetToolTip(btnUp, Language.Get("moveup"));
            ttGeneric.SetToolTip(btnDown, Language.Get("movedown"));
            ttGeneric.SetToolTip(btnUndo, Language.Get("undo"));
            ttGeneric.SetToolTip(btnNew, Language.Get("new"));
            ttGeneric.SetToolTip(btnLock, Language.Get("set_password"));
            ttGeneric.SetToolTip(chkDeepScan, Language.Get("msg_deepscan"));
        }
        private void SetEditControlEnable(bool enabled)
        {
            btnNew.Enabled = enabled;
            btnOpen.Enabled = enabled;
            btnAdd.Enabled = enabled;
            btnUp.Enabled = enabled;
            btnDown.Enabled = enabled;
            btnSettings.Enabled = enabled;
            if (enabled)
                ScriptGrid_SelectionChanged(null, null);
            btnChangeName.Enabled = enabled && !string.IsNullOrEmpty(txtFilePath.Text);
            btnSaveAs.Enabled = enabled && (ScriptGrid.Rows != null && ScriptGrid.Rows.Count > 0);
            btnSave.Enabled = enabled && !string.IsNullOrEmpty(txtFilePath.Text);
            btnUndo.Enabled= enabled && !string.IsNullOrEmpty(txtFilePath.Text);
            btnLock.Enabled = enabled && !string.IsNullOrEmpty(txtFilePath.Text);
        }
        private void UpdateRemainingText(bool renew=false)
        {
            if (cbTimeType.DataSource == null)
            {
                cbTimeType.DataSource=LocalizationList.Create(AppConstant.SupportedCondition);
                cbTimeType.ValueMember = "Value";
                cbTimeType.DisplayMember = "Text";
            }
            if (rdLoopByTime.Checked && cbTimeType.SelectedItem != null)
            {
                LocalizationList item = cbTimeType.SelectedItem as LocalizationList;
                if (renew)
                {
                    if (item.Value.Equals("BY_COUNT"))
                        remainingLoop = txtTimeCount.Value;
                    else
                    {
                        switch (item.Value)
                        {
                            case "BY_HOUR":
                                remainingLoop = txtTimeCount.Value * 3600;
                                break;
                            case "BY_MINUTE":
                                remainingLoop = txtTimeCount.Value * 60;
                                break;
                            default:
                                remainingLoop = txtTimeCount.Value;
                                break;
                        }
                    }
                }
                string unit = "";
                decimal displayValue = remainingLoop;
                if (item.Value == "BY_COUNT")
                {
                    unit = "times";
                }
                else
                {
                    if (playTimer.Enabled)
                    {
                        if (TotalInterval % 100 == 0)
                            remainingLoop--;
                        displayValue = remainingLoop;
                        if (remainingLoop == 0)
                        {
                            BtnPlay_Click(null, null);
                        }
                    }
                    if (remainingLoop >= 3600)
                    {
                        displayValue = Math.Ceiling(remainingLoop / 3600);
                        unit = "hour";
                    }
                    else if (remainingLoop >= 60)
                    {
                        displayValue = Math.Ceiling(remainingLoop / 60);
                        unit = "minute";
                    }
                    else
                    {
                        unit = "second";
                    }
                    if (displayValue >= 2)
                        unit += "s";
                }
                txtTimeLeft.Text = string.Format("{0} {1} {2}", displayValue,
                    Language.Get(unit).ToLower(), Language.Get("left."));
            }
            else txtTimeLeft.Text = "";
        }

        private void CheckScriptFolder()
        {
            string current = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string fullPath = System.IO.Path.Combine(current, defaultPath);
            if (!System.IO.Directory.Exists(fullPath))
                System.IO.Directory.CreateDirectory(fullPath);
            fileBrowser.InitialDirectory = fullPath;
            saveDialog.InitialDirectory = fullPath;
        }   
        private void UpdateRadioList()
        {
            if (ScriptGrid.Script!=null)
            {
                if (!string.IsNullOrWhiteSpace(ScriptGrid.Script.Name))
                    this.Text = string.Format("{0} - {1}", Program.AppName, ScriptGrid.Script.Name);
                else this.Text = Program.AppName;
                switch (ScriptGrid.Script.LoopType)
                {
                    case 1:
                        rdLoopByTime.Checked = true;
                        if (ScriptGrid.Script.LoopCount!=null)
                            txtTimeCount.Value = ScriptGrid.Script.LoopCount.Value;
                        if (ScriptGrid.Script.LoopTimeType != null && cbTimeType.Items.Count> ScriptGrid.Script.LoopTimeType)
                            cbTimeType.SelectedIndex = ScriptGrid.Script.LoopTimeType.Value;
                        break;
                    default:
                        rdLoopUnlimited.Checked = true;
                        break;
                }

            }
        }

        private void AppendList(string keyName, string keyType)
        {
            //listBox1.Items.Insert(0, item);
            //if (listBox1.Items.Count > 50)
            //    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
            long offset = TimeOffset * 10;
            if (ScriptGrid.Rows != null)
            {
                if (ScriptGrid.Rows.Count >= limitRecord && recordTimer.Enabled)
                {
                    ToggleRecord(true);
                    WinProcess.BringProcessToFront(Process.GetCurrentProcess());
                    MessageBox.Show(Language.Get("msg_limit_reached"), Language.Get("info"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ScriptGrid.Rows.Count > 0 && offset <= 300)
                {
                    var lastRow = ScriptGrid.LastRow; //ScriptGrid.Rows[ScriptGrid.Rows.Count - 1];
                    string lastEventType = lastRow.EventType.ToLower();
                    long lastOffset = lastRow.TimeOffset;
                    if (lastRow.KeyName == keyType)
                    {
                        if (lastEventType == "left_down" && keyName.ToLower() == "left_up")
                        {
                            offset += lastOffset;
                            ScriptGrid.RemoveAt(ScriptGrid.GridCount - 1);
                            keyName = "LEFT_CLICK";
                            //return;
                        }
                        if (lastEventType == "right_down" && keyName.ToLower() == "right_up")
                        {
                            offset += lastOffset;
                            ScriptGrid.RemoveAt(ScriptGrid.GridCount - 1);
                            keyName = "RIGHT_CLICK";
                            //return;
                        }
                        if (lastEventType == "key_down" && keyName.ToLower() == "key_up")
                        {
                            offset += lastOffset;
                            ScriptGrid.RemoveAt(ScriptGrid.GridCount - 1);
                            keyName = "KEY_PRESS";
                            //return;
                        }
                    }
                }
                if (AppConstant.SupportedEvents.Contains(keyName))
                    ScriptGrid.Add(new ScriptItem()
                    {
                        EventType = keyName,
                        KeyName = keyType,
                        TimeOffset = offset
                    });
                if (scriptGrid.RowCount > 0)
                {
                    if (scriptGrid.InvokeRequired)
                        scriptGrid.Invoke((MethodInvoker)(() => { scriptGrid.FirstDisplayedScrollingRowIndex = scriptGrid.RowCount - 1; }));
                    else
                        scriptGrid.FirstDisplayedScrollingRowIndex = scriptGrid.RowCount - 1;
                }
            }
            TimeOffset = 0;
        }

        private void KeyboardHook_KeyAction(MouseHook.KeyHookEventArgs args)
        {
            if (recordTimer.Enabled)
            {
                if (!SharedProperty.IsHotkey(args.Key, KeyModifier.None))
                    AppendList(Enum.GetName(args.Type.GetType(), args.Type), Enum.GetName(args.Key.GetType(), args.Key));

            }
        }

        private void ClearListProcess()
        {
            var currentIndex = 0;
            var count = 0;
            if (!listProcess.InvokeRequired)
            {
                currentIndex = listProcess.SelectedIndex;
                count = listProcess.Items.Count;
            }
            else
            {
                listProcess.Invoke((MethodInvoker)(() =>
                {
                    currentIndex = listProcess.SelectedIndex;
                    count = listProcess.Items.Count;
                }));
            }
                for (var i = count - 1; i >= 0; i--)
                    if (i != currentIndex)
                    {
                        if (!listProcess.InvokeRequired)
                            listProcess.Items.RemoveAt(i);
                        else listProcess.Invoke((MethodInvoker)(() =>
                        {
                            listProcess.Items.RemoveAt(i);
                        }));
                    }
        }
        private object List_FindItemById(int Id)
        {
            for (var i = 0; i < listProcess.Items.Count; i++)
                if (Convert.ToInt32((listProcess.Items[i] as DropDownItem).Id) == Id)
                    return listProcess.Items[i];
            return null;
        }

        private void LoadProcesses(bool deep = false)
        {
            scanProgress.Visible = true;
            scanProgress.Value = 0;
            Task.Run(() =>
            {
                ClearListProcess();
                List<Process> procs = new List<Process>(WinProcess.RunningProcesses);
                var maxCount = procs.Count;
                var current = 0;
                var progress = 0;
                procs.Sort((a, b) => string.Compare(a.ProcessName, b.ProcessName));
                foreach (Process p in procs)
                {
                    try
                    {
                        if (!p.HasExited && (deep || p.MainWindowHandle != IntPtr.Zero)
                        && p.Id != Process.GetCurrentProcess().Id)
                        {

                            Icon icon = null;
                            try
                            {
                                icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                            }
                            catch (Exception e) {
                                icon = Program.DefaultFormIcon;
                            }
                            string name = !string.IsNullOrEmpty(p.MainWindowTitle) ? p.MainWindowTitle : p.ProcessName;
                            var title = string.Format("{0} ({1})", name, p.Id);
                            if (List_FindItemById(p.Id) == null) {
                                if (listProcess.InvokeRequired)
                                    listProcess.Invoke((MethodInvoker)(() =>
                                    {
                                        listProcess.Items.Add(new DropDownItem(p.Id, title, icon));
                                    }));
                                else
                                    listProcess.Items.Add(new DropDownItem(p.Id, title, icon));
                                    }
                        }
                    }
                    catch (Exception e)
                    { }
                    current++;
                    if (current - progress > 5)
                    {
                        progress = (int) Math.Ceiling((decimal) current / maxCount)*100;
                        if (progress < 0)
                            progress = 0;
                        if (progress > 100)
                            progress = 100;
                        if (scanProgress.InvokeRequired)
                            scanProgress.Invoke((MethodInvoker)(() =>
                            {
                                scanProgress.Value = progress;
                            }));
                        else scanProgress.Value = progress;
                    }
                }
                if (scanProgress.InvokeRequired)
                    scanProgress.Invoke((MethodInvoker)(() =>
                    {
                        scanProgress.Visible = false;
                    }));
                else scanProgress.Visible = false;
            });
        }

        private void MouseHook_MouseAction(MouseHook.MouseHookEventArgs arg)
        {
            if (recordTimer.Enabled)
            {
                try
                {
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Process process = null;
                    if (listProcess.InvokeRequired)
                        listProcess.Invoke((MethodInvoker)(() =>
                        {
                            process = Process.GetProcessById((int)((DropDownItem)listProcess.SelectedItem).Id);
                        }));
                    else
                        process = Process.GetProcessById((int)((DropDownItem)listProcess.SelectedItem).Id);
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)(() =>
                        {
                            AppendList(Enum.GetName(arg.Key.GetType(), arg.Key),
                                WinAPI.RetrieveCoord(process.MainWindowHandle, Cursor.Position.X, Cursor.Position.Y));
                        }));
                    else
                        AppendList(Enum.GetName(arg.Key.GetType(), arg.Key),
                            WinAPI.RetrieveCoord(process.MainWindowHandle, Cursor.Position.X, Cursor.Position.Y));
                }
                catch (Exception e) { }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!BringProcessToFront())
            {
                MessageBox.Show(Language.Get("msg_access_denied") ?? "Access denied.",
                    Language.Get("error") ?? "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool BringProcessToFront()
        {
            if (listProcess.SelectedItem != null)
            {
                DropDownItem item = listProcess.SelectedItem as DropDownItem;
                if (item != null)
                {
                    try
                    {
                        var p = Process.GetProcessById(Convert.ToInt32(item.Id));
                        if (p.HasExited || p.MainWindowHandle == IntPtr.Zero)
                        {
                            return false;
                        }
                        else
                        {
                            WinProcess.BringProcessToFront(p);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        ProcessExited();
                    }
                }
            }
            return false;
        }

        private void ListProcess_DropDown(object sender, EventArgs e)
        {
        }

        private void ListScanCooldown_Tick(object sender, EventArgs e)
        {
            btnScan.Enabled = true;
            chkDeepScan.Enabled = true;
            listScanCooldown.Enabled = false;
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            if (!listScanCooldown.Enabled)
            {
                btnScan.Enabled = false;
                chkDeepScan.Enabled = false;
                listScanCooldown.Enabled = true;
                LoadProcesses(chkDeepScan.Checked);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (playTimer.Enabled)
            {
                var result=MessageBox.Show(Language.Get("msg_script_isplaying"),
                    Language.Get("confirmation"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result== DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (keySet != null && keySet.Count > 0)
            {
                foreach (var vk in keySet)
                    InputSender.Keyboard.KeyUp(vk);
                keySet.Clear();
            }
            // Fix permanent mouse down bug
            if (mouseSet != null && mouseSet.Count > 0)
            {
                foreach (var mk in mouseSet)
                    if (mk == MouseKey.LEFT_DOWN)
                        InputSender.Mouse.LeftButtonUp();
                    else if (mk == MouseKey.RIGHT_DOWN)
                        InputSender.Mouse.RightButtonUp();
                mouseSet.Clear();
            }
            MouseHook.MouseHook.Stop();
            MouseHook.KeyboardHook.Stop();
        }

        private void ScriptGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ToggleRecord(bool auto=false)
        {
            if (playTimer.Enabled) return;
            TimeOffset = 0;
            if (recordTimer.Enabled)
            {
                if (btnRecord.InvokeRequired)
                    btnRecord.Invoke((MethodInvoker)(() => {
                        btnRecord.Image = global::Autoquit.Properties.Resources.record;
                    }));
                else
                    btnRecord.Image = global::Autoquit.Properties.Resources.record;
                if (!auto)
                    ScriptGrid.RemoveAt(ScriptGrid.GridCount - 1);
                RecordingIndicator.Hide();
            }
            else
            {
                if (ScriptGrid.Rows.Count >= limitRecord)
                {
                    IsErrorDisplayed = true;
                    MessageBox.Show(Language.Get("msg_limit_reached"), Language.Get("info"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    IsErrorDisplayed = false;
                    return;
                }
                if (btnRecord.InvokeRequired)
                    btnRecord.Invoke((MethodInvoker)(() => {
                        btnRecord.Image = global::Autoquit.Properties.Resources.stop;
                    }));
                else
                    btnRecord.Image = global::Autoquit.Properties.Resources.stop;
                if (!BringProcessToFront())
                {
                    IsErrorDisplayed = true;
                    MessageBox.Show(Language.Get("msg_access_denied") ?? "Access denied.",
                        Language.Get("error") ?? "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsErrorDisplayed = false;
                    return;
                }
                RecordingIndicator.Show();
                RecordingIndicator.Location = new Point(0, 0);
                RecordingIndicator.FullWidth();
            }
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)(() => { recordTimer.Enabled = !recordTimer.Enabled; }));
            else
                recordTimer.Enabled = !recordTimer.Enabled;
            if (btnRecord.InvokeRequired)
                btnPlay.Invoke((MethodInvoker)(() => {
                    btnPlay.Enabled = listProcess.SelectedItem != null && !recordTimer.Enabled;
                }));
            else
                btnPlay.Enabled = listProcess.SelectedItem != null && !recordTimer.Enabled;
            string tag = btnRecord.Tag.ToString();

            if (btnRecord.InvokeRequired)
                btnRecord.Invoke((MethodInvoker)(() =>
                {
                    btnRecord.Tag = btnRecord.Text;
                    btnRecord.Text = tag;
                }));
            else
            {
                btnRecord.Tag = btnRecord.Text;
                btnRecord.Text = tag;
            }
        }
        private void BtnRecord_Click(object sender, EventArgs e)
        {
            ToggleRecord();
        }

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            TimeOffset += recordTimer.Interval/10;
        }

        private void ChkDeepScan_CheckedChanged(object sender, EventArgs e)
        {
            BtnScan_Click(null, null);
        }

        private void ProcessExited(bool msg = false)
        {
            var selected = listProcess.SelectedItem;
            listProcess.SelectedIndex = -1;
            if (selected!=null)
                listProcess.Items.Remove(selected);
            cbWindows.Items.Clear();
            cbWindows.Enabled = false;
            if (msg)
                MessageBox.Show(Language.Get("msg_process_exited"),
                    Language.Get("info"));
        }
        private void ListProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbWindows.Enabled = listProcess.SelectedItem != null;
            btnToFront.Enabled = listProcess.SelectedItem != null;
            btnPlay.Enabled = listProcess.SelectedItem != null && !recordTimer.Enabled;
            btnRecord.Enabled = !playTimer.Enabled && listProcess.SelectedItem != null;
            var selected = (DropDownItem)listProcess.SelectedItem;
            if (selected != null)
            {
                Process process;
                try
                {
                    process = Process.GetProcessById((int)selected.Id);
                }
                catch (Exception ex)
                {
                    ProcessExited(true);
                    return;
                }
                cbWindows.Items.Clear();
                var mainWindow = selected.Clone(process.MainWindowHandle);
                mainWindow.Value = "Main Window";
                cbWindows.Items.Add(mainWindow);
                cbWindows.SelectedIndex = 0;
                if (!(process == null || process.HasExited))
                {
                    var childs = WinProcess.GetAllChildHandles(process.MainWindowHandle);
                    string title = "";
                    foreach (var item in childs)
                        if (item != IntPtr.Zero)
                        {
                            title = string.Format("{0} ({1})", WinProcess.GetWindowName(item), item);
                            cbWindows.Items.Add(new DropDownItem(item, title, selected.Icon));
                        }
                }
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (ScriptGrid.Rows == null || ScriptGrid.Rows.Count == 0 ||
                listProcess.SelectedItem == null)
            {
                IsErrorDisplayed = true;
                MessageBox.Show(Language.Get("msg_incompatible_script"), Language.Get("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                IsErrorDisplayed = false;
                return;
            }
            if (recordTimer.Enabled) return;
            if (!playTimer.Enabled && !string.IsNullOrEmpty(ScriptGrid.Script?.Password))
            {
                SharedProperty.ToggleHotkey(this, true);
                Locker.ShowDialog();
                SharedProperty.ToggleHotkey(this);
                if (!Locker.Success)
                {
                    return;
                }
                Locker.Success = false;
            }
            playTimer.Enabled = !playTimer.Enabled;
            if (playTimer.Enabled)
            {
                btnPlay.Image = global::Autoquit.Properties.Resources.stop;
                UpdateRemainingText(true);
            }
            else
            {
                btnPlay.Image = global::Autoquit.Properties.Resources.play;
                // Fix permanent hold bug
                if (keySet != null && keySet.Count > 0)
                {
                    foreach (var vk in keySet)
                        InputSender.Keyboard.KeyUp(vk);
                    keySet.Clear();
                }
                // Fix permanent mouse down bug
                if (mouseSet != null && mouseSet.Count > 0)
                {
                    foreach (var mk in mouseSet)
                        if (mk == MouseKey.LEFT_DOWN)
                            InputSender.Mouse.LeftButtonUp();
                        else if (mk== MouseKey.RIGHT_DOWN)
                            InputSender.Mouse.RightButtonUp();
                    mouseSet.Clear();
                }
            }
            scriptGrid.Enabled = !playTimer.Enabled;
            listProcess.Enabled = !playTimer.Enabled;
            string tag = btnPlay.Tag.ToString();
            btnPlay.Tag = btnPlay.Text;
            btnPlay.Text = tag;
            btnRecord.Enabled = !playTimer.Enabled && listProcess.SelectedItem != null; 
            TotalInterval = 0;
            ScriptGrid.SelectRow(0);
            gbPlaybackOption.Enabled= !playTimer.Enabled;
            gbPlaybackInfo.Enabled = !playTimer.Enabled;
            SetEditControlEnable(!playTimer.Enabled);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            SharedProperty.ToggleHotkey(this, true);
            var result=fileBrowser.ShowDialog();
            SharedProperty.ToggleHotkey(this);
            if (result==DialogResult.OK)
            {
                txtFilePath.Text = fileBrowser.FileName;
                var script=ScriptContent.Read<Script>(fileBrowser.FileName);
                if (script != null)
                {
                    ScriptGrid.Bind(script, true);
                    UpdateRadioList();
                }
                else
                {
                    MessageBox.Show(Language.Get("msg_corrupted_file"),
                        Language.Get("error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ScriptGrid.New();
            btnSaveAs.Enabled = (ScriptGrid.Rows != null && ScriptGrid.Rows.Count > 0);
        }

        private void ScriptGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (!playTimer.Enabled)
            {
                btnUp.Enabled = scriptGrid.SelectedRows.Count > 0;
                btnDown.Enabled = scriptGrid.SelectedRows.Count > 0;
                if (scriptGrid.SelectedRows.Count > 0)
                {
                    if (scriptGrid.SelectedRows[0].Index == 0)
                        btnUp.Enabled = false;
                    if (scriptGrid.SelectedRows[0].Index == scriptGrid.Rows.Count - 1)
                        btnDown.Enabled = false;
                }
            }
        }

        private void RdLoopByTime_CheckedChanged(object sender, EventArgs e)
        {
            txtTimeCount.Enabled = rdLoopByTime.Checked;
            cbTimeType.Enabled = rdLoopByTime.Checked;
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            var speedText = cbPlaybackSpeed.SelectedItem.ToString();
            int speed = 0;
            if (speedText.Contains("Random"))
            {
                if (currentRndSpeed==0)
                    currentRndSpeed= (new Random().Next(1, 8)) * 25;
                speed = currentRndSpeed;
            }
            else
                speed = int.Parse((speedText.Substring(0, speedText.Length - 1)));
            TotalInterval += playTimer.Interval / 10;
            TimeOffset += ((playTimer.Interval / 10)*speed/100);
            ProcessWinEvents();
            UpdateRemainingText();
        }

        private void ProcessWinEvents()
        {
            long offset = TimeOffset * 10;
            if (ScriptGrid.SelectedRow == null)
                ScriptGrid.SelectRow(0);
            if ((bool?) ScriptGrid.SelectedRow.Cells["Active"]?.Value == false)
            {
                if (ScriptGrid.SelectedRow.Index == ScriptGrid.Rows.Count - 1)
                    ScriptGrid.SelectRow(0);
                else
                    ScriptGrid.SelectRow(ScriptGrid.SelectedRow.Index + 1);
                return;
            }
            if (offset>=(long) (ScriptGrid.SelectedRow.Cells["TimeOffset"]?.Value ?? 0))
            {
                var eventType = ScriptGrid.SelectedRow.Cells["EventType"]?.Value?.ToString();
                var keyName = ScriptGrid.SelectedRow.Cells["KeyName"]?.Value?.ToString();
                bool manipulate = ScriptGrid.Column("SendInput").Visible && (bool) ScriptGrid.SelectedRow.Cells["SendInput"].Value;
                if (eventType != "DO_NOTHING")
                {
                    Process process = null;
                    try
                    {
                        process = Process.GetProcessById((int)((DropDownItem)listProcess.SelectedItem).Id);
                    } catch(Exception e)
                    {
                        BtnPlay_Click(null, null);
                        MessageBox.Show(Language.Get("msg_process_exited"), Language.Get("error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (process == null || process.HasExited)
                    {
                        BtnPlay_Click(null, null);
                        MessageBox.Show(Language.Get("msg_process_exited"), Language.Get("error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MouseHook.MouseKey mouseKey;
                    MouseHook.KeyType keyboardKey;
                    var targetWindows = (IntPtr) (((DropDownItem)cbWindows.SelectedItem).Id); //process.MainWindowHandle;
                    int failCount = 0;
                    if (Enum.TryParse(eventType, out mouseKey))
                    {
                        var coord = keyName?.Split(':');
                        if (coord != null && coord.Length == 2)
                        {
                            int x, y;
                            if (int.TryParse(coord[0], out x) && int.TryParse(coord[1], out y))
                            {
                                if (!manipulate)
                                    MouseHook.WinAPI.SendMouseEx(targetWindows, mouseKey, x, y);
                                else
                                {
                                    ManipulateMouse(process.MainWindowHandle, mouseKey, x, y);
                                }
                            }
                            else
                            {
                                BtnPlay_Click(null, null);
                                MessageBox.Show(Language.Get("msg_invalid_coord"), Language.Get("error"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            BtnPlay_Click(null, null);
                            MessageBox.Show(Language.Get("msg_invalid_coord"), Language.Get("error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else failCount++;
                    if (Enum.TryParse(eventType, out keyboardKey))
                    {
                        Keys key;
                        if (keyName != null && keyName.Length == 1)
                            keyName = keyName.ToUpper();
                        if (Enum.TryParse(keyName, out key))
                        {
                            if (!manipulate)
                            {
                                if (SharedProperty.appSettings.AllowInputMode && !SysKey.IsSysKey(key))
                                    SysKey.Down(InputSender);
                                MouseHook.WinAPI.SendKeyboard(targetWindows, keyboardKey, key);
                                if (SharedProperty.appSettings.AllowInputMode && !SysKey.IsSysKey(key))
                                    SysKey.Release(InputSender);
                                if (SharedProperty.appSettings.AllowInputMode && SysKey.IsSysKey(key) && keyboardKey == KeyType.KEY_UP)
                                    SysKey.Switch(key, false);
                            }
                            else
                            {
                                ManipulateKeyboard(keyboardKey, key);
                            }
                        }
                        else
                        {
                            BtnPlay_Click(null, null);
                            MessageBox.Show(Language.Get("msg_invalid_agrument"), Language.Get("error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else failCount++;
                    if ((eventType == "ENTER_TEXT" || eventType == "ENTER_SECRET" || eventType == "RANDOM_TEXT") && !string.IsNullOrWhiteSpace(keyName))
                    {
                        Keys key;
                        string keyList;
                        bool shouldShift = false;
                        if (eventType == "ENTER_TEXT" || eventType == "ENTER_SECRET" || !keyName.Contains(";"))
                            keyList = keyName;
                        else
                        {
                            var keyNames = keyName.Replace(";;",";").Split(';');
                            var outLoop = 100;
                            do
                            {
                                keyList = keyNames[rnd.Next(0, keyNames.Length - 1)];
                                outLoop--;
                            }
                            while (string.IsNullOrEmpty(keyList) || keyNames.Length == 1 || outLoop<=0);
                        }
                        foreach (char charKey in keyList)
                        {
                            if ((key=KeyMapper.Get(charKey, out shouldShift))!=Keys.None)
                            {
                                failCount = 0;
                                if (!manipulate)
                                {
                                    MouseHook.WinAPI.SendKeyboard(targetWindows, KeyType.KEY_PRESS, key);
                                }
                                else
                                {
                                    WindowsInput.Native.VirtualKeyCode vk = (WindowsInput.Native.VirtualKeyCode)Enum.ToObject(typeof(WindowsInput.Native.VirtualKeyCode), (int)key);
                                    if (shouldShift)
                                        InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                                    InputSender.Keyboard.KeyPress(vk);
                                    if (shouldShift)
                                        InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                                }
                            }
                        }
                    }
                    if (failCount >= 2)
                    {
                        BtnPlay_Click(null, null);
                        MessageBox.Show(Language.Get("msg_invalid_agrument"), Language.Get("error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                TimeOffset = 0;
                if (ScriptGrid.SelectedRow.Index == ScriptGrid.Rows.Count - 1)
                {
                    ScriptGrid.SelectRow(0);
                    if ("Random...".Equals(cbPlaybackSpeed.SelectedItem))
                        currentRndSpeed = (rnd.Next(2, 8)) * 25;
                    TimeCount++;
                    if (rdLoopByTime.Checked && cbTimeType.SelectedItem != null)
                    {
                        LocalizationList item = cbTimeType.SelectedItem as LocalizationList;
                        if ("BY_COUNT".Equals(item.Value))
                            if (remainingLoop > 1)
                                remainingLoop--;
                            else
                            {
                                remainingLoop = 0;
                                BtnPlay_Click(null, null);
                            }
                        
                    }
                    if ((TimeCount) % 50==0 && TotalInterval > 30000)
                        GC.Collect();
                }
                else
                    ScriptGrid.SelectRow(ScriptGrid.SelectedRow.Index + 1);
            }
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SharedProperty.ToggleHotkey(this, true);
            var result = saveDialog.ShowDialog();
            SharedProperty.ToggleHotkey(this);
            if (result== DialogResult.OK)
            {
                txtFilePath.Text = saveDialog.FileName;
                Save(txtFilePath.Text);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (ScriptGrid.Rows!=null && ScriptGrid.Rows.Count>0)
            {
                var result = MessageBox.Show(Language.Get("prompt_new"), Language.Get("confirmation"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result== DialogResult.Yes)
                {
                    ScriptGrid.Script.Scripts.Clear();
                }
            }
        }

        private void TxtFilePath_TextChanged(object sender, EventArgs e)
        {
            btnChangeName.Enabled = !string.IsNullOrEmpty(txtFilePath.Text);
            btnSave.Enabled = !string.IsNullOrEmpty(txtFilePath.Text);
            btnUndo.Enabled = !string.IsNullOrEmpty(txtFilePath.Text);
            btnLock.Enabled = !string.IsNullOrEmpty(txtFilePath.Text);
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (ScriptGrid.SelectedRow != null)
            {
                var currentIndex = ScriptGrid.SelectedRow.Index;
                var item = ScriptGrid.Script.Scripts[currentIndex];
                ScriptGrid.Script.Scripts.RemoveAt(currentIndex);
                ScriptGrid.Script.Scripts.Insert(currentIndex-1,item);
                ScriptGrid.SelectRow(currentIndex - 1);
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (ScriptGrid.SelectedRow != null)
            {
                var currentIndex = ScriptGrid.SelectedRow.Index;
                var item = ScriptGrid.Script.Scripts[currentIndex];
                ScriptGrid.Script.Scripts.RemoveAt(currentIndex);
                ScriptGrid.Script.Scripts.Insert(currentIndex + 1, item);
                ScriptGrid.SelectRow(currentIndex + 1);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            ScriptGrid.UpdateIndex();
            Save(txtFilePath.Text);
            btnSave.Enabled = !string.IsNullOrEmpty(txtFilePath.Text);
            MessageBox.Show(Language.Get("msg_saved"), Language.Get("info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Language.Get("prompt_undo"), Language.Get("confirmatio"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtFilePath.Text = fileBrowser.FileName;
                var script = ScriptContent.Read<Script>(txtFilePath.Text);
                if (script != null)
                {
                    ScriptGrid.Bind(script, true);
                    UpdateRadioList();
                }
            }
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Invoker = this;
            ab.ShowDialog();
        }

        private void BtnChangeName_Click(object sender, EventArgs e)
        {
            ChangeName form = new ChangeName();
            form.Invoker = this;
            SharedProperty.ToggleHotkey(this, true);
            form.ShowDialog();
            SharedProperty.ToggleHotkey(this);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SharedProperty.ToggleHotkey(this, true);
            Views.Settings form = new Views.Settings();
            form.Invoker = this;
            form.ShowDialog();
            SharedProperty.ToggleHotkey(this, false);
        }
        #region Hotkey Handler
        // Hot key handler

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                MouseHook.KeyModifier modifier = (MouseHook.KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
                if (SharedProperty.IsHotkey(id,key,modifier) && !isSettingOpen && !IsErrorDisplayed)
                {
                    var hotkey = SharedProperty.FindHotkey(id);
                    if (hotkey.event_name == "PLAY")
                        BtnPlay_Click(null, null);
                    if (hotkey.event_name == "RECORD")
                        ToggleRecord(true);
                }

                // do something
            }
        }

        internal WindowsInput.Native.VirtualKeyCode ToVirtualKey(Keys key)
        {
            return (WindowsInput.Native.VirtualKeyCode)Enum.ToObject(typeof(WindowsInput.Native.VirtualKeyCode), (int)key);
        }

        internal void ManipulateKeyboard(KeyType keyboardKey, Keys key)
        {
            WindowsInput.Native.VirtualKeyCode vk = ToVirtualKey(key);
            if (InputSender!=null)
                switch (keyboardKey)
                {
                    case KeyType.KEY_DOWN:
                        if (!SysKey.Switch(key,true))
                        {
                            SysKey.Down(InputSender);
                            InputSender.Keyboard.KeyDown(vk);
                        }
                        keySet.Add(vk);
                        break;
                    case KeyType.KEY_UP:
                        if (!SysKey.IsSysKey(key))
                        {
                            SysKey.Release(InputSender);
                            InputSender.Keyboard.KeyUp(vk);
                        }
                        else SysKey.Switch(key, false);
                        if (keySet.Contains(vk))
                            keySet.Remove(vk);
                        break;
                    default:
                        SysKey.Down(InputSender);
                        InputSender.Keyboard.KeyPress(vk);
                        SysKey.Release(InputSender);
                        break;
                }
        }
        internal void ManipulateMouse(IntPtr hWnd, MouseKey mouseKey, int x, int y)
        {
            Rect rct = new Rect();
            if (WinAPI.GetWindowRect(hWnd, ref rct))
            {
                double rx = (x + rct.Left) * 65535 / (Screen.PrimaryScreen.Bounds.Width - 1);
                double ry = (y + rct.Top) * 65535 / (Screen.PrimaryScreen.Bounds.Height - 1);
                InputSender.Mouse.MoveMouseToPositionOnVirtualDesktop(rx,ry);
                switch (mouseKey)
                {
                    case MouseKey.LEFT_CLICK:
                        InputSender.Mouse.LeftButtonClick();
                        break;
                    case MouseKey.LEFT_DBCLICK:
                        InputSender.Mouse.LeftButtonDoubleClick();
                        break;
                    case MouseKey.LEFT_DOWN:
                        InputSender.Mouse.LeftButtonDown();
                        mouseSet.Add(mouseKey);
                        break;
                    case MouseKey.LEFT_UP:
                        InputSender.Mouse.LeftButtonUp();
                        if (mouseSet.Contains(MouseKey.LEFT_DOWN))
                            mouseSet.Remove(MouseKey.LEFT_DOWN);
                        break;
                    case MouseKey.RIGHT_CLICK:
                        InputSender.Mouse.RightButtonClick();
                        break;
                    case MouseKey.RIGHT_DBCLICK:
                        InputSender.Mouse.RightButtonDoubleClick();
                        break;
                    case MouseKey.RIGHT_DOWN:
                        InputSender.Mouse.RightButtonDown();
                        mouseSet.Add(mouseKey);
                        break;
                    case MouseKey.RIGHT_UP:
                        InputSender.Mouse.RightButtonUp();
                        if (mouseSet.Contains(MouseKey.RIGHT_DOWN))
                            mouseSet.Remove(MouseKey.RIGHT_DOWN);
                        break;
                }
            }
        }
        #endregion


        private class SystemKeyHold
        {
            public bool ShiftHold=false;
            public bool LShiftHold = false;
            public bool RShiftHold = false;
            public bool LCtrlHold=false;
            public bool RCtrlHold = false;
            public bool RMenu = false;
            public bool LMenu = false;
            public bool IsSysKey(Keys key)
            {
                return key == Keys.Shift ||
                    key == Keys.LControlKey || key == Keys.RControlKey ||
                    key==Keys.LShiftKey || key==Keys.RShiftKey ||
                    key==Keys.LMenu || key==Keys.RMenu
                    ;
            }
            public bool Switch(Keys key, bool set)
            {
                switch (key)
                {
                    case Keys.Shift:
                        ShiftHold = set;
                        return true;
                    case Keys.LShiftKey:
                        LShiftHold = set;
                        return true;
                    case Keys.RShiftKey:
                        RShiftHold = set;
                        return true;
                    case Keys.LControlKey:
                        LCtrlHold = set;
                        return true;
                    case Keys.RControlKey:
                        RCtrlHold = set;
                        return true;
                    case Keys.LMenu:
                        LMenu = set;
                        return true;
                    case Keys.RMenu:
                        RMenu = set;
                        return true;
                }
                return false;
            }
            public void Down(IInputSimulator InputSender)
            {
                if (ShiftHold)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.SHIFT);
                else
                if (LShiftHold)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                else
                if (RShiftHold)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RSHIFT);
                if (LCtrlHold)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                if (RCtrlHold)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RCONTROL);
                if (LMenu)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LMENU);
                else
                if (RMenu)
                    InputSender.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RMENU);
            }
            public void Release(IInputSimulator InputSender)
            {
                if (ShiftHold)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.SHIFT);
                else
                if (LShiftHold)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                else
                if (RShiftHold)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RSHIFT);
                if (LCtrlHold)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                if (RCtrlHold)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RCONTROL);
                if (LMenu)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LMENU);
                else
                if (RMenu)
                    InputSender.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RMENU);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var helpLink = new UsageHelp();
            helpLink.ShowDialog();
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            var form = new ChangePassword();
            SharedProperty.ToggleHotkey(this, true);
            form.ShowDialog();
            SharedProperty.ToggleHotkey(this);
            form.Dispose();
        }
    }
}
