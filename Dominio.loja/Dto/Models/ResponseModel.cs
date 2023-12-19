using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ResponseModel<T> 
    {
        private dynamic Data { get; set; }
        private string Message { get; set; }
        private int RowCount { get; set; } = 0;
        public object Parameters { get; set; }
        private bool Success { get; set; }
        public ResponseModel(List<T> data, string message)
        {
            Data = data;
            Message = message;
            RowCount = data.Count();
        }
        public ResponseModel(IEnumerable<T> data , string message)
        {
            Data = data;
            Message = message;
            RowCount = data != null ? data.Count() : 0 ;
        }
        public ResponseModel( dynamic data , string message , int RowCount )
        {
            Data = data;
            Message = message;
            RowCount = RowCount;
        }
        public ResponseModel(bool success , string message)
        {
            Success = success;
            Message = message;
        }
    }

}
