using Dominio.loja.Interfaces.Files;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;


namespace Dominio.loja.Events.FileUpload
{
    public sealed class All : FileType, IFileTypeRestriction
    {
        public override string Type => typeof(All).Name;
        public long MaxLength { get; set; }
        public long MinLength { get; set; }

        public All(IFileTypeProperty ft) : base(ft.Value)
        {
            
        }
        public All() { }

        /// <summary>
        /// Must be validated with <see cref="FileInfo"/>
        /// </summary>
        /// <param name="ft" ></param>
        /// <exception cref="InvalidDataException"></exception>
        public void IsValid(object ft , FileInfo fi)
        {
            if (MaxLength != 0 && fi.Length > MaxLength)
                throw new ArgumentOutOfRangeException($"Max file length allowed is {MaxLength} bytes , file sent has {fi.Length}");
            if (fi.Length < MinLength)
                throw new ArgumentOutOfRangeException($"Min file length allowed is {MinLength} bytes , file sent has {fi.Length}");
        }

    }
}
