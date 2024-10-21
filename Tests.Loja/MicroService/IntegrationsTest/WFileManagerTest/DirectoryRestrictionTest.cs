using Dominio.loja.Events.FileUpload;
using Dominio.loja.Interfaces.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.Record;
using System.Text.Json;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;

namespace Tests.loja.MicroService.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class DirectoryRestrictionTest
    {
        private List<IFileTypeProperty> fileProperties = new();
        private string RestrictionJson { get; set; }
        private TestFilesReader FileReader= new();
        public DirectoryRestrictionTest()
        {
            List<FileProperties.Dimensions> dim = new();
            dim.Add(new FileProperties.Dimensions(273, 567));
            dim.Add(new FileProperties.Dimensions(1980, 1000));
            string dimensionsJson=JsonSerializer.Serialize(dim);

            RestrictionJson = "[";
            RestrictionJson += "{ \"Type\" : \"Image\" , \"Dimensions\":"+ dimensionsJson + " },";
            RestrictionJson += "{ \"Type\" : \"Pdf\" },";
            RestrictionJson += "{ \"Type\" : \"Excel\" },";
            RestrictionJson += "{ \"Type\" : \"Doc\" },";
            RestrictionJson += "{ \"Type\" : \"Video\" },";
            RestrictionJson += "{ \"Type\" : \"All\" },";
            RestrictionJson += "{\"Type\":\"ValidExtensions\",\"Extensions\":[\"pdf\",\"jpg\" , \"png\"]}";
            RestrictionJson += "]";

        }

        [TestMethod]
        public void DirectoryRestriction()
        {
            var i = typeof(Type).Name; 
            
            var dr = new DirectoryRestriction(RestrictionJson);
            var fi = FileReader.GetTestImageFi();
            var prop = new Image();
            
            prop.SetFileProperty(new FileProperties.Dimensions(273 , 567 ));
            dr.ValidateRestrictions(prop, fi);
        }
    }
}
