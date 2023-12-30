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

namespace Tests.Loja.Tests.Infra
{
    [TestClass]
    public class StoreClientsContextTest
    {
        private readonly IStoreClientsContext _context;
        public StoreClientsContextTest()
        {
            string dir = Directory.GetCurrentDirectory();
            string jsonDir = dir.Replace("\\Tests.Loja\\bin\\Debug\\net6.0", "") + "\\Api.loja\\appsettings.json";
            string json = File.ReadAllText(jsonDir);
            dynamic launchSettings = JObject.Parse(json);
            _context = new StoreClientsContext((string)launchSettings.ConnectionString);
        }

        [TestMethod]
        public void GetCartProductsReturnsUsableQuery()
        {
            //action
            var query = _context.GetCartProducts();
            
            //Assert
            Assert.IsFalse(query.Where(x=> x.Client.ID_Clients == 0).Any());

        }
       
        [TestMethod]
        public void GetOrdersRequestReturnsValidQUery()
        {
            var query = _context.GetOrdersRequest(0);
            Assert.IsTrue(query.Count() == 0);

        }
    }
}
