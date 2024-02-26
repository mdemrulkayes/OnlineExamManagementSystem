using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
                Name = "SuperAdmin",
                NormalizedName = "Super Admin"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "SupportAdmin",
                NormalizedName = "Support Admin"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "QuizAuthor",
                NormalizedName = "Author"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Examine",
                NormalizedName = "Examine"
            }
        });
    }
}