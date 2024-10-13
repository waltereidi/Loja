using Dominio.loja.Events.FileUpload;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.loja.MicroService.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class DirectoryRestrictionTest
    {

        public DirectoryRestrictionTest()
        {

        }

        [TestMethod]
        public void DirectoryRestriction()
        {
            string json = "[";
            json += "{ \"Type\" : \"Image\" },";
            json += "{ \"Type\" : \"Pdf\" },";
            json += "{ \"Type\" : \"Excel\" },";
            json += "{ \"Type\" : \"Doc\" },";
            json += "{ \"Type\" : \"Video\" }";
            json += "]";

            var dr = new DirectoryRestriction(json);

        }
    }
}
