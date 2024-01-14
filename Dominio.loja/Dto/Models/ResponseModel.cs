using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ResponseModel
    {
        private dynamic Data { get; set; }
        private string Message { get; set; }
        private int RowCount { get; set; } = 0;
        private bool Success { get; set; }
        public ResponseModel( bool sucesso , dynamic data, string message)
        {
            Data = data;
            Message = message;
            Success = sucesso;
        }
      
    }

}
