using Dominio.loja.Entity;
using NPOI.SS.UserModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.Tests.Utils
{
    [TestClass]
    public class ERPlusTest
    {
        private string path;
        public ERPlusTest()
        {
            path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "") + "\\TestFiles\\CreatedFiles\\";
        }

        [TestMethod]
        public void ReadExcelFileReturnsColumns()
        {

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            dynamic firstSheet = new ExcelPackage();
            ExcelWorksheet sheet;
            using (var package = new ExcelPackage(new FileInfo("C:/arq1.xlsx")))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                sheet = package.Workbook.Worksheets["Sheet1"];
                var i = package.Workbook;
                //List<object> list = GetList<object>(sheet);
                List<Prices> listPrices = GetList<Prices>(sheet);
            }







            Assert.IsNotNull(sheet);


        }
        private List<T> GetList<T>(ExcelWorksheet sheet)
        {
            List<T> list = new List<T>();
            //first row is for knowing the properties of object
            var columnInfo = Enumerable.Range(1, sheet.Dimension.Columns).ToList().Select(n =>
                new { Index = n, ColumnName = sheet.Cells[1, n].Value.ToString().Replace(" ", "").Replace("*", "") }
            );

            for (int row = 2; row < sheet.Dimension.Rows; row++)
            {
                T obj = (T)Activator.CreateInstance(typeof(T));//generic object
                foreach (var prop in typeof(T).GetProperties())
                {
                    int col = columnInfo.SingleOrDefault(c => c.ColumnName == prop.Name).Index;
                    var val = sheet.Cells[row, col].Value;
                    var propType = prop.PropertyType;
                    if (!string.IsNullOrEmpty(val?.ToString()))
                    {
                        prop.SetValue(obj, Convert.ChangeType(val, propType));

                    }
                }
                list.Add(obj);
            }

            return list;
        }
        [TestMethod]
        public void WriteColoredExcelFileCanReadFile()
        {
            //setup 
            var path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            path += "WriteColoredExcelFileCanReadFile.xlsx";
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            DataTable dt = new DataTable();


            for (int i = 0; i < 100; i++)
            {
                dt.Columns.Add(i.ToString());

            }
            for (int k = 0; k < 100; k++)
            {
                dt.Rows.Add(k, k.ToString() + "SDSD");
            }


            //Action
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("teste");

            worksheet.Cells["A1"].LoadFromDataTable(dt, true);


            worksheet.Cells["A1:Z100"].Style.Fill.PatternType = ExcelFillStyle.Solid;

            worksheet.Cells["A1:Z100"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            worksheet.Cells["A1:Z100"].Style.Font.Bold = true;
            worksheet.Cells["A1:Z100"].Style.Font.Italic = true;
            worksheet.Cells["A1:Z100"].Style.Fill.BackgroundColor.SetColor(Color.Red);
            FileInfo fileInfo = new FileInfo(path);
            excel.SaveAs(fileInfo);

            //Assert
            Assert.IsNotNull(File.Exists(path));


        }

    }
}
