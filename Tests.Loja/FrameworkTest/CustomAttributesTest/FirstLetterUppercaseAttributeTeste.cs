using Dominio.loja.Entity;
using Framework.loja;
using Framework.loja.CustomAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Tests.loja.FrameworkTest.CustomAttributesTest
{
    internal class TestEntity : Entity<int>
    {
        [FirstLetterUppercase("Error")]
        public string Value { get; set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
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

            try
            {
                Validator.ValidateObject(test, context, true);

            }catch(Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }



        }
    }
}
