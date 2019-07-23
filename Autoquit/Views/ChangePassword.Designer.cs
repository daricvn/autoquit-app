namespace Autoquit.Views
{
    partial class ChangePassword
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.lbOld = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(191, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "@cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(86, 197);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(99, 32);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "@accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "@set_your_password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(138, 60);
            this.txtOld.MaxLength = 100;
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(204, 20);
            this.txtOld.TabIndex = 3;
            this.txtOld.UseSystemPasswordChar = true;
            this.txtOld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtOld_KeyDown);
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(138, 103);
            this.txtNew.MaxLength = 100;
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(204, 20);
            this.txtNew.TabIndex = 4;
            this.txtNew.UseSystemPasswordChar = true;
            this.txtNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNew_KeyDown);
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(138, 145);
            this.txtRepeat.MaxLength = 100;
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(204, 20);
            this.txtRepeat.TabIndex = 5;
            this.txtRepeat.UseSystemPasswordChar = true;
            this.txtRepeat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRepeat_KeyDown);
            // 
            // lbOld
            // 
            this.lbOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOld.Location = new System.Drawing.Point(15, 60);
            this.lbOld.Name = "lbOld";
            this.lbOld.Size = new System.Drawing.Size(117, 20);
            this.lbOld.TabIndex = 6;
            this.lbOld.Text = "@old_pass";
            this.lbOld.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "@new_pass";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "@repeat_pass";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 241);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbOld);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "@set_password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Label lbOld;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}