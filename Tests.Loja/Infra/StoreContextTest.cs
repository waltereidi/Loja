using Api.loja.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.loja.Infra
{
    [TestClass]
    public class StoreContextTest
    {
        private StoreContext _context;

        public StoreContextTest()
        {
            _context = new StoreContext();

        }
        [TestMethod]
        public void TestCategoriesORM()
        {
            //Validates if ORM is returning the nested classes from initial migration

            var categories =_context.categories.First();
            var subCategories = _context.subCategories.First();
            var subSubCategories = _context.subSubCategories.First();

            Assert.IsNotNull(categories);
            Assert.IsNotNull(subCategories.Categories);
            Assert.IsNotNull(subSubCategories.SubCategories);
        }
       

    }
}
