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
    class Doc
    {
        private string _Filepath = "";
        private string _FileDirectory = "";
        private string _Filename = "";

        private ObservableCollection<string> _ImagePaths = new ObservableCollection<string>();
        private ObservableCollection<Bitmap> _Images = new ObservableCollection<Bitmap>();

        public ObservableCollection<Template> Templates
        {
            get { return _Templates; }
            set { _Templates = value; }
        }
        private ObservableCollection<Template> _Templates = new ObservableCollection<Template>();


        /// Workflow -
        ///     Create a doc (assign path to PDF, manage images etc
        ///     Convert images (convert pages to images)
        ///         Store paths to images
        ///     Assign template (template defines areas of interest on the document)
        ///     Crop images down to template areas

        public Doc() : this("")
        {
        }
        public Doc(string _Filepath)
        {
            this._Filepath = _Filepath;

            Init();
        }


        private void Init()
        {
            if (_Filepath != null || _Filepath.Length > 0 || File.Exists(_Filepath))
            {
                _FileDirectory = Path.GetDirectoryName(_Filepath);
                _Filename = Path.GetFileNameWithoutExtension(_Filepath);
            }

            _ImagePaths.CollectionChanged += _ImagePaths_CollectionChanged; ;
            _Images.CollectionChanged += _Images_CollectionChanged;
        }


        public void ConvertToImage()
        {

        }



        private void _ImagePaths_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void _Images_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }
    }
}
