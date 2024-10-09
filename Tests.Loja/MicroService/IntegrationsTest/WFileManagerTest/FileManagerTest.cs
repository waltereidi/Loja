using Integrations;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npoi.Mapper;
using System.Drawing;
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
        private readonly TestFilesReader _testFilesReader = new TestFilesReader();
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
            IFileStrategy strategy = new UploadFile(file, "testCase", null);

            //Act
            var result = _fileManager.Start<UploadContracts.UploadResponse>(strategy )
                .ContinueWith(_ =>
                {
                    _.Result.ForEach(f => f.CommitFile());
                    IFileStrategy readStrategy = new ReadFile(_.Result.First().FileName, _.Result.First().GetDirectory());
                    var files = _fileManager.Start<FileStream>(readStrategy);
                    var bytes = files.Result.First().ReadByte();

                    //The uploaded file is in mentioned directory 
                    Assert.IsTrue(_.Result.Any(x => x.GetFileInfo().Exists));
                    //The temporary file is deleted 
                    Assert.IsFalse(_.Result.Any(x => File.Exists(x.FullName)));
                    //
                    Assert.IsNotNull(bytes);
                });

        }
        [TestMethod]
        public void UploadImageShouldReturnFileInfo()
        {
            MemoryStream ms = _testFilesReader.GetTestImage();
            IFormFile file = new FormFile(ms, 0, ms.Length, "id_from_form", "testfile.png");
            IFileStrategy strategy = new UploadFile(file, "testCase" , WFileManager.Enum.UploadOptions.Image );

            _fileManager.Start<Images.UploadResponse>(strategy)
                .ContinueWith(_ => Assert.IsTrue(_.Result.First().Height > 0)).Wait();
        }
        [TestMethod]
        public void TestNewBitMap()
        {
            var bm = new Bitmap(_testFilesReader.GetTestImageFi().FullName);
            Assert.IsNotNull(bm);
        }
    }
}
