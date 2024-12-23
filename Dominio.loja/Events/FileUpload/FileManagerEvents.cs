﻿using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Interfaces.Files;
using Microsoft.IdentityModel.Tokens;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManagerEvents
    {
        public class FileProperties
        {
            public record All(long max, long min);
            public record Dimensions(int height, int width);
            public record Pages(int pages);
            public record Sheet(int sheets , int rows );
            public record Video(Dimensions dimensions , int durationInSeconds );
        }
        public class FileTypeValidationResult
        {
            private bool IsValid { get; set; }
        }

        public abstract class CreateFile
        {
            public FileInfo Fi { get; set; }
            public string OriginalName { get; set; }
            public FileDirectory Fd { get; set; }    
            public IFileTypeProperty? FileProperties { get; set; }

            public CreateFile(string fullName, string originalName, FileDirectory directory , IFileTypeProperty? properties = null )
            {
                if (originalName.IsNullOrEmpty())
                    throw new ArgumentNullException($"original name cannot be null or empty {nameof(originalName)}");

                if (originalName.IsNullOrEmpty())
                    throw new ArgumentNullException($"original name cannot be null or empty {nameof(originalName)}");

                Fi = new FileInfo(fullName);
                OriginalName = originalName;
                Fd = directory;
                FileProperties = properties;
            }

        }
        public class CategoryChangedPicture : CreateFile
        {
            public Categories Category { get; private set; }
            public CategoryChangedPicture(string fullName, string originalName, FileDirectory directory, Categories category , IFileTypeProperty? properties) : base(fullName, originalName, directory , properties)
            {
                Category = category;
            }
        }
    }
}
