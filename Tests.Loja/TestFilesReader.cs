using NPOI.POIFS.NIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.loja
{
    public class TestFilesReader : Configuration
    {
        public readonly DirectoryInfo TestImagesDir;

        public TestFilesReader()  : base()
        {
            TestImagesDir = new(base._testDirPath.FullName + "/TestFiles/TestImages/");
            
        }
        public MemoryStream GetTestImage()
        {
            var file = TestImagesDir.GetFiles().First();

            var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);

            MemoryStream ms = new MemoryStream();
            fs.CopyTo(ms);
            return ms;
        }
    }
}
