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
        public record class CreateSubSubCategory(SubCategories SubCategory, string Name, string Description);
        public record class UpdateSubSubCategory(int? Id, string name, string description);
        public record class UpdateSubCategory(int? Id, string name, string description);
        public record class UpdateCategory( int? Id, string name, string description);
    }
}
