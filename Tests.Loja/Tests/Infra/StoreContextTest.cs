using Api.loja.Data;
using Castle.Core.Configuration;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void TestORMClients()
        {
            var result = _storeContext.clients.Find(1);
            
            Assert.IsTrue(result.PermissionsGroup != null);
        }
        [TestMethod]
        public void TestProductsORM()
        {
            var result = _storeContext.products.Find(1);
            Assert.IsTrue(result.ProductsStorage != null );

        }
        [TestMethod]
        public void testRequestORM()
        {
            var result = _storeContext.requestOrders.Find(1);
            var result1 = _storeContext.clientsProducts_cart.Find(1);
            Assert.IsTrue(result.RequestOrdersProducts is not null);
            Assert.IsTrue(result1.Products is not null);
        }


    }
}
