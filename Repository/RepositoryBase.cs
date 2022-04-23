using System.Linq.Expressions;
using Contracts.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
{
    private AppDbContext _context { get; }

    protected RepositoryBase(AppDbContext context) => _context = context;
    
    public async Task<IList<T>> ReadAllAsync(params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().AsQueryable();
        if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
        includeExpressions.ToList().ForEach(x => query = query.Include(x));
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T?> ReadByIdAsync(Guid id, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().AsQueryable();
        if (!includeExpressions.Any()) return await _context.Set<T>().FindAsync(id);
        includeExpressions.ToList().ForEach(x => query = query.Include(x));
        var result = await query.AsNoTracking().ToListAsync();
        return result.FirstOrDefault();
    }

    public async Task<IList<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().Where(expression);
        if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
        includeExpressions.ToList().ForEach(x => query = query.Include(x));
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        await _context.Entry(entity).ReloadAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        await _context.Entry(entity).ReloadAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}