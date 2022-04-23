using System.Linq.Expressions;

namespace Contracts.Repositories;

public interface IRepositoryBase<T>
{
    Task<IList<T>> ReadAllAsync(params Expression<Func<T, Object>>[] includeExpressions);
    
    Task<IList<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, Object>>[] includeExpressions);
    
    Task<T> CreateAsync(T entity);
    
    Task<T> UpdateAsync(T entity);
    
    Task<bool> DeleteAsync(T entity);
}