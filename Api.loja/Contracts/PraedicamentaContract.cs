using Dominio.loja.Entity.Integrations.WFileManager;
using System.Text.Json.Serialization;

namespace Api.loja.Contracts
{
    public static class PraedicamentaContract
    {
        public class V1
        {
            public class Requests
            {
                public record GetAllCategories();
                public record GetCategoriyById(int id);
                public record GetSubCategoryById(int id);
                public record GetSubSubCategoryById(int id);
                public record AddCategories(string Name, string Description);
                public record AddSubCategories(int CategoriesId, string Name, string Description);
                public record AddSubSubCategories(int SubCategoriesId, string Name, string Description);
                public record UpdateCategory(int Id, string Name, string Description);
                public record UpdateSubCategory(int Id, string Name, string Description);
                public record UpdateSubSubCategory(int Id, string Name, string Description);
                public record GetAllSubSubCategories();
                public record ChangePicture(IFormFile file, int id, Uri referer  );
            }
            //Responses
            public record class GetCategory(int? id , string Name , string? Description , DateTime Created_at , DateTime? Updated_at );
            public record class GetSubCategory(int? id, string Name, string Description,int CategoriesId ,DateTime Created_at, DateTime? Updated_at);
            public record class GetSubSubCategory(int? id, string Name, string Description,int SubCategoriesId, DateTime Created_at, DateTime? Updated_at);
            public record class GetAll(int Id ,string Name , string Description , DateTime created_at , DateTime? updated_at ,FileStorage Image , IEnumerable<GetAllSubCategory?> getSubCategories);
            public record class GetAllSubCategory(int Id , string Name , string Description , DateTime created_at, DateTime? updated_at,int category_id, IEnumerable<GetSubSubCategory?> getSubSubCategories );
            
        }
    }
}
