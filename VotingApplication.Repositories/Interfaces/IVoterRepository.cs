using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Repositories.Interfaces
{
    public interface IVoterRepository : IGenericRepository<Voter>
    {
        Task DeleteVoterAsync(int id);
    }
}
