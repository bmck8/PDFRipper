using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emerson.Cookstown.Extensions;
using PDFRipper;

namespace PDFRipperWinFormApp
{
    public partial class Templates : Form
    {
        private string _TemplateDocumentPath = "";
        public Templates()
        {
            InitializeComponent();
        }
        public Templates(string _TemplateDocumentPath)
        {
            InitializeComponent();

            this._TemplateDocumentPath = _TemplateDocumentPath;
            Init();
        }


        private void Init()
        {
            /// Load document image
            try
            {
                if (File.Exists(_TemplateDocumentPath))
                {
                    Image img = null;

                    /// If PDF convert first page out
                    if (Path.GetExtension(_TemplateDocumentPath).ToUpperInvariant().Contains("PDF"))
                    {
                        Imager i = new Imager(_TemplateDocumentPath);
                        List<Bitmap> bmp = i.PDFToImage().ToList();
                        img = bmp[0];
                    }
                    else
                    {
                        img = Image.FromFile(_TemplateDocumentPath);
                    }

                    pbImage.Image = img;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed '" + MethodBase.GetCurrentMethod().Name + "': " + ex.ToString());
            }


        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    Color c = Color.DodgerBlue;
        //    ColorDialog cd1 = new ColorDialog();

        //    cd1.Color = Color.DodgerBlue;
        //    cd1.AllowFullOpen = true;
        //    cd1.FullOpen = true;
        //    cd1.AnyColor = true;

        //    List<int> cList = Emerson.Cookstown.Colour.Palette.Original.AllColours.Select(x => ColorTranslator.ToOle(x)).ToList();
        //    cd1.CustomColors = cList.ToArray();

        //    if (cd1.ShowDialog(this) == DialogResult.OK) { c = cd1.Color; }

        //    PanelTransparent pt = new PanelTransparent();
        //    pt.Opacity = 30;
        //    pt.BackColor = c;
        //    pt.Name = "pTrans_" + DateTime.Now.ToString("hhmmss");

        //    this.Controls.Add(pt);
        //    pt.BringToFront();
        //}

        //private void btnRemove_Click(object sender, EventArgs e)
        //{
        //    List<PanelTransparent> c = this.Controls.OfType<PanelTransparent>().Where(x => x.isSelected).ToList();

        //    if (c.Count > 0) { c.ForEach(x => x.Dispose()); this.Invalidate(true); }
        //}



        private void pbImage_Selected(object sender, EventArgs e)
        {
            /// Add region to list view
            RectangleF rRegion = pbImage.SelectionRegion;


            if (rRegion.Width > 5 && rRegion.Height > 5)
            {
                int rNumber = lvPOI.Items.Count;

                ListViewItem lvi = new ListViewItem();
                lvi.Name = "region_" + rNumber;
                lvi.Text = "Region " + rNumber + " {X:" + (int)rRegion.X + "; Y:" + (int)rRegion.Y + "; W:" + (int)rRegion.Width + "; H:" + (int)rRegion.Height + ";}";
                lvi.Tag = rRegion;

                lvPOI.Items.Add(lvi);
            }
        }

        private void lvPOI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPOI.SelectedItems.Count > 0)
            {
                ListViewItem lviSelected = lvPOI.SelectedItems[0];
                RectangleF rRegion = (RectangleF)lviSelected.Tag;
                pbImage.SelectionRegion = rRegion;
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lvPOI.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvPOI.SelectedItems)
                {
                    lvPOI.Items.Remove(lvi);
                }
            }
        }
    }
}
