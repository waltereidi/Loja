using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framwork.loja.Utility.Files;
using LogicExtensions;

namespace Framework.loja.DomainTest.FileUploadTest
{
    [TestClass]
    public class ReadableFileLengthTest
    {

        public ReadableFileLengthTest() { }

        [TestMethod]
        [DataRow(1)]
        [DataRow(1001)]
        [DataRow(1000001)]
        [DataRow(1000000001)]
        [DataRow(1000000000001)]
        public void ReadableFileLengthReturnsKB_MB_GB(long size) 
        {
            string readableFileLength = (string)new ReadableFileLength(size);
            
            Assert.IsTrue(!readableFileLength.IsNullOrEmpty());
        }
    }
}
