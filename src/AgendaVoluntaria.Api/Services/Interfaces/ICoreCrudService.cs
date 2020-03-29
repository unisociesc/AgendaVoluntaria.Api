using AgendaVoluntaria.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services.Interfaces
{
    public interface ICoreCrudService<TEntity>
        where TEntity : ICoreModel
    {
        Task<int> CreateAsync(TEntity entity);

        Task<int> DeleteAsync(Guid id);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression);

        Task<int> UpdateAsync(TEntity entity);

    }
}
