using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class SubSubCategories : MasterEntity<int>
    {
        public int SubSubCategoriesId { get; set; }
        public int SubCategoriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
