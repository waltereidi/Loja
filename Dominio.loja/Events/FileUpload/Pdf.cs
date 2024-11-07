using Dominio.loja.Interfaces.Files;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

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

        public Pdf(IFileTypeProperty ft) : base(ft.Value) { }

        public void IsValid(object ft , FileInfo fi) 
        {
            Pdf pdf = (Pdf)ft;
            if (Min < pdf.Pages)
                throw new ArgumentOutOfRangeException($"The document should have ({Min}) pages , but have {pdf.Pages}");

            if (Max > 0 && pdf.Pages > Max)
                throw new ArgumentOutOfRangeException($"The document should have a maximum of ({Max}) pages , but have {pdf.Pages}");
        }

        public void Deserialize()
        {
            throw new NotImplementedException();
        }
    };

}
