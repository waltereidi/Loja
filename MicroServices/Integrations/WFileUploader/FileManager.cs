﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.loja.Interfaces;

namespace Integrations;

public class FileManager
{
    public FileManager()
    {
        
    }
    
    public IEnumerable<T>Start<T>(IFileStrategy fileStrategy) where T : class
    {
        return fileStrategy.Start<T>();
    }
    public async Task<IEnumerable<T>> StartAsync<T>(IFileStrategy fileStrategy) where T : class
    {
        return fileStrategy.Start<T>();
    }

    public async void LogFile(IEnumerable<FileInfo> files)
    {

    }
}
