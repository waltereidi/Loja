using Api.loja.Data;
using Dominio.loja.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Tests.Loja.Tests.Infra
{
    [TestClass]
    public class StoreContextTest
    {
        private StoreContext _storeContext;

        public StoreContextTest()
        {
            _storeContext = new StoreContext();
            
        }
        [TestMethod]
        public void TestORMCategories()
        {
            var result = _storeContext.categories.Find(1);
            Assert.IsNotNull(result.SubCategories);
        }
        [TestMethod]
        public void TestORMClients()
        {
            var result = _storeContext.clients.Find(1);
            
            Assert.IsTrue(result.PermissionsGroup != null);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestProductsORM()
        {
            
            var result = _storeContext.products.Find(1);
            var productsCategories = _storeContext.productsCategories.Find(1);
            var jsonTest = JsonConvert.SerializeObject(productsCategories, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            Assert.IsNotNull(result.ProductsStorage);
            Assert.IsNotNull(productsCategories.Products);

        }
        [TestMethod]
        public void testRequestORM()
        {
            var result =_storeContext.requestOrders.Find(1);
            var result1 = _storeContext.clientsProducts_cart.Find(1);
            Assert.IsTrue(result.RequestOrdersProducts is not null);
            Assert.IsTrue(result1.Products is not null);
        }


    }
}
