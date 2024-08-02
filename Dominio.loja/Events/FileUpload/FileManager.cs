using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        List<FileStorage> FileStorages = new List<FileStorage>(); 
        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case FileManagerEvents.Files c:
                    //var Files= new FileDirectory(Apply);
                    //ApplyToEntity(Files, c);
                    break;

                default: throw new NotImplementedException();
            }
        }
    }
}
