namespace PitochokPlague.Infrastructure;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
}