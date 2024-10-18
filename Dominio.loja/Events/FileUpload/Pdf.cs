using Dominio.loja.Interfaces.Files;
using Framework.loja.ExtensionMethods;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Pdf : FileType, IFileTypeRestriction
    { 
        private int Min { get; set; }
        private int Max { get; set; }
        public override string Type =>typeof(Pdf).Name;
        public int Pages { get; set; }
        private record FileProperty(int pages);

        public Pdf() { }

        public Pdf(int pages) 
        {
        }
        public void IsValid(object ft) 
        {
            Pdf pdf = (Pdf)ft;
            if (Min < pdf.Pages)
                throw new ArgumentOutOfRangeException($"The document should have ({Min}) pages , but have {pdf.Pages}");

            if (Max > 0 && pdf.Pages > Max)
                throw new ArgumentOutOfRangeException($"The document should have a maximum of ({Max}) pages , but have {pdf.Pages}");
        }

    };

}
