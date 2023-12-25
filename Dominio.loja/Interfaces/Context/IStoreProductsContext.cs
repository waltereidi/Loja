using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreProductsContext
    {
        DbSet<Categories> Categories { get; set; } 
        DbSet<Prices> Prices { get; set; }
        DbSet<Products> Products { get; set; }
        

    }
}
