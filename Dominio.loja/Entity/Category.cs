using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class Category : MasterEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

    }


}
