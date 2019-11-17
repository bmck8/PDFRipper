using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFRipperWinFormApp
{
    public partial class Selector : Form
    {
        public Selector()
        {
            InitializeComponent();
        }

        public Selector(string _FilePath)
        {
            InitializeComponent();

            pdf1.setShowToolbar(false);
            pdf1.LoadFile(_FilePath);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PDFRipper.tPanel p = new PDFRipper.tPanel();
            p.Name = "tsPanel" + DateTime.Now.ToString("hhmmss");
            p.BackColor = Color.Red;
            p.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height + 5);
            this.Controls.Add(p);

            p.BringToFront();
            pdf1.SendToBack();

            //this.Invalidate(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            List<Panel> allPOI = new List<Panel>();
            foreach (Panel t in this.Controls.OfType<Panel>())
            {
                if (t.Name.Contains("tsPanel"))
                {
                    allPOI.Add(t);
                }
            }

            if (allPOI.Count > 0)
            {
                foreach (Control c in allPOI)
                {
                    c.BringToFront();
                    c.Invalidate();
                }
            }
        }


    }
}
