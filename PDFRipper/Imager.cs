/// 
/// PDF to image convestion by ImageMagick https://github.com/dlemstra/Magick.NET
/// 


using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace PDFRipper
{
    public class Imager
    {
        private string _FileDirectory = "";
        private string _Filename = "";
        private string _nFilepath = "";
        private string _Filepath = "";

        public event EventHandler<ImagerProgressChangedEventArgs> ProgressChanged;

        public Imager()
        {

        }
        public Imager(string _Filepath)
        {
            this._Filepath = _Filepath;
        }

        private void Init()
        {
            if (_Filepath != null || _Filepath.Length > 0 || File.Exists(_Filepath))
            {
                _FileDirectory = Path.GetDirectoryName(_Filepath);
                _Filename = Path.GetFileNameWithoutExtension(_Filepath);
                _nFilepath = Path.Combine(new[] { _FileDirectory, _Filename });
            }
        }


        public List<Bitmap> PDFToImage()
        {
            if (_FileDirectory != null || _FileDirectory.Length > 0 || _Filepath != null || _Filepath.Length > 0) { Init(); }

            return PDFToImage(_Filepath);
        }
        public List<Bitmap> PDFToImage(string _Filepath)
        {
            if (_Filepath == null || _Filepath.Length == 0 || !File.Exists(_Filepath)) { throw new ArgumentException("File path must be an existing file"); }

            List<Bitmap> lRes = new List<Bitmap>();

            if (!Directory.Exists(_nFilepath)) { Directory.CreateDirectory(_nFilepath); }

            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(200, 200);

            using (MagickImageCollection ic = new MagickImageCollection())
            {
                ProgressChanged?.Invoke(this, new ImagerProgressChangedEventArgs("Loading " + _Filename));
                ic.Read(_Filepath, settings);

                int CurrentFile = 1;
                int TotalFiles = ic.Count;
                int CurrentProgress = 0;
                int page = 1;

                foreach (MagickImage image in ic)
                {
                    CurrentFile = ic.IndexOf(image) + 1;
                    CurrentProgress = (CurrentFile / TotalFiles) * 100;
                    string nFilename = _Filename + ".Page" + page + ".jpg";
                    string nFilePath = _nFilepath + "\\" + nFilename;

                    ProgressChanged?.Invoke(this, new ImagerProgressChangedEventArgs("Writing files (" + CurrentFile + "/" + TotalFiles + ")"));
                    image.Format = MagickFormat.Jpeg;
                    image.Write(nFilePath);

                    if (File.Exists(nFilePath)) { lRes.Add(new Bitmap(nFilePath)); }

                    page++;
                }
            }

            return lRes;
        }

        private void MagickNET_Log(object sender, LogEventArgs e)
        {
            try
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed '" + MethodBase.GetCurrentMethod().Name + "': " + ex.ToString());
            }
        }
    }


    public class ImagerProgressChangedEventArgs : EventArgs
    {
        public object Description
        {
            get; private set;
        }

        public ImagerProgressChangedEventArgs(object _Description)
        {
            this.Description = _Description;
        }
    }
}
