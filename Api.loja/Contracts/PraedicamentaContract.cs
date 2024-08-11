using Dominio.loja.Entity.Integrations.WFileManager;

namespace Api.loja.Contracts
{
    public static class PraedicamentaContract
    {
        public class V1
        {
            public class Requests
            {
                public record class GetAllCategories();
                public record class GetCategoriyById(int id);
                public record class GetSubCategoryById(int id);
                public record class GetSubSubCategoryById(int id);
                public record class AddCategories(string Name, string Description);
                public record class AddSubCategories(int CategoriesId, string Name, string Description);
                public record class AddSubSubCategories(int SubCategoriesId, string Name, string Description);
                public record class UpdateCategory(int Id, string Name, string Description);
                public record class UpdateSubCategory(int Id, string Name, string Description);
                public record class UpdateSubSubCategory(int Id, string Name, string Description);
                public record class GetAllSubSubCategories();
            }
            //Responses
            public record class GetCategories(int? id , string Name , string? Description , DateTime Created_at , DateTime? Updated_at );
            public record class GetSubCategories(int? id, string Name, string Description,int CategoriesId ,DateTime Created_at, DateTime? Updated_at);
            public record class GetSubSubCategories(int? id, string Name, string Description,int SubCategoriesId, DateTime Created_at, DateTime? Updated_at);
            public record class GetAll(int Id ,string Name , string Description , DateTime created_at , DateTime? updated_at ,FileStorage Image , IEnumerable<GetAllSubCategory?> getSubCategories);
            public record class GetAllSubCategory(int Id , string Name , string Description , DateTime created_at, DateTime? updated_at,int category_id, IEnumerable<GetAllSubSubCategory?> getSubSubCategories );
            public record class GetAllSubSubCategory(int Id , string Name , string Description , DateTime created_at, DateTime? updated_at , int subCategory_id);
            
        }
    }
}
