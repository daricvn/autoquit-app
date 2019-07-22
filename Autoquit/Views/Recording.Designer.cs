namespace Autoquit.Views
{
    partial class Recording
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
            this.effectTimer = new System.Windows.Forms.Timer(this.components);
            this.topLine = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.topLine)).BeginInit();
            this.SuspendLayout();
            // 
            // effectTimer
            // 
            this.effectTimer.Enabled = true;
            this.effectTimer.Interval = 50;
            this.effectTimer.Tick += new System.EventHandler(this.EffectTimer_Tick);
            // 
            // topLine
            // 
            this.topLine.BackColor = System.Drawing.Color.Red;
            this.topLine.Location = new System.Drawing.Point(-2, -1);
            this.topLine.Name = "topLine";
            this.topLine.Size = new System.Drawing.Size(213, 8);
            this.topLine.TabIndex = 1;
            this.topLine.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recording...";
            // 
            // Recording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 51);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Recording";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Recording";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Recording_Load);
            ((System.ComponentModel.ISupportInitialize)(this.topLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer effectTimer;
        private System.Windows.Forms.PictureBox topLine;
        private System.Windows.Forms.Label label1;
    }
}