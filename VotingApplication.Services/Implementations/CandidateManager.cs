using System.Threading.Tasks;
using VotingApplication.Entities;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public class CandidateManager : ManagerBase<Candidate>, ICandidateManager
    {
        private readonly ICandidateRepository CandidateRepository;
        private readonly ICategoryRepository CategoryRepository;

        public CandidateManager(ICategoryRepository categoryRepository, ICandidateRepository repository) : base(repository)
        {
            CategoryRepository = categoryRepository;
            CandidateRepository = repository;
        }

        public async Task<bool> AddCandidateToCategory(int candidateId, int categoryId)
        {
            var isDataUpdated = false;
            var category = await CategoryRepository.GetByIdAsync(categoryId);
            var candidate = await CandidateRepository.GetByIdAsync(candidateId);

            if (category != null && candidate != null)
            {
                candidate.CatergoryId = categoryId;
                await CandidateRepository.UpdateAsync(candidate);
                isDataUpdated = true;
            }

            return isDataUpdated;
        }
    }
}
