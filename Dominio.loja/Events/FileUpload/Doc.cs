using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class Doc : FileType 
    {
        public int MaxPages { get; set; }
        public int MinPages {  get; set; }
        [JsonIgnore]
        public int Pages { get; set; }  
        public override void GenerateEmptyRestriction()
        {
            MinPages = 0;
            MaxPages = 0;
        }
        public Doc() { }
        public override void IsValid(object ft) 
        {
            Doc doc = (Doc)ft;
            if(Pages < MinPages)
                throw new ArgumentOutOfRangeException($"Maximun allowed pages is ${MinPages} and was sent ${Pages}");

            if ( MaxPages > 0 && Pages > MaxPages)
                throw new ArgumentOutOfRangeException($"Maximun allowed pages is ${MaxPages} and was sent ${Pages}");
        } 
    };

}
