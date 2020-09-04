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
        public async Task CategoryUpdateTestMethodAsync()
        {
            var context = new DataContext();
            var repository = new CategoryRepository(context);
            var data = await repository.GetAllAsync();

            if (data.Any())
            {
                var firstData = data.FirstOrDefault();
                firstData.Name = "Update Test";
                var response = await repository.UpdateAsync(firstData);
                Assert.IsTrue(response != null);
            }

            Assert.IsTrue(true);
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
            var data = await repository.GetAllAsync();
            
            if (data.Any())
            {
                var response = await repository.GetByIdAsync(data.FirstOrDefault().Id);
                Assert.IsTrue(response != null);
            }

            Assert.IsTrue(true);
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
