using Microsoft.EntityFrameworkCore;
using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
