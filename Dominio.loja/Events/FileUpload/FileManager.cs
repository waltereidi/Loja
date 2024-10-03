using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Entity.Integrations.WFileManager.Relation;
using Framework.loja;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        private FileRelation? _file { get; set; } 
        private FileInfo _fi { get; set; }
        public FileManager()
        {
        }
        public FileManager(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            var directoryRestrictions = _file.FileStorage.Directory.Restriction;

            directoryRestrictions.ValidateExtension(_file.FileStorage.Extension);

            
            if (_file.FileStorage.FileProperties != null)
                directoryRestrictions.ValidateExtensionProperties(_file.FileStorage.FileProperties);


        }
        public FileRelation GetFile()
        {
            var result = _file ?? throw new ArgumentNullException(nameof(_file));
            return result; 
        }
        protected override void When(object @event)
        {
            switch (@event)
            {
                case CategoryChangedPicture c: 
                    var file = new FileStorage(Apply);
                    ApplyToEntity(file, c);
                    BindRelation(new FileCategories(file , c.Category.Id.Value ), c.Fi );
                    break;
                default: throw new NotImplementedException(nameof(@event));
            }
        }

        protected void BindRelation(FileRelation rel , FileInfo fi)
        {
            _file = rel;
            _fi = fi;
        }
   
        

    }
}
