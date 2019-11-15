using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tessnet2;


namespace PDFRipper
{
    public class Ripper
    {
        /// So,
        /// Take a PDF file
        /// load into visible window
        /// mark areas of interest
        /// clip areas of interest into jpg
        /// OCR jpgs into text
        /// https://stackoverflow.com/questions/16598390/tesseract-ocr-simple-example
        /// https://github.com/tesseract-ocr/
        /// 
        /// 
        /// https://www.pixel-technology.com/freeware/tessnet2/

        public static List<string> Test(string _ImageFilePath)
        {
            List<string> res = new List<string>();
            try
            {
                /// Grab image
                Bitmap image = new Bitmap(_ImageFilePath);

                /// Init OCR
                Tesseract ocr = new Tesseract();
                ocr.Init(@"D:\Git\PDFRipper\PDFRipper\Content\tessdata", "eng", false);

                var result = ocr.DoOCR(image, Rectangle.Empty);

                /// Transfer to native list
                res = result.AsEnumerable().Select(x => x.Text).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }


    }
}

