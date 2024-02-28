using Modules.Identity;
using Quizzer.Api.Exceptions;
using Serilog;
using Serilog.Events;
using SharedKernel.Infrastructure;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config.GetSection("Serilog"))
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    builder.Services.RegisterSharedInfrastructure();

    builder.Services.RegisterIdentityModule(builder.Configuration);

    var app = builder.Build();

    app.UseSerilogRequestLogging(options =>
    {
        // Customize the message template
        options.MessageTemplate = "Handled {RequestPath}";

        // Emit debug-level events instead of the defaults
        options.GetLevel = (_, _, _) => LogEventLevel.Debug;

        // Attach additional properties to the request completion event
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        };
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MigrateIdentityModuleDatabase();
    app.UseExceptionHandler();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHttpsRedirection();

    app.MapIdentityRoutes();

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

public partial class Program;