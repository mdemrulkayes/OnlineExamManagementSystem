using Microsoft.EntityFrameworkCore;
using SharedKernel.Core;

namespace SharedKernel.Infrastructure;
internal class UnitOfWork(DbContext dbContext) : IUnitOfWork
{
    private bool _disposed;
    
    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        var itemSaved = await dbContext.SaveChangesAsync(cancellationToken);
        return itemSaved;
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                dbContext.Dispose();
        _disposed = true;
    }
}
