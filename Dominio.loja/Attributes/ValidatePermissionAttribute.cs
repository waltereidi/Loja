using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ValidatePermissionAttribute : Attribute 
    {
            
            public ValidatePermissionAttribute(string permission)
            { 
                    
            }
        }
}
