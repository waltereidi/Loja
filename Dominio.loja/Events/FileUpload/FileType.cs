using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class FileType
    {
        public record All(long max, long min);
        public record Image(int heigth, int width);
        public record Video(int heigth, int width, int length);
        public record Pdf();
        public record Doc();
        public record Excel();
    }
}
