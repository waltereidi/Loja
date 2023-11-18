using Dominio.loja.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ValidatePermissionAttribute : Attribute 
    {
            private readonly PermissionsRelation permissionsRelation;
            public ValidatePermissionAttribute(string permission)
            { 
                
            }
        }
}
