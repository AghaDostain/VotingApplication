using System.Threading.Tasks;
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

        public async Task DeleteCandidateAsync(int id)
        {
            await context.Database.ExecuteSqlInterpolatedAsync($"dbo.sp_DeleteCandidate @candidateId = {id}");
        }
    }
}
