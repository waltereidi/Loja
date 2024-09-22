using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Framework.loja;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;
using static System.Net.Mime.MediaTypeNames;


namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        FileStorage _storage = new();
        public FileManager()
        {
        }
        public FileManager(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            if (!ValidateExtension(_storage.Directory.ValidExtensions, _storage.Extension))
                throw new InvalidDataException("Data extension is not allowed!");


            if (_storage.Length > 10000000)
                throw new InvalidOperationException("Data size too Big");
            
            //if(!_storage.Directory.Restriction.Validate(new FileInfo()))
            //{
            //   throw new Exception("Invalid file"); 
            //}
        }

        private bool ValidateExtension(string allowedExtensions, string type) => allowedExtensions.Split(';').Any(x => type.Contains(x));

        protected override void When(object @event)
        {
            switch (@event)
            {
                case CategoryChangedPicture c: 
                    var file = new FileStorage(Apply);
                    ApplyToEntity(file, c);
                    _storage = file; break;
                    
                
                default: throw new NotImplementedException(nameof(@event));
            }
        }
        private void CreteFileForCategory( CategoryChangedPicture cmd )
        {
            
        }
        public FileStorage GetCreatedFile() => _storage;
        

    }
}
