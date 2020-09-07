using System.Threading.Tasks;
using VotingApplication.Entities;
using VotingApplication.Models.API_Models;

namespace VotingApplication.Services.Interfaces
{
    public interface ICandidateManager : IManager<Candidate> 
    {
        Task<bool> AddCandidateToCategory(int candidateId, int categoryId);
        Task<CandidateVoteInfoVM> GetVotesCountForCandidate(int candidateId);
        Task DeletCandidateAsync(int id);
    }
}
