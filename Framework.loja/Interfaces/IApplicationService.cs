using Framework.loja.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.loja.Interfaces
{
    public interface IApplicationService 
    {
        Task Handle<T>(T command) where T : class;
        Task HandleCreate<T>(T dataSource) where T : class;
        Task HandleUpdate<T>(T dataSource, Action<T> operation) where T : class;
        Task HandleDelete<T>(T dataSource, Action<T> operation) where T : class;
    }
}
