namespace PitochokPlague.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly PitochokPlagueContext _context;

    public UnitOfWork(PitochokPlagueContext context)
    {
        _context = context;
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
}