using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Models.Core;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Repositories.Core
{
    public class CoreRepository<TEntity> : ICoreRepository<TEntity>
        where TEntity : CoreModel
    {
        protected readonly Context _context;
        protected readonly INotifier _notifier;

        public CoreRepository(Context context, INotifier notifier)
        {
            _context = context;
            _notifier = notifier;
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            TEntity entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            _notifier.Add("Registro não encontrado");
            return -1;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await _context
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context
                .Set<TEntity>()
                .AsNoTracking()
                .Where(expression)
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context
                .Set<TEntity>()
                .FindAsync(id);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
