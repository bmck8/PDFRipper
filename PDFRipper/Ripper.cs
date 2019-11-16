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
        /// https://www.pixel-technology.com/freeware/tessnet2


        public static List<string> TestEverything(string _ImageFilePath)
        {
            List<string> res = new List<string>();
            try
            {
                /// Grab image
                Bitmap image = new Bitmap(_ImageFilePath);

                /// Init OCR
                Tesseract ocr = new Tesseract();
                ocr.Init(@"D:\Git\PDFRipper\PDFRipper\Content\tessdata", "eng", false);

                ocr.ProgressEvent += Ocr_ProgressEvent;

                /// Full variable list
                var v = ocr.GetVariableList();

                /// Set character whitelist
                ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");


                List<Word> OCRResult = ocr.DoOCR(image, Rectangle.Empty);


                /// Get each line from the image
                int lMax = tessnet2.Tesseract.LineCount(OCRResult);
                for (int i = 0; i < lMax; i++) { Console.WriteLine(Tesseract.GetLineText(OCRResult, i)); }


                Random rnd = new Random();

                /// Get threshold image
                Bitmap thresholdImage = ocr.GetThresholdedImage(image, new Rectangle(0, 0, image.Size.Width, image.Size.Height));
                Bitmap thresholdImageWords = ocr.GetThresholdedImage(image, new Rectangle(0, 0, image.Size.Width, image.Size.Height));
                Bitmap thresholdImageChars = ocr.GetThresholdedImage(image, new Rectangle(0, 0, image.Size.Width, image.Size.Height));

                /// Mark identified chars/words
                using (Graphics g = Graphics.FromImage(thresholdImageWords))
                {
                    foreach (Word word in OCRResult)
                    {
                        g.DrawRectangle(new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), word.Left, word.Top, word.Right - word.Left, word.Bottom - word.Top);
                    }
                }

                using (Graphics g = Graphics.FromImage(thresholdImageChars))
                {
                    foreach (Word word in OCRResult)
                    {
                        foreach (Character c in word.CharList)
                        {
                            g.DrawRectangle(new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), c.Left, c.Top, c.Right - c.Left, c.Bottom - c.Top);
                        }
                    }
                }

                thresholdImageWords.Save(".\\Resources\\thresholdImageWords.png");
                thresholdImageChars.Save(".\\Resources\\thresholdImageChars.png");

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

