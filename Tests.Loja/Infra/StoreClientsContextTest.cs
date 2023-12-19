using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Dominio.loja.Interfaces.Services;
using Infra.loja.Data;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.Infra
{
    [TestClass]
    public class StoreClientsContextTest
    {
        private readonly IStoreClientsContext _context; 
        public StoreClientsContextTest()
        {
            String dir = System.IO.Directory.GetCurrentDirectory();
            string jsonDir = dir.Replace("\\Tests.Loja\\bin\\Debug\\net6.0", "") + "\\Api.loja\\appsettings.json";
            string json = File.ReadAllText(jsonDir);
            dynamic launchSettings = JObject.Parse(json);
            _context = new StoreClientsContext((string)launchSettings.ConnectionString);
        }

        [TestMethod]
        public void DeleteCartProductsReturnsFalseWhenNotFound()
        {
            //Setup 
            ClientsProductsCart entity = new ClientsProductsCart() { ID_Clients=0};

            //Action 
            var result = _context.DeleteCartProducts(entity);

            //Assert 

            Assert.IsFalse(result);
           

        }

    }
}
