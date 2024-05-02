namespace Api.loja.Contracts
{
    public static class PraedicamentaContract
    {
        public class V1
        {
            public record class GetCategories(int id );
            public record class AddCategories(string Name , string Description);
            public record class AddSubCategories(int CategoriesId , string Name,string Description);
            public record class AddSubSubCategories(int SubCategoriesId, string Name, string Description);
            public record class getAll(int Id ,string Name , string Description , IEnumerable<getSubCategory> getSubCategories);
            public record class getSubCategory(int Id , string Name , string Description ,IEnumerable<getSubSubCategory> getSubSubCategories );
            public record class getSubSubCategory(int Id , string Name , string Description );

        }
    }
}
