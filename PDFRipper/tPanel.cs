
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AcroPDFLib;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace PDFRipper
{
    public class tPanel : Panel
    {
        private const int cGripSize = 20;
        private bool mDragging;
        private Point mDragPos;
        private bool IsOnGrip(Point pos)
        {
            return pos.X >= this.ClientSize.Width - cGripSize &&
                   pos.Y >= this.ClientSize.Height - cGripSize;
        }
        private const int WS_EX_TRANSPARENT = 0x20;
        public tPanel()
        {
            SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.MouseDown += panel_MouseDown;
            this.MouseUp += panel_MouseUp;
            this.MouseMove += panel_MouseMove;
        }

        private int opacity = 50;
        [DefaultValue(50)]
        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
                this.Invalidate();
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            this.BringToFront();
            base.OnPaint(e);
        }
        private Point MouseDownLocation;
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (IsOnGrip(e.Location))
                {
                    mDragging = IsOnGrip(e.Location);
                    mDragPos = e.Location;
                }
                else
                {
                    MouseDownLocation = e.Location;
                }
            }

        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            mDragging = false;

            if (this.Parent != null)
            {
                this.Parent.Invalidate(true);
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mDragging)
            {
                this.Size = new Size(this.Width + e.X - mDragPos.X, this.Height + e.Y - mDragPos.Y);
                mDragPos = e.Location;
            }
            else if (IsOnGrip(e.Location)) { this.Cursor = Cursors.SizeNWSE; }
            else
            {
                this.Cursor = Cursors.Default;
                Panel p = (Panel)sender;
                if (e.Button == MouseButtons.Left)
                {
                    p.Left = e.X + p.Left - MouseDownLocation.X;
                    p.Top = e.Y + p.Top - MouseDownLocation.Y;
                }
            }
        }
    }

}