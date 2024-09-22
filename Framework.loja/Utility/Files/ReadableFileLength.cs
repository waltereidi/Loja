

namespace Framwork.loja.Utility.Files
{
    /// <summary>
    /// Converts number into human readable file size. <br></br>
    /// (string)new ReadableFileLength(1000) //Output 1KB 
    /// </summary>
    public class ReadableFileLength
    {
        public long SizeInBytes { get; private set; }
        
        public ReadableFileLength(long sizeInBytes) => SizeInBytes = sizeInBytes;
        public ReadableFileLength(int sizeInBytes) => SizeInBytes = sizeInBytes;

        
        public static implicit operator string(ReadableFileLength fileSize)
        {
            if ( fileSize.SizeInBytes < 1000)
                return $"{fileSize.SizeInBytes} Bytes"; 
            else if (fileSize.SizeInBytes < 1000000)
                return $"{fileSize.SizeInBytes/1000} KB";
            else if (fileSize.SizeInBytes < 1000000000)
                return $"{fileSize.SizeInBytes / 1000000} MB";
            else
                return $"{fileSize.SizeInBytes / 1000000000} GB";
        }

    }
}
