using Api.loja.Data;
using Dominio.loja.Interfaces.Context;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.Infra
{
    [TestClass]
    public class StoreContextTest
    {
        IStoreContext _storeContext;
        public StoreContextTest() 
        {
            _storeContext = new StoreContext();
        }

        [TestMethod]
        public void DbSetPermissionsReturnDataSet()
        {

        }

    }
}
