using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Gw2Runes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Resource variables

        private Image _background;
        private Image _rune;

        private PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
        private Font _captionFont;
        private Font _textFont;
        private SolidBrush _captionBrush = new SolidBrush(Color.FromArgb(220, 158, 37));
        private SolidBrush _textBrush = new SolidBrush(Color.FromArgb(156, 156, 156));

        private String _runeTextString;

        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadResources();
            LoadDefaulValues();
        }

        private void LoadDefaulValues()
        {
            _runeTextString = tbRuneText.Text;
        }

        private void pBox_Paint(object sender, PaintEventArgs e)
        {
            DrawPreview(e.Graphics);
        }

        #endregion

        #region Private Methods

        private void LoadResources()
        {
            _background = Image.FromFile(@"Resources\images\Background\background.png");
            _rune = Image.FromFile(@"Resources\Images\Runes\rune.jpg");

            _privateFontCollection.AddFontFile(@"Resources\Fonts\Fritz Quadrata Cyrillic Regular.ttf");
            _captionFont = new Font(_privateFontCollection.Families.First().Name, 18.0f, GraphicsUnit.Pixel);
            _textFont = new Font(_privateFontCollection.Families.First().Name, 16.0f, GraphicsUnit.Pixel);
        }

        private void DrawPreview(Graphics e)
        {
            if (_background == null) return;
            if (_rune == null) return;

            e.SmoothingMode = SmoothingMode.AntiAlias;
            e.DrawImage(_background, new Point(0, 0));
            e.DrawImage(_rune, new Point(12, 28));
            e.DrawString(
                String.Format("Superior Rune of {0}", tbCaption.Text),
                _captionFont,
                _captionBrush,
                new PointF(60, 44));
            e.DrawString(
                _runeTextString,
                _textFont,
                _textBrush,
                new PointF(18, 88));
        }

        #endregion

        #region Buttons

        private void btnCaptionColor_Click(object sender, EventArgs e)
        {
            ChangeBrushColorViaDialog(ref _captionBrush);
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            ChangeBrushColorViaDialog(ref _textBrush);
        }

        private void ChangeBrushColorViaDialog(ref SolidBrush brush)
        {
            using (var colorDialog = new ColorDialog() {AllowFullOpen = true, Color = _captionBrush.Color})
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    brush = new SolidBrush(colorDialog.Color);
                }
            }

            pBox.Refresh();
        }

        #endregion

        #region Universal Events

        private void RefreshPictureBox(object sender, EventArgs e)
        {
            pBox.Refresh();
        }

        #endregion

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            _runeTextString = tbRuneText.Text;

            pBox.Refresh();
        }

    }
}