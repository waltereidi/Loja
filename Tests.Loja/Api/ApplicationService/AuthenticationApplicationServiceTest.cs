﻿
using Api.loja.Contracts;
using Api.loja.Controllers.Admin;
using Api.loja.Data;
using Api.loja.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Utils.loja.Excel;


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

      

    }
}
