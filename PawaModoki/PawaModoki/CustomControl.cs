using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawaModoki
{
    public partial class CustomControl : Control
    {
        public CustomControl()
        {
            InitializeComponent();
        }
    }
    public class RightToLeftProgressBar : ProgressBar
    {
        public RightToLeftProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rect);

            if (this.Value > 0)
            {
                // プログレスバーの描画部分を計算
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round((float)rect.Width * ((float)this.Value / this.Maximum)), rect.Height);

                // 反転して描画
                clip.X = rect.Width - clip.Width;

                e.Graphics.FillRectangle(Brushes.LimeGreen, clip);
            }
        }
    }
    public class LeftToRightProgressBar : ProgressBar
    {
        public LeftToRightProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rect);

            if (this.Value > 0)
            {
                // プログレスバーの描画部分を計算
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round((float)rect.Width * ((float)this.Value / this.Maximum)), rect.Height);

                e.Graphics.FillRectangle(Brushes.LimeGreen, clip);
            }
        }
    }
}
