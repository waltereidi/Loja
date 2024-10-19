using Dominio.loja.Interfaces.Files;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }

        public List<IFileTypeRestriction> Restriction { get; set; } = new();

        public static implicit operator string(DirectoryRestriction dr) => dr.Value;
        public DirectoryRestriction() { }
        public DirectoryRestriction(string value)
        {
            var jsonArray = JsonObject.Parse(value).AsArray().Any() ?
                JsonObject.Parse(value).AsArray().ToList()
                : null;

            if (jsonArray == null)
                return;

            jsonArray.ForEach(f => {
                FileType ft = new(f.ToJsonString());
                Restriction.Add(ChooseFileTypeRestriction(ft));
            });
        }
        /// <summary>
        ///  Select eligible validations to be applied <br></br>
        ///  Aggregate validations result <br></br>
        ///  Throw exception if any validation fails
        /// </summary>
        /// <param name="ft"></param>
        /// <param name="fi"></param>
        /// <exception cref="InvalidDataException"></exception>
        public void ValidateRestrictions(FileType ft, FileInfo fi)
        {
            List<IFileTypeRestriction> validations = Restriction.FindAll(x => x.Type == ft.Type
                || x.Type == typeof(All).Name
                || x.Type == typeof(ValidExtensions).Name);

            
            List<string> validationExceptions = new ();
            
            foreach(var res in validations)
            {
                validationExceptions.Add( TryValidate(res , ft , fi ) );
            }
            if (validationExceptions.Any())
            {
                string ex = validationExceptions.Aggregate((agg , next) => $"{agg}\n{next}");
                throw new InvalidDataException(ex);
            }
                
        }
        private string? TryValidate(IFileTypeRestriction res , FileType ft , FileInfo fi)
        {
            try
            {
                res.IsValid(ft, fi);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// Object type selection must remain as SSOT
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private IFileTypeRestriction ChooseFileTypeRestriction(FileType ft)
        {
            switch (ft.Type)
            {
                case "Pdf": return DeserializeFileTypeRestriction<Pdf>(ft);
                case "Image": return DeserializeFileTypeRestriction<Image>(ft);
                case "Excel": return DeserializeFileTypeRestriction<Excel>(ft);
                case "Doc": return DeserializeFileTypeRestriction<Doc>(ft);
                case "Video": return DeserializeFileTypeRestriction<Video>(ft);
                case "ValidExtensions":return  DeserializeFileTypeRestriction<ValidExtensions>(ft);
                case "All": return DeserializeFileTypeRestriction<All>(ft);
                default: throw new NotImplementedException();
            }
        }

        T DeserializeFileTypeRestriction<T>(FileType ft) where T : FileType
            => JsonSerializer.Deserialize<T>((string)ft);
    }
}
