using System.Threading.Tasks;
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

        public async Task DeleteVoterAsync(int id)
        {
            await context.Database.ExecuteSqlInterpolatedAsync($"dbo.sp_DeleteVoter @voterId = {id}");
        }
    }
}
