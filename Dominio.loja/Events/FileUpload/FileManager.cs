using Dominio.loja.Entity.Integrations.WFileManager;
using Framework.loja;


namespace Dominio.loja.Events.FileUpload
{
    public class FileManager : AggregateRoot<int>
    {
        FileStorage storage;
        public FileManager(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case FileManagerEvents.CreateFiles c:
                    var Files= new FileStorage(Apply);
                    ApplyToEntity(Files, c);
                    break;

                default: throw new NotImplementedException();
            }
        }


    }
}
