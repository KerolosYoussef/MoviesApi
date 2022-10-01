using MovieRate.Core.Interfaces;
using MovieRate.Core.Models;
using MovieRate.Infrastructure.Data;
using MovieRate.Infrastructure.Repositories;

namespace MovieRate.API;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IGenericRepository<Genre> GenreRepository { get; }
    public IGenericRepository<Movie> MovieRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        GenreRepository = new GenericRepository<Genre>(_context);
        MovieRepository = new GenericRepository<Movie>(_context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async void Dispose()
    {
        await _context.DisposeAsync();
    }
}