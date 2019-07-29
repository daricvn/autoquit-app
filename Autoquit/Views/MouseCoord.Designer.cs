namespace Autoquit.Views
{
    partial class MouseCoord
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
            this.xLine = new System.Windows.Forms.PictureBox();
            this.yLine = new System.Windows.Forms.PictureBox();
            this.lbMousecoord = new System.Windows.Forms.Label();
            this.timeTicker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yLine)).BeginInit();
            this.SuspendLayout();
            // 
            // xLine
            // 
            this.xLine.BackColor = System.Drawing.Color.Yellow;
            this.xLine.Location = new System.Drawing.Point(171, 70);
            this.xLine.Name = "xLine";
            this.xLine.Size = new System.Drawing.Size(100, 2);
            this.xLine.TabIndex = 0;
            this.xLine.TabStop = false;
            // 
            // yLine
            // 
            this.yLine.BackColor = System.Drawing.Color.Yellow;
            this.yLine.Location = new System.Drawing.Point(224, 21);
            this.yLine.Name = "yLine";
            this.yLine.Size = new System.Drawing.Size(2, 100);
            this.yLine.TabIndex = 1;
            this.yLine.TabStop = false;
            // 
            // lbMousecoord
            // 
            this.lbMousecoord.AutoSize = true;
            this.lbMousecoord.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMousecoord.ForeColor = System.Drawing.Color.Red;
            this.lbMousecoord.Location = new System.Drawing.Point(7, 6);
            this.lbMousecoord.Name = "lbMousecoord";
            this.lbMousecoord.Size = new System.Drawing.Size(100, 18);
            this.lbMousecoord.TabIndex = 2;
            this.lbMousecoord.Text = "mouse coord";
            // 
            // timeTicker
            // 
            this.timeTicker.Interval = 60;
            this.timeTicker.Tick += new System.EventHandler(this.TimeTicker_Tick);
            // 
            // MouseCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 189);
            this.ControlBox = false;
            this.Controls.Add(this.lbMousecoord);
            this.Controls.Add(this.yLine);
            this.Controls.Add(this.xLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseCoord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MouseCoord";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MouseCoord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox xLine;
        private System.Windows.Forms.PictureBox yLine;
        private System.Windows.Forms.Label lbMousecoord;
        private System.Windows.Forms.Timer timeTicker;
    }
}