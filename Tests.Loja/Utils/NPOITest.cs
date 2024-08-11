using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio.loja.Dto.Models;
using Dominio.loja.Entity;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.Storage;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Utils.loja.Enums;
using Utils.loja.Excel;

namespace Tests.loja.Utils
{
    [TestClass]
    public class NPOITest
    {
        public NPOIExcel _NPOIExcel;
        public Prices _prices;
        public string path;
        public NPOITest()
        {
            _NPOIExcel = new NPOIExcel();
            _prices = new Prices()
            {
                Created_at = DateTime.Now,
                Updated_at = null,
                Description = "TestCase",
                Price = (decimal)0.15,

            };
            path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net8.0\\", "") + "\\TestFiles\\CreatedFiles\\";

        }

        [TestMethod]
        public void ObjectToStringArrayReturnTuplesWithEqualAmountOfValues()
        {
            //Setup 

            //Action
            var method = _NPOIExcel.GetType().GetMethod("ObjectToStringList", BindingFlags.Instance | BindingFlags.NonPublic);
            List<string> stringList = (List<string>)method.Invoke(_NPOIExcel, new[] { _prices });

            //Assert
            Assert.IsTrue(stringList.Count()>0);

        }
        [TestMethod]
        public void CreateStyleReturnsArrayWithSelectedStyle()
        {
            //Setup 
            var method = _NPOIExcel.GetType().GetMethod("CreateStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            HSSFWorkbook workbook = new HSSFWorkbook();

            //action
            List<HSSFCellStyle> styleList = (List<HSSFCellStyle>)method.Invoke(_NPOIExcel, new object[] { workbook, NPOISheetStyles.LightOrange });

            //assert
            Assert.IsTrue(styleList.First().FillForegroundColor == IndexedColors.LightOrange.Index);
            Assert.IsTrue(styleList.First().FillPattern == FillPattern.SolidForeground);

        }
        [TestMethod]
        public void CreateExcelReturnsNotNullClass()
        {
            //Setup 

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            List<Prices> listPrices = new();
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            listPrices.Add(_prices);

            //Action
            var Return = _NPOIExcel.CreateExcel(listPrices, NPOISheetStyles.LightOrange);
            using (var fileData = new FileStream(path + "CreateExcelReturnsNotNUllClass.xlsx", FileMode.Create))
            {
                Return.Write(fileData);
            }
            //Assert
            Assert.IsNotNull(Return);
            Assert.IsTrue(File.Exists(path + "CreateExcelReturnsNotNUllClass.xlsx"));
        }
        [TestMethod]
        public void CreateExcelReturnsNotNullObject()
        {
            //Setup 


            if (File.Exists(path + "CreateExcelReturnsNotNUllObject.xlsx"))
            {
                File.Delete(path + "CreateExcelReturnsNotNUllObject.xlsx");
            }
            object obj = new { Property = "prop", Number = 1, Decimal = 0.1, DateTime = DateTime.Now, Boolean = true };
            List<object> listObject = new();
            listObject.Add(obj);
            listObject.Add(obj);
            listObject.Add(obj);
            listObject.Add(obj);

            //Action
            var Return = _NPOIExcel.CreateExcel(listObject, NPOISheetStyles.LightOrange);
            using (var fileData = new FileStream(path + "CreateExcelReturnsNotNUllObject.xlsx", FileMode.Create))
            {
                Return.Write(fileData);
            }
            //Assert
            Assert.IsNotNull(Return);
            Assert.IsTrue(File.Exists(path + "CreateExcelReturnsNotNUllObject.xlsx"));
        }
        [TestMethod]
        public void ValidateSheetFieldsReturnFalseWhenFieldsMatch()
        {

            if (File.Exists(path + "CreateExcelReturnsNotNUllClass.xlsx"))
            {
                //Setup 
                HSSFWorkbook workbook;
                using (FileStream file = new FileStream(path + "ValidSheetFromPricesClass.xlsx", FileMode.Open, FileAccess.Read))
                {
                    workbook = new HSSFWorkbook(file);
                }
                Prices prices = new Prices();
                //Action 
                bool Return = _NPOIExcel.ValidateSheetFields(prices, workbook);

                //Assert
                Assert.IsFalse(Return);

            }
            else
            {
                //File not existent
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void ValidateSheetFieldsReturnFalseWhenFieldsNotMatch()
        {

            if (File.Exists(path + "CreateExcelReturnsNotNUllObject.xlsx"))
            {
                //Setup 
                HSSFWorkbook workbook;
                using (FileStream file = new FileStream(path + "ValidSheetFromRandomObject.xlsx", FileMode.Open, FileAccess.Read))
                {
                    workbook = new HSSFWorkbook(file);
                }
                Prices prices = new Prices();
                //Action 
                bool Return = _NPOIExcel.ValidateSheetFields(prices, workbook);

                //Assert
                Assert.IsFalse(Return);
            }
            else
            {
                //File not existent
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void ImportSheetFromFileReturnsNullOnInvalidFile()
        {
            //Setup 
            string fileName = "InvalidFileTest.xlsx";

            //Action 
            IWorkbook workbook = _NPOIExcel.ImportSheetFromFile(path, fileName);
            //Assert
            Assert.IsNull(workbook);
        }
        [TestMethod]
        public void ImportSheetFromFileReturnsSheetOnValidFile()
        {
            //Setup 
            string fileName = "ValidSheetFromPricesClass.xlsx";

            //Action 
            IWorkbook workbook = _NPOIExcel.ImportSheetFromFile(path, fileName);

            //Assert
            Assert.IsNotNull(workbook);
        }
        [TestMethod]
        public void GetSheetValuesReturnsMappedObject()
        {
            //Setup 
            List<Prices> prices = new();
            Prices price = new Prices();
            HSSFWorkbook workbook;
            using (FileStream file = new FileStream(path + "ValidSheetFromPricesClass.xlsx", FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }

            //Action 
            prices = _NPOIExcel.GetSheetValues<Prices>(workbook, 0);

            //Assert 
            Assert.IsTrue(prices.Count > 1);
        }

        [TestMethod]
        public void ReturnValidationSheetReturnsSheet()
        {
            //Setup 
            if (File.Exists(path + "ReturnValidationSheetReturnsSheet.xlsx"))
            {
                File.Delete(path + "ReturnValidationSheetReturnsSheet.xlsx");
            }

            List<ExcelImportProducts> listProducts = new();
            listProducts.Add(new ExcelImportProducts() { Name = "Product1", Description = "Product1", ID_Products = "1" });
            listProducts.Add(new ExcelImportProducts() { Name = "Product1", Description = "Product1", ID_Products = "s" });
            listProducts.Add(new ExcelImportProducts() { Name = "1", Description = "1", ID_Products = "1" });
            listProducts.Add(new ExcelImportProducts() { Name = "Product1", Description = "Product1", ID_Products = "1" });

            //Action 
            var Return = _NPOIExcel.ReturnValidationSheet(listProducts, NPOISheetStyles.LightOrange);
            using (var fileData = new FileStream(path + "ReturnValidationSheetReturnsSheet.xlsx", FileMode.Create))
            {
                Return.Item2.Write(fileData);
            }

            //Assert 
            Assert.IsNotNull(Return);
        }
   
    }
}
