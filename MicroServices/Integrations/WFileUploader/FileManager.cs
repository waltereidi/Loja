using WFileManager.loja.Interfaces;

namespace Integrations;

public class FileManagerMS
{
    public FileManagerMS()
    {
        
    }
    
    public Task<IEnumerable<T>> Start<T>(IFileStrategy fileStrategy) where T : class
    {
        return fileStrategy.Start<T>();
    }
    
    public async void LogFile(IEnumerable<FileInfo> files)
    {

    }
}
