using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class Pdf : FileType 
    { 
        private int Min { get; set; }
        private int Max { get; set; }
        [JsonIgnore]
        public int Pages { get; set; }
        public Pdf() { }
        public Pdf(int pages) 
        {
            Pages = pages; 
        }
        public override void IsValid(object ft) 
        {
            Pdf pdf = (Pdf)ft;
            if (Min < pdf.Pages)
                throw new ArgumentOutOfRangeException($"The document should have ({Min}) pages , but have {pdf.Pages}");

            if (Max > 0 && pdf.Pages > Max)
                throw new ArgumentOutOfRangeException($"The document should have a maximum of ({Max}) pages , but have {pdf.Pages}");
        }
        public override void GenerateEmptyRestriction()
        {
            Min = 0; 
            Max = 0;
        }

    };

}
