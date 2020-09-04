﻿using System.Threading.Tasks;
using VotingApplication.Entities;
using VotingApplication.Models.API_Models;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public class CandidateManager : ManagerBase<Candidate>, ICandidateManager
    {
        private readonly ICandidateRepository CandidateRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IVoteRepository VoteRepository;

        public CandidateManager(ICategoryRepository categoryRepository, IVoteRepository voteRepository, ICandidateRepository repository) : base(repository)
        {
            CategoryRepository = categoryRepository;
            CandidateRepository = repository;
            VoteRepository = voteRepository;
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

        public async Task<CandidateVoteInfoVM> GetVotesCountForCandidate(int candidateId)
        {
            var result = new CandidateVoteInfoVM { CandidateId = candidateId, VoteCount = 0 };
            var data = await VoteRepository.FindAsync(s => s.CandidateId == candidateId);
            result.VoteCount = data.Count;
            return result;
        }
    }
}
