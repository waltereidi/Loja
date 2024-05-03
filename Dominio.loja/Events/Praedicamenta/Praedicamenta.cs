using Dominio.loja.Entity;
using Framework.loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.Praedicamenta
{
    public class Praedicamenta : AggregateRoot<int>
    {
        public Categories category { get; set; }
        public SubCategories subCategory { get; set; }
        public SubSubCategories subSubCategory { get; set; }

        public Praedicamenta(object @event)
        {
            Apply(@event);
        }
        public Praedicamenta()
        {
        }
        protected override void EnsureValidState()
        {
            if ( subCategory!=null && subCategory.CategoriesId != category.Id )
                throw new AggregateException("Entities does not match");

            if (subSubCategory!=null && subSubCategory.SubCategoriesId != subCategory.Id)
                throw new AggregateException("Entities does not match");
        }

        protected override void When(object @event)
        {
            switch(@event)
            {
                case PraedicamentaEvents.CreateCategory c : category = new() { Name = c.Name , Description = c.Description , Created_at = DateTime.Now };break;
                case PraedicamentaEvents.CreateSubCategory c:
                    subCategory = new() { Categories = c.Category, Name = c.Name, Description = c.Description, CategoriesId = c.Category.Id, Created_at = DateTime.Now };
                    category = subCategory.Categories;
                    ;break;
                case PraedicamentaEvents.CreateSubSubCategory c:
                    subSubCategory = new() { Name = c.Name, Description = c.Description, SubCategoriesId = c.SubCategory.Id, SubCategories = c.SubCategory, Created_at = DateTime.Now };
                    subCategory = c.SubCategory;
                    category = c.SubCategory.Categories;
                    ;break;
                
                default:throw new NotImplementedException();
            }
        }

        public void UpdateCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateSubCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateSubSubCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(int id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubSubCategory(int id, string name, string description)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubCategory(int id, string name, string description)
        {
            throw new NotImplementedException();
        }
    }
}
