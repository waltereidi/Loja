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
            TestEntity entity = new TestEntity() { param="string",param2 ="teste",param3="test4",param4="sss" };
            
            System.Reflection.TypeInfo typeInfo = typeof(TestEntity).GetTypeInfo();


            //Assert 
            var Return = entity.GetAttribute();
            Assert.IsTrue( Return.Count()>0 );


        }

    }
}
