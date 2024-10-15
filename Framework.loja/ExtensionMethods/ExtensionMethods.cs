using System;
using System.Net.Mime;

namespace Framework.loja.ExtensionMethods
{
    public static class MyExtensions
    {
        public static bool PropertyValueExists<T>(this object obj, string typeName, T typeValue) where T : class 
        {
            var prop = obj.GetType().GetProperty(typeName)?.GetValue(obj);

            if( prop.GetType() == typeValue.GetType())
            {
                return prop.Equals(typeValue);
            }
            return false;
        }
        
    }
}