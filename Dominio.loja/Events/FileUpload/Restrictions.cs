using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class Restrictions
    {
        public record Restrictions(Image? image, Video? video, Pdf? pdf, Doc? doc, Excel? excel, All? all, DirectoryValidExtensions? extensions);

    }
}
