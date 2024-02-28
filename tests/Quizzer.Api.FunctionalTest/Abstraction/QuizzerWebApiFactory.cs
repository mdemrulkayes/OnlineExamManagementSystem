﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Persistence;
using Testcontainers.MsSql;

namespace Quizzer.Api.FunctionalTest.Abstraction;
public class QuizzerWebApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{

    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithPassword("Pass@word")
        .Build();
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var cs = new SqlConnectionStringBuilder(_msSqlContainer.GetConnectionString())
        {
            InitialCatalog = "Quizzer"
        }.ToString();
        builder.ConfigureServices(services =>
        {
            var descriptorType =
                typeof(DbContextOptions<IdentityModuleDbContext>);

            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == descriptorType);

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }
            services.AddDbContext<IdentityModuleDbContext>(opt =>
            {
                opt.UseSqlServer(cs);
            });
        });
    }

    public Task InitializeAsync()
    {
        return _msSqlContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        _msSqlContainer.StopAsync();
        return _msSqlContainer.DisposeAsync().AsTask();
    }
}
