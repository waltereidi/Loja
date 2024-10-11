using Framwork.loja.Utility.Files;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }
        public Restrictions Restriction { get; private set; }
        public DirectoryRestriction() { }
        
        public DirectoryRestriction(string value)
        {
            Restriction =!value.IsNullOrEmpty() ? JsonSerializer.Deserialize<Restrictions>(value) : GenerateEmptyRestrictions() ;

            Value = value;
        }


        public static implicit operator string(DirectoryRestriction dr)=> dr.Value;

        public void ValidateExtension(string extension) => Restriction.extensions?.Validate(extension);


        private void ValidateRestrictionsTypeAll(int length)
        {
            var all = Restriction.all;

            if (all.min > 0 && all.min < length)
            {
                throw new InvalidDataException($"File length smaller than {(string)new ReadableFileLength(length)}");
            }

            {
                throw new InvalidDataException($"File length bigger than {(string)new ReadableFileLength(length)}");
            }
        }
    }
}
