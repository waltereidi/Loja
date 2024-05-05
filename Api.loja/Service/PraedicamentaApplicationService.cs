using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
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
        public async Task Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case V1.AddCategories c: HandleCreateCategories(c); break;
                case V1.AddSubCategories c: HandleCreateSubCategories(c); break;
                case V1.AddSubSubCategories c: HandleCreateSubSubCategories(c); break;
                case V1.updateCategory u: HandleUpdateCategories(u); break;
                case V1.updateSubCategory u: HandleUpdateSubCategories(u); break;
                case V1.updateSubSubCategory u: HandleUpdateSubSubCategories(u); break;
                default:break;
            }
        }

        private void HandleUpdateSubSubCategories(V1.updateSubSubCategory c)
        {
            SubCategories subCategory = _context.subCategories.First(x => x.Id == c.SubCategoriesId );
            _praedicamenta = new(new PraedicamentaEvents.UpdateSubSubCategory(subCategory, c.Name, c.Description));
            _context.subSubCategories.Update(_praedicamenta.subSubCategory);
            _context.SaveChanges();
        }

        private void HandleUpdateSubCategories(V1.updateSubCategory c)
        {
            Categories category = _context.categories.First(x => x.Id == c.CategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.UpdateSubCategory(category, c.Name, c.Description));
            _context.subCategories.Update(_praedicamenta.subCategory);
            _context.SaveChanges();
        }

        private void HandleUpdateCategories(V1.updateCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateCategory(c.Name, c.Description));
            _context.categories.Update(_praedicamenta.category);
            _context.SaveChanges();
        }

        private void HandleCreateSubSubCategories(V1.AddSubSubCategories c)
        {
            SubCategories subCategory = _context.subCategories.First(x => x.Id == c.SubCategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.CreateSubSubCategory(subCategory, c.Name, c.Description));
            _context.subSubCategories.Add(_praedicamenta.subSubCategory);
            _context.SaveChanges();
        }

        private void HandleCreateSubCategories(V1.AddSubCategories c)
        {
            Categories category = _context.categories.First(x=> x.Id == c.CategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.CreateSubCategory(category ,c.Name, c.Description));
            _context.subCategories.Add(_praedicamenta.subCategory);
            _context.SaveChanges();
        }

        private async Task HandleCreateCategories(V1.AddCategories c)
        {
            _praedicamenta= new(new PraedicamentaEvents.CreateCategory(c.Name , c.Description) );
            _context.categories.Add(_praedicamenta.category);
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
