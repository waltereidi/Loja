using Api.ServicesManager.Interfaces;
using Api.ServicesManager.MicroService;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.loja.MicroService.MicroServicesManager
{
    [TestClass]
    public class HostedServicesTest
    {
        private readonly IHostedServices _service;
        public HostedServicesTest() 
        {
            _service = new HostedServices();
        }

        [TestMethod]
        public void HostedServicesUpdateServicesState_EnableAll()
        {
            //After services get started , its current state need to be uploaded 
            //isRunning should be set to the last successfull change
            Task.Run(async () =>
            {
                await _service.EnableAllServices();
            }).ContinueWith(_ =>
            {
                var servicesList = _service.GetAllServicesState().Result;
                Assert.IsFalse(servicesList.Any(x => x.IsRunning != false));
            });
            
        }
        [TestMethod]
        public void HostedServicesUpdateServicesState_DisableAll()
        {
            //After services get started , its current state need to be uploaded 
            //isRunning should be set to the last successfull change
            Task.Run(async () =>
            {
                await _service.EnableAllServices();
                await _service.DisableAllServices();
            }).ContinueWith(_ =>
            {
                var servicesList = _service.GetAllServicesState().Result;
                Assert.IsFalse(servicesList.Any(x => x.IsRunning == false));
            });
            
        }

    }
}
