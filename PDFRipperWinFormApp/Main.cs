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
            lvFiles.Items.Clear();
            foreach (string fPath in _lFiles)
            {
                FileInfo fi = new FileInfo(fPath);

                ListViewItem lvi = new ListViewItem(fi.Name);
                lvi.Tag = fPath;

                lvFiles.Items.Add(lvi);
            }

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            /// Add a file to the list
            using (OpenFileDialog f = new OpenFileDialog())
            {
                DialogResult dr = f.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    foreach (string file in f.FileNames)
                    {
                        if (!_lFiles.Contains(file))
                        {
                            _lFiles.Add(file);
                        }
                    }
                }
            }

        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            PanelTransparent dp = new PanelTransparent();
            dp.Opacity = 50;
            dp.BackColor = Color.Blue;
            this.Controls.Add(dp);
            dp.BringToFront();

            /// Remove a file to the list
            foreach (ListViewItem lvi in lvFiles.SelectedItems)
            {
                _lFiles.Remove(lvi.Tag.ToString());
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.WorkerSupportsCancellation = true;
            bg.WorkerReportsProgress = true;
            bg.ProgressChanged += Bg_ProgressChanged;
            bg.DoWork += Bg_DoWork;

            bg.RunWorkerAsync(new object[] { _lFiles });
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = (BackgroundWorker)sender;
            try
            {
                object[] args = (object[])e.Argument;

                bg.ReportProgress(0, "Obtaining file list");
                ObservableCollection<string> lFiles = (ObservableCollection<string>)args[0];


                int CurrentFile = 0;
                int TotalFiles = lFiles.Count;
                int CurrentProgress = 0;

                foreach (string file in lFiles)
                {
                    CurrentFile = lFiles.IndexOf(file) + 1;
                    CurrentProgress = (CurrentFile / TotalFiles) * 100;
                    bg.ReportProgress(CurrentProgress, "Parsing files (" + CurrentFile + "/" + TotalFiles + ")");

                    Imager i = new Imager(file);
                    i.ProgressChanged += I_ProgressChanged;
                    i.PDFToImage();
                }


                bg.ReportProgress(100, "Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed '" + MethodBase.GetCurrentMethod().Name + "': " + ex.ToString());
            }
        }

        private void I_ProgressChanged(object sender, ImagerProgressChangedEventArgs e)
        {
            if (lvProgress.InvokeRequired) { lvProgress.BeginInvoke((Action)(() => { AddProgress(e.Description.ToString()); })); }
            else { AddProgress(e.Description.ToString()); }
        }

        private void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (lvProgress.InvokeRequired) { lvProgress.BeginInvoke((Action)(() => { AddProgress(e.UserState.ToString()); })); }
            else { AddProgress(e.UserState.ToString()); }
        }
        private void AddProgress(string _ProgressText)
        {
            lvProgress.Items.Add(new ListViewItem(_ProgressText + " (" + DateTime.Now.ToString("HH:mm:ss") + ")"));
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            string cName = c.Name;
            int NextStep = 0;

            if (cName.EndsWithNumeric())
            {
                string temp = "";
                foreach (char ch in cName) { if (ch.ToString().isNumeric()) { temp += ch; } }
                NextStep = int.Parse(temp);
            }

            Control[] cStepPanels = this.Controls.Find("pStep" + NextStep, true);
            if (cStepPanels.Count() > 0)
            {
                Control nPanel = cStepPanels[0];
                nPanel.Visible = false;
                nPanel.Size = pStep1.Size;
                nPanel.AnimateIN(ControlExtensions.AnimateEffect.Slide, 300, 0);
            }
        }

        private void lblStep_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            string cName = c.Name;
            int StepNumber = 0;

            if (cName.EndsWithNumeric())
            {
                string temp = "";
                foreach (char ch in cName) { if (ch.ToString().isNumeric()) { temp += ch; } }
                StepNumber = int.Parse(temp);
            }

            //190, 30 (Hidden)

            Control[] cStepPanels = this.Controls.Find("pStep" + StepNumber, true);
            if (cStepPanels.Count() > 0)
            {
                Control nPanel = cStepPanels[0];
                nPanel.Size = new Size(190, 30);
            }
        }

        private void pbProgressShow_Click(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(pProgress.Location, pProgress.Size);
            r.Y += pProgressInner.Location.Y;

            if (!this.ClientRectangle.IntersectsWith(r)) { pProgress.Top -= (pProgressInner.Height + 5); }
            else { pProgress.Top += (pProgressInner.Height + 5); }
        }
    }
}
