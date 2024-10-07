using LogicExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Contracts;

namespace Tests.loja.MicroService.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class FileManagerLogTest
    {

        public FileManagerLogTest() { }

        [TestMethod]
        public void TestFileManagerLogAndResultRetrieval()
        {
            FileManagerLog fml = new();
            
            fml.AddEvent("Test", true, "TP");
            fml.AddEvent("Test2", true, null);
            fml.AddEvent("Test3", true, "TP");
            fml.AddEvent("Test4", true, "TP");
            fml.AddEvent("Test5", false, "TP");
            fml.AddEvent("Test6", true, "TP");

            string elog = fml.ErrorLog;
            Assert.IsFalse(fml.Success);
            Assert.IsFalse(elog.IsNullOrEmpty());
        }
    }
}
