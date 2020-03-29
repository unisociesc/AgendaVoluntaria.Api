using AgendaVoluntaria.Api.Models.Core;
using AgendaVoluntaria.Api.Models.Interfaces;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Core
{
    public class CoreCrudService<TEntity, TRepository> : ICoreCrudService<TEntity>
        where TEntity : CoreModel
        where TRepository : ICoreRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly INotifier _notifier;

        public CoreCrudService(INotifier notifier, TRepository repository)
        {
            _notifier = notifier;
            _repository = repository;
        }
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IList<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.GetByAsync(expression);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
