using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Framework.loja;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;


namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        List<FileStorage> _storage = new();
        public FileManager()
        {
        }
        public FileManager(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            if (_storage.Any(x => !ValidateExtension(x.Directory.ValidExtensions, x.Extension)))
                throw new InvalidDataException("Data extension is not allowed!");


            if (_storage.Any(x => x.Length > 10000000))
                throw new InvalidOperationException("Data size too Big");
            _storage.RemoveAll(x => x.OriginalName == null);
        }

        private bool ValidateExtension(string allowedExtensions, string type) => allowedExtensions.Split(';').Any(x => type.Contains(x));

        protected override void When(object @event)
        {
            switch (@event)
            {
                case CreateFile c: 
                    var file = new FileStorage(Apply);
                    ApplyToEntity(file, c);
                    _storage.Add(file); break;
                    
                case CreateFiles c:
                    c.files.ForEach(f =>  {
                        Apply(new CreateFile(f, c.fd) );
                        var file = new FileStorage(Apply);
                        _storage.Add(file); 
                    }); break;
                default: throw new NotImplementedException(nameof(@event));
            }
        }
        public List<FileStorage> GetCreatedFiles() => _storage;
        

    }
}
