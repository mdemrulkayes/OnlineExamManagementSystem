using System.Reflection;
using FluentValidation;
using Modules.Identity;
using Modules.Identity.Features.Registration;
using Quizzer.Api.Exceptions;
using Serilog;
using SharedKernel.Core.Behaviours;
using SharedKernel.Infrastructure;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Debug()
    .CreateLogger();

try
{
    logger.Information("Application builder started");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((_, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(builder.Configuration);
    });
    builder.Services.AddEndpointsApiExplorer(); //TODO: Need to replace with FastEndpoints library configuration

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    #region Register Modules

    List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];

    builder.Services.RegisterSharedInfrastructureModule();
    builder.Services.RegisterIdentityModule(builder.Configuration, logger, mediatRAssemblies);

    #endregion

    //Registering mediatR and pipeline behaviours
    builder.Services.AddMediatR(opt =>
    {
        opt.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray());
    });
    builder.Services.AddMediatRRequestLoggingBehaviour();
    builder.Services.AddMediatRFluentValidationBehaviour();

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    #region Modulewise database migration

    app.MigrateIdentityModuleDatabase();

    #endregion

    app.UseExceptionHandler();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    #region Map module routes
    //TODO: Need to replace with FastEndpoint library implementation
    app.MapIdentityRoutes();

    #endregion

    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "Error occurred in the application startup. Message: {@Message}", ex.Message);
    throw new ApplicationException("An application exception occurred at the time of start up");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program; //Add this to manage test