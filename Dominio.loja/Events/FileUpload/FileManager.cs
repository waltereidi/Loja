using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Entity.Integrations.WFileManager.Relation;
using Framework.loja;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        private FileStorage _storage = new();
        private FileRelation? _file { get; set; } 
        public FileManager()
        {
        }
        public FileManager(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            _storage.Directory.Restriction.Validate(new FileInfo(""));
            
            //if(!_storage.Directory.Restriction.Validate(new FileInfo()))
            //{
            //   throw new Exception("Invalid file"); 
            //}
        }


        protected override void When(object @event)
        {
            switch (@event)
            {
                case CategoryChangedPicture c: 
                    var file = new FileStorage(Apply);
                    ApplyToEntity(file, c);
                    _storage = file;
                    _file = new FileCategories();
                    break;
                    
                
                default: throw new NotImplementedException(nameof(@event));
            }
        }
        private void CreteFileForCategory( CategoryChangedPicture cmd )
        {
            
        }
        public FileStorage GetCreatedFile() => _storage;
        

    }
}
