using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.loja.ExtensionMethods;


namespace Tests.loja.FrameworkTest.ExtensionMethodsTest
{
    [TestClass]
    public class EntensionMethodsTest
    {
        public EntensionMethodsTest() { }

        [TestMethod]
        public void VerifyIfAnObject_HasType_WithValue()
        {
            object obj = new { Prop = "Props" };
            bool exists = obj.PropertyValueExists<string>("Prop" , "Props");

            Assert.IsTrue(exists);
        }

    }
}
