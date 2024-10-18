using Dominio.loja.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Doc : FileType , IFileTypeRestriction
    {
        public int MaxPages { get; set; }
        public int MinPages {  get; set; }
        public int Pages { get; set; }

        public override string Type => typeof(Doc).Name;
        public Doc() { }
        public Doc(int pages )
        {
            Pages = pages;
        }

        public Doc(string value) : base(value)
        {
        }

        public void IsValid(object ft , FileInfo fi) 
        {
            Doc doc = (Doc)ft;
            if(Pages < MinPages)
                throw new ArgumentOutOfRangeException($"Maximun allowed pages is ${MinPages} and was sent ${Pages}");

            if ( MaxPages > 0 && Pages > MaxPages)
                throw new ArgumentOutOfRangeException($"Maximun allowed pages is ${MaxPages} and was sent ${Pages}");
        }

    };

}
