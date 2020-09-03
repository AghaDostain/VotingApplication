using System.Collections.Generic;
using System.Threading.Tasks;
using VotingApplication.Common;

namespace VotingApplication.Services.Interfaces
{
    public interface IManager<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAsync(PagingRequest request);
        Task<TEntity> AddAsync(TEntity user);
        Task<TEntity> UpdateAsync(TEntity user);
        Task DeleteAsync(TEntity user);
        Task DeleteAsync(int id);
        Task<List<TEntity>> SearchAsync(SearchRequest request, string includeProperties = "");
    }
}
