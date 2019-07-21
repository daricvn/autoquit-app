using Autoquit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Services
{
    internal static class ScriptGrid
    {
        private static DataGridView Grid;
        private static volatile Script currentScript;
        private static BindingSource source;
        public static ScriptItem LastRow
        {
            get
            {
                if (Rows!=null && Rows.Count>0) return Rows[Rows.Count - 1];
                return null;
            }
        }
        public static int GridCount
        {
            get
            {
                if (Rows!=null) return Rows.Count;
                return 0;
            }
        }
        public static BindingList<ScriptItem> Rows
        {
            get
            {
                return currentScript?.Scripts;
            }
        }
        public static Script Script
        {
            get
            {
                return currentScript;
            }
        }
        public static void RemoveAt(int index)
        {
            if (index>=0)
            if (Rows != null && Rows.Count > index)
            {
                if (Grid.InvokeRequired)
                    Grid.Invoke((MethodInvoker)(() =>
                    {
                        if (Rows.Count > index)
                            Rows.RemoveAt(index);
                    }));
                else
                {
                    Rows.RemoveAt(index);
                }
            }
        }
        public static bool Register(DataGridView grid, Script script)
        {
            Grid = grid;
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToResizeRows = false;
            source = new BindingSource(script, "Scripts");
            Grid.DataSource = source;
            currentScript = script;
            if (Grid.Columns.Count > 0)
                foreach (DataGridViewColumn col in Grid.Columns)
                    col.HeaderText = Language.Get(col.HeaderText.ToLower());
            var cols = Column("Index");
            if (cols != null)
            {
                cols.ReadOnly = true;
                cols.Width = 50;
            }
            cols = Column("Active");
            if (cols != null)
            {
                cols.Width = 50;
            }
            cols = Column("SendInput");
            if (cols != null)
            {
                cols.HeaderText += "(?)";
                cols.Width = 70;
                cols.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cols.ToolTipText = Language.Get("msg_sendinput");
            }
            Grid.DataError += Grid_DataError;
            Grid.UserDeletingRow += Grid_UserDeletingRow;
            Grid.UserDeletedRow += Grid_UserDeletedRow;
            Grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            Grid.ColumnHeaderMouseDoubleClick += Grid_ColumnHeaderMouseDoubleClick;
            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               Grid,
               new object[] { true });
            return true;
        }

        private static void Grid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Grid.Columns.Count > e.ColumnIndex && Grid.Columns[e.ColumnIndex].Name=="SendInput")
            {
                if (Rows!=null && Rows.Count > 0)
                {
                    var check = !Rows[0].SendInput;
                    foreach (var row in Rows)
                        row.SendInput = check;
                    Bind(currentScript);
                }
            }
        }

        private static void Grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateIndex();
        }

        private static void Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var result = MessageBox.Show(Language.Get("prompt_deleting"), Language.Get("confirmation"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private static void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
                MessageBox.Show(Language.Get(e.Exception.GetType().Name), 
                    Language.Get("error"), 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        public static void Update()
        {
            Bind(currentScript);
        }
        public static void UpdateIndex()
        {
            if (currentScript != null)
            {
                for (var i = 0; i < currentScript.Scripts.Count; i++)
                    currentScript.Scripts[i].Index = i + 1;
                Bind(currentScript);
            }
        }

        public static bool Bind(Script script, bool isNew = false)
        {
            currentScript = script;
            if (isNew)
            {
                if (Grid.SelectedCells.Count > 0)
                    Grid.SelectedCells[0].Selected = false;
                if (Grid.SelectedRows.Count > 0)
                    Grid.SelectedRows[0].Selected = false;
                if (Grid.SelectedColumns.Count > 0)
                    Grid.SelectedColumns[0].Selected = false;
                source.DataSource = script;
                source.DataMember = "Scripts";
            }
            
            Grid.DataSource = source;
            Grid.Refresh();
            return true;
        }
        public static ScriptItem New()
        {
            var item = new ScriptItem()
            {
                Index=currentScript.Scripts.Count+1,
                Active=true
            };
            currentScript.Scripts.Add(item);
            Bind(currentScript);
            return item;
        }
        public static bool Add(ScriptItem item)
        {
            item.Index = currentScript.Scripts.Count + 1;
            item.Active = true;
            if (Grid.InvokeRequired)
                Grid.Invoke((MethodInvoker)(() =>
                {
                    currentScript.Scripts.Add(item);
                        Bind(currentScript);

                }));
            else
            {
                currentScript.Scripts.Add(item);
                    Bind(currentScript);
            }

            return true;
        }
        public static DataGridViewColumn Column(string name)
        {
            if (Grid.Columns.Count > 0)
                foreach (DataGridViewColumn col in Grid.Columns)
                    if (col.DataPropertyName == name)
                        return col;
            return null;
        }
        public static DataGridViewColumn BindColumnToList(string name, object list, string value=null, string text=null)
        {
            var oldCol = Column(name);
            if (oldCol != null)
            {
                DataGridViewComboBoxColumn colBox = new DataGridViewComboBoxColumn();
                colBox.HeaderText = oldCol.HeaderText;
                colBox.DataPropertyName = oldCol.DataPropertyName;
                colBox.DataSource = list;
                colBox.DisplayIndex = oldCol.DisplayIndex;
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(text))
                {
                    colBox.ValueMember = value;
                    colBox.DisplayMember = text;
                }
                colBox.Name = oldCol.Name;
                Grid.Columns.Insert(oldCol.Index, colBox);
                Grid.Columns.Remove(oldCol);
            }
            return null;
        }
        public static void SelectRow(int index)
        {
            Grid.ClearSelection();
            if (Grid.Rows.Count > index)
                Grid.Rows[index].Selected = true;
        }
        public static DataGridViewRow SelectedRow
        {
            get
            {
                if (Grid.SelectedRows==null || Grid.SelectedRows.Count == 0)
                    return null;
                return Grid.SelectedRows[0];
            }
        }
    }
}
