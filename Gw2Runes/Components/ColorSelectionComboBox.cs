using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gw2Runes.Components
{
    public class ColorSelectionComboBox : ComboBox
    {
        public ColorSelectionComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                var item = (ColorSelectionComboBoxItem) Items[e.Index];

                e.Graphics.FillRectangle(new SolidBrush(item.Color), e.Bounds.Left, e.Bounds.Top, ItemHeight, ItemHeight);
                e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + ItemHeight, e.Bounds.Top + 2);
            }

            base.OnDrawItem(e);
        }
    }

    public sealed class ColorSelectionComboBoxItem
    {
        public String Value;
        public Color Color;

        public ColorSelectionComboBoxItem(String val, Color color)
        {
            Value = val;
            Color = color;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}