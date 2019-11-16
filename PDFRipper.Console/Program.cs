using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFRipper;

namespace PDFRipper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string FilePath = @"D:\Git\PDFRipper\PDFRipper\Resources\Test\1.tif";

                List<string> res = Ripper.TestEverything(FilePath);

                bool HasWords = res.Count > 0;

                Console.WriteLine(res.Count + " words detected in image");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
