using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Persistence;
using System.Reflection;
using Modules.Identity.Entities;

namespace Modules.Identity;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterFluentValidation()
            .RegisterIdentityDatabase(configuration);
        return services;
    }
    private static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
    {
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        return services;
    }
    private static IServiceCollection RegisterIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityModuleDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("IdentityModuleDbContext"));
        });

        RegisterIdentity(services);

        MigrateDatabase(services);

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

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<IdentityModuleDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void MigrateDatabase(IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IdentityModuleDbContext>();
        dbContext.Database.Migrate();
    }
}
