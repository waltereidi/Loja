using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Requests
{
    public class PostRequestOrdersRequest
    {
        [Required]
        public int ClientsId {get;set;}
        [StringLength(2048)]
        public string Description { get;set;}
        [Required]
        public List<ClientsProductsCart> CartProducts {get;set;}

    }
}
