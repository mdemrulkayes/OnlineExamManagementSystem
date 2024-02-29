using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Persistence;
using Modules.Identity.Constants;
using Modules.Identity.Entities;
using Modules.Identity.Features.Registration;
using Microsoft.AspNetCore.Builder;

namespace Modules.Identity;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterIdentityDatabase(configuration)
            .RegisterUserRegistrationServices();
        return services;
    }

    private static IServiceCollection RegisterIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityModuleDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("IdentityModuleDbContext"), optBuilder =>
            {
                optBuilder.EnableRetryOnFailure(10);
                optBuilder.MigrationsHistoryTable(IdentityModuleConstants.MigrationHistoryTableName, IdentityModuleConstants.SchemaName);
                optBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });

        RegisterIdentity(services);
        return services;
    }

    private static void RegisterIdentity(IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.User.RequireUniqueEmail = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<IdentityModuleDbContext>()
            .AddDefaultTokenProviders();
    }

    public static IApplicationBuilder MigrateIdentityModuleDatabase(this IApplicationBuilder app)
    {
        var scopedService = app.ApplicationServices.CreateScope();
        var dbContext = scopedService.ServiceProvider.GetRequiredService<IdentityModuleDbContext>();

        if (dbContext.Database.IsSqlServer())
        {
            dbContext.Database.Migrate();
        }

        return app;
    }
}
