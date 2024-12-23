﻿
using Dominio.loja.Interfaces.Files;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class ValidExtensions : FileType , IFileTypeRestriction
    {
        public override string Type => typeof(ValidExtensions).Name;
        public List<string> Extensions { get; set; } = new();
        public ValidExtensions() { }
        public ValidExtensions(string value) : base(value)
        {
        }

        /// <summary>
        /// Must be validated with <see cref="FileInfo"/>
        /// </summary>
        /// <param name="ft" ></param>
        /// <exception cref="InvalidDataException"></exception>
        public void IsValid(object ft , FileInfo fi)
        {
            if (Extensions.Count() > 0 && !Extensions.Any(x => fi.Extension.ToLower().Contains(x.ToLower())))
                throw new InvalidDataException("File extensions does not match");
        }

        public void Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
