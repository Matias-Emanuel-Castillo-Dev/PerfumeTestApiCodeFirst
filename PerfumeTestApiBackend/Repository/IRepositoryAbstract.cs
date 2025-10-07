using PerfumeTestApiBackend.Models;
using System.Linq.Expressions;

namespace PerfumeTestApiBackend.Repository
{
    public interface IRepositoryAbstract<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector);
        Task<TResult?> GetByIdAsync<TResult>(int id, Expression<Func<TEntity, TResult>> selector);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}