using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFRipper
{
    [Serializable]
    class Template
    {
        private string _Filepath = "";
        private string _FileDirectory = "";
        private string _Filename = "";

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Name = "";

        public ObservableCollection<Rectangle> AreasOfInterest
        {
            get { return _AreasOfInterest; }
            set { _AreasOfInterest = value; }
        }
        private ObservableCollection<Rectangle> _AreasOfInterest = new ObservableCollection<Rectangle>();


        public Template(string _TemplateFile)
        {
            Init();
        }


        private void Init()
        {
            if (_Filepath != null || _Filepath.Length > 0 || File.Exists(_Filepath))
            {
                _FileDirectory = Path.GetDirectoryName(_Filepath);
                _Filename = Path.GetFileNameWithoutExtension(_Filepath);
            }

            _AreasOfInterest.CollectionChanged += _AreasOfInterest_CollectionChanged;
        }


        private void _AreasOfInterest_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        public override string ToString()
        {
            return _Name;
        }

    }
}
