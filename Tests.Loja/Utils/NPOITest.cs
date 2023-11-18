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
        public NPOITest() 
        {
           _NPOIExcel = new NPOIExcel();
           _prices = new Prices()
            {
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
                Description = "TestCase",
                Price = (decimal)0.15,
                Id = null
            };
        }

        [TestMethod]
        public void ObjectToStringArrayReturnTuplesWithEqualAmountOfValues()
        {
            //Setup 
           
            //Action
            var method = _NPOIExcel.GetType().GetMethod("ObjectToStringList", BindingFlags.Instance | BindingFlags.NonPublic);
            List<string> stringList= (List<string>)method.Invoke(_NPOIExcel, new[] { _prices });

            //Assert
            Assert.IsTrue(stringList.Count()== 5);
            Assert.IsTrue(stringList[0] == _prices.Price.ToString());
            Assert.IsTrue(stringList[1] == _prices.Description.ToString());
            Assert.IsTrue(stringList[2] == _prices.Id.ToString());
            Assert.IsTrue(stringList[3] == _prices.Updated_at.ToString());
            Assert.IsTrue(stringList[4] == _prices.Created_at.ToString());
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
            var path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            path += "\\TestFiles\\CreatedFiles\\CreateExcelReturnsNotNUllClass.xlsx";
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
            using (var fileData = new FileStream(path , FileMode.Create))
            {
                Return.Write(fileData);
            }
            //Assert
            Assert.IsNotNull(Return);
            Assert.IsTrue(File.Exists(path));   
        }
        [TestMethod]
        public void CreateExcelReturnsNotNullObject()
        {
            //Setup 
            var path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            path += "\\TestFiles\\CreatedFiles\\CreateExcelReturnsNotNUllObject.xlsx";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            object obj = new { Property = "prop", Number = 1, Decimal = 0.1  , DateTime = DateTime.Now , Boolean = true };
            List<object> listObject= new List<object>();
            listObject.Add(obj);
            listObject.Add(obj);
            listObject.Add(obj);
            listObject.Add(obj);

            //Action
            var Return = _NPOIExcel.CreateExcel(listObject, NPOISheetStyles.LightOrange);
            using (var fileData = new FileStream(path, FileMode.Create))
            {
                Return.Write(fileData);
            }
            //Assert
            Assert.IsNotNull(Return);
            Assert.IsTrue(File.Exists(path));
        }
  

    }
}
