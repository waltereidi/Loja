using Dominio.loja.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Doc : FileType , IFileTypeRestriction
    {
        public int MaxPages { get; set; }
        public int MinPages {  get; set; }
        [JsonIgnore]
        public int Pages { get; set; }

        public override string Type => typeof(Doc).Name;

        public void GenerateEmptyRestriction()
        {
            MinPages = 0;
            MaxPages = 0;
        }
        public Doc(FileType ft) { }
        public void IsValid(object ft) 
        {
            Doc doc = (Doc)ft;
            if(Pages < MinPages)
                throw new ArgumentOutOfRangeException($"Maximun allowed pages is ${MinPages} and was sent ${Pages}");

            if ( MaxPages > 0 && Pages > MaxPages)
                throw new ArgumentOutOfRangeException($"Maximun allowed pages is ${MaxPages} and was sent ${Pages}");
        }

        public void SerializeFileProperties()
        {
            throw new NotImplementedException();
        }

        public void DeserializeFileProperties()
        {
            throw new NotImplementedException();
        }
    };

}
