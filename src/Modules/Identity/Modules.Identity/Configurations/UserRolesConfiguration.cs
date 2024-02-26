using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modules.Identity.Constants;

namespace Modules.Identity.Configurations;
internal sealed class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder
            .ToTable("UserRoles")
            .HasKey(x => new
            {
                x.RoleId,
                x.UserId
            });

        builder.HasData(new List<IdentityRole<Guid>> {
            new()
            {
                Id = Guid.NewGuid(),
                Name = RoleConstants.SuperAdmin,
                NormalizedName = "Super Admin"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = RoleConstants.SupportAdmin,
                NormalizedName = "Support Admin"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = RoleConstants.QuizAuthor,
                NormalizedName = "Author"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = RoleConstants.Examine,
                NormalizedName = "Examine"
            }
        });
    }
}