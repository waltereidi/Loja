using Dominio.loja.Enums;
using System.Globalization;

namespace Dominio.loja.Attributes
{
    [AttributeUsage(AttributeTargets.Field  | AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelValidationAttributes : Attribute
    {
        public ExcelValidation Validation { get; set; }
        public DateTimeFormatValidation Format { get; set; }
        public string? ValidationParameters { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public ExcelValidationAttributes(ExcelValidation validation , string? validationParameter )
        {
            Validation = validation;
            ValidationParameters = validationParameter;
        }
        public ExcelValidationAttributes(ExcelValidation validation, int minLen, int maxLen) 
        {
            if (validation != ExcelValidation.StringLength)
                throw new InvalidOperationException("This constructor can only be used by StringLength");

            if (minLen >= maxLen)
                throw new InvalidDataException("minLen must be smaller or equals than maxLen");
            

            Validation = validation;
            MinLength = minLen;
            MaxLength = maxLen;
        }
        public ExcelValidationAttributes(ExcelValidation validation)
        {
            if (validation != ExcelValidation.IsNumber && validation != ExcelValidation.Required)
                throw new InvalidDataException("Only IsNumber and Required can be provided to this constructor");

            Validation = validation;
        }
        public ExcelValidationAttributes(ExcelValidation validation , DateTimeFormatValidation timeStampFormat )
        {
            if(validation != ExcelValidation.DateTimeFormat)
            {
                throw new InvalidDataException("Only DateTimeFormat is allowed for this constructor");
            }
            Validation = ExcelValidation.DateTimeFormat; 
            Format = timeStampFormat; 

        }

        public Tuple<bool , string> StringLength(string value)
        {
            

            if(MinLength >= 0 && MaxLength >= 0 || MinLength <=  MaxLength )
            {
                Tuple<bool , string> invalidatedString = new(false, $"String must be smaller than {MinLength} and bigger than {MaxLength}");

                return ( value.Length >= MinLength && value.Length <= MaxLength) ? new(true, "") : invalidatedString; 
            }
            else
            {
                return new(false, "Invalid Constructor of method, parameters not set at attribute declaration");
                throw new InvalidDataException("minLen and maxLen must be setted , maxLen must be bigger than minLen and the provided value must be a string");
            }

        }
        public Tuple<bool , string> IsNumber(string value)
        {
            int numberValue = 0;
            if (int.TryParse(value, out numberValue))
            {
                return new(true , "");
            }
            else
            {
                return new(false, "Invalid number");
            }
        }

        public Tuple<bool , string> Required(string value)
        {
            if(String.IsNullOrEmpty(value))
            {
                return new(false, "This value cannot be not empty");
            }else
            {
                return new(true , "");
            }

            
        }
        

        public Tuple<bool , string> DateTimeFormat(string value)
        {
            if (!(Validation == ExcelValidation.DateTimeFormat && Format != null))
                throw new InvalidDataException("Incorrect construtor called");

            DateTime date;
            bool isValid;
            switch (Format)
            {
                case DateTimeFormatValidation.ddmmyyyy:
                        isValid = (
                        DateTime.TryParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "dd-mm-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d/m/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d-m-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d/m/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d-m-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));
                        break;
                case DateTimeFormatValidation.mmddyyyy:
                    isValid = (
                        DateTime.TryParseExact(value, "mm/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "mm-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "m/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "m-d-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "m/d/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "m-d-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) );
                        break;
                case DateTimeFormatValidation.ddmmyyyyHHMMSS:
                    isValid = (
                        DateTime.TryParseExact(value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d-M-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d/M/yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d-M-yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d/M/yy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d-M-yy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "dd/MM/yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "dd-MM-yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d/M/yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "d-M-yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));
                        break;
                case DateTimeFormatValidation.mmddyyyyHHMMSS:
                    isValid = (
                        DateTime.TryParseExact(value, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M-d-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M/d/yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M-d-yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M/d/yy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M-d-yy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "MM/dd/yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "MM-dd-yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M/d/yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                        DateTime.TryParseExact(value, "M-d-yyyy H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));
                        break;
                default: throw new InvalidDataException("Parameters defined in constructor not match defined returns");
            }

                return !isValid ? new (false , "Invalid dateTimeFormat provided , allow") : new (true, ""); 


        }
        
        
        
    }
}
