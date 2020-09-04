using Microsoft.EntityFrameworkCore;
using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Repositories.Implementations
{
    public class VoterRepository : GenericRepository<Voter>, IVoterRepository
    {
        public VoterRepository(DbContext context) : base(context)
        {

        }
    }
}
