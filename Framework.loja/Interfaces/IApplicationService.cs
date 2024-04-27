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
    }
}
