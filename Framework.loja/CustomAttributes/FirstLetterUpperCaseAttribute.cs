using Framework.loja.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Framework.loja.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,AllowMultiple = false)]
    public class FirstLetterUppercaseAttribute : Attribute , IStringValidationAttribute
    {
        public string RegexPattern => "^$|^[A-Z]";
        public FirstLetterUppercaseAttribute(Func<object> fun)
        {
            var i = fun;
            
        }
        public FirstLetterUppercaseAttribute(object i ) : this(()=>i)
        {
            
        }
        //public override bool IsValid(object value) => Regex.IsMatch(value.ToString(), RegexPattern);
        


    }

}
