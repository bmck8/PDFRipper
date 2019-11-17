using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFRipperWinFormApp
{
    public partial class Main : Form
    {
        private ObservableCollection<string> _lFiles = new ObservableCollection<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _lFiles.CollectionChanged += _lFiles_CollectionChanged;
        }

        private void _lFiles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateListBox();
        }
        private void UpdateListBox()
        {
            listView1.Items.Clear();
            foreach (string fPath in _lFiles)
            {
                FileInfo fi = new FileInfo(fPath);

                ListViewItem lvi = new ListViewItem(fi.Name);
                lvi.Tag = fPath;

                listView1.Items.Add(lvi);
            }

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            /// Add a file to the list
            using (OpenFileDialog f = new OpenFileDialog())
            {
                DialogResult dr = f.ShowDialog(this);

                if(dr == DialogResult.OK)
                {
                    foreach (string file in f.FileNames)
                    {
                        if (!_lFiles.Contains(file))
                        {
                            _lFiles.Add(file);

                            using (Selector s = new Selector(file))
                            {
                                DialogResult sdr = s.ShowDialog(this);

                                if (sdr == DialogResult.OK)
                                {
                                    /// take any selected areas
                                }
                            }
                        }
                    }
                }
            }

        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            PDFRipper.tPanel dp = new PDFRipper.tPanel();
            dp.Opacity = 50;
            dp.BackColor = Color.Blue;
            this.Controls.Add(dp);
            dp.BringToFront();

            /// Remove a file to the list
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                _lFiles.Remove(lvi.Tag.ToString());
            }
        }



    }
}
