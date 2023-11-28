using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tests.Loja.TestEntities;


namespace Tests.Loja.Tests
{
    [TestClass]
    public class AttributesTest
    {
        [TestMethod]
        public void testTestClassAttributesCanValidate()
        {
            //Setup
            TestEntity entity = new TestEntity() { param="string"};
            System.Reflection.TypeInfo typeInfo = typeof(TestEntity).GetTypeInfo();
            var attrs = typeInfo.GetCustomAttributes();
            //Assert 
            foreach(var item in attrs)
            {
                var i = item.ToString();
                var k = item.GetType();
                var s = item.TypeId;
                
            }
            
                
            //Action

        }

    }
}
