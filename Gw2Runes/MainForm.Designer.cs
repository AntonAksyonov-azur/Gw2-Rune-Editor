using Gw2Runes.Components;

namespace Gw2Runes
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.tbCaption = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.myImageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbRuneText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorSelectionComboBox = new Gw2Runes.Components.ColorSelectionComboBox();
            this.imageComboBox = new Gw2Runes.Components.ImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBox
            // 
            this.pBox.BackColor = System.Drawing.Color.Black;
            this.pBox.Location = new System.Drawing.Point(13, 19);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(350, 600);
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            this.pBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pBox_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 633);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(546, 458);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 2;
            this.btnSaveAs.Text = "Save As..";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // tbCaption
            // 
            this.tbCaption.Location = new System.Drawing.Point(9, 105);
            this.tbCaption.Name = "tbCaption";
            this.tbCaption.Size = new System.Drawing.Size(107, 20);
            this.tbCaption.TabIndex = 3;
            this.tbCaption.Text = "Melisenta";
            this.tbCaption.TextChanged += new System.EventHandler(this.RefreshPictureBox);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorSelectionComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.imageComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbRuneText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbCaption);
            this.groupBox2.Location = new System.Drawing.Point(393, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 440);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Content";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rune Icon:";
            // 
            // myImageList
            // 
            this.myImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImageList.ImageStream")));
            this.myImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.myImageList.Images.SetKeyName(0, "run1.jpg");
            this.myImageList.Images.SetKeyName(1, "runa.jpg");
            this.myImageList.Images.SetKeyName(2, "rune.jpg");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text:";
            // 
            // tbRuneText
            // 
            this.tbRuneText.Location = new System.Drawing.Point(6, 144);
            this.tbRuneText.Multiline = true;
            this.tbRuneText.Name = "tbRuneText";
            this.tbRuneText.Size = new System.Drawing.Size(216, 284);
            this.tbRuneText.TabIndex = 5;
            this.tbRuneText.Text = resources.GetString("tbRuneText.Text");
            this.tbRuneText.TextChanged += new System.EventHandler(this.RefreshPictureBox);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Caption:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.Filter = "Jpeg complessed images (low size)|*.jpg|Png truecolor images (high quality)|*.png" +
                "";
            this.saveFileDialog.FilterIndex = 2;
            // 
            // colorSelectionComboBox
            // 
            this.colorSelectionComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorSelectionComboBox.FormattingEnabled = true;
            this.colorSelectionComboBox.Location = new System.Drawing.Point(122, 104);
            this.colorSelectionComboBox.Name = "colorSelectionComboBox";
            this.colorSelectionComboBox.Size = new System.Drawing.Size(100, 21);
            this.colorSelectionComboBox.TabIndex = 8;
            this.colorSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.RefreshPictureBox);
            // 
            // imageComboBox
            // 
            this.imageComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageComboBox.FormattingEnabled = true;
            this.imageComboBox.ImageList = this.myImageList;
            this.imageComboBox.ItemHeight = 44;
            this.imageComboBox.Location = new System.Drawing.Point(9, 32);
            this.imageComboBox.Name = "imageComboBox";
            this.imageComboBox.Size = new System.Drawing.Size(213, 50);
            this.imageComboBox.TabIndex = 5;
            this.imageComboBox.SelectedIndexChanged += new System.EventHandler(this.RefreshPictureBox);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 657);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveAs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GW 2 Rune Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.TextBox tbCaption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRuneText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label3;
        private Components.ImageComboBox imageComboBox;
        private Components.ColorSelectionComboBox colorSelectionComboBox;
        private System.Windows.Forms.ImageList myImageList;
    }
}

