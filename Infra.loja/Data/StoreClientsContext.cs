using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        private DbSet<RequestOrders> requestOrders { get; set; } = null;
        private DbSet<RequestOrdersClientsProductsCart> requestOrdersClientsProductsCart { get; set; } = null;



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
        public bool DeleteCartProducts(int ID_ClientsProductsCart )
        {
            try
            {
                IQueryable<ClientsProductsCart> clientsProductsCart = clientsProducts_cart.Where(x => x.ID_Products == ID_ClientsProductsCart);
                
                if (clientsProductsCart.Any() )
                {
                    ClientsProductsCart update = clientsProductsCart.First();
                    update.IsActive = false;
                    clientsProducts_cart.Update(update);
                    return SaveChanges() > 0 ? true : false;
                }
                
                return false;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }
        public bool ChangeAmountCartProduct(int ID_ClientsProductsCart, int quantity)
        {
            try
            {
                ClientsProductsCart clientsProductsCart = clientsProducts_cart.First(x => x.ID_Products == ID_ClientsProductsCart);
                if (clientsProductsCart != null)
                {
                    clientsProductsCart.Quantity = quantity;
                    clientsProducts_cart.Update(clientsProductsCart);
                    return SaveChanges() > 0 ? true : false;
                }

                return false;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public List<ClientsProductsCart>? GetCartProducts(int ID_Clients)
        {
            var query = from cli in clients
                        join cpc in clientsProducts_cart on cli.ID_Clients equals cpc.ID_ClientsProducts_Cart
                        join prd in products on cpc.ID_Products equals prd.ID_Products
                        where cli.ID_Clients == ID_Clients
                        select new ClientsProductsCart()
                        {
                            Created_at = cpc.Created_at,
                            Updated_at = cpc.Updated_at,
                            Client = cli,
                            Product = prd,
                            IsActive = cpc.IsActive,
                            Quantity = cpc.Quantity
                        };
                        
            return query.Any() ? query.ToList() : null;
        }
        public List<RequestOrdersClientsProductsCart> GetOrdersRequest(int ID_Clients)
        {
            var query = from cli in clients
                        join cap in clientsProducts_cart on cli.ID_Clients equals cap.ID_Clients
                        join rcpc in requestOrdersClientsProductsCart on cap.ID_ClientsProducts_Cart equals rcpc.ID_ClientsProducts_Cart
                        join req in requestOrders on rcpc.ID_RequestOrders equals req.ID_RequestOrders
                        where cli.ID_Clients == ID_Clients
                        select new RequestOrdersClientsProductsCart()
                        {
                            ID_RequestOrders_clientsProducts_Cart = rcpc.ID_RequestOrders_clientsProducts_Cart,
                            Created_at = rcpc.Created_at,
                            Updated_at = rcpc.Updated_at,
                            RequestOrders = req,
                            ClientsProductCart = cap
                        };
            return query.Any() ? query.ToList() : null;

        }

        public bool PutCartProducts(int ID_Products, int ID_Clients , int quantity)
        {
            var  query = from cli in clients 
                         join prd in products on cli.

        }

        public bool PutOrdersRequest(RequestOrders request)
        {
            throw new NotImplementedException();
        }
       
            
    }
}
