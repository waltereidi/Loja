using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Entity.Integrations.WFileManager.Relation;
using Dominio.loja.Events.FileUpload;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
using Integrations;
using Microsoft.AspNetCore.Components.RenderTree;
using Npoi.Mapper;
using System.Drawing.Text;
using System.Linq;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
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
            V1.Requests.ChangePicture g => await ChangePicture(g).ContinueWith(_ => _context.SaveChangesAsync()),
            _ => throw new InvalidOperationException(nameof(command))
        };
        private async Task ChangePicture(V1.Requests.ChangePicture cmd)
        {
            Categories category = _context.categories.First(x => x.Id == cmd.id);

            FileManagerMS fs = new FileManagerMS();

            FileDirectory directory = _context.fileDirectory.First(x => x.Referer == cmd.referer);

            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile(cmd.file, directory.DirectoryName, WFileManager.Enum.UploadOptions.Image);
            //Create File Physically
            var result = fs.Start <Images.UploadResponse>(strategy).First();
            Image properties = new Image(result.Height , result.Width);

            FileManager fm = new(new FileManagerEvents.CategoryChangedPicture(result.FullName , result.OriginalFileName, directory ,category , properties));


            var createdFiles = fm.GetFile();
            
            _context.fileStorage.Add(createdFiles.FileStorage);
            FileCategories
            _context.fileCategories.Entry();
            
            _context.SaveChanges();

        }

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

        private V1.GetCategory GetCategoryById(int id) => _context.categories
            .Select(s => new V1.GetCategory(s.Id, s.Name, s.Description, s.Created_at, s.Updated_at))
            .First(x => x.id == id);
            
        private V1.GetSubCategory GetSubCategoryById(int id) => _context.subCategories
            .Select(s=> new V1.GetSubCategory(s.Id , s.Name , s.Description ,s.CategoriesId, s.Created_at , s.Updated_at ))
            .First(x=>x.id == id);

        private V1.GetSubSubCategory GetSubSubCategoryById(int id) => _context.subSubCategories
            .Select(s => new V1.GetSubSubCategory(s.Id, s.Name, s.Description, s.SubCategoriesId, s.Created_at, s.Updated_at))
            .First(x => x.id == id);

        private async Task<IEnumerable<V1.GetAll?>> GetAll()
        {
            var allSubSubCategories = _context.subSubCategories
                       .Select(ssc => new V1.GetSubSubCategory(ssc.Id ?? 0, ssc.Name, ssc.Description, ssc.SubCategoriesId, ssc.Created_at, ssc.Updated_at))
                       .ToList();

            //Below SubSubCategorySelect 
            List<V1.GetAllSubCategory> allSubCategories = new();

            _context.subCategories
                .ForEach(sc =>
                {
                    var ssc = allSubSubCategories
                        .Where(x => x.SubCategoriesId == sc.Id)
                        .ToList();
                    var i = new V1.GetAllSubCategory(sc.Id ?? 0, sc.Name, sc.Description, sc.Created_at, sc.Updated_at, sc.CategoriesId, ssc);
                    allSubCategories.Add(i);
                });

            List<V1.GetAll> result = new();
            _context.categories
                .ForEach(c =>
                {
                    var sc = allSubCategories
                        .Where(x => x.category_id == c.Id)
                        .ToList();
                    var i = new V1.GetAll(c.Id ?? 0, c.Name, c.Description, c.Created_at, c.Updated_at, c.Image, sc);
                    result.Add(i);
                });
                
            return result;
        }

        private async Task<IEnumerable<V1.GetSubSubCategory>> GetAllSubSubCategories() => _context.subSubCategories
            .Select(s => new V1.GetSubSubCategory(s.Id, s.Name, s.Description, s.SubCategoriesId, s.Created_at, s.Updated_at))
            .ToList();
    }
}
