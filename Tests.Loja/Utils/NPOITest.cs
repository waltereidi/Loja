using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio.loja.Entity;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.Storage;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
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
        public void GenerateExcelCreatesFileInLocation()
        {
            //setup 
            string path = "C:\\Users\\walte\\Desktop\\";
            string filename = "spreadsheet.xlsx";

            //action 
            //_NPOIExcel.CreateExcel(path, filename);
            //Assert
            //Assert.IsTrue(File.Exists(path+filename));
            
            
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
        public void CreateExcelReturnsNotNullObject()
        {
            //Setup 
            List<Prices> listPrices = new List<Prices>();
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            listPrices.Add(_prices);
            
            //Action
            var Return = _NPOIExcel.CreateExcel(listPrices, NPOISheetStyles.LightOrange);
            //Assert
            Assert.IsNotNull(Return);
            using (var fileData = new FileStream("C:\\Users\\walte\\Desktop\\bin\\style.xlsx", FileMode.Create))
            {
                Return.Write(fileData);
            }
        }

    }
}
