using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieRate.Core.Interfaces;
using MovieRate.Core.Models;
using MovieRate.Infrastructure.Data;
using MovieRate.Infrastructure.Constants;
    
namespace MovieRate.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return (await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id))!;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, object>>[]? includes = null,
        Expression<Func<T, object>>? orderBy = null, string? orderByType = OrderByTypes.Ascending)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (orderBy != null)
        {
            query = orderByType == OrderByTypes.Descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }
        
        return await query.ToListAsync();
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>>[]? includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return (await query.FirstOrDefaultAsync(criteria))!;
    }

    public async Task<IReadOnlyList<T>> FindAllAsync(Expression<Func<T, bool>> criteria,
        Expression<Func<T, object>>[]? includes = null,
        Expression<Func<T, object>>? orderBy = null, string orderByType = OrderByTypes.Ascending)
    {
        IQueryable<T> query = _context.Set<T>();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (orderBy != null)
        {
            query = orderByType == OrderByTypes.Ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
        }
    
        return await query.Where(criteria).ToListAsync();
    }
    
    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}