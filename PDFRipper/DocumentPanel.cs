
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AcroPDFLib;
using System.Drawing.Drawing2D;

namespace PDFRipper
{
    public class DocumentPanel : Panel
    {
        private Rectangle rLeft = new Rectangle();
        private Rectangle rRight = new Rectangle();
        private Rectangle rTop = new Rectangle();
        private Rectangle rBottom = new Rectangle();

        private const int cGripSize = 20;
        private bool mDragging;
        private Point mDragPos;
        private bool IsOnGrip(Point pos)
        {
            return pos.X >= this.ClientSize.Width - cGripSize &&
                   pos.Y >= this.ClientSize.Height - cGripSize;
        }

        public DocumentPanel()
        {

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.BorderStyle = BorderStyle.FixedSingle;

            this.MouseDown += panel_MouseDown;
            this.MouseUp += panel_MouseUp;
            this.MouseMove += panel_MouseMove;

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; /// WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor,
            //    new Rectangle(this.ClientSize.Width - cGripSize, this.ClientSize.Height - cGripSize, cGripSize, cGripSize));
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50 * 255 / 100, this.BackColor)), this.ClientRectangle);
            base.OnPaint(e);
            this.BringToFront();


            /// Mark resize points
            //Graphics g = e.Graphics;

            //rLeft = new Rectangle(new Point(0, (this.Height / 2) - 2), new Size(5, 5));
            //g.FillRectangle(new SolidBrush(Color.Red), rLeft);

            //rRight = new Rectangle(new Point((this.Width) - 6, (this.Height / 2) - 2), new Size(5, 5));
            //g.FillRectangle(new SolidBrush(Color.Red), rRight);

            //rTop = new Rectangle(new Point((this.Width / 2), (0)), new Size(5, 5));
            //g.FillRectangle(new SolidBrush(Color.Red), rTop);

            //rBottom = new Rectangle(new Point((this.Width / 2), (this.Height) - 6), new Size(5, 5));
            //g.FillRectangle(new SolidBrush(Color.Red), rBottom);


            //Rectangle rPos = new Rectangle(this.Location, this.Size);
            //if (Parent != null)
            //{
            //    List<AxAcroPDFLib.AxAcroPDF> iSects = Parent.Controls.OfType<AxAcroPDFLib.AxAcroPDF>().Where(x => x.Bounds.IntersectsWith(rPos)).ToList();
            //    if (iSects.Count > 0)
            //    {
            //    }
            //}

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
