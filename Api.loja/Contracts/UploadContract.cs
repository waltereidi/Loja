namespace Api.loja.Contracts
{
    public class UploadContract
    {
        public class V1
        {
            public record class UploadFile(IFormFile file );
            public record class UploadMultipleFiles(IFormCollection files);
        }
    }
}
