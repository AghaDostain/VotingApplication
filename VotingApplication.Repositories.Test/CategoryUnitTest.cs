using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingApplication.Data;
using VotingApplication.Entities;
using VotingApplication.Repositories.Implementations;

namespace VotingApplication.Repositories.Test
{
    [TestClass]
    public class CategoryUnitTest
    {
        [TestMethod]
        public async Task CategoryAddTestMethodAsync()
        {
            var context = new DataContext();
            var repository = new CategoryRepository(context);
            var data = new Category
            {
                 Name = "Test"                 
            };
            var response = await repository.AddAsync(data);
            Assert.IsTrue(response != null);
        }
        
        [TestMethod]
        public async Task CategoryGetAllTestMethodAsync()
        {
            var context = new DataContext();
            var repository = new CategoryRepository(context);
            var response = await repository.GetAllAsync();
            Assert.IsTrue(response.Any());
        }

        [TestMethod]
        public async Task CategoryGetSingleTestMethodAsync()
        {
            var context = new DataContext();
            var repository = new CategoryRepository(context);
            var response = await repository.GetByIdAsync(1);
            Assert.IsTrue(response != null);
        }

        [TestMethod]
        public async Task CategoryDeleteSingleTestMethodAsync()
        {
            var context = new DataContext();
            var repository = new CategoryRepository(context);
            await repository.DeleteAsync(1);
            var response = await repository.GetByIdAsync(1);
            Assert.IsTrue(response == null);
        }
    }
}
