using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Entity.Integrations.WFileManager.Relation;
using Framework.loja;
using Framwork.loja.Utility.Files;
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
            ValidateExtension();
            ValidateRestrictionsTypeAll();
               
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
        private void ValidateExtension()
        {

        }
        private void ValidateRestrictionsTypeAll()
        {
            var all =_file.FileStorage.Directory.Restriction.Restriction.all;

            if (all.min > 0 && all.min < _fi.Length)
            {
                throw new InvalidDataException($"File length smaller than {(string)new ReadableFileLength(_fi.Length)}");
            }

            if (all.max > 0 && all.max > _fi.Length)
            {
                throw new InvalidDataException($"File length bigger than {(string)new ReadableFileLength(_fi.Length)}");
            }
        }

    }
}
