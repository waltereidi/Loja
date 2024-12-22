using Api.loja.Data;
using Dominio.loja.Entity.Integrations.WFileManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;

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
        [TestMethod]
        public void TestCategoriesFileDirectory()
        {
            //Validates if ORM is returning the nested classes from initial migration

            FileDirectory dir = _context.fileDirectory.First();

            
            Assert.IsNotNull(dir.DirectoryName);
        }
        [TestMethod]
        public void TestAuthenticationORM()
        {
            //Ensures the conversion to IPAddress class from string is lucid 
            var ipScore = _context.ipScore.Select(x=> x.Score );
            var auth = _context.auth.Select(x=>x.Score);

            Assert.IsNotNull(ipScore);

        }
        


    }
}
