using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.loja.Utility;

namespace Tests.loja.Integrations.WFileManager
{
    [TestClass]
    public class FileManagerUtilityTest
    {
        private readonly FileManagerUtility _utility;
        public FileManagerUtilityTest()=>_utility = new FileManagerUtility();

        [TestMethod]
        public void FileManagerUtilityTestReturnsExtension()
        {
            string ext = _utility.GetFileExtension("testCase.txt");
            Assert.IsTrue( ext.Equals(".txt"));
        }
    }
}
