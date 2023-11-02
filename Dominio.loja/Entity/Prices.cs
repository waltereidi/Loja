using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class Prices : MasterEntity
    {
        public SqlMoney Price { get; set; }
        public string Description { get; set; }
    }
}
