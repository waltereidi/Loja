using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.Praedicamenta
{
    public class PraedicamentaEvents
    {
        public record class CreateCategory(string Name , string Description);
        public record class CreateSubCategory(Categories Category, string Name, string Description);
        public record class CreateSubSubCategory(SubCategories Category, string Name, string Description);
    }
}
