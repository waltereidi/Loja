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
            HSSFCellStyle style = (HSSFCellStyle)workbook.CreateCellStyle();
            
            HSSFFont font = (HSSFFont)workbook.CreateFont();
            font.FontHeight = 12;
            font.FontName = "Arial";
            style.SetFont(font);

            switch(sheetStyle)
            {
                case NPOISheetStyles.LightOrange:style.FillForegroundColor= IndexedColors.LightOrange.Index; break;
                case NPOISheetStyles.SkyBlue: style.FillForegroundColor = IndexedColors.SkyBlue.Index; break;
                case NPOISheetStyles.Aqua: style.FillForegroundColor = IndexedColors.Aqua.Index; break;
                case NPOISheetStyles.LightGreen: style.FillForegroundColor = IndexedColors.LightGreen.Index; break;
                case NPOISheetStyles.Gray: style.FillForegroundColor = IndexedColors.Grey25Percent.Index; break;
                default : style.FillForegroundColor = IndexedColors.White.Index; break;
            }
            
            List<HSSFCellStyle> Return = new List<HSSFCellStyle>();

            HSSFCellStyle styleHeader = style; 
            styleHeader.FillPattern = FillPattern.FineDots;
            Return.Add(styleHeader);

            HSSFCellStyle styleRowStrong = style;
            styleRowStrong.FillPattern = FillPattern.SolidForeground;
            Return.Add(styleRowStrong);

            HSSFCellStyle styleRowLight = style; 
            styleRowLight.FillPattern = FillPattern.AltBars;
            Return.Add(styleRowLight);
            
            return Return;

        }
        private void CreateSheetHeader(IRow row ,object data , HSSFCellStyle styleHeader )
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
            
            IRow HeaderRow = sheet.CreateRow(1);
            CreateSheetHeader(HeaderRow, data, styleList[0]);

            for( int i = 0; data.Count() < i; i++ )
            {
                List<string> stringList = ObjectToStringList(data[i]);
                IRow row = sheet.CreateRow(i+2);
                if( i%2 == 1)
                {
                    CreateRow(row, stringList, styleList[1]);
                }
                else
                {
                    CreateRow(row, stringList, styleList[2]);
                }
            }
            
            return workbook;
        }

    }
}
