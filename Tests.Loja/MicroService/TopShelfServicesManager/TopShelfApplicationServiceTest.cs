using Api.TopShelfServicesManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Api.TopShelfServicesManager.Contracts.TopShelfContract;

namespace Tests.loja.MicroService.TopShelfServicesManager
{
    [TestClass]
    public class TopShelfApplicationServiceTest : Configuration 
    {
        private readonly TopShelfApplicationService _service; 

        public TopShelfApplicationServiceTest():base("MicroServices/Api.TopShelfServicesManager")
        {
            _service = new TopShelfApplicationService(_configuration);
        }
        [TestMethod]
        public void TestSendCommandStartsQuartz()
        {
            var task = _service.Handle(new T1.StartQuartz());
        }
    }
}
