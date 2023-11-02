using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    internal class Products : MasterEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long Ean { get; set; }

        public string Sku { get; set; }

        public List<Prices> Price { get; set; }

        public Category Category { get; set; }


    }
}
