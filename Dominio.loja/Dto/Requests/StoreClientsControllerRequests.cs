using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.RequestsStoreClientsControllerRequests;

public record class OrdersRequest(int ClientsId , string Description , List<ClientsProductsCart> CartProducts);
public record class ProductsRequest(int ClientsId , int ProductsId , int Quantity );
