using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class StoreAdminContextTest
    {
        private readonly StoreAdminContext _context;
        public StoreAdminContextTest()
        {
            string dir = Directory.GetCurrentDirectory();
            string jsonDir = dir.Replace("\\Tests.Loja\\bin\\Debug\\net6.0", "") + "\\Api.loja\\appsettings.json";
            string json = File.ReadAllText(jsonDir);
            dynamic launchSettings = JObject.Parse(json);
            //_context = new StoreAdminContext((string)launchSettings.ConnectionString);
        }

    }
}
