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
        }
    }
}
