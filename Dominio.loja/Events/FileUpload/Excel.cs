
using Dominio.loja.Interfaces.Files;
using System.Text.Json.Serialization;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Excel : FileType , IFileTypeRestriction
    {
        [JsonIgnore]
        public int Rows { get; set; }
        [JsonIgnore]
        public int Sheets { get; set; }
        public int MaxRows { get; set; }
        public int MinRows { get; set; }
        public int MaxSheets { get; set; }    
        public int MinSheets { get; set; }

        public override string Type => typeof(Excel).Name;
        
        public Excel() { }
        public Excel(int rows , int sheets)
        {
            Rows = rows; 
            Sheets = sheets;
        }

        public Excel(string value) : base(value)
        {
        }

        public void IsValid(object ft) 
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
        public void GenerateEmptyRestriction()
        {
            MaxRows = 0;
            MinRows = 0;
            MaxSheets = 0;
            MinSheets = 0;
        }

        public void SerializeFileProperties()
        {
            throw new NotImplementedException();
        }

        public void DeserializeFileProperties()
        {
            throw new NotImplementedException();
        }
    }
}
