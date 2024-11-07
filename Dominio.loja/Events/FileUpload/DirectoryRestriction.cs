using Dominio.loja.Interfaces.Files;
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
            Value = value;
            var jsonArray = JsonObject.Parse(value).AsArray().Any() ?
                JsonObject.Parse(value).AsArray().ToList()
                : null;

            if (jsonArray == null)
                return;

            jsonArray.ForEach(f => {
                FileType ft = new(f.ToJsonString());
                Restriction.Add(ft.GetTypeRestriction());
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
        public void ValidateRestrictions(IFileTypeProperty ft, FileInfo fi)
        {
            if (!Restriction.Any())
                return;

            List<IFileTypeRestriction> validations = Restriction.FindAll(x => x.Type == ft.Type
                || x.Type == typeof(All).Name
                || x.Type == typeof(ValidExtensions).Name);

            List<string> validationExceptions = new ();
            
            foreach(var res in validations)
            {
                var result = GetValidationResult(res, ft, fi);
                if (!String.IsNullOrEmpty(result))
                    validationExceptions.Add(result);
            }
            if (validationExceptions.Any())
            {
                string ex = validationExceptions.Aggregate((agg , next) => $"{agg}\n{next}");
                throw new InvalidDataException(ex);
            }
                
        }
        private string? GetValidationResult(IFileTypeRestriction res ,  IFileTypeProperty ft , FileInfo fi)
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
 

    }
}
