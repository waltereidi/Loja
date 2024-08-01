using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFileManager.Contracts
{
    public class UploadContracts
    {
        public record class UploadResponse( FileInfo file , string OriginalFileName );
    }
}
