using System;
using System.Linq;
using System.Threading.Tasks;
using VotingApplication.Data;
using VotingApplication.Repositories.Implementations;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Models.Validations.Helper
{
    internal class RepositoryHelper
    {
        private readonly DataContext dbContext;

        public RepositoryHelper()
        {
            dbContext = new DataContext();
        }

        internal bool ValidateCandidate(int candidateId)
        {
            var data = dbContext.Candidates.Where(s => s.Id == candidateId).FirstOrDefault();
            return data != null;
        }

        internal bool ValidateCandidateCategory(int candidateId, int categoryId)
        {
            var data = dbContext.Candidates.Where(s => s.Id == candidateId).FirstOrDefault();
            return data != null && data.CatergoryId == categoryId;
        }

        internal bool ValidateCategory(int categoryId)
        {
            var data = dbContext.Categories.Where(s => s.Id == categoryId).FirstOrDefault();
            return data != null;
        }

        internal bool ValidateCategoryNameExistence(string categoryName)
        {
            var data = dbContext.Categories.Where(s => s.Name == categoryName).FirstOrDefault();
            return data != null;
        }

        internal bool ValidateCandidateNameExistence(string categoryName)
        {
            var data = dbContext.Candidates.Where(s => s.Name == categoryName).FirstOrDefault();
            return data != null;
        }

        internal bool ValidateVoter(int voterId)
        {
            var data = dbContext.Voters.Where(s => s.Id == voterId).FirstOrDefault();
            return data != null;
        }
    }
}
