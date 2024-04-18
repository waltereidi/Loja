using Dominio.loja.Attributes;
using Dominio.loja.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            ExcelValidationAttributes excelValidationAttributes = new (ExcelValidation.StringLength , 3 , 12);

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
            ExcelValidationAttributes excelValidationAttributes = new (ExcelValidation.StringLength, 3, 12);

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
            ExcelValidationAttributes excelValidationAttributes = new (ExcelValidation.IsNumber);
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
            ExcelValidationAttributes excelValidationAttributes = new (ExcelValidation.Required);
            //Action 
            var Return = excelValidationAttributes.Required("");
            var ValidatedReturn = excelValidationAttributes.Required("Not Empty");
            //Assert 
            Assert.IsFalse(Return.Item1);
            Assert.IsTrue(ValidatedReturn.Item1);
        }
        [TestMethod]
        public void DateTimeFormatReturnsTrueForAllWithValidTimeStampValues()
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new (ExcelValidation.DateTimeFormat , DateTimeFormatValidation.ddmmyyyy);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("29/12/2023").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("2/2/2023").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("29-12-2023").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("23-2-2023").Item1);

            excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.mmddyyyy);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("9/22/2023").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("2/23/2023").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("9-2-2023").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("12-30-2023").Item1);

            excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.mmddyyyyHHMMSS );
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("9/22/2023 18:30:59").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("2/23/2023 21:11:02").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("9-2-2023 23:59:59").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("12-30-2023 22:58:58").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("12-30-2023 2:58:58").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("12-30-2023 2:8:8").Item1);


            excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.ddmmyyyyHHMMSS);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("22/02/2023 18:30:59").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("02/03/2023 21:11:02").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("9-2-2023 23:59:59").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("30-12-2023 22:58:58").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("30-11-2023 2:58:58").Item1);
            Assert.IsTrue(excelValidationAttributes.DateTimeFormat("1-11-2023 2:8:8").Item1);
        }
        [TestMethod]
        public void DateTimeFormatRetutnsFalseWhenFormatIsNotValid()
        {
            //Setup 
            ExcelValidationAttributes excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.ddmmyyyy);
            Assert.IsFalse(excelValidationAttributes.DateTimeFormat("29/12/202").Item1);

            excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.mmddyyyy);
            Assert.IsFalse(excelValidationAttributes.DateTimeFormat("9\\22\\2023").Item1);

            excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.mmddyyyyHHMMSS);
            Assert.IsFalse(excelValidationAttributes.DateTimeFormat("9/32/2023 18:30:59").Item1);


            excelValidationAttributes = new (ExcelValidation.DateTimeFormat, DateTimeFormatValidation.ddmmyyyyHHMMSS);
            Assert.IsFalse(excelValidationAttributes.DateTimeFormat("22/02/20232 18:30:59").Item1);

        }
    }
}
