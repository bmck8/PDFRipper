using System;
using PDFRipper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PDFRipper.UnitTests
{
    [TestClass]
    public class RipperTest
    {
        [TestMethod]
        public void TestImage()
        {
            try
            {
                string FilePath = @"D:\Git\PDFRipper\PDFRipper\Resources\Test\1.tif";

                List<string> res = Ripper.Test(FilePath);

                bool HasWords = res.Count > 0;

                Console.WriteLine(res.Count + " words detected in image");
                Assert.IsTrue(HasWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        [TestMethod]
        public void TestPDFSection()
        {
            try
            {
                string FilePath = @"D:\Git\PDFRipper\PDFRipper\Resources\Test\2.png";

                List<string> res = Ripper.Test(FilePath);

                bool HasWords = res.Count > 0;

                Console.WriteLine(res.Count + " words detected in image");
                Assert.IsTrue(HasWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        [TestMethod]
        public void TestAddress()
        {
            try
            {
                string FilePath = @"D:\Git\PDFRipper\PDFRipper\Resources\Test\3.png";

                List<string> res = Ripper.Test(FilePath);

                bool HasWords = res.Count > 0;

                Console.WriteLine(res.Count + " words detected in image");
                Assert.IsTrue(HasWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
