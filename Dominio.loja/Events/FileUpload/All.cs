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
    public sealed class All : FileType, IFileTypeRestriction
    {
        public override string Type => typeof(All).Name;
        public long MaxLength { get; set; }
        public long MinLength { get; set; }
        public long Length { get; set; }
        public All(string value) : base(value)
        {
            DeserializeFileProperties();
        }

        public void DeserializeFileProperties()
        {
            All all = JsonSerializer.Deserialize<All>(base.Value);
            MaxLength = all.MaxLength;
            MinLength = all.MinLength;
        }

        public void IsValid(object ft)
        {
            All all = (All)ft;
            if (MaxLength != 0 && Length > MaxLength)
                throw new ArgumentOutOfRangeException($"Max file length allowed is {MaxLength} bytes , file sent has {Length}");
            if (Length < MinLength)
                throw new ArgumentOutOfRangeException($"Min file length allowed is {MinLength} bytes , file sent has {Length}");
        }

        public void SerializeFileProperties()
        {
            throw new NotImplementedException();
        }
    }
}
