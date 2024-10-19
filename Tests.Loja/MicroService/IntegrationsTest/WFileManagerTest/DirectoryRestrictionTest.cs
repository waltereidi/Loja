using Dominio.loja.Events.FileUpload;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.loja.MicroService.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class DirectoryRestrictionTest
    {
        private string RestrictionJson { get; set; }
        public DirectoryRestrictionTest()
        {
            RestrictionJson = "[";
            RestrictionJson += "{ \"Type\" : \"Image\" },";
            RestrictionJson += "{ \"Type\" : \"Pdf\" },";
            RestrictionJson += "{ \"Type\" : \"Excel\" },";
            RestrictionJson += "{ \"Type\" : \"Doc\" },";
            RestrictionJson += "{ \"Type\" : \"Video\" },";
            RestrictionJson += "{ \"Type\" : \"All\" },";
            RestrictionJson += "{\"Type\":\"ValidExtensions\",\"Extensions\":[\"pdf\",\"jpg\"]}";
            RestrictionJson += "]";
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
            

            ValidExtensions ext = new ValidExtensions();
            ext.Extensions.Add("pdf");
            ext.Extensions.Add("jpg");
            ext.SerializeFileProperties();
            

            var dr = new DirectoryRestriction(RestrictionJson);
        }
    }
}
