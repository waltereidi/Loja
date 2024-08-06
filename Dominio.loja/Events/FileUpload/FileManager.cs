using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Framework.loja;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;


namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        List<FileStorage> _storage = new();
        
        public FileManager(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            if (_storage.Any(x => x.Length > 10000))
                throw new InvalidOperationException("Data size too Big");
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case CreateFile c: 
                    var file = new FileStorage(Apply);
                    ApplyToEntity(file, c);
                    _storage.Add(file); break;
                    
                case CreateFiles c:
                    c.fi.ForEach(f => {
                        Apply(new CreateFile(f, c.fd));
                        var file = new FileStorage(Apply);
                        _storage.Add(file); 
                    }); break;
                default: throw new NotImplementedException(nameof(@event));
            }
        }
        public List<FileStorage> GetCreatedFiles() => _storage;
        


    }
}
