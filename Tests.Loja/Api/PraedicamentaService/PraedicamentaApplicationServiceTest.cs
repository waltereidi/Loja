using Api.loja.Data;
using Api.loja.Service;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Api.loja.Contracts.PraedicamentaContract;

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
            V1.Requests.AddCategories createCategory = new("Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createCategory);
            var changes = _service._praedicamenta.GetChanges();
            //Assert

            Assert.IsTrue(changes.Count() > 0);
        }
        [TestMethod]
        public void createSubCategoriesRegisterNewEvent()
        {
            //setup 
            V1.Requests.AddCategories createSubCategory = new("Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);

        }
        [TestMethod]
        public void createSubSubCategoriesRegisterNewEvent()
        {
            //setup 
            V1.Requests.AddSubSubCategories createSubSubCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(createSubSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }

        [TestMethod]
        public void updateCategoriesWork()
        {
            V1.Requests.UpdateCategory updateCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(updateCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }
        [TestMethod]
        public void updateSubCategoriesWork()
        {
            V1.Requests.UpdateSubCategory updateSubCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(updateSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }
        [TestMethod]
        public void updateSubSubCategoriesWork()
        {
            //setup 
            V1.Requests.UpdateSubSubCategory updateSubSubCategory = new(1, "Unit Test Category", "Category created by test unit");
            //action
            _service.Handle(updateSubSubCategory);
            //Assert
            Assert.IsTrue(_service._praedicamenta.GetChanges().Count() > 0);
        }
        [TestMethod]
        public void GetAllSubSubCategories()
        {
            //This ilustruous test assures that a Task<object?> can return IEnumerables<T>
            var result = _service.Handle(new V1.Requests.GetAllSubSubCategories()).Result;
            Assert.IsInstanceOfType( result ,typeof(IEnumerable<V1.GetSubSubCategory>));

        }
        [TestMethod]
        public void GetAllCategories()
        {
            //shows how this endpoint would execute
            var result = _service.Handle(new V1.Requests.GetAllCategories()).Result;
            
            Assert.IsInstanceOfType(result, typeof(IEnumerable<V1.GetAll>));
        }
    }
}
