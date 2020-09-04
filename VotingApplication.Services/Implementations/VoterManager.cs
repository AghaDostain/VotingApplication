using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public class VoterManager : ManagerBase<Voter>, IVoterManager
    {
        private readonly IVoterRepository VoterRepository;

        public VoterManager(IVoterRepository repository) : base(repository)
        {
            VoterRepository = repository;
        }
    }
}
