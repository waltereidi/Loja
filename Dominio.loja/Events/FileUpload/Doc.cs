using Dominio.loja.Interfaces.Files;
using Framework.loja.ExtensionMethods;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;


namespace Dominio.loja.Events.FileUpload
{
    public sealed class Doc : FileType , IFileTypeRestriction, IFileTypeProperty
    {
        public int MaxPages { get; set; }
        public int MinPages {  get; set; }
        public int Pages { get; set; }

        public override string Type => typeof(Doc).Name;
        public Doc() { }

        public Doc(IFileTypeProperty ft) : base(ft.Value)
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

        public void SetFileProperty(object fp)
        {
            var pages = (FileProperties.Pages)fp;
            Pages = pages.pages;
        }

        public void Deserialize()
        {
            throw new NotImplementedException();
        }
    }

}
