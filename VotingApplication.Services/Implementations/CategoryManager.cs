using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public class CategoryManager : ManagerBase<Category>, ICategoryManager
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
            CategoryRepository = repository;
        }
    }
}
