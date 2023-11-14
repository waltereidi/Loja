using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Utils.loja.Excel;

namespace Tests.Loja.Utils
{
    [TestClass]
    public class NPOITest
    {
        public NPOIExcel _NPOIExcel;
        public NPOITest() 
        {
           _NPOIExcel = new NPOIExcel();
        }

        [TestMethod]
        public void GenerateExcelCreatesFileInLocation()
        {
            //setup 
            string path = "C:\\Users\\walte\\Desktop\\";
            string filename = "spreadsheet.xlsx";

            //action 
            _NPOIExcel.CreateExcel(path, filename);
            //Assert
            Assert.IsTrue(File.Exists(path+filename));
            
            
        }
  

    }
}
