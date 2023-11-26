using Api.loja.Data;
using Castle.Core.Configuration;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
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
    public class StoreContextTest
    {
        private StoreContext _storeContext;
        
        public StoreContextTest() 
        {
            String dir = System.IO.Directory.GetCurrentDirectory();
            string jsonDir = dir.Replace("\\Tests.Loja\\bin\\Debug\\net6.0", "") + "\\Api.loja\\appsettings.json";
            string json = File.ReadAllText(jsonDir);
            dynamic launchSettings = JObject.Parse(json);
            _storeContext = new StoreContext((string)launchSettings.ConnectionString);
        }

        [TestMethod]
        public void DbSetPermissionsReturnDataSet()
        {
            //setup 
            
            //action
            _storeContext.GetPermissionsRelation("TestCase");
            
            //assert 
            Assert.IsTrue(ClientsPermission.permissionsList.Count() > 0);
            
        }

    }
}
