using Integrations;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npoi.Mapper;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
using WFileManager.loja.ReadStrategy;
using WFileManager.loja.WriteStrategy;

namespace Tests.loja.MicroServices.IntegrationsTest.WFileManagerTest
{
    [TestClass]
    public class FileManagerTest
    {
        private readonly FileManagerMS _fileManager = new();
        public FileManagerTest()
        {
        }
        /// <summary>
        /// Upload file should create a temporary file <br></br>
        /// commit the temporary file should save it on its correct position <br></br>
        /// Dispose must delete a temporary file if still exists <br></br>
        /// </summary>
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
            IFileStrategy strategy = new UploadFile(file, "testCase");

            //Act
            var result = _fileManager.Start<UploadContracts.UploadResponse>(strategy );
            result.ForEach(f => f.CommitFile());

            IFileStrategy readStrategy = new ReadFile(result.First().FileName, result.First().GetDirectory());
            var files = _fileManager.Start<FileStream>(readStrategy);
            var bytes = files.First().ReadByte();

            //The uploaded file is in mentioned directory 
            Assert.IsTrue(result.Any(x => x.GetFileInfo().Exists ));
            //The temporary file is deleted 
            Assert.IsFalse(result.Any(x => File.Exists(x.FullName)));
            //
            Assert.IsNotNull(bytes);

        }
    }
}
