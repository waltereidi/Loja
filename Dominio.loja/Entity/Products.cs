using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class Products : MasterEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public long? Ean { get; set; }

        public string? Sku { get; set; }

        public int Price_id { get; set; }

        public int Category_Id { get; set; }


    }
}
