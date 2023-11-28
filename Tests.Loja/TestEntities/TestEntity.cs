using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Loja.Attributes;

namespace Tests.Loja.TestEntities
{
    public class TestEntity
    {
        [Attributes.TestClass("Test")]
        public string param { get; set; }

    }
}
