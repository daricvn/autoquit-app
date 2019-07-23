using SimpleControl;

namespace Autoquit
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnToFront = new System.Windows.Forms.Button();
            this.listScanCooldown = new System.Windows.Forms.Timer(this.components);
            this.btnScan = new System.Windows.Forms.Button();
            this.recordTimer = new System.Windows.Forms.Timer(this.components);
            this.scriptGrid = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.chkDeepScan = new System.Windows.Forms.CheckBox();
            this.scanProgress = new System.Windows.Forms.ProgressBar();
            this.playTimer = new System.Windows.Forms.Timer(this.components);
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.gbPlaybackOption = new System.Windows.Forms.GroupBox();
            this.cbPlaybackSpeed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTimeType = new System.Windows.Forms.ComboBox();
            this.txtTimeCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rdLoopByTime = new System.Windows.Forms.RadioButton();
            this.rdLoopUnlimited = new System.Windows.Forms.RadioButton();
            this.gbPlaybackInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeLeft = new System.Windows.Forms.TextBox();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.versionLabel = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWindows = new SimpleControl.SimpleSelectBox();
            this.listProcess = new SimpleControl.SimpleSelectBox();
            this.ttGeneric = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnLock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scriptGrid)).BeginInit();
            this.gbPlaybackOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeCount)).BeginInit();
            this.gbPlaybackInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToFront
            // 
            this.btnToFront.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnToFront.Enabled = false;
            this.btnToFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToFront.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToFront.Location = new System.Drawing.Point(630, 12);
            this.btnToFront.Name = "btnToFront";
            this.btnToFront.Size = new System.Drawing.Size(146, 27);
            this.btnToFront.TabIndex = 2;
            this.btnToFront.Text = "@bring_to_front";
            this.btnToFront.UseVisualStyleBackColor = false;
            this.btnToFront.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listScanCooldown
            // 
            this.listScanCooldown.Interval = 3000;
            this.listScanCooldown.Tick += new System.EventHandler(this.ListScanCooldown_Tick);
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(480, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(144, 27);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "@scan";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // recordTimer
            // 
            this.recordTimer.Interval = 50;
            this.recordTimer.Tick += new System.EventHandler(this.RecordTimer_Tick);
            // 
            // scriptGrid
            // 
            this.scriptGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scriptGrid.Location = new System.Drawing.Point(12, 73);
            this.scriptGrid.Name = "scriptGrid";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scriptGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.scriptGrid.Size = new System.Drawing.Size(441, 380);
            this.scriptGrid.TabIndex = 6;
            this.scriptGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScriptGrid_CellContentClick);
            this.scriptGrid.SelectionChanged += new System.EventHandler(this.ScriptGrid_SelectionChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(641, 477);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 32);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "@exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(641, 439);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(135, 32);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "@settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 503);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(319, 20);
            this.txtFilePath.TabIndex = 13;
            this.txtFilePath.TextChanged += new System.EventHandler(this.TxtFilePath_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(337, 501);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(116, 23);
            this.btnOpen.TabIndex = 14;
            this.btnOpen.Text = "@open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // chkDeepScan
            // 
            this.chkDeepScan.Location = new System.Drawing.Point(480, 45);
            this.chkDeepScan.Name = "chkDeepScan";
            this.chkDeepScan.Size = new System.Drawing.Size(160, 26);
            this.chkDeepScan.TabIndex = 18;
            this.chkDeepScan.Text = "@deep_scan";
            this.chkDeepScan.UseVisualStyleBackColor = true;
            this.chkDeepScan.CheckedChanged += new System.EventHandler(this.ChkDeepScan_CheckedChanged);
            // 
            // scanProgress
            // 
            this.scanProgress.Location = new System.Drawing.Point(-1, 536);
            this.scanProgress.Name = "scanProgress";
            this.scanProgress.Size = new System.Drawing.Size(799, 10);
            this.scanProgress.TabIndex = 19;
            this.scanProgress.Visible = false;
            // 
            // playTimer
            // 
            this.playTimer.Interval = 50;
            this.playTimer.Tick += new System.EventHandler(this.PlayTimer_Tick);
            // 
            // fileBrowser
            // 
            this.fileBrowser.FileName = "*.script";
            this.fileBrowser.Filter = "Script Files|*.script";
            // 
            // gbPlaybackOption
            // 
            this.gbPlaybackOption.Controls.Add(this.cbPlaybackSpeed);
            this.gbPlaybackOption.Controls.Add(this.label4);
            this.gbPlaybackOption.Controls.Add(this.cbTimeType);
            this.gbPlaybackOption.Controls.Add(this.txtTimeCount);
            this.gbPlaybackOption.Controls.Add(this.label3);
            this.gbPlaybackOption.Controls.Add(this.rdLoopByTime);
            this.gbPlaybackOption.Controls.Add(this.rdLoopUnlimited);
            this.gbPlaybackOption.Location = new System.Drawing.Point(480, 133);
            this.gbPlaybackOption.Name = "gbPlaybackOption";
            this.gbPlaybackOption.Size = new System.Drawing.Size(296, 157);
            this.gbPlaybackOption.TabIndex = 21;
            this.gbPlaybackOption.TabStop = false;
            this.gbPlaybackOption.Text = "@playback_option";
            // 
            // cbPlaybackSpeed
            // 
            this.cbPlaybackSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbPlaybackSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaybackSpeed.FormattingEnabled = true;
            this.cbPlaybackSpeed.Items.AddRange(new object[] {
            "50%",
            "75%",
            "100%",
            "125%",
            "150%",
            "200%",
            "Random..."});
            this.cbPlaybackSpeed.Location = new System.Drawing.Point(173, 123);
            this.cbPlaybackSpeed.Name = "cbPlaybackSpeed";
            this.cbPlaybackSpeed.Size = new System.Drawing.Size(106, 21);
            this.cbPlaybackSpeed.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "@playback_speed";
            // 
            // cbTimeType
            // 
            this.cbTimeType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeType.Enabled = false;
            this.cbTimeType.FormattingEnabled = true;
            this.cbTimeType.Location = new System.Drawing.Point(150, 93);
            this.cbTimeType.Name = "cbTimeType";
            this.cbTimeType.Size = new System.Drawing.Size(129, 21);
            this.cbTimeType.TabIndex = 9;
            // 
            // txtTimeCount
            // 
            this.txtTimeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeCount.Enabled = false;
            this.txtTimeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCount.Location = new System.Drawing.Point(64, 93);
            this.txtTimeCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtTimeCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTimeCount.Name = "txtTimeCount";
            this.txtTimeCount.Size = new System.Drawing.Size(80, 21);
            this.txtTimeCount.TabIndex = 8;
            this.txtTimeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeCount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.txtTimeCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "@loop_count";
            // 
            // rdLoopByTime
            // 
            this.rdLoopByTime.AutoSize = true;
            this.rdLoopByTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLoopByTime.Location = new System.Drawing.Point(14, 42);
            this.rdLoopByTime.Name = "rdLoopByTime";
            this.rdLoopByTime.Size = new System.Drawing.Size(137, 19);
            this.rdLoopByTime.TabIndex = 2;
            this.rdLoopByTime.TabStop = true;
            this.rdLoopByTime.Text = "@loop_by_condition";
            this.rdLoopByTime.UseVisualStyleBackColor = true;
            this.rdLoopByTime.CheckedChanged += new System.EventHandler(this.RdLoopByTime_CheckedChanged);
            // 
            // rdLoopUnlimited
            // 
            this.rdLoopUnlimited.AutoSize = true;
            this.rdLoopUnlimited.Checked = true;
            this.rdLoopUnlimited.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLoopUnlimited.Location = new System.Drawing.Point(14, 19);
            this.rdLoopUnlimited.Name = "rdLoopUnlimited";
            this.rdLoopUnlimited.Size = new System.Drawing.Size(119, 19);
            this.rdLoopUnlimited.TabIndex = 0;
            this.rdLoopUnlimited.TabStop = true;
            this.rdLoopUnlimited.Text = "@loop_unlimited";
            this.rdLoopUnlimited.UseVisualStyleBackColor = true;
            // 
            // gbPlaybackInfo
            // 
            this.gbPlaybackInfo.Controls.Add(this.label1);
            this.gbPlaybackInfo.Controls.Add(this.txtTimeLeft);
            this.gbPlaybackInfo.Location = new System.Drawing.Point(480, 296);
            this.gbPlaybackInfo.Name = "gbPlaybackInfo";
            this.gbPlaybackInfo.Size = new System.Drawing.Size(296, 52);
            this.gbPlaybackInfo.TabIndex = 22;
            this.gbPlaybackInfo.TabStop = false;
            this.gbPlaybackInfo.Text = "@playback_info";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "@remaining";
            // 
            // txtTimeLeft
            // 
            this.txtTimeLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeLeft.Location = new System.Drawing.Point(137, 19);
            this.txtTimeLeft.Name = "txtTimeLeft";
            this.txtTimeLeft.ReadOnly = true;
            this.txtTimeLeft.Size = new System.Drawing.Size(153, 20);
            this.txtTimeLeft.TabIndex = 0;
            this.txtTimeLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "script";
            this.saveDialog.Filter = "Script Files|*.script";
            // 
            // versionLabel
            // 
            this.versionLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.versionLabel.Location = new System.Drawing.Point(546, 512);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(230, 21);
            this.versionLabel.TabIndex = 26;
            this.versionLabel.Text = "version {0} - by Darick Nguyễn";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Autoquit.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(12, 459);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 32);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Autoquit.Properties.Resources._new;
            this.btnNew.Location = new System.Drawing.Point(219, 459);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(34, 32);
            this.btnNew.TabIndex = 24;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnChangeName
            // 
            this.btnChangeName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnChangeName.Enabled = false;
            this.btnChangeName.FlatAppearance.BorderSize = 0;
            this.btnChangeName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeName.Image = global::Autoquit.Properties.Resources.changename;
            this.btnChangeName.Location = new System.Drawing.Point(379, 459);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(34, 32);
            this.btnChangeName.TabIndex = 23;
            this.btnChangeName.UseVisualStyleBackColor = false;
            this.btnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPlay.Enabled = false;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Image = global::Autoquit.Properties.Resources.play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(605, 363);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPlay.Size = new System.Drawing.Size(171, 32);
            this.btnPlay.TabIndex = 20;
            this.btnPlay.Tag = "@stop_play";
            this.btnPlay.Text = "@play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Autoquit.Properties.Resources.done;
            this.btnSave.Location = new System.Drawing.Point(259, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(34, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUndo.Enabled = false;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Autoquit.Properties.Resources.undo;
            this.btnUndo.Location = new System.Drawing.Point(299, 459);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(34, 32);
            this.btnUndo.TabIndex = 16;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.FlatAppearance.BorderSize = 0;
            this.btnSaveAs.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.Image = global::Autoquit.Properties.Resources.saveas;
            this.btnSaveAs.Location = new System.Drawing.Point(419, 459);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(34, 32);
            this.btnSaveAs.TabIndex = 15;
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDown.Enabled = false;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Image = global::Autoquit.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(120, 459);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(34, 32);
            this.btnDown.TabIndex = 12;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUp.Enabled = false;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Image = global::Autoquit.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(80, 459);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(34, 32);
            this.btnUp.TabIndex = 11;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Autoquit.Properties.Resources.icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(697, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 75);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.PictureBox1_DoubleClick);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRecord.Enabled = false;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecord.Location = new System.Drawing.Point(605, 401);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRecord.Size = new System.Drawing.Size(171, 32);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Tag = "@stop_record";
            this.btnRecord.Text = "@begin_record";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 28;
            this.label2.Text = "@controls";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbWindows
            // 
            this.cbWindows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWindows.Enabled = false;
            this.cbWindows.FormattingEnabled = true;
            this.cbWindows.ItemHeight = 20;
            this.cbWindows.Location = new System.Drawing.Point(180, 41);
            this.cbWindows.Name = "cbWindows";
            this.cbWindows.Size = new System.Drawing.Size(273, 26);
            this.cbWindows.TabIndex = 27;
            // 
            // listProcess
            // 
            this.listProcess.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listProcess.FormattingEnabled = true;
            this.listProcess.ItemHeight = 20;
            this.listProcess.Location = new System.Drawing.Point(47, 12);
            this.listProcess.Name = "listProcess";
            this.listProcess.Size = new System.Drawing.Size(406, 26);
            this.listProcess.TabIndex = 8;
            this.listProcess.SelectedIndexChanged += new System.EventHandler(this.ListProcess_SelectedIndexChanged);
            // 
            // ttGeneric
            // 
            this.ttGeneric.AutoPopDelay = 12000;
            this.ttGeneric.InitialDelay = 500;
            this.ttGeneric.ReshowDelay = 100;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 54);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(38, 13);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Help ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // btnLock
            // 
            this.btnLock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLock.Enabled = false;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.Image = global::Autoquit.Properties.Resources._lock;
            this.btnLock.Location = new System.Drawing.Point(339, 459);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(34, 32);
            this.btnLock.TabIndex = 30;
            this.btnLock.UseVisualStyleBackColor = false;
            this.btnLock.Click += new System.EventHandler(this.BtnLock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 545);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbWindows);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.gbPlaybackInfo);
            this.Controls.Add(this.gbPlaybackOption);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.scriptGrid);
            this.Controls.Add(this.scanProgress);
            this.Controls.Add(this.chkDeepScan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.listProcess);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnToFront);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Autoquit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scriptGrid)).EndInit();
            this.gbPlaybackOption.ResumeLayout(false);
            this.gbPlaybackOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeCount)).EndInit();
            this.gbPlaybackInfo.ResumeLayout(false);
            this.gbPlaybackInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnToFront;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer listScanCooldown;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Timer recordTimer;
        private System.Windows.Forms.DataGridView scriptGrid;
        private SimpleSelectBox listProcess;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkDeepScan;
        private System.Windows.Forms.ProgressBar scanProgress;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Timer playTimer;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.GroupBox gbPlaybackOption;
        private System.Windows.Forms.RadioButton rdLoopByTime;
        private System.Windows.Forms.RadioButton rdLoopUnlimited;
        private System.Windows.Forms.GroupBox gbPlaybackInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimeLeft;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTimeType;
        private System.Windows.Forms.NumericUpDown txtTimeCount;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Label versionLabel;
        private SimpleSelectBox cbWindows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlaybackSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip ttGeneric;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnLock;
    }
}

