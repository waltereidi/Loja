using Framework.loja;
using Framework.loja.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests.loja.FrameworkTest.CustomAttributesTest
{
    public class TestEntity
    {
        [FirstLetterUppercase]
        public string Value { get; set; }
    }

    [TestClass]
    public class FirstLetterUppercaseAttributeTeste
    {

        [TestMethod]
        public void ReturnsFirstLetterUpperCased()
        {
            TestEntity test = new()
            {
                Value = "test"
            };
            var context = new ValidationContext(test);
            Validator.ValidateObject(test, context);

            Assert.AreEqual("Test", test.Value);
        }
    }
}
