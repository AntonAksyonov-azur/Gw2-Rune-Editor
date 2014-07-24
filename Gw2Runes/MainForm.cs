using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AndaForceUtils.Math;
using Gw2Runes.Components;
using Gw2Runes.Properties;

namespace Gw2Runes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Constants

        private const int BackgroundWidth = 350;
        private const int BackgroundHeight = 600;

        #endregion

        #region Resource variables

        private Image _background;
        private Image _rune;

        private readonly PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
        private Font _captionFont;
        private Font _textFont;
        private SolidBrush _captionBrush = new SolidBrush(Color.FromArgb(220, 158, 37));
        private SolidBrush _textBrush = new SolidBrush(Color.FromArgb(156, 156, 156));

        private String _runeTextString;

        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowVersionInfo();
            LoadResources();
            LoadDefaulValues();
            
            SetupComboBoxes();
        }

        private void pBox_Paint(object sender, PaintEventArgs e)
        {
            DrawPreview(e.Graphics);
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            _runeTextString = tbRuneText.Text;

            pBox.Refresh();
        }

        private void imageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rune = (imageComboBox.SelectedItem as ImageComboBoxItem).Image;

            pBox.Refresh();
        }

        private void colorSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _captionBrush.Color = (colorSelectionComboBox.SelectedItem as ColorSelectionComboBoxItem).Color;

            pBox.Refresh();
        }

        #endregion

        #region Button Events

        private void btnCaptionColor_Click(object sender, EventArgs e)
        {
            ChangeBrushColorViaDialog(ref _captionBrush);
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            ChangeBrushColorViaDialog(ref _textBrush);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = tbCaption.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var pBoxImage = new Bitmap(BackgroundWidth, BackgroundHeight);
                var workingGraphics = Graphics.FromImage(pBoxImage);

                // Height of entered text + 90px rune icon and caption + 60px for empty space under
                var resultHeight =
                    (int) MathHelper.Clamp(
                        workingGraphics.MeasureString(_runeTextString, _textFont).Height + 90 + 60,
                        0,
                        BackgroundHeight);

                DrawPreview(Graphics.FromImage(pBoxImage));

                var imageResult = new Bitmap(BackgroundWidth, resultHeight);
                workingGraphics = Graphics.FromImage(imageResult);
                workingGraphics.DrawImage(pBoxImage, 0, 0);
                workingGraphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, imageResult.Width - 1,
                    imageResult.Height - 1);

                imageResult.Save(
                    saveFileDialog.FileName,
                    new[] {ImageFormat.Jpeg, ImageFormat.Png}[saveFileDialog.FilterIndex - 1]);
            }
        }

        #endregion

        #region Universal Events

        private void RefreshPictureBox(object sender, EventArgs e)
        {
            pBox.Refresh();
        }

        #endregion

        #region Private Methods

        private void ShowVersionInfo()
        {
            Text = String.Format(
                "{0}, Version: {1}.{2}.{3}.{4}",
                Assembly.GetExecutingAssembly().GetName().Name,
                Assembly.GetExecutingAssembly().GetName().Version.Major,
                Assembly.GetExecutingAssembly().GetName().Version.Minor,
                Assembly.GetExecutingAssembly().GetName().Version.Build,
                Assembly.GetExecutingAssembly().GetName().Version.Revision);
        }

        private void LoadDefaulValues()
        {
            _runeTextString = tbRuneText.Text;
        }

        private void LoadResources()
        {
            _background = Resources.background;
            _rune = Resources.rune;

            LoadFontFromResources();
//            _privateFontCollection.AddFontFile(@"Resources\Fonts\Fritz_Quadrata_Cyrillic_Regular.ttf");

            var fnt = _privateFontCollection.Families.First();
            _captionFont = new Font(fnt, 18.0f, GraphicsUnit.Pixel);
            _textFont = new Font(fnt, 16.0f, GraphicsUnit.Pixel);

//            _background = Image.FromFile(@"Resources\images\Background\background.png");
//            _rune = Image.FromFile(@"Resources\Images\Runes\rune.jpg");
        }

        private void LoadFontFromResources()
        {
            const string resourceFontName = "Gw2Runes.Resources.Fonts.Fritz_Quadrata_Cyrillic_Regular.ttf";
            Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFontName);

            IntPtr data = Marshal.AllocCoTaskMem((int) fontStream.Length);
            var fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int) fontStream.Length);

            Marshal.Copy(fontdata, 0, data, (int) fontStream.Length);

            _privateFontCollection.AddMemoryFont(data, (int) fontStream.Length);

            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
        }

        private void SetupComboBoxes()
        {
            imageComboBox.ApplyImageList(myImageList);

            colorSelectionComboBox.Items.Add(
                new ColorSelectionComboBoxItem("Superior", "Superior Rune of ", Color.FromArgb(220, 158, 37)));
            colorSelectionComboBox.Items.Add(
                new ColorSelectionComboBoxItem("Major", "Major Rune of ", Color.FromArgb(230, 230, 37)));
            colorSelectionComboBox.Items.Add(
                new ColorSelectionComboBoxItem("Minor", "Minor Rune of ", Color.FromArgb(140, 179, 62)));
            colorSelectionComboBox.SelectedItem = colorSelectionComboBox.Items[0];
        }

        private void DrawPreview(Graphics e)
        {
            if (_background == null) return;
            if (_rune == null) return;

            e.SmoothingMode = SmoothingMode.AntiAlias;
            e.DrawImage(_background, new Point(0, 0));
            e.DrawImage(_rune, new Point(12, 28));
            e.DrawString(
                String.Format("{0} {1}", (colorSelectionComboBox.SelectedItem as ColorSelectionComboBoxItem).DataValue, tbCaption.Text),
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

        #region Extracted Methods

        private void ChangeBrushColorViaDialog(ref SolidBrush brush)
        {
            using (var colorDialog = new ColorDialog {AllowFullOpen = true, Color = _captionBrush.Color})
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    brush = new SolidBrush(colorDialog.Color);
                }
            }

            pBox.Refresh();
        }

        #endregion

       
    }
}