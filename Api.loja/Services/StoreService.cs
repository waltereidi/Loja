﻿using Api.loja.Data;
using Dominio.loja.Interfaces.Context;

namespace Api.loja.Services
{
    public class StoreService 
    {
        IStoreControllerContext _context;
        public StoreService( StoreContext context )
        {
            _context = context;
        }


    }
}
