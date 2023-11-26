using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ResponseModel
    {
        public dynamic Data { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public ResponseModel()
        {

        }
        public ResponseModel(dynamic Data, string Mensagem)
        {
            Data = Data;
            Mensagem = Mensagem;
            Sucesso = Data == null ? false : true;

        }
    }

}
