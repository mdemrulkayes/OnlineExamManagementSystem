using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SharedKernel.Core;

namespace Modules.Identity.Persistence.Interceptors;
internal sealed class IdentityModuleUpdateAuditableEntityInterceptor(ITimeProvider timeProvider, IUser user) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateIdentityModuleAuditableEntity(eventData.Context);
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateIdentityModuleAuditableEntity(DbContext context)
    {
        var entries = context.ChangeTracker.Entries<IUpdatedAuditableEntity>()
            .Where(x => x.State == EntityState.Modified);
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.UpdatedBy =
                        user.Id != null ? 
                        Guid.Parse(user.Id) : 
                        null;
                    entry.Entity.UpdatedDate = timeProvider.TimeNow;
                    break;
            }
        }
    }
}
