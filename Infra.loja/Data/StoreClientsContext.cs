﻿using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public bool PutEditMyProfile(Clients entity)
        {
            clients.Update(entity);
            return SaveChanges() > 0 ? true : false;
        }
        public Clients GetEditMyProfile(string email)
        {
            var query = clients.Where(x => x.Email == email);
            return query.Any() ? query.First() : null; 
        }
        public bool DeleteCartProducts(ClientsProductsCart entity)
        {
            ClientsProductsCart update = entity;
            update.IsActive = false;

            clientsProducts_cart.Update(update);
            try
            {
                return SaveChanges() > 0 ? true : false;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public List<ClientsProductsCart>? GetCartProducts(int ID_Clients)
        {
            var query = clientsProducts_cart.Where(x => x.ID_Clients == ID_Clients && x.IsActive);
            return query.Any() ? query.ToList() : null;
        }
        public object GetOrdersRequest()
        {
            throw new NotImplementedException();
        }

        public object PutCartProducts()
        {
            throw new NotImplementedException();
        }

        public object PutOrdersRequest()
        {
            throw new NotImplementedException();
        }

    }
}
