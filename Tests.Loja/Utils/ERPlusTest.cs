using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            dynamic firstSheet = new ExcelPackage();
            using (var package = new ExcelPackage(new FileInfo("C:/arq.xlsx")))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                firstSheet = package.Workbook.Worksheets["Planilha1"];

            }
            Assert.IsNotNull(firstSheet);

           
        }
        [TestMethod]
        public void WriteColoredExcelFileCanReadFile()
        {
            //setup 
            var path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            path += "WriteColoredExcelFileCanReadFile.xlsx";
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            
            DataTable dt = new DataTable();
            
            
            for(int i = 0; i< 100; i++ )
            {
                dt.Columns.Add(i.ToString());
               
            }
            for (int k = 0; k < 100; k++)
            {
                dt.Rows.Add(k, k.ToString() + "SDSD");
            }
            

            //Action
            OfficeOpenXml.ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("teste");

            worksheet.Cells["A1"].LoadFromDataTable(dt, true);

            
            worksheet.Cells["A1:Z100"].Style.Fill.PatternType = ExcelFillStyle.Solid;

            worksheet.Cells["A1:Z100"].Style.Border.Top.Style=ExcelBorderStyle.Thin;
            worksheet.Cells["A1:Z100"].Style.Font.Bold=true;
            worksheet.Cells["A1:Z100"].Style.Font.Italic=true;
            worksheet.Cells["A1:Z100"].Style.Fill.BackgroundColor.SetColor(Color.Red);
            FileInfo fileInfo = new FileInfo(path);
            excel.SaveAs(fileInfo);

            //Assert
            Assert.IsNotNull(File.Exists(path));


        }
        
    }
}
