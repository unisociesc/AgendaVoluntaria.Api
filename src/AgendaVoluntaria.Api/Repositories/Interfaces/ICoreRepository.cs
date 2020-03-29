using AgendaVoluntaria.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories.Interfaces
{
    public interface ICoreRepository<TEntity>
        where TEntity : ICoreModel
    {
        Task<int> CreateAsync(TEntity entity);

        Task<int> DeleteAsync(Guid id);

        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(Guid id);


        Task<int> UpdateAsync(TEntity entity);
    }
}
