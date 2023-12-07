using Dominio.loja.Attributes;
using Dominio.loja.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.TestAttributes
{
    [TestClass]
    public class ExcelValidationAttributesTest
    {
        
        public ExcelValidationAttributesTest()
        {
           
        }

        [TestMethod]
        public void StringLengthMustReturnTrueAndEmptyString()
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new ExcelValidationAttributes(ExcelValidation.StringLength , 3 , 12);

            //Action 
            var Return = excelValidationAttributes.StringLength("StringLength");
            //Assert
            Assert.IsTrue(Return.Item1);
            Assert.IsTrue(Return.Item2 == "");

        }
        [TestMethod]
        public void StringLengthMustReturnFalseAndMessageString() 
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new ExcelValidationAttributes(ExcelValidation.StringLength, 3, 12);

            //Action 
            var Return = excelValidationAttributes.StringLength("StringLengthTooBigForTheSettedMaximumLength");
            //Assert
            Assert.IsFalse(Return.Item1);
            Assert.IsTrue(Return.Item2.Length > 10);

        }
        [TestMethod]
        public void IsNumberReturnsTrueWhenValidNumberIsProvided()
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new ExcelValidationAttributes(ExcelValidation.IsNumber);
            //Action 
            var Return = excelValidationAttributes.IsNumber("28");
            //Assert 
            Assert.IsTrue(Return.Item1);
            Assert.IsTrue(Return.Item2 == "");

        }
        [TestMethod]
        public void IsNumberReturnsFalseWhenInvalidNumber()
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new ExcelValidationAttributes(ExcelValidation.IsNumber);
            //Action
            var Return = excelValidationAttributes.IsNumber("sd");
            //Assert 
            Assert.IsFalse(Return.Item1);
            Assert.IsFalse(Return.Item2.Length == 0);

        }
        [TestMethod]
        public void RequiredReturnsFalseWhenValueIsEmptyAndTrueWhenValueNotEmpty()
        {
            //Setup
            ExcelValidationAttributes excelValidationAttributes = new ExcelValidationAttributes(ExcelValidation.Required);
            //Action 
            var Return = excelValidationAttributes.Required("");
            var ValidatedReturn = excelValidationAttributes.Required("Not Empty");
            //Assert 
            Assert.IsFalse(Return.Item1);
            Assert.IsTrue(ValidatedReturn.Item1);
        }
        [TestMethod]
        public void DateTimeFormatReturnsTrueWhenFormatIsValid()
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new ExcelValidationAttributes(ExcelValidation.DateTimeFormat , "dd/MM/YYYY");
            //Action 
            var Return = excelValidationAttributes.DateTimeFormat("29/12/1993");
            //Assert 
        }
    }
}
