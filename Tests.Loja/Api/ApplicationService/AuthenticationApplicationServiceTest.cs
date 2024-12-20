﻿
using Api.loja.Contracts;
using Api.loja.Controllers.Admin;
using Api.loja.Data;
using Api.loja.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Reflection;
using Utils.loja.Excel;
using static Tests.loja.Api.ApplicationServiceTest.AuthenticationApplicationServiceTest.ProcessBusinessLogic;


namespace Tests.loja.Api.ApplicationServiceTest
{
    [TestClass]
    public class AuthenticationApplicationServiceTest : Configuration
    {
        private readonly AuthenticationApplicationService _service;
        private readonly AuthenticationController _controller;    
        public AuthenticationApplicationServiceTest() : base("Api.loja")
        {
            _service = new(_configuration , new StoreContext());

            _controller = new AuthenticationController(null , _service );
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";
            _controller.ControllerContext.HttpContext.Connection.RemoteIpAddress = IPAddress.Parse("::1");
        }
        /// <summary>
        /// Integration test
        /// </summary>
        [TestMethod]
        public void TestAuthentication()
        {
            var dto = new AuthenticationContract.V1.Request.LoginRequest("testCase@email.com" , "123" );

            var result = _controller.Login(dto);
            Assert.IsNotNull(result);
        }


        /// <summary>
        /// RANDOM TEST FOR STUDIES, TESTS SHOULD BE DESCRIPTIVE<br></br>
        /// </summary>
        public class SampleEventArgs
        {
            public SampleEventArgs(string text) { Text = text; Console.WriteLine(Text); }
            public string Text { get; } // readonly
        }

        public class Publisher
        {
            // Declare the delegate (if using non-generic pattern).
            public delegate void SampleEventHandler(object sender, SampleEventArgs e);

            // Declare the event.
            public event SampleEventHandler SampleEvent;

            // Wrap the event in a protected virtual method
            // to enable derived classes to raise the event.
            protected virtual void RaiseSampleEvent()
            {
                // Raise the event in a thread-safe manner using the ?. operator.
                SampleEvent?.Invoke(this, new SampleEventArgs("Hello"));
            }
        }


        [TestMethod]
        public void Main()
        {
            var e = new Publisher();
            e.SampleEvent += bl_ProcessCompleted;
            bl_ProcessCompleted(this,new SampleEventArgs( "teste"));

        }

        // event handler
        public void bl_ProcessCompleted(object sender, SampleEventArgs e)
        {
            Console.WriteLine("bl_ProcessCompleted");
        }

        public class ProcessBusinessLogic
        {
            public delegate void Notify();  // delegate

            public event Notify ProcessCompleted; // event

            public void StartProcess()
            {
                Console.WriteLine("Process Started!// Raise the event in a thread-safe manner using the ?. operator.// Raise the event in a thread-safe manner using the ?. operator.");
                // some code here..
                OnProcessCompleted();
            }

            protected virtual void OnProcessCompleted() //protected virtual method
            {
                //if ProcessCompleted is not null then call delegate
                ProcessCompleted?.Invoke();
            }
        }
    }
}
