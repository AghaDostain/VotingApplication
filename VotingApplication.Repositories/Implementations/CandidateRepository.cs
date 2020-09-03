using Microsoft.EntityFrameworkCore;
using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Repositories.Implementations
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(DbContext context) : base(context)
        {

        }
    }
}
