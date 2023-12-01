using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio.loja.DTO.Requests;
using Dominio.loja.Entity;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.Storage;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NuGet.Protocol;
using Tests.Loja.Dominio.Dto.Requests;
using Utils.loja.Enums;
using Utils.loja.Excel;

namespace Tests.Loja.Utils
{
    [TestClass]
    public class NPOITest
    {
        public NPOIExcel _NPOIExcel;
        public Prices _prices ;
        public string path;
        public NPOITest() 
        {
           _NPOIExcel = new NPOIExcel();
           _prices = new Prices()
            {
                Created_at = DateTime.Now,
                Updated_at = null ,
                Description = "TestCase",
                Price = (decimal)0.15,
                ID_Prices = 1
            };
            var path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "")+ "\\TestFiles\\CreatedFiles\\";

        }

        [TestMethod]
        public void ObjectToStringArrayReturnTuplesWithEqualAmountOfValues()
        {
            //Setup 
           
            //Action
            var method = _NPOIExcel.GetType().GetMethod("ObjectToStringList", BindingFlags.Instance | BindingFlags.NonPublic);
            List<string> stringList= (List<string>)method.Invoke(_NPOIExcel, new [] {_prices });

            //Assert
            Assert.IsTrue(stringList.Count()== 5);
            Assert.IsTrue(stringList[0] == _prices.ID_Prices.ToString());
            Assert.IsTrue(stringList[1] == _prices.Price.ToString());
            Assert.IsTrue(stringList[2] == _prices.Description.ToString());
            Assert.IsTrue(stringList[3] == _prices.Created_at.ToString());
            Assert.IsTrue(stringList[4] == _prices.Updated_at.ToString());
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
            Assert.IsTrue(styleList.First().FillPattern == FillPattern.SolidForeground );
            
        }
        [TestMethod]
        public void CreateExcelReturnsNotNullClass()
        {
            //Setup 
            
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            List<Prices> listPrices = new List<Prices>();
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            
            //Action
            var Return = _NPOIExcel.CreateExcel(listPrices, NPOISheetStyles.LightOrange);
            using (var fileData = new FileStream(path+ "CreateExcelReturnsNotNUllClass.xlsx", FileMode.Create))
            {
                Return.Write(fileData);
            }
            //Assert
            Assert.IsNotNull(Return);
            Assert.IsTrue(File.Exists(path+ "CreateExcelReturnsNotNUllClass.xlsx"));   
        }
        [TestMethod]
        public void CreateExcelReturnsNotNullObject()
        {
            //Setup 
            
            
            if (File.Exists(path + "CreateExcelReturnsNotNUllObject.xlsx"))
            {
                File.Delete(path+ "CreateExcelReturnsNotNUllObject.xlsx");
            }
            object obj = new { Property = "prop", Number = 1, Decimal = 0.1  , DateTime = DateTime.Now , Boolean = true };
            List<object> listObject= new List<object>();
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
            
            if(File.Exists(path+ "CreateExcelReturnsNotNUllClass.xlsx"))
            {
                //Setup 
                HSSFWorkbook workbook;
                using (FileStream file = new FileStream(path + "CreateExcelReturnsNotNUllClass.xlsx", FileMode.Open, FileAccess.Read))
                {
                    workbook = new HSSFWorkbook(file);
                }
                Prices prices = new Prices();
                //Action 
                bool Return = _NPOIExcel.ValidateSheetFields( prices , workbook);

                //Assert
                Assert.IsTrue(Return);

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
                using (FileStream file = new FileStream(path + "CreateExcelReturnsNotNUllObject.xlsx", FileMode.Open, FileAccess.Read))
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

    }
}
