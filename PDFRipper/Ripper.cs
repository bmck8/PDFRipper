using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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
        /// https://www.pixel-technology.com/freeware/tessnet2


        public static List<string> TestEverything(string _ImageFilePath)
        {
            List<string> res = new List<string>();
            try
            {
                /// File name
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileInfo fi = new FileInfo(_ImageFilePath);
                FileName = fi.Name;

                string ResultsPath = ".\\Results\\" + FileName;
                if (!Directory.Exists(ResultsPath)) { Directory.CreateDirectory(ResultsPath); }

                /// Grab image
                Bitmap imgOG = new Bitmap(_ImageFilePath);
                imgOG.Save(ResultsPath + "\\0_imgOriginal.png");
                Bitmap imgGray = GrayScaleFilter(imgOG);
                imgGray.Save(ResultsPath + "\\1_imgMod_Gray.png");

                Bitmap imgBW = BWFilter(imgOG);
                imgBW.Save(ResultsPath + "\\1_imgMod_BW.png");


                Tesseract tess = new Tesseract();

                /// Full variable list
                var v = tess.GetVariableList();

                /// Set character whitelist
                string charWhitelist = tess.GetVariable("tessedit_char_whitelist").ToString();
                tess.SetVariable("tessedit_char_whitelist", "");
                charWhitelist = tess.GetVariable("tessedit_char_whitelist").ToString();
                //ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

                tess.Init(@"D:\Git\PDFRipper\PDFRipper\Content\tessdata", "eng", false);

                tess.ProgressEvent += Ocr_ProgressEvent;



                List<Word> OCRRes_OG = tess.DoOCR(imgOG, Rectangle.Empty);
                List<Word> OCRRes_Gray = tess.DoOCR(imgGray, Rectangle.Empty);
                List<Word> OCRRes_BW = tess.DoOCR(imgBW, Rectangle.Empty);


                /// Get each line from the image
                int lMax = tessnet2.Tesseract.LineCount(OCRRes_OG);
                Console.WriteLine(" - Original image processing results - ");
                for (int i = 0; i < lMax; i++) { Console.WriteLine(Tesseract.GetLineText(OCRRes_OG, i)); }
                Console.WriteLine();

                lMax = tessnet2.Tesseract.LineCount(OCRRes_Gray);
                Console.WriteLine(" - Grayscale image processing results - ");
                for (int i = 0; i < lMax; i++) { Console.WriteLine(Tesseract.GetLineText(OCRRes_Gray, i)); }
                Console.WriteLine();

                lMax = tessnet2.Tesseract.LineCount(OCRRes_BW);
                Console.WriteLine(" - Black & white image processing results - ");
                for (int i = 0; i < lMax; i++) { Console.WriteLine(Tesseract.GetLineText(OCRRes_BW, i)); }
                Console.WriteLine();

                /// Get threshold image
                Bitmap imgResult = tess.GetThresholdedImage(imgOG, new Rectangle(0, 0, imgOG.Size.Width, imgOG.Size.Height));
                Bitmap imgResult_Word = tess.GetThresholdedImage(imgOG, new Rectangle(0, 0, imgOG.Size.Width, imgOG.Size.Height));
                Bitmap imgResult_Char = tess.GetThresholdedImage(imgOG, new Rectangle(0, 0, imgOG.Size.Width, imgOG.Size.Height));

                /// Mark identified chars/words
                Random rnd = new Random();
                using (Graphics g = Graphics.FromImage(imgResult_Word))
                {
                    foreach (Word word in OCRRes_OG)
                    {
                        g.DrawRectangle(new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), word.Left, word.Top, word.Right - word.Left, word.Bottom - word.Top);
                    }
                }

                using (Graphics g = Graphics.FromImage(imgResult_Char))
                {
                    foreach (Word word in OCRRes_OG)
                    {
                        foreach (Character c in word.CharList)
                        {
                            g.DrawRectangle(new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), c.Left, c.Top, c.Right - c.Left, c.Bottom - c.Top);
                        }
                    }
                }

                imgResult.Save(ResultsPath + "\\imgResult.png");
                imgResult_Word.Save(ResultsPath + "\\imgResult_Word.png");
                imgResult_Char.Save(ResultsPath + "\\imgResult_Char.png");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }

        private static void Ocr_ProgressEvent(int percent)
        {
            Console.WriteLine("OCR progress: " + percent + "%");
        }

        public static Bitmap GrayScaleFilter(Bitmap image)
        {
            Bitmap grayScale = new Bitmap(image.Width, image.Height);

            for (Int32 y = 0; y < grayScale.Height; y++)
            {
                for (Int32 x = 0; x < grayScale.Width; x++)
                {
                    Color c = image.GetPixel(x, y);

                    Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                    grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
                }
            }

            return grayScale;
        }

        public static Bitmap BWFilter(Bitmap image)
        {
            using (Graphics gr = Graphics.FromImage(image))
            {
                var gray_matrix = new float[][] {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
                };

                var ia = new ImageAttributes();
                ia.SetColorMatrix(new ColorMatrix(gray_matrix));
                ia.SetThreshold(0.8f); // Change this threshold as needed

                var rc = new Rectangle(0, 0, image.Width, image.Height);
                gr.DrawImage(image, rc, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);


            }

            return image;
        }

        public static List<string> Test(string _ImageFilePath)
        {
            List<string> res = new List<string>();
            try
            {
                /// Grab image
                Bitmap image = new Bitmap(_ImageFilePath);

                /// Init OCR
                Tesseract ocr = new Tesseract();
                var v = ocr.GetVariableList();

                /// Set character whitelist
                ///ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"); 

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

