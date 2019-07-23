using Autoquit.Constant;
using Autoquit.Models;
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
    public partial class UsageHelp : Form
    {
        public UsageHelp()
        {
            InitializeComponent();
            Language.ApplyLanguage(this);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsageHelp_Load(object sender, EventArgs e)
        {
            var conditions = AppConstant.SupportedEvents;
            List<LocalizationList> list = new List<LocalizationList>(conditions.Length);
            foreach (string con in conditions)
                list.Add(new LocalizationList()
                {
                    Value = Language.Get(con),
                    Text = Language.Get(con + "_help")
                });
            helpGrid.DataSource = list;
            helpGrid.Columns[0].Width = 130;
            helpGrid.Columns[1].Width = 272;
            helpGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            helpGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

        }
    }
}
