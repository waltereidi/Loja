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

        public void CreateExcel(string path , string filename )
        {
            

            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFFont myFont = (HSSFFont)workbook.CreateFont();
            myFont.FontHeightInPoints = 11;
            myFont.FontName = "Tahoma";

            
            // Defining a border
            HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            borderedCellStyle.SetFont(myFont);
            borderedCellStyle.BorderLeft = BorderStyle.Medium;
            borderedCellStyle.BorderTop = BorderStyle.Medium;
            borderedCellStyle.BorderRight = BorderStyle.Medium;
            borderedCellStyle.BorderBottom = BorderStyle.Medium;
            borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

            borderedCellStyle.FillForegroundColor = IndexedColors.Red.Index;
            borderedCellStyle.FillPattern = FillPattern.Squares;

            ISheet Sheet = workbook.CreateSheet("Report");
            //Creat The Headers of the excel
            IRow HeaderRow = Sheet.CreateRow(2);

            //Create The Actual Cells
            CreateCell(HeaderRow, 0, "Batch Name", borderedCellStyle);
            CreateCell(HeaderRow, 1, "RuleID", borderedCellStyle);
            CreateCell(HeaderRow, 2, "Rule Type", borderedCellStyle);
            CreateCell(HeaderRow, 3, "Code Message Type", borderedCellStyle);
            CreateCell(HeaderRow, 4, "Severity", borderedCellStyle);

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
