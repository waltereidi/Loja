using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces
{
    public interface IAuthentication
    {
        bool IsAuthenticated { get; }
        void ValidateAuthentication(object @e);
    }
}
