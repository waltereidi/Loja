﻿using Dominio.loja.Entity.Integrations.WFileManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.loja.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class FileDirectoryTest
    {
        private readonly FileDirectory _fd = new FileDirectory("TestDir");
        [TestMethod]
        public void testc()
        {
            string fd = _fd.DirectoryName;

        }
        

        


    }
}