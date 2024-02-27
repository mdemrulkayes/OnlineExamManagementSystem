using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Modules.Identity.Constants;

namespace Modules.Identity.Configurations;
internal sealed class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder
            .ToTable("Roles")
            .HasKey(x => x.Id);

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