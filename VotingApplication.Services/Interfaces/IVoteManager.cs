using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Services.Interfaces
{
    public interface IVoteManager : IManager<Vote>
    {
        Task<bool> CastVote(int candidateId, int categoryId, int voterId);
    }
}
