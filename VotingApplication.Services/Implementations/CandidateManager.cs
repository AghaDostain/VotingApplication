using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public class CandidateManager : ManagerBase<Candidate>, ICandidateManager
    {
        private readonly ICandidateRepository CandidateRepository;

        public CandidateManager(ICandidateRepository repository) : base(repository)
        {

        }
    }
}
