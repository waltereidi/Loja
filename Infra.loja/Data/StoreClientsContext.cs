using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.loja.Data
{
    public class StoreClientsContext : DbContext, IStoreClientsContext
    {
        private readonly string _connectionString;
        public StoreClientsContext(DbContextOptions<StoreClientsContext> options) : base(options)
        {

        }
        public StoreClientsContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        private DbSet<Products> products { get; set; } = null;
        private DbSet<ProductsCategories> productsCategories { get; set; } = null;
        private DbSet<ProductsPrices> productsPrices { get; set; } = null;
        private DbSet<ProductsStorage> productsStorage { get; set; } = null;
        private DbSet<Categories> categories { get; set; } = null;
        private DbSet<Prices> prices { get; set; } = null;
        private DbSet<Clients> clients { get; set; } = null;
        private DbSet<ClientsProductsCart> clientsProducts_cart { get; set; } = null;   

        public bool DeleteCartProducts()
        {
            throw new NotImplementedException();
        }

        public object GetCartProducts()
        {
            throw new NotImplementedException();
        }

        public object GetEditMyProfile()
        {
            throw new NotImplementedException();
        }

        public object GetOrdersRequest()
        {
            throw new NotImplementedException();
        }

        public object PutCartProducts()
        {
            throw new NotImplementedException();
        }

        public object PutEditMyProfile()
        {
            throw new NotImplementedException();
        }

        public object PutOrdersRequest()
        {
            throw new NotImplementedException();
        }
    }
}
