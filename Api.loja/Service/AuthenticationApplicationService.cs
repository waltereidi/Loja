using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Events.Authentication;
using Framework.loja.Dto.Models;
using Framework.loja.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using NPOI.SS.Formula.Functions;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Reflection.Metadata.Ecma335;

namespace Api.loja.Service
{
    public class AuthenticationApplicationService : IApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _context;
        public AuthenticationApplicationService(IConfiguration configuration ,StoreContext context )
        {
            _configuration = configuration;
            _context = context;
        }
        public Task Handle<T>(T command) where T : class => command switch
        {
             
        };

        public Task<ControllerResponse<T>> HandleCreate<T>(T dataSource) where T : class
        {
            throw new NotImplementedException();
        }

        Task<ControllerResponse<T>> IApplicationService.Handle<T>(T command)
        {
            throw new NotImplementedException();
        }

  
    }
}
