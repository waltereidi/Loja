using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Api.loja.Service
{
    public class PraedicamentaApplicationService : IApplicationService
    {
        private readonly StoreContext _context;
        public Praedicamenta praedicamenta;
        public PraedicamentaApplicationService(StoreContext context)
        {
            _context = context;
        }
        public async Task Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case PraedicamentaContract.V1.AddCategories c : HandleCreateCategories(c);break;
                case PraedicamentaContract.V1.AddSubCategories c: HandleCreateSubCategories(c); break;
                case PraedicamentaContract.V1.AddSubSubCategories c: HandleCreateSubSubCategories(c); break;
                default:break;
            }
        }

        private void HandleCreateSubSubCategories(PraedicamentaContract.V1.AddSubSubCategories c)
        {
            SubCategories subCategory = _context.subCategories.First(x => x.Id == c.SubCategoriesId);
            praedicamenta = new(new PraedicamentaEvents.CreateSubSubCategory(subCategory, c.Name, c.Description));
            _context.subCategories.Add(praedicamenta.subCategory);
            _context.SaveChanges();
        }

        private void HandleCreateSubCategories(PraedicamentaContract.V1.AddSubCategories c)
        {
            Categories category = _context.categories.First(x=> x.Id == c.CategoriesId);
            praedicamenta = new(new PraedicamentaEvents.CreateSubCategory(category ,c.Name, c.Description));
            _context.subCategories.Add(praedicamenta.subCategory);
            _context.SaveChanges();
        }

        private async Task HandleCreateCategories(PraedicamentaContract.V1.AddCategories c)
        {
            praedicamenta= new(new PraedicamentaEvents.CreateCategory(c.Name , c.Description) );
            _context.categories.Add(praedicamenta.category);
            _context.SaveChanges();
        }

        public IEnumerable<PraedicamentaContract.V1.getAll>? GetAll()
        {
            return _context.categories
                .Select(cat => new PraedicamentaContract.V1.getAll(cat.Id, cat.Name, cat.Description,
                _context.subCategories.Any(asub => asub.CategoriesId == cat.Id) ?
                    _context.subCategories.Where(xsub => xsub.CategoriesId == cat.Id)
                    .Select(sub => new PraedicamentaContract.V1.getSubCategory(sub.Id, sub.Name, sub.Description,
                        _context.subSubCategories.Any(asubsub => asubsub.SubCategoriesId == sub.Id) ?
                            _context.subSubCategories
                            .Where(xsubsub => xsubsub.SubCategoriesId == sub.Id)
                            .Select(subsub => new PraedicamentaContract.V1.getSubSubCategory(subsub.Id, subsub.Name, subsub.Description)).ToList() : null
                    )).ToList() :null
              )).ToList();

        }
    }
}
