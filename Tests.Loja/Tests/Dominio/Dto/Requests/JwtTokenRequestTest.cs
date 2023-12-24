using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.loja.DTO.Requests;
using Dominio.loja.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Loja.Tests.Dominio.Dto.Requests
{
    [TestClass]
    public class JwtTokenRequestTest
    {
        private readonly LoginRequest _entity;
        public JwtTokenRequestTest()
        {
            _entity = new LoginRequest
            {
                Login = "testCase@email.com",
                Password = "123",
                jwtKey = "YourSecretKeyForAuthenticationOfApplication",
                issuer = "youtCompanyIssuer.com",
                Clients = new Clients
                {
                    Email = "testCase@email.com",
                    Password = "123"
                }
            };

        }

        [TestMethod]
        public void getTokenReturnsToken()
        {
            var token = _entity.GetToken();
            Assert.IsTrue(token.Length > 0);
        }
        [TestMethod]
        public void getTokenIncorrectUserReturnsNull()
        {
            _entity.Clients.Email = "testCase";
            var token = _entity.GetToken();
            Assert.IsNull(token);
        }
        [TestMethod]
        public void getAccessNullClientReturnsNull()
        {
            _entity.Clients = null;
            var token = _entity.GetToken();
            Assert.IsNull(token);
        }


    }
}
