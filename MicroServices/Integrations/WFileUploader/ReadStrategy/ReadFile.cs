using WFileManager.loja.Interfaces;

namespace WFileManager.loja.ReadStrategy
{
    public class ReadFile : IFileStrategy
    {
        private readonly IEnumerable<FileInfo> _fileInfos;
        private readonly List<FileInfo> _files;
        private readonly DirectoryInfo _dir;
        public ReadFile(string fileName , DirectoryInfo dir)
        {
            _dir = dir.Exists ? dir : throw new DirectoryNotFoundException(nameof(dir));
            _files = new();
            _files.Add(new(Path.Combine(dir.FullName , fileName)));

            if (_files.Any(x => !x.Exists))
                throw new FileNotFoundException();
        }
        public ReadFile(string[] files , DirectoryInfo dir)
        {
            _dir = dir.Exists ? dir : throw new DirectoryNotFoundException(nameof(dir));
            _files = files.Count() > 0 ? files
                .ToList()
                .Select(s => new FileInfo(Path.Combine(dir.FullName , s)))
                .ToList() : throw new FileNotFoundException(nameof(files));
        }
        
        async Task<IEnumerable<T>> IFileStrategy.Start<T>() 
        {
            IEnumerable<FileStream> fsArray = _files.Select(s => File.Open(s.FullName, FileMode.Open)).ToArray();
            return (IEnumerable<T>)fsArray;
        }
    }
}
