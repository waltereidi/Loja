using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public abstract class FileTypeAbstraction
    {
        public abstract void IsValid(object ft);
        public abstract void GenerateEmptyRestriction();
    }
}
