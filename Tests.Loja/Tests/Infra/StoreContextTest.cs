using Api.loja.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Protocol;

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
            Assert.IsNotNull(result.ToJson());
            Assert.IsNotNull(result.SubCategories);
        }
        [TestMethod]
        public void TestORMClients()
        {
            var result = _storeContext.clients.Find(1);
            
            Assert.IsTrue(result.PermissionsGroup != null);
            Assert.IsNotNull(result.ToJson());
        }
        [TestMethod]
        public void TestProductsORM()
        {
            var result = _storeContext.products.Find(1);
            Assert.IsNotNull(result.ToJson());
            Assert.IsTrue(result.ProductsStorage != null );

        }
        [TestMethod]
        public void testRequestORM()
        {
            var result = _storeContext.requestOrders.Find(1);
            var result1 = _storeContext.clientsProducts_cart.Find(1);
            Assert.IsNotNull(result.ToJson());
            Assert.IsNotNull(result1.ToJson());
            Assert.IsTrue(result.RequestOrdersProducts is not null);
            Assert.IsTrue(result1.Products is not null);
        }


    }
}
