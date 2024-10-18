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
        public void GenerateSerializedProperties_All()
        {
            All all = new All();
        }


        [TestMethod]
        public void DirectoryRestriction()
        {
            var i = typeof(Type).Name; 
            string json = "[";
            json += "{ \"Type\" : \"Image\" },";
            json += "{ \"Type\" : \"Pdf\" },";
            json += "{ \"Type\" : \"Excel\" },";
            json += "{ \"Type\" : \"Doc\" },";
            json += "{ \"Type\" : \"Video\" },";
            json += "{ \"Type\" : \"All\" },";
            json += "{\"Type\":\"ValidExtensions\",\"Extensions\":[\"pdf\",\"jpg\"]}";
            json += "]";

            ValidExtensions ext = new ValidExtensions();
            ext.Extensions.Add("pdf");
            ext.Extensions.Add("jpg");
            ext.SerializeFileProperties();
            

            var dr = new DirectoryRestriction(json);
        }
    }
}
