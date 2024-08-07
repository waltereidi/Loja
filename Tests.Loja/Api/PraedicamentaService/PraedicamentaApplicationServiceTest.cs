﻿using Api.loja.Contracts;
using Api.loja.Data;
using Api.loja.Service;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [TestCleanup]
        public void CleanUp() => _transaction.RollbackAsync();

        [TestMethod]
        public void createCategoriesRegisterNewEvent()
        {
            //setup 
            PraedicamentaContract.V1.AddCategories createCategory = new("Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createCategory);
            var changes = _service._praedicamenta.GetChanges();
            //Assert

            Assert.IsTrue(changes.Count()>0);
        }
        [TestMethod]
        public void createSubCategoriesRegisterNewEvent()
        {
            //setup 
            PraedicamentaContract.V1.AddSubCategories createSubCategory = new(1,"Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
            
        }
        [TestMethod]
        public void createSubSubCategoriesRegisterNewEvent()
        {
            //setup 
            PraedicamentaContract.V1.AddSubSubCategories createSubSubCategory = new(1,"Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createSubSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }

        [TestMethod]
        public void updateCategoriesWork()
        {
            PraedicamentaContract.V1.updateCategory updateCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(updateCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }
        [TestMethod]
        public void updateSubCategoriesWork()
        {
            PraedicamentaContract.V1.updateSubCategory updateSubCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(updateSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }
        [TestMethod]
        public void updateSubSubCategoriesWork()
        {
            //setup 
            PraedicamentaContract.V1.updateSubSubCategory updateSubSubCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(updateSubSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }
    }
}
