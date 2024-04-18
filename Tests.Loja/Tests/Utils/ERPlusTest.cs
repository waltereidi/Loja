using Dominio.loja.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private readonly string path;
        public ERPlusTest()
        {
            path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "") + "\\TestFiles\\CreatedFiles\\";
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
