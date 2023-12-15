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
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using NPOI.SS.Formula.Functions;
using Npoi.Mapper;
using System.Runtime.CompilerServices;
using MathNet.Numerics;
using Dominio.loja.Attributes;
using Dominio.loja.Enums;
using Dominio.loja.Dto.Models;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.POIFS.Storage;
using System.Runtime.InteropServices;

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
            HSSFCellStyle styleError = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFCellStyle styleNormal = (HSSFCellStyle)workbook.CreateCellStyle();

            styleError.FillForegroundColor = IndexedColors.Red.Index;
            styleNormal.FillForegroundColor = IndexedColors.White.Index;
            styleError.FillPattern = FillPattern.SolidForeground;
            styleNormal.FillPattern = FillPattern.SolidForeground;
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

            Return.Add(styleError);
            Return.Add(styleNormal);
            

            Return.First().FillPattern= FillPattern.SolidForeground;

            Return.ElementAt(1).FillPattern = FillPattern.SolidForeground;
            Return.ElementAt(1).FillBackgroundColor = IndexedColors.White.Index;

            Return.ElementAt(2).FillPattern = FillPattern.BigSpots;
            
            
            return Return;

        }
    
        private void CreateSheetHeader<T>(IRow row ,T data , HSSFCellStyle styleHeader )
        {
            string[] headerNames = data.GetType().GetProperties().Select(key => key.Name).ToArray();
            
            foreach (var header in headerNames.Select((Name , i ) => new { Name , i }) )
            {
                ICell Cell = row.CreateCell(header.i);
                var member = data.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property && x.Name == header.Name ).First();
                var attrList = member?.GetCustomAttributes<ExcelValidationAttributes>().ToList();
                var headerAttr = attrList?.Where(x => x.Validation == ExcelValidation.CustomSheetField);
                string customHeaderName = headerAttr.Any() ? headerAttr.First().ValidationParameters : null; 
                Cell.SetCellValue(customHeaderName  ?? header.Name);
                Cell.CellStyle = styleHeader;
            }
        }
        private List<string> GetSheetHeaders<T>(T data)
        {
            string[] headerNames = data.GetType().GetProperties().Select(key => key.Name).ToArray();
            List<string> Return = new List<string>();
            foreach (var header in headerNames.Select((Name, i) => new { Name, i }))
            {
                Return.Add(header.Name);
            }
            return Return;
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
        private void CreateRowWithValidation(IRow row , List<ExcelValidatedCell> data , List<HSSFCellStyle> styleList , IComment comment )
        {
            for(int i = 0; i < data.Count; i++)
            {
                ICell Cell = row.CreateCell(i);
                
                if (data[i].isValid)
                {
                    Cell.SetCellValue(data[i].Value);
                    Cell.CellStyle = styleList.ElementAt(4);
                }else
                {
                    Cell.SetCellValue(data[i].Value);
                    Cell.CellStyle = styleList.ElementAt(3);
                    comment.String = new HSSFRichTextString($"{comment.Author}:{Environment.NewLine} {data[i].ErrorMessage}");
                    Cell.CellComment = comment;
                    
                }
                
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

            foreach(var row in data.Select( (row , index ) => new { values =row , index = index+1} ))
            {
                List<string> stringList = ObjectToStringList(row.values) ;
                IRow newRow = sheet.CreateRow(row.index);
                if( row.index %2 == 1)
                {
                    CreateRow(newRow, stringList, styleList.ElementAt(1));
                }
                else
                {
                    CreateRow(newRow, stringList, styleList.ElementAt(2));
                }
            }
            
            return workbook;
        }

        public Tuple<bool , IWorkbook?> ReturnValidationSheet<T>(List<T> validationClass , NPOISheetStyles sheetStyle ) where T : class
        {
            //Sheet setup 
            List<ExcelValidatedRow> excelValidationRows = new List<ExcelValidatedRow>();
            HSSFWorkbook workbook = new HSSFWorkbook();
            List<HSSFCellStyle> styleList = CreateStyle(workbook, sheetStyle);
            ISheet sheet = workbook.CreateSheet("Report");
            IRow HeaderRow = sheet.CreateRow(0);
            CreateSheetHeader(HeaderRow, validationClass.First(), styleList.First());
            IDrawing drawing = sheet.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 0, 0, 1, 1, 1, 1);
            IComment comment = drawing.CreateCellComment(anchor);
            //Create cell comment


            //Gets all rows inside of list and get all attributes of class  and validate every custom attribute inside of class attribute.
            foreach ( var row in validationClass.Select( (row , index) => new { values = row , index = index+1  } ) ) //For every class inside of the list , starts validation
            {
                List<ExcelValidatedCell> excelValidationCells = new List<ExcelValidatedCell>();
                var debug = row.values.GetType().GetMembers();
                IRow newRow = sheet.CreateRow(row.index);
                foreach (var member in row.values.GetType().GetMembers().Where( x=> x.MemberType == MemberTypes.Property).Select( (values , index)=> new{ values , index } ).ToList()) //For every attribute inside of the class start validation
                {
                    
                    string cellValue = row.values.GetType().GetProperty(member.values.Name)?.GetValue(row.values).ToString(); //get Current cell value

                    ExcelValidatedCell currentValidation = new ExcelValidatedCell(cellValue);
                    foreach ( ExcelValidationAttributes attribute in member.values.GetCustomAttributes<ExcelValidationAttributes>().ToList() ) //For every Custom attribute inside of the class attribute
                    {
                        switch (attribute.Validation) //Validate row by custom attribute definition in class
                        {
                            case ExcelValidation.StringLength: currentValidation.AddValidation( attribute.StringLength(cellValue)); break;
                            case ExcelValidation.StringContains:throw new NotImplementedException(); break;
                            case ExcelValidation.IsNumber: currentValidation.AddValidation(attribute.IsNumber(cellValue)); break;
                            case ExcelValidation.Required: currentValidation.AddValidation(attribute.Required(cellValue)) ; break;
                            case ExcelValidation.StringValidationMethod: throw new NotImplementedException(); break;
                        }
                    }
                    excelValidationCells.Add(currentValidation);
                    CreateRowWithValidation( newRow , excelValidationCells, styleList , comment);

                }
                excelValidationRows.Add(new ExcelValidatedRow(excelValidationCells));
            }
            bool isValid = excelValidationRows.Where(x => x.isValid ).Count() == 0 ;
            return new Tuple<bool ,IWorkbook >(isValid , workbook );
        }
        public bool ValidateSheetFields<T>(T validationClass , IWorkbook workbook)
        {
            ISheet ws = workbook.GetSheetAt(0);
            IRow headerRow = ws.GetRow(0);

            List<string> validationHeader = GetSheetHeaders(validationClass);

            if (headerRow.Count() > validationHeader.Count())
                return false;

            foreach(ICell cell in headerRow)
            {
                if(!validationHeader.Contains(cell.StringCellValue))
                {
                    return false;
                }
            }
            return true;
        }
        public List<T> GetSheetValues<T>(IWorkbook workbook , int sheetNumber) where T : class
        {
            Mapper mapper = new Mapper(workbook);
            var obj= mapper.Take<T>(sheetNumber).ToList();

            List<T> Return = new List<T>();
            foreach (var item in obj)
            {
                Return.Add(item.Value);
            }

            return Return;
        }
        public IWorkbook? ImportSheetFromFile(string path , string fileName )
        {
            var workbook = new HSSFWorkbook();
            if(File.Exists(path + fileName))
            {
                using (FileStream file = new FileStream(path + fileName, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        workbook = new HSSFWorkbook(file);
                    }catch(Exception ex)
                    {
                        Console.Error.Write(ex.Message);
                        return null; 
                    }
                }
                return workbook.NumberOfSheets > 0 ? workbook : null;
            }
            else
            {
                return null;
            }
        }
    }
}
