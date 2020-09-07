using System;
using System.Threading.Tasks;
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

        public async Task DeleteVoterAsync(int id)
        {
            await VoterRepository.DeleteVoterAsync(id);
        }

        public async Task<bool> UpdateVoterInfo(int voterId, DateTime dob)
        {
            var isVoteUpdated = false;
            var voter = await VoterRepository.GetByIdAsync(voterId);

            if (voter != null)
            {
                voter.DOB = dob;
                await VoterRepository.UpdateAsync(voter);
                isVoteUpdated = true;
            }

            return isVoteUpdated;
        }
    }
}
