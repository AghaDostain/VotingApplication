using System;
using System.Threading.Tasks;
using VotingApplication.Data;
using VotingApplication.Repositories.Implementations;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Models.Validations.Helper
{
    internal class RepositoryHelper
    {
        private readonly ICandidateRepository CandidateRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IVoterRepository VoterRepository;

        public RepositoryHelper()
        {
            var context = new DataContext();
            CandidateRepository = new CandidateRepository(context);
            CategoryRepository = new CategoryRepository(context);
            VoterRepository = new VoterRepository(context);
        }

        internal async Task<bool> ValidateCandidate(int candidateId)
        {
            var data = await CandidateRepository.GetByIdAsync(candidateId);
            return data != null;
        }

        internal async Task<bool> ValidateCategory(int categoryId)
        {
            var data = await CategoryRepository.GetByIdAsync(categoryId);
            return data != null;
        }
        
        internal async Task<bool> ValidateVoter(int voterId)
        {
            var data = await VoterRepository.GetByIdAsync(voterId);
            return data != null;
        }
    }    
}
