﻿namespace Api.loja.Contracts
{
    public class UploadContract
    {
        public class V1
        {
            public record class UploadFile(IFormFile file, HttpRequest request);
            public record class UploadMultipleFiles(IFormFileCollection files, HttpRequest request);
            public record class UploadFileResponse();
        }
    }
}
