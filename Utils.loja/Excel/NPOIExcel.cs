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
            foreach(var header in headerNames.Select((Name , i ) => new { Name , i }) )
            {
                ICell Cell = row.CreateCell(header.i);
                Cell.SetCellValue(header.Name);
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
        private void CreateErrorRow(IRow row , List<Tuple<bool , string>> data , string errorMessages ,List<HSSFCellStyle> styleList )
        {
            for(int i = 0; i < data.Count; i++)
            {
                ICell Cell = row.CreateCell(i);
                Cell.SetCellValue(data[i].Item2);
                if (data[i].Item1)
                {
                    Cell.CellStyle = styleList.ElementAt(3);
                }else
                {
                    Cell.CellStyle = styleList.ElementAt(4);
                }
            }
            ICell ErrorMessageCell = row.CreateCell(data.Count + 1);
            ErrorMessageCell.SetCellValue(errorMessages);
            ErrorMessageCell.CellStyle = styleList.ElementAt(3);

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
                    CreateRow(row, stringList, styleList.ElementAt(2));
                }
            }
            
            return workbook;
        }

        public Tuple<bool , IWorkbook?> ReturnValidationSheet<T>(List<T> validationClass ) where T : class
        {
            
            Dictionary<string, Tuple<bool, string>> dictionary = new Dictionary<string, Tuple<bool, string>>(); 

            //Para cada classe da lista enviada nos parametros deve ser extraídos cada atributo da classe com todas e comparada
            //com todas as possibilidades que o atributo customizável oferece
            foreach( var row in validationClass)
            {
                foreach (MemberInfo member in row.GetType().GetMembers() )
                {
                    
                    foreach( ExcelValidationAttributes attribute in member.GetCustomAttributes<ExcelValidationAttributes>().ToList() )
                    {
                        Tuple<bool, string> validation;
                        switch(attribute.Validation)
                        {
                            case ExcelValidation.StringLength: break;
                            case ExcelValidation.StringContains: break;
                            case ExcelValidation.IsNumber:break;
                            case ExcelValidation.Required: break;
                            case ExcelValidation.StringValidationMethod: throw new NotImplementedException(); break;
                        }

                        string cellValue = row.GetType().GetProperty(member.Name)?.GetValue(row).ToString();
                        dictionary.Add( cellValue , new Tuple<bool , string >(false, "") );
                    }
                }
            }
           
            return new Tuple<bool ,IWorkbook >(false , new HSSFWorkbook() );
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
