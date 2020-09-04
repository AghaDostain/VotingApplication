using Microsoft.EntityFrameworkCore;
using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Repositories.Implementations
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(DbContext context) : base(context)
        {

        }
    }
}
