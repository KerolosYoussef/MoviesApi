using MovieRate.Core.Models;

namespace MovieRate.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<Genre> GenreRepository { get; }
    public IGenericRepository<Movie> MovieRepository { get; }
    Task CompleteAsync();
}