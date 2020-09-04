using System.Linq;
using System.Threading.Tasks;
using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public class VoteManager : ManagerBase<Vote>, IVoteManager
    {
        private readonly IVoteRepository VoteRepository;
        private readonly ICandidateRepository CandidateRepository;
        private readonly IVoterRepository VoterRepository;
        private readonly ICategoryRepository CategoryRepository;

        public VoteManager(ICandidateRepository candidateRepository, IVoterRepository voterRepository, ICategoryRepository categoryRepository, IVoteRepository repository) : base(repository)
        {
            CandidateRepository = candidateRepository;
            CategoryRepository = categoryRepository;
            VoterRepository = voterRepository;
            VoteRepository = repository;
        }

        public async Task<bool> CastVote(int candidateId, int categoryId, int voterId)
        {
            bool isVoteCasted = false;
            var voter = await VoterRepository.GetByIdAsync(voterId);
            var candidate = await CandidateRepository.GetByIdAsync(candidateId);
            var category = await CategoryRepository.GetByIdAsync(categoryId);

            if (voter != null && candidate != null && category != null)
            {
                var vote = await VoteRepository.FindAsync(s => s.CategoryId == categoryId && s.VoterId == voterId);

                // Check to verify if voter has already casted vote for category   
                if (!vote.Any())
                {
                    var newVote = new Vote { VoterId = voterId, CategoryId = categoryId, CandidateId = candidateId };
                    var data = await VoteRepository.AddAsync(newVote);
                    isVoteCasted = true;
                }
            }

            return isVoteCasted;
        }
    }
}
