using Framework.loja.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Framework.loja.CustomAttributes
{
    public class FirstLetterUppercaseAttribute : ValidationAttribute , IStringValidationAttribute
    {
        public string RegexPattern => "^$|^[A-Z]";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (!Regex.IsMatch(value.ToString(), RegexPattern))
            {
                return new ValidationResult("The first letter of 'name' must be uppercase");
            }
            
            return ValidationResult.Success;
        }

    }

}
