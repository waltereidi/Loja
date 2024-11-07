using Dominio.loja.Interfaces.Files;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;


namespace Dominio.loja.Events.FileUpload
{
    public sealed class Excel : FileType , IFileTypeRestriction ,IFileTypeProperty
    {
        public int Rows { get; set; }
        public int Sheets { get; set; }
        public int MaxRows { get; set; }
        public int MinRows { get; set; }
        public int MaxSheets { get; set; }    
        public int MinSheets { get; set; }

        public override string Type => typeof(Excel).Name;
        
        public Excel() { }
        public Excel(IFileTypeProperty ft) : base(ft.Value)
        {
        }


        public void IsValid(object ft, FileInfo fi) 
        {
            if (Rows < MinRows )
                throw new ArgumentOutOfRangeException($"Minimun amount of rows allowed is {MinRows} and was sent {Rows}");

            if (MaxRows > 0 && Rows > MaxRows)
                throw new ArgumentOutOfRangeException($"Maximun amount of rows allowed is {MaxRows} and was sent {Rows}");

            if (Sheets < MinSheets)
                throw new ArgumentOutOfRangeException($"Minimun amount of sheets allowed is {MinSheets} and was sent {Sheets}");

            if (MaxSheets > 0 && MaxSheets > Sheets)
                throw new ArgumentOutOfRangeException($"Maximum amount of sheets allowed is {MaxSheets} and was sent {Sheets}");
        }

        public void SetFileProperty(object fp)
        {
            var sheet = (FileProperties.Sheet)fp;
            Rows = sheet.rows;
            Sheets = sheet.sheets;
        }

        public void Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
