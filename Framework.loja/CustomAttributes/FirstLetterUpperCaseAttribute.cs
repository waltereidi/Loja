using Framework.loja.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Framework.loja.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,AllowMultiple = false)]
    public class FirstLetterUppercaseAttribute : ValidationAttribute , IStringValidationAttribute
    {
        public string RegexPattern => "^$|^[A-Z]";
        private string ErrorMessage { get; set; }
        public FirstLetterUppercaseAttribute(Func<string> error)
        {
            
        }
        public FirstLetterUppercaseAttribute(string i ) : this(()=>i)
        {
            ErrorMessage = i;
        }
        public override bool IsValid(object value) => Regex.IsMatch(value.ToString(), RegexPattern);      
       
    }

}
