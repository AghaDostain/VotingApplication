using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Services.Interfaces
{
    public interface ICandidateManager : IManager<Candidate> 
    {
        Task<bool> AddCandidateToCategory(int candidateId, int categoryId);
    }
}
