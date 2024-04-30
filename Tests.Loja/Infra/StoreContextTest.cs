using Api.loja.Data;
using Dominio.loja.Entity.Integrations.WFileManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Tests.loja.Infra
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
        public void TestCategoriesORM()
        {
            
        }

    }
}
