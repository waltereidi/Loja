﻿using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
using NPOI.SS.Formula.Functions;
using static Api.loja.Contracts.PraedicamentaContract;

namespace Api.loja.Service
{
    public class PraedicamentaApplicationService : IApplicationService
    {
        public Praedicamenta _praedicamenta;
        private readonly StoreContext _context;
        public PraedicamentaApplicationService(StoreContext context)
        {
            _context = context;
            _praedicamenta = new Praedicamenta();
        }

        public async Task<object?> Handle(object command) => command switch
        {
            V1.AddCategories c =>await HandleCreateCategories(c).ContinueWith(_=> _context.SaveChangesAsync()),
            V1.AddSubCategories c => HandleCreateSubCategories(c).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.AddSubSubCategories c => HandleCreateSubSubCategories(c).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.updateCategory u => HandleUpdateCategories(u).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.updateSubCategory u => HandleUpdateSubCategories(u).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.updateSubSubCategory u => HandleUpdateSubSubCategories(u).ContinueWith(_=> _context.SaveChangesAsync()),
            V1.GetCategories g => GetCategoryById(g.id ?? throw new ArgumentNullException()),
            V1.GetSubCategories g => GetSubCategoryById(g.id ??throw new ArgumentNullException()),
            V1.GetSubSubCategories g => GetSubCategoryById(g.id ?? throw new ArgumentNullException()),
            _ => Task.CompletedTask
        };

        private async Task HandleUpdateSubSubCategories(V1.updateSubSubCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateSubSubCategory(c.Id, c.Name, c.Description));
            _context.subSubCategories.Update(_praedicamenta.subSubCategory);
            
        }

        private async Task HandleUpdateSubCategories(V1.updateSubCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateSubCategory(c.Id, c.Name, c.Description));
            _context.subCategories.Update(_praedicamenta.subCategory);
        }

        private async Task HandleUpdateCategories(V1.updateCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateCategory(c.Id,c.Name, c.Description));
            _context.Update<Categories>(_praedicamenta.category);
        }

        private async Task HandleCreateSubSubCategories(V1.AddSubSubCategories c)
        {
            SubCategories subCategory = _context.subCategories.First(x => x.Id == c.SubCategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.CreateSubSubCategory(subCategory, c.Name, c.Description));
            _context.subSubCategories.Add(_praedicamenta.subSubCategory);
        }

        private async Task HandleCreateSubCategories(V1.AddSubCategories c)
        {
            Categories category = _context.categories.First(x=> x.Id == c.CategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.CreateSubCategory(category ,c.Name, c.Description));
            _context.subCategories.Add(_praedicamenta.subCategory);
        }

        private async Task HandleCreateCategories(V1.AddCategories c)
        {
            _praedicamenta = new(new PraedicamentaEvents.CreateCategory(c.Name, c.Description));
            _context.categories.Add(_praedicamenta.category);
        }


        public async Task<V1.GetCategories?> GetCategoryById(int id) => _context.categories
            .Where(x => x.Id == id)
            .Select(s => new V1.GetCategories(s.Id, s.Name, s.Description, s.Created_at, s.Updated_at))
            .FirstOrDefault();
            
        public async Task<V1.GetSubCategories?> GetSubCategoryById(int id) => _context.subCategories
            .Where(x=>x.Id == id)
            .Select(s=> new V1.GetSubCategories(s.Id , s.Name , s.Description ,s.CategoriesId, s.Created_at , s.Updated_at ))
            .FirstOrDefault();

        public async Task<V1.GetSubSubCategories?> GetSubSubCategoryById(int id) => _context.subSubCategories
            .Where(x=>x.Id == id)
            .Select(s=> new V1.GetSubSubCategories(s.Id, s.Name , s.Description , s.SubCategoriesId , s.Created_at , s.Updated_at))
            .FirstOrDefault();

    }
}
