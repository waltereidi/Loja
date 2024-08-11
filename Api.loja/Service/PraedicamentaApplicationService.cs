using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
using System.Drawing.Text;
using System.Linq;
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
            V1.Requests.AddCategories c =>await HandleCreateCategories(c).ContinueWith(_=> _context.SaveChangesAsync()),
            V1.Requests.AddSubCategories c => await HandleCreateSubCategories(c).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.Requests.AddSubSubCategories c => await HandleCreateSubSubCategories(c).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.Requests.UpdateCategory u => await HandleUpdateCategories(u).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.Requests.UpdateSubCategory u => await HandleUpdateSubCategories(u).ContinueWith(_ => _context.SaveChangesAsync()),
            V1.Requests.UpdateSubSubCategory u => await HandleUpdateSubSubCategories(u).ContinueWith(_=> _context.SaveChangesAsync()),
            V1.Requests.GetCategoriyById g => GetCategoryById(g.id),
            V1.Requests.GetSubCategoryById g => GetSubCategoryById(g.id),
            V1.Requests.GetSubSubCategoryById g => GetSubSubCategoryById(g.id),
            V1.Requests.GetAllCategories g => await GetAll(),
            V1.Requests.GetAllSubSubCategories g => await GetAllSubSubCategories(),
            _ => throw new InvalidOperationException(nameof(command))
        };

        private async Task HandleUpdateSubSubCategories(V1.Requests.UpdateSubSubCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateSubSubCategory(c.Id, c.Name, c.Description));
            _context.subSubCategories.Update(_praedicamenta.subSubCategory);
        }

        private async Task HandleUpdateSubCategories(V1.Requests.UpdateSubCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateSubCategory(c.Id, c.Name, c.Description));
            _context.subCategories.Update(_praedicamenta.subCategory);
        }

        private async Task HandleUpdateCategories(V1.Requests.UpdateCategory c)
        {
            _praedicamenta = new(new PraedicamentaEvents.UpdateCategory(c.Id,c.Name, c.Description));
            _context.Update<Categories>(_praedicamenta.category);
        }

        private async Task HandleCreateSubSubCategories(V1.Requests.AddSubSubCategories c)
        {
            SubCategories subCategory = _context.subCategories.First(x => x.Id == c.SubCategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.CreateSubSubCategory(subCategory, c.Name, c.Description));
            _context.subSubCategories.Add(_praedicamenta.subSubCategory);
        }

        private async Task HandleCreateSubCategories(V1.Requests.AddSubCategories c)
        {
            Categories category = _context.categories.First(x=> x.Id == c.CategoriesId);
            _praedicamenta = new(new PraedicamentaEvents.CreateSubCategory(category ,c.Name, c.Description));
            _context.subCategories.Add(_praedicamenta.subCategory);
        }

        private async Task HandleCreateCategories(V1.Requests.AddCategories c)
        {
            _praedicamenta = new(new PraedicamentaEvents.CreateCategory(c.Name, c.Description));
            _context.categories.Add(_praedicamenta.category);
        }

        private V1.GetCategories GetCategoryById(int id) => _context.categories
            .Select(s => new V1.GetCategories(s.Id, s.Name, s.Description, s.Created_at, s.Updated_at))
            .First(x => x.id == id);
            
        private V1.GetSubCategories GetSubCategoryById(int id) => _context.subCategories
            .Select(s=> new V1.GetSubCategories(s.Id , s.Name , s.Description ,s.CategoriesId, s.Created_at , s.Updated_at ))
            .First(x=>x.id == id);

        private V1.GetSubSubCategories GetSubSubCategoryById(int id) => _context.subSubCategories
            .Select(s => new V1.GetSubSubCategories(s.Id, s.Name, s.Description, s.SubCategoriesId, s.Created_at, s.Updated_at))
            .First(x => x.id == id);
        
        private async Task<IEnumerable<V1.GetAll?>> GetAll() => _context.categories
                .OrderByDescending(x => x.Created_at)
                .Select(s => new V1.GetAll(s.Id ?? 0, s.Name, s.Description, s.Created_at, s.Updated_at, s.Image, // Below SubCategorySelect
                    _context.subCategories
                    .Where(x => x.Id == s.Id)
                    .Select(sc => new V1.GetAllSubCategory(sc.Id ?? 0, sc.Name, sc.Description, sc.Created_at, sc.Updated_at, sc.CategoriesId, //Below SubSubCategorySelect 
                        _context.subSubCategories.Where(xsc => xsc.Id == sc.Id)
                        .Select(ssc => new V1.GetAllSubSubCategory(ssc.Id ?? 0, ssc.Name, ssc.Description, ssc.Created_at, ssc.Updated_at, ssc.SubCategoriesId))))
                    ));

        private async Task<IEnumerable<SubSubCategories>> GetAllSubSubCategories() => _context.subSubCategories.ToList();

    }
}
