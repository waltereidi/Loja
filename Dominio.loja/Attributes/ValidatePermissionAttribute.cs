
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
