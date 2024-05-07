using Api.loja.Contracts;
using Api.loja.Data;
using Api.loja.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.loja.Api.ApplicationServiceTest
{
    [TestClass]
    public class AuthenticationApplicationServiceTest : Configuration
    {
        private readonly AuthenticationApplicationService _service;
        public AuthenticationApplicationServiceTest() : base("Api.loja")
        {
            _service = new(_configuration , new StoreContext());
        }
        [TestMethod]
        public void LoginRequest_Executes()
        {
            var request = new AuthenticationContract.V1.LoginRequest("testCase@email.com" , "123");
            _service.Handle(request);
            var login = _service._auth;
            Assert.IsNotNull(login.loginAdmin.Token);
            
        }
    }
}
