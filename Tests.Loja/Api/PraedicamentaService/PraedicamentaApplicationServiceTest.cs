using Api.loja.Contracts;
using Api.loja.Data;
using Api.loja.Service;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.loja.Api.PraedicamentaService
{
    [TestClass]
    public class PraedicamentaApplicationServiceTest
    {
        private readonly PraedicamentaApplicationService _service;
        private readonly StoreContext _context = new();
        private IDbContextTransaction _transaction;
        public PraedicamentaApplicationServiceTest() 
        {
            _service = new(_context);
            _transaction = _context.Database.BeginTransaction();
        }

        
        [TestMethod]
        public void createCategoriesRegisterNewEvent()
        {
            //setup 
            PraedicamentaContract.V1.AddCategories createCategory = new("Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createCategory);
            //Assert
            Assert.IsNotNull(_service.praedicamenta.GetChanges());
            _transaction.Rollback();
        }
        [TestMethod]
        public void createSubCategoriesRegisterNewEvent()
        {
            //setup 
            PraedicamentaContract.V1.AddSubCategories createSubCategory = new(1,"Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createSubCategory);
            //Assert
            Assert.IsNotNull(_service.praedicamenta.GetChanges());
            _transaction.Rollback();
        }
        [TestMethod]
        public void createSubSubCategoriesRegisterNewEvent()
        {
            //setup 
            PraedicamentaContract.V1.AddSubSubCategories createSubSubCategory = new(1,"Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createSubSubCategory);
            //Assert
            Assert.IsNotNull(_service.praedicamenta.GetChanges());
            _transaction.Rollback();
        }
        [TestMethod]
        public void getAllDoesNotBreakApplication()
        {
            var i = _service.GetAll();
            Assert.IsNotNull(i);
        }
    }
}
