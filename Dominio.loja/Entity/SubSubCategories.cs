﻿using Dominio.loja.Events.Praedicamenta;
using Framework.loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class SubSubCategories : Entity<int>
    {
        public int SubCategoriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual SubCategories SubCategories { get; set; }

        public SubSubCategories(Action<object> applier) :base(applier){ }
        protected override void When(object @event)
        {
            switch (@event)
            {
                case PraedicamentaEvents.CreateSubSubCategory e:
                    SubCategoriesId = e.SubCategory.Id;
                    Name = e.Name;
                    Description = e.Description;
                    SubCategories = e.SubCategory;
                    break;
                default: throw new NotImplementedException();
            }

        }
    }
}
