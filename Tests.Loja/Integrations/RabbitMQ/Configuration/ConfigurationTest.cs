using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.loja.Configuration;

namespace Tests.loja.Integrations.RabbitMQ.Configuration
{
    [TestClass]
    public class ConfigurationTest
    {
        private readonly Configurations _configuration;
        public ConfigurationTest() 
        {
            _configuration = new Configurations();
        }

        [TestMethod]
        public void ConfigurationReturnsDevParameters()
        {
            var config = _configuration._configuration;
            string queueName = config.GetSection("UploadQueue:QueueName").Value;
            Assert.IsTrue(queueName.Contains("Dev" ));
        }
    }
}
