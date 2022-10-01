using System.Linq.Expressions;
using MovieRate.Core.Models;

namespace MovieRate.Core.Interfaces;

public interface IGenericRepository<T> where T : BaseModel
{
    Task<T> GetByIdAsync(int id);
    
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, object>>[]? includes = null,
        Expression<Func<T, object>>? orderBy = null, string? orderByType = null);
    
    Task<T> FindAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>>[]? includes = null);
    
    Task<IReadOnlyList<T>> FindAllAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>>[]? includes = null,
        Expression<Func<T, object>>? orderBy = null , string orderByType = "Asc");
    
    Task<T> AddAsync(T entity);

    T Update(T entity);

    void Delete(T entity);
}