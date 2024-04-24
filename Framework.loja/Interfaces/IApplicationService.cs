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
        Task<ControllerResponse<T>> Handle<T>(T command) where T : class;
        Task<ControllerResponse<T>> HandleCreate<T>(T dataSource) where T : class;
        Task<ControllerResponse<T>> HandleUpdate<T>(T dataSource, Action<T> operation) where T : class;
        Task<ControllerResponse<T>> HandleDelete<T>(T dataSource, Action<T> operation) where T : class;
    }
}
