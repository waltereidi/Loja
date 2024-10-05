﻿using System.Drawing;

namespace WFileManager.Contracts
{
    public class Images
    {
        public class UploadResponse : UploadContracts.UploadResponse
        {
            public int Width { get; private set; }
            public int Height { get; private set; }

            public UploadResponse(FileInfo file, string originalFileName, DirectoryInfo nonTemporaryDirectory) : base(file, originalFileName, nonTemporaryDirectory)
            {
                var bitmap = new Bitmap( base.FullName);
                Height = bitmap.Height;
                Width = bitmap.Width;
            }
            public Bitmap GetBitMap()
            {
                var bitmap = new Bitmap(base.NonTemporaryFile.Exists ? base.NonTemporaryFile.FullName : base.FullName);
                return bitmap;
            }
        }
        
    }
}
