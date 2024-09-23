using System.Drawing;

namespace WFileManager.Contracts
{
    public class UploadImageResponse : UploadContracts.UploadResponse
    {
        public int Width { get; set; }
        public int Height { get; set; }
        
        public UploadImageResponse(FileInfo file, string originalFileName, DirectoryInfo nonTemporaryDirectory) : base(file , originalFileName , nonTemporaryDirectory)
        { 
           
        }
        public Bitmap GetBitMap()
        {
            var bitmap = new Bitmap(base.NonTemporaryFile.Exists ? base.NonTemporaryFile.FullName : base.FullName);
            return bitmap;
        }
    }
}
