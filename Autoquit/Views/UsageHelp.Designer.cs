namespace Autoquit.Views
{
    partial class UsageHelp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.helpGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.helpGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // helpGrid
            // 
            this.helpGrid.AllowUserToAddRows = false;
            this.helpGrid.AllowUserToDeleteRows = false;
            this.helpGrid.AllowUserToResizeRows = false;
            this.helpGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.helpGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.helpGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.helpGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.helpGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.helpGrid.Location = new System.Drawing.Point(12, 12);
            this.helpGrid.Name = "helpGrid";
            this.helpGrid.ReadOnly = true;
            this.helpGrid.RowHeadersVisible = false;
            this.helpGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.helpGrid.ShowCellErrors = false;
            this.helpGrid.ShowEditingIcon = false;
            this.helpGrid.ShowRowErrors = false;
            this.helpGrid.Size = new System.Drawing.Size(423, 309);
            this.helpGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(171, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "@close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // UsageHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.helpGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsageHelp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "@help";
            this.Load += new System.EventHandler(this.UsageHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.helpGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView helpGrid;
        private System.Windows.Forms.Button button1;
    }
}