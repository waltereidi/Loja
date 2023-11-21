using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class Products : MasterEntity
    {
        [Key]
        public int ID_Products { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string? Description { get; set; }

        public long? Ean { get; set; }
        [StringLength(64)]
        public string? Sku { get; set; }



    }
}
