using Integrations;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFileManager.loja.Interfaces;
using WFileManager.loja.WriteStrategy;

namespace Tests.loja.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class FileManagerTest
    {
        private readonly  FileManager _fileManager = new FileManager();
        public FileManagerTest()
        {
        }

        [TestMethod]
        public void UploadFileShouldReturnFileInfo()
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
                .ContinueWith(_ => Assert.IsFalse(_.Result.Any(x=>!x.Exists)));

        }
    }
}
