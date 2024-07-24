using System.Reflection;
using Modules.Identity;
using Modules.Quiz.Endpoints;
using Modules.Quiz.Infrastructure;
using Quizzer.Api.Exceptions;
using Quizzer.Api.Extensions;
using Quizzer.Api.Services;
using Serilog;
using Shared.Core;
using Shared.Core.Behaviours;
using Shared.Core.Extensions;
using Shared.Infrastructure;

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

    builder.Services.AddScoped<IUser, CurrentUser>();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    #region Register Modules

    List<Assembly> mediatRAssemblies = [typeof(Quizzer.Api.Program).Assembly];

    builder.Services.RegisterSharedInfrastructureModule();
    builder.Services.RegisterIdentityModule(builder.Configuration, logger, mediatRAssemblies);
    builder.Services.RegisterQuestionModule(builder.Configuration, logger, mediatRAssemblies);

    #endregion

    builder.Services.RegisterEndpoints(mediatRAssemblies);

    //Registering mediatR and pipeline behaviours
    builder.Services.AddMediatR(opt =>
    {
        opt.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray());
    });

    builder.Services.AddMediatRRequestLoggingBehaviour();
    builder.Services.AddMediatRFluentValidationBehaviour(mediatRAssemblies);

    builder.Services.RegisterJwtSwagger();

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
    app.MigrateQuestionModuleDatabase();

    #endregion

    app.UseExceptionHandler();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapEndpoints();

    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "Error occurred in the application startup. Exception: {@Message}", ex.Message);
    throw new ApplicationException("An application exception occurred at the time of start up");
}
finally
{
    Log.CloseAndFlush();
}

namespace Quizzer.Api
{
    public partial class Program; //Add this to manage test
}