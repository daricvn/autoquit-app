using System.Drawing;
using System.Windows.Forms;

namespace SimpleControl
{
    public class SimpleSelectBox : ComboBox
    {
        public SimpleSelectBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Draws the items into the ColorSelector object
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (Items.Count <= 0)
            {
                base.OnDrawItem(e);
                return;
            }
            if (e.Index < 0)
            {
                base.OnDrawItem(e);
                return;
            }
            DropDownItem item = Items[e.Index] as DropDownItem;
            // Draw the colored 16 x 16 square
            e.Graphics.DrawImage(item.Icon.ToBitmap(), e.Bounds.Left, e.Bounds.Top,21,21);
            e.Graphics.DrawString(item.Value, e.Font, new
                    SolidBrush(e.ForeColor), e.Bounds.Left + item.Icon.Width, e.Bounds.Top + 2);
            base.OnDrawItem(e);
        }
    }
    public class DropDownItem
    {
        public object Id { get; private set; }
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private string value;

        public Icon Icon
        {
            get { return img; }
            set { img = value; }
        }
        private Icon img;

        public DropDownItem(object id, string val, Icon icon)
        {
            Id = id;
            value = val;
            img = icon;
        }

        public override string ToString()
        {
            return value;
        }
        public DropDownItem Clone()
        {
            return new DropDownItem(this.Id, this.Value, this.Icon);
        }
        public DropDownItem Clone(object Id)
        {
            return new DropDownItem(Id, this.Value, this.Icon);
        }
    }
}
