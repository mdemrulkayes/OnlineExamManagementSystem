using Modules.Identity;
using Quizzer.Api.Exceptions;
using Serilog;
using SharedKernel.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((_, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(builder.Configuration);
    });

    builder.Services.AddFluentValidationAutoValidation(opt =>
    {
        opt.DisableDataAnnotationsValidation = true;
    });
    ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
    ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();

    builder.Services.Configure<ApiBehaviorOptions>(options =>
        options.SuppressModelStateInvalidFilter = true);

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    #region Register Modules

    builder.Services.RegisterSharedInfrastructureModule();
    builder.Services.RegisterIdentityModule(builder.Configuration);

    #endregion

    builder.Services.AddEndpointsApiExplorer();
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
    Log.Fatal(ex, "Error occurred in the application startup. Message: {@Message}", ex.Message);
    throw new ApplicationException("An application exception occurred at the time of start up");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program; //Add this to manage test