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
        public void TestORMCategoriesPromotionXCategories()
        {
            //setup 

            //action
            var result =_storeContext.categoriesPromotion.ToList();
            //assert 
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.First().Categories != null);

        }
        [TestMethod]

        public void TestORMProducts()
        {
            //setup 
            var result = _storeContext.productsCategories.ToList();
            var result1 = _storeContext.products.ToList();

            Assert.IsTrue(result.First() != null);
        }

    }
}
