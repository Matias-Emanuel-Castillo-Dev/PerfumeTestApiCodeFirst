using Microsoft.EntityFrameworkCore;
using PerfumeTestApiBackend.Models;
using System.Linq.Expressions;

namespace PerfumeTestApiBackend.Repository
{
    public abstract class RepositoryAbstract<TEntity,TContext>
        where TEntity : BaseModel
        where TContext: DbContext
    {
        protected readonly TContext _context;

        protected RepositoryAbstract(TContext context)
        {
            _context = context;
        }
           

        //VERSIÓN OPTIMIZADA - No usa Includes, solo Select
        protected virtual IQueryable<TResult> ProjectToOptimized<TResult>(
            Expression<Func<TEntity, TResult>> selector)
        {
            //Directamente aplica el SELECT sin Includes previos
        return _context.Set<TEntity>().Select(selector);
        }

        protected virtual async Task<TResult?> GetEntityWithFilter<TResult>(
        Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TResult>> selector)
        {
            return await _context.Set<TEntity>()
                .Where(filter)
                .Select(selector)
                .FirstOrDefaultAsync();
        }


        public virtual async Task<IEnumerable<TResult>> GetAllAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector)
        {
            return await ProjectToOptimized(selector).ToListAsync();
        }

        public virtual async Task<TResult?> GetByIdAsync<TResult>(
            int id,
            Expression<Func<TEntity, TResult>> selector)
        {
            return await ProjectToOptimized(selector)
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity?> DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;

        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            try
            {
                var res = await _context.Set<TEntity>().FindAsync(entity.Id);
                if (res != null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return entity;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
