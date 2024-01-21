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
        public ResponseModel(int save)
        {
            Success = save>0 ? true : false;
            RowCount = save;
            Message = $"Total de registros modificados{save}";
        }
        public ResponseModel( bool sucesso , dynamic data, string message)
        {
            Data = data;
            Message = message;
            Success = sucesso;
        }
        public ResponseModel(bool sucesso, dynamic data)
        {
            Data = data;
            Success = sucesso;
        }
        public ResponseModel(bool sucesso, string message)
        {
            Message = message;
            Success = sucesso;
        }
    }

}
