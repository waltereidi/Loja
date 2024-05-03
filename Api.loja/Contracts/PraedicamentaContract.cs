namespace Api.loja.Contracts
{
    public static class PraedicamentaContract
    {
        public class V1
        {
            public record class GetCategories(int id , string Name , string Description , DateTime Created_at , DateTime? Updated_at);
            public record class GetSubCategories(int id, string Name, string Description,int CategoriesId ,DateTime Created_at, DateTime? Updated_at);
            public record class GetSubSubCategories(int id, string Name, string Description,int SubCategoriesId, DateTime Created_at, DateTime? Updated_at);
            public record class AddCategories(string Name , string Description);
            public record class AddSubCategories(int CategoriesId , string Name,string Description);
            public record class AddSubSubCategories(int SubCategoriesId, string Name, string Description);
            public record class getAll(int Id ,string Name , string Description , IEnumerable<getAllSubCategory> getSubCategories);
            public record class getAllSubCategory(int Id , string Name , string Description ,IEnumerable<getAllSubSubCategory> getSubSubCategories );
            public record class getAllSubSubCategory(int Id , string Name , string Description );
            public record class updateCategory(int Id, string Name, string Description);
            public record class updateSubCategory(int Id, string Name, string Description);
            public record class updateSubSubCategory(int Id, string Name, string Description);
        }
    }
}
