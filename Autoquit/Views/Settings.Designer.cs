namespace Autoquit.Views
{
    partial class Settings
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
            this.gbHotKey = new System.Windows.Forms.GroupBox();
            this.cbModifiers = new System.Windows.Forms.ComboBox();
            this.txtPlayScript = new System.Windows.Forms.TextBox();
            this.txtStartRecording = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAppSettings = new System.Windows.Forms.GroupBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.chkNoInput = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ttGeneric = new System.Windows.Forms.ToolTip(this.components);
            this.gbHotKey.SuspendLayout();
            this.gbAppSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHotKey
            // 
            this.gbHotKey.Controls.Add(this.cbModifiers);
            this.gbHotKey.Controls.Add(this.txtPlayScript);
            this.gbHotKey.Controls.Add(this.txtStartRecording);
            this.gbHotKey.Controls.Add(this.label3);
            this.gbHotKey.Controls.Add(this.label2);
            this.gbHotKey.Controls.Add(this.label1);
            this.gbHotKey.Location = new System.Drawing.Point(12, 12);
            this.gbHotKey.Name = "gbHotKey";
            this.gbHotKey.Size = new System.Drawing.Size(294, 111);
            this.gbHotKey.TabIndex = 0;
            this.gbHotKey.TabStop = false;
            this.gbHotKey.Text = "@hotkey";
            // 
            // cbModifiers
            // 
            this.cbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModifiers.FormattingEnabled = true;
            this.cbModifiers.Items.AddRange(new object[] {
            " ",
            "Shift",
            "Control",
            "Alt"});
            this.cbModifiers.Location = new System.Drawing.Point(136, 48);
            this.cbModifiers.Name = "cbModifiers";
            this.cbModifiers.Size = new System.Drawing.Size(80, 21);
            this.cbModifiers.TabIndex = 5;
            // 
            // txtPlayScript
            // 
            this.txtPlayScript.Location = new System.Drawing.Point(222, 48);
            this.txtPlayScript.Name = "txtPlayScript";
            this.txtPlayScript.Size = new System.Drawing.Size(66, 20);
            this.txtPlayScript.TabIndex = 4;
            this.txtPlayScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStartRecording_KeyDown);
            // 
            // txtStartRecording
            // 
            this.txtStartRecording.Location = new System.Drawing.Point(222, 22);
            this.txtStartRecording.Name = "txtStartRecording";
            this.txtStartRecording.Size = new System.Drawing.Size(66, 20);
            this.txtStartRecording.TabIndex = 3;
            this.txtStartRecording.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStartRecording_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "@retrieve_coord";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "@play_stop_script";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "@start_stop_record";
            // 
            // gbAppSettings
            // 
            this.gbAppSettings.Controls.Add(this.cbLanguage);
            this.gbAppSettings.Controls.Add(this.chkNoInput);
            this.gbAppSettings.Controls.Add(this.label4);
            this.gbAppSettings.Location = new System.Drawing.Point(12, 129);
            this.gbAppSettings.Name = "gbAppSettings";
            this.gbAppSettings.Size = new System.Drawing.Size(294, 98);
            this.gbAppSettings.TabIndex = 1;
            this.gbAppSettings.TabStop = false;
            this.gbAppSettings.Text = "@app_settings";
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(117, 55);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(171, 21);
            this.cbLanguage.TabIndex = 6;
            // 
            // chkNoInput
            // 
            this.chkNoInput.AutoSize = true;
            this.chkNoInput.Checked = true;
            this.chkNoInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoInput.Location = new System.Drawing.Point(16, 28);
            this.chkNoInput.Name = "chkNoInput";
            this.chkNoInput.Size = new System.Drawing.Size(104, 17);
            this.chkNoInput.TabIndex = 4;
            this.chkNoInput.Text = "@noinput_mode";
            this.chkNoInput.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "@language";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(120, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "@save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ttGeneric
            // 
            this.ttGeneric.AutoPopDelay = 15000;
            this.ttGeneric.InitialDelay = 500;
            this.ttGeneric.ReshowDelay = 100;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 274);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbAppSettings);
            this.Controls.Add(this.gbHotKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "@settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gbHotKey.ResumeLayout(false);
            this.gbHotKey.PerformLayout();
            this.gbAppSettings.ResumeLayout(false);
            this.gbAppSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHotKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAppSettings;
        private System.Windows.Forms.CheckBox chkNoInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip ttGeneric;
        private System.Windows.Forms.TextBox txtStartRecording;
        private System.Windows.Forms.TextBox txtPlayScript;
        private System.Windows.Forms.ComboBox cbModifiers;
        private System.Windows.Forms.ComboBox cbLanguage;
    }
}