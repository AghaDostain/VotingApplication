using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Repositories.Interfaces
{
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
        Task DeleteCandidateAsync(int id);
    }
}
