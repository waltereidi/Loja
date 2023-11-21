using System;
using System.Reflection;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using NPOI.HSSF.Record.Chart;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using Utils.loja.Enums;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using NPOI.OpenXmlFormats.Dml.Diagram;

namespace Utils.loja.Excel
{
    public class NPOIExcel 
    {
        public NPOIExcel() 
        { 
        
        }
        private List<HSSFCellStyle> CreateStyle(HSSFWorkbook workbook , NPOISheetStyles sheetStyle )
        {
            
            HSSFCellStyle styleHeader = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFCellStyle styleRowStrong = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFCellStyle styleRowLight = (HSSFCellStyle)workbook.CreateCellStyle();
            List<HSSFCellStyle> Return = new List<HSSFCellStyle>();

            Return.Add(styleHeader);
            Return.Add(styleRowStrong);
            Return.Add(styleRowLight);

            HSSFFont font = (HSSFFont)workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.FontName = "Arial";
            Return.ForEach(s => s.SetFont(font));

            switch(sheetStyle)
            {
                case NPOISheetStyles.LightOrange:Return.ForEach(style => { style.FillForegroundColor = IndexedColors.LightOrange.Index; }) ; break;
                case NPOISheetStyles.SkyBlue: Return.ForEach( style => style.FillForegroundColor = IndexedColors.SkyBlue.Index ); break;
                case NPOISheetStyles.Aqua: Return.ForEach( style=>style.FillForegroundColor = IndexedColors.Aqua.Index); break;
                case NPOISheetStyles.LightGreen: Return.ForEach(style => style.FillForegroundColor = IndexedColors.LightGreen.Index); break;
                case NPOISheetStyles.Gray:Return.ForEach( style =>  style.FillForegroundColor = IndexedColors.Grey25Percent.Index); break;
                default : Return.ForEach(style => style.FillForegroundColor = IndexedColors.White.Index); break;
            }
            
            

            Return.First().FillPattern= FillPattern.SolidForeground;

            Return.ElementAt(1).FillPattern = FillPattern.SolidForeground;
            Return.ElementAt(1).FillBackgroundColor = IndexedColors.White.Index;

            Return.Last().FillPattern = FillPattern.BigSpots;
            
            
            return Return;

        }
        private void CreateSheetHeader<T>(IRow row ,T data , HSSFCellStyle styleHeader )
        {
            string[] headerNames = data.GetType().GetProperties().Select(key => key.Name).ToArray();
            foreach(var header in headerNames.Select((Name , i ) => new { Name , i }) )
            {
                ICell Cell = row.CreateCell(header.i);
                Cell.SetCellValue(header.Name);
                Cell.CellStyle = styleHeader;
            }
        }

        private void CreateRow(IRow row, List<string> data, HSSFCellStyle style)
        {
            for(int i = 0; i < data.Count; i++)
            {
                ICell Cell = row.CreateCell(i);
                Cell.SetCellValue(data[i]);
                Cell.CellStyle = style;
            }
            
        }
        private List<string> ObjectToStringList( object data )
        {
            List<string> Return = new List<string?>();
            
            foreach( var prop in data.GetType().GetProperties().ToArray() )
            {
                var value = data.GetType().GetProperty(prop?.Name)?.GetValue(data)??"";
                Return.Add(value.ToString());
            }
            return Return;
        }
        
        public HSSFWorkbook CreateExcel<T>(List<T> data , NPOISheetStyles sheetStyle )
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            List<HSSFCellStyle> styleList = CreateStyle(workbook, sheetStyle);

            ISheet sheet = workbook.CreateSheet("Report");
            
            IRow HeaderRow = sheet.CreateRow(0);
            CreateSheetHeader(HeaderRow, data.First(), styleList.First());

            for( int i = 0; i < data.Count(); i++ )
            {
                List<string> stringList = ObjectToStringList(data[i]);
                IRow row = sheet.CreateRow(i+1);
                if( i%2 == 1)
                {
                    CreateRow(row, stringList, styleList.ElementAt(1));
                }
                else
                {
                    CreateRow(row, stringList, styleList.Last());
                }
            }
            
            return workbook;
        }

    }
}
