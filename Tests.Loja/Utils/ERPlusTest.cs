using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.Utils
{
    [TestClass]
    public class ERPlusTest
    {

        public ERPlusTest()
        {

        }

        [TestMethod]
        public void ReadExcelFileReturnsColumns()
        {
            dynamic firstSheet = new ExcelPackage();
            using (var package = new ExcelPackage(new FileInfo("C:/arq.xlsx")))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                firstSheet = package.Workbook.Worksheets["Planilha1"];

            }
            Assert.IsNotNull(firstSheet);

           
        }
        [TestMethod]
        public void WriteExcelFileCanReadFile()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nome");
            dt.Columns.Add("Telefone");
            dt.Rows.Add("1", "11111");
            dt.Rows.Add("2", "22222");
            FileInfo fileInfoTemplate = new FileInfo("C:/arq2.xlsx");

            OfficeOpenXml.ExcelPackage excel = new ExcelPackage(fileInfoTemplate);

            ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("teste");
            worksheet.Cells["A1"].LoadFromDataTable(dt, true);

            FileInfo fileInfo = new FileInfo("C:\\Users\\walte\\Desktop\\Pingendo\\arq3.xlsx");
            excel.SaveAs(fileInfo);

        }
    }
}
