using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.loja;
using WFileManager.loja.Interfaces;
using WFileManager.loja.WriteStrategy;
namespace Tests.loja.Integrations
{
    [TestClass]
    public class WFileManagerTest
    {
        private readonly WFileManager.loja.WFileManager _fileManager = new WFileManager.loja.WFileManager();
        public WFileManagerTest() 
        { 
        }
         [TestMethod]
        public async void UploadFileShouldReturnFileInfo()
        {
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            IFileStrategy strategy = new UploadFile(file);

            //Act
            _fileManager.StartAsync<FileInfo>(strategy)
                .ContinueWith(_=> Assert.IsInstanceOfType(_.Result, typeof(IActionResult)));
            
        }
    }
}
