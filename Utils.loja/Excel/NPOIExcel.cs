using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using NPOI.HSSF.Record.Chart;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using Utils.loja.Enums;

namespace Utils.loja.Excel
{
    public class NPOIExcel 
    {
        public NPOIExcel() 
        { 
        
        }
        public void CreateCell(IRow CurrentRow, int CellIndex, string Value, HSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
            
        }
        public List<HSSFCellStyle> CreateStyle(HSSFWorkbook workbook , NPOISheetStyles sheetStyle )
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
        public void CreateSheetHeader(IRow row ,object data , HSSFCellStyle styleHeader )
        {
            string[] headerNames = data.GetType().GetProperties().Select(key => key.Name).ToArray();
            foreach(var header in headerNames.Select((Name , i ) => new { Name , i }) )
            {
                ICell Cell = row.CreateCell(header.i);
                Cell.SetCellValue(header.Name);
                Cell.CellStyle = styleHeader;
            }
        }

        public HSSFWorkbook CreateExcel(object data , NPOISheetStyles sheetStyle )
        {
            
            
            HSSFWorkbook workbook = new HSSFWorkbook();

            List<HSSFCellStyle> styleList = CreateStyle(workbook, sheetStyle);

            ISheet Sheet = workbook.CreateSheet("Report");
            
            IRow HeaderRow = Sheet.CreateRow(1);
            CreateSheetHeader(HeaderRow, data, styleList[0]);

            IRow CurrentRow = Sheet.CreateRow(1);
            CreateCell(CurrentRow, 0, "sdsd", borderedCellStyle);
            CreateCell(CurrentRow, 1, "sdsdsdsd", borderedCellStyle);
            CreateCell(CurrentRow, 2, "sdsdsde", borderedCellStyle);
            CreateCell(CurrentRow, 3, "Cosdsddsgesde", borderedCellStyle);
            CreateCell(CurrentRow, 4, "Sesddity", borderedCellStyle);
            
            
            using (var fileData = new FileStream(path+filename, FileMode.Create))
            {
                workbook.Write(fileData);
            }
        }

    }
}
