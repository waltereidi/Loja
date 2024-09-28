﻿using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Microsoft.IdentityModel.Tokens;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManagerEvents
    {
        public abstract class CreateFile
        {
            public FileInfo Fi { get; set; }
            public string OriginalName { get; set; }
            public FileDirectory Fd { get; set; }    
            public CreateFile(string fullName ,string originalName , FileDirectory directory )
            {
                if (originalName.IsNullOrEmpty())
                    throw new ArgumentNullException($"original name cannot be null or empty {nameof(originalName)}");

                if (originalName.IsNullOrEmpty())
                    throw new ArgumentNullException($"original name cannot be null or empty {nameof(originalName)}");

                Fi = new FileInfo(fullName);
                OriginalName = originalName; 
                Fd = directory;
            }
        }
        public class CategoryChangedPicture : CreateFile
        {
            public Categories Category { get; private set; }
            public CategoryChangedPicture(string fullName, string originalName, FileDirectory directory, Categories category) : base(fullName, originalName, directory)
            {
                Category = category;
            }
        }
    }
}
