using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;
using static Api.loja.Contracts.PraedicamentaContract;

namespace Api.loja.Service
{
    public class PraedicamentaApplicationService : IApplicationService
    {
        private readonly StoreContext _context;
        public PraedicamentaApplicationService(StoreContext context)
        {
            _context = context;
        }
        public async Task Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case V1.AddCategories c : HandleCreateCategories(c);break;
                case V1.AddSubCategories c: HandleCreateSubCategories(c); break;
                case V1.AddSubSubCategories c: HandleCreateSubSubCategories(c); break;
                case V1.updateCategory u: HandleUpdate( c=>c.UpdateCategory(u.Id , u.Name , u.Description ) );break;
                case V1.updateSubCategory u: HandleUpdate(c => c.UpdateSubCategory(u.Id , u.Name , u.Description)); break;
                case V1.updateSubSubCategory u: HandleUpdate(c => c.UpdateSubSubCategory(u.Id , u.Name , u.Description )); break;
                default:break;
            }
        }

        private async Task HandleUpdate(Action<Praedicamenta> action) 
        {
                
        }
        
        private void HandleCreateSubSubCategories(V1.AddSubSubCategories c)
        {
            SubCategories subCategory = _context.subCategories.First(x => x.Id == c.SubCategoriesId);
            praedicamenta = new(new PraedicamentaEvents.CreateSubSubCategory(subCategory, c.Name, c.Description));
            _context.subCategories.Add(praedicamenta.subCategory);
            _context.SaveChanges();
        }

        private void HandleCreateSubCategories(V1.AddSubCategories c)
        {
            Categories category = _context.categories.First(x=> x.Id == c.CategoriesId);
            praedicamenta = new(new PraedicamentaEvents.CreateSubCategory(category ,c.Name, c.Description));
            _context.subCategories.Add(praedicamenta.subCategory);
            _context.SaveChanges();
        }

        private async Task HandleCreateCategories(V1.AddCategories c)
        {
            praedicamenta= new(new PraedicamentaEvents.CreateCategory(c.Name , c.Description) );
            _context.categories.Add(praedicamenta.category);
            _context.SaveChanges();
        }

        public IEnumerable<V1.getAll>? GetAll()
        {
            return _context.categories
                .Select(cat => new V1.getAll(cat.Id, cat.Name, cat.Description,
                _context.subCategories.Any(asub => asub.CategoriesId == cat.Id) ?
                    _context.subCategories.Where(xsub => xsub.CategoriesId == cat.Id)
                    .Select(sub => new V1.getAllSubCategory(sub.Id, sub.Name, sub.Description,
                        _context.subSubCategories.Any(asubsub => asubsub.SubCategoriesId == sub.Id) ?
                            _context.subSubCategories
                            .Where(xsubsub => xsubsub.SubCategoriesId == sub.Id)
                            .Select(subsub => new V1.getAllSubSubCategory(subsub.Id, subsub.Name, subsub.Description)).ToList() : null
                    )).ToList() :null
              )).ToList();
        }
        public V1.GetCategories GetCategoryById(int id) => _context.categories
            .Where(x => x.Id == id)
            .Select(s => new V1.GetCategories(s.Id, s.Name, s.Description, s.Created_at, s.Updated_at))
            .FirstOrDefault();
            
        public V1.GetSubCategories GetSubCategoryById(int id) => _context.subCategories
            .Where(x=>x.Id == id)
            .Select(s=> new V1.GetSubCategories(s.Id , s.Name , s.Description ,s.CategoriesId, s.Created_at , s.Updated_at ))
            .FirstOrDefault();

        public V1.GetSubSubCategories GetSubSubCategoryById(int id) => _context.subSubCategories
            .Where(x=>x.Id == id)
            .Select(s=> new V1.GetSubSubCategories(s.Id, s.Name , s.Description , s.SubCategoriesId , s.Created_at , s.Updated_at))
            .FirstOrDefault();

    }
}
