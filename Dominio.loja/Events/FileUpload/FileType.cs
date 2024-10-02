
using static Dominio.loja.Events.FileUpload.DirectoryRestriction;
using System.Text.Json;

namespace Dominio.loja.Events.FileUpload
{
    public abstract class FileType
    {
        public abstract void IsValid(object ft);
        public virtual string GetSerializedOptions()
        {
            return JsonSerializer.Serialize(this);
        }
    }




}
