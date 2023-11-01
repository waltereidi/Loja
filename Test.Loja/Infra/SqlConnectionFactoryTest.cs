using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infra.loja;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Test.Loja.Infra
{
    [TestClass]
    public class SqlConnectionFactoryTest
    {


        public SqlConnectionFactoryTest()
        {
        }

        [TestMethod]
        public void OpenConnectionReturnsConnection()
        {
            String dir = System.IO.Directory.GetCurrentDirectory();
            string jsonDir = dir.Replace("\\Test.Loja\\bin\\Debug\\net6.0", "") + "\\Api.loja\\appsettings.json";
            string json = File.ReadAllText(jsonDir);
            dynamic launchSettings = JObject.Parse(json);
            
            var sqlConnectionFactory = new SqlConnectionFactory((string)launchSettings.ConnectionString );
            Assert.IsNotNull(sqlConnectionFactory);

        }
    }
}
