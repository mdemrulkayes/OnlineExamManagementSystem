using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SharedKernel.Core;

namespace Modules.Question.Infrastructure.Data.Interceptors;
internal sealed class QuestionModuleUpdateAuditableEntityInterceptor(ITimeProvider timeProvider, IUser user) : SaveChangesInterceptor
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

        var createEntries = context.ChangeTracker.Entries<ICreatedAuditableEntity>()
            .Where(x => x.State == EntityState.Modified);
        foreach (var entry in createEntries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy =
                        user.Id != null ?
                            Guid.Parse(user.Id) :
                            null;
                    entry.Entity.CreatedDate = timeProvider.TimeNow;
                    break;
            }
        }

        var updateEntries = context.ChangeTracker.Entries<IUpdatedAuditableEntity>()
            .Where(x => x.State == EntityState.Modified);
        foreach (var entry in updateEntries)
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


        var deletedEntries = context.ChangeTracker.Entries<IDeletedAuditableEntity>()
            .Where(x => x.State == EntityState.Modified);
        foreach (var entry in deletedEntries)
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.Entity.DeletedBy =
                        user.Id != null ?
                            Guid.Parse(user.Id) :
                            null;
                    entry.Entity.DeletedDate = timeProvider.TimeNow;
                    entry.Entity.IsDeleted = true;
                    break;
            }
        }

    }
}
