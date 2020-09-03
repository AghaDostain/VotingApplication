using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VotingApplication.Common;
using VotingApplication.Repositories.Interfaces;

namespace VotingApplication.Services.Interfaces
{
    public abstract class ManagerBase<TEntity> : IManager<TEntity>
        where TEntity : class //Entity
    {
        protected readonly IGenericRepository<TEntity> Repository;

        public ManagerBase(IGenericRepository<TEntity> repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<TEntity> AddAsync(TEntity model)
        {
            return await Repository.AddAsync(model);
        }

        public virtual async Task DeleteAsync(TEntity model)
        {
            await Repository.DeleteAsync(model);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAsync(PagingRequest request)
        {
            request = request != null ? request : new PagingRequest();
            return  await GetInternalAsync(request);
        }

        protected virtual async Task<List<TEntity>> GetInternalAsync(PagingRequest request)
        {
            //Build the filter expression
            //var lambda = request.Filters == null ? null : request.Filters.BuildFiltersLambda<TEntity>();
            Expression<Func<TEntity, bool>> lambda = null;
            var data = await Repository.FindAsync(lambda, request.Sort, request.Page, request.PageSize);
            return data;
        }

        public virtual async Task<List<TEntity>> SearchAsync(SearchRequest request, string includeProperties = "")
        {
            var lambda = BuildFilters(request.Filters);
            return await Repository.FindAsync(lambda, request.Sort, request.Page, request.PageSize, includeProperties);
        }

        public virtual Expression<Func<TEntity, bool>> BuildFilters(IList<FilterInfo> filters)
        {
            if (filters != null)
            {
                return filters.BuildFiltersLambda<TEntity>();
            }
            return null;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity model)
        {
            return await Repository.UpdateAsync(model, key => (int)key.GetType().GetProperty("Id").GetValue(key) == (int)model.GetType().GetProperty("Id").GetValue(model));
        }
    }
}
