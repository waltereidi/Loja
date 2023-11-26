using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ResponseModel<T> where T : class?
    {
        private List<T> Data { get; set; }
        private string Mensagem { get; set; }
        private int RowCount { get; set; }
        public object Parameters { get; set; }

        public ResponseModel(List<T> Data, string Mensagem)
        {
            Data = Data;
            Mensagem = Mensagem;
            RowCount = Data == null ? 0 : Data.Count();
        }
    }

}
