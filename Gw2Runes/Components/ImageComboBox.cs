using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gw2Runes.Components
{
    public class ImageComboBox : ComboBox
    {
        public ImageComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void ApplyImageList(ImageList list)
        {
            if (list != null)
            {
                var result = list.Images.Keys
                    .OfType<String>()
                    .OrderBy(a => a);

                foreach (var imageKey in result)
                {
                    Items.Add(new ImageComboBoxItem(imageKey, list.Images[imageKey]));
                }

                if (Items.Count > 0)
                {
                    SelectedItem = Items[0];
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                var item = (ImageComboBoxItem) Items[e.Index];

                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);
                e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width,
                    e.Bounds.Top + 2);
            }

            base.OnDrawItem(e);
        }
    }

    public sealed class ImageComboBoxItem
    {
        public String Value;
        public Image Image;

        public ImageComboBoxItem(String val, Image image)
        {
            Value = val;
            Image = image;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}