using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DP_music.CustomItems
{
    public class CustomTextBox: Control
    {
        #region Змінні

        StringFormat SF = new StringFormat();
        int TopBorderOffset = 0;
        TextBox tbInput = new TextBox();

        #endregion

        public string TextPreview { get; set; } = "Input Text";
        public Font FontTextPreview { get; set; } = new Font("Century Gothic", 8, FontStyle.Bold);
        public Color BorderColor { get; set; } = Color.Blue;
        public Color BorderColorNotActive { get; set; } = Color.Gray;

        public string TextInput
        {
            get => tbInput.Text;
            set
            {
                tbInput.Text = value;
                Refresh();
            }
        }

        public new string Text
        {
            get => tbInput.Text;
            set
            {
                tbInput.Text = value;
                Refresh();
            }
        }

        public CustomTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(150, 40);
            Font = new Font("Century Gothic", 11.25F, FontStyle.Regular);

            BackColor = Color.White;
            ForeColor = Color.Black;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            AdjustTextBoxInput();
            Controls.Add(tbInput);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            tbInput.Text = Text;
        }

        private void AdjustTextBoxInput()
        {
            tbInput = new TextBox();
            tbInput.Name = "InputBox";
            tbInput.BorderStyle = BorderStyle.None;
            tbInput.BackColor = BackColor;
            tbInput.ForeColor = ForeColor;
            tbInput.Font = Font;

            int offset = TextRenderer.MeasureText(TextPreview, FontTextPreview).Height / 2;
            tbInput.Location = new Point(5, Height / 2 - TopBorderOffset + 2);
            tbInput.Size = new Size(Width - 10, tbInput.Height);
        }

        #region оновлення властивостей
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            tbInput.BackColor = BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            tbInput.ForeColor = ForeColor;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            tbInput.Font = Font;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            tbInput.Size = new Size(Width - 10, tbInput.Height);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;

            graph.Clear(Parent.BackColor);

            TopBorderOffset = graph.MeasureString(TextPreview, FontTextPreview).ToSize().Height / 2;

            Rectangle rectBase = new Rectangle(0, TopBorderOffset, Width - 1, Height - 1 - TopBorderOffset);

            Size TextPreviewRectSize = graph.MeasureString(TextPreview, FontTextPreview).ToSize();
            Rectangle rectTextPreview = new Rectangle(5, 0, TextPreviewRectSize.Width + 3, TextPreviewRectSize.Height);

            //Обводка
            graph.DrawRectangle(new Pen(BorderColor), rectBase);

            //Заголовок/Опис
            graph.DrawRectangle(new Pen(Parent.BackColor), rectTextPreview);
            graph.FillRectangle(new SolidBrush(Parent.BackColor), rectTextPreview);

            //Колір всередині
            graph.FillRectangle(new SolidBrush(BackColor), rectBase);

            graph.DrawString(TextPreview, FontTextPreview, new SolidBrush(BorderColor), rectTextPreview, SF);

        }
    }
}
