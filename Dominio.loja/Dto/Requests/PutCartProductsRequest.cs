using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Requests
{
    public class PutCartProductsRequest
    {
        [Required]
        public int ClientsId { get; set; }
        [Required]
        public int ProductsId { get; set; }
        [Required]
        [Range(0, 100000)]
        public int Quantity { get; set; }
    }
}
