using System;
using api.oems.Core.Tutor;
using api.oems.Core;
using api.oems.Persistence;
using api.oems.Persistence.Tutor;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using api.oems.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Reflection;

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
    builder.Services.AddControllers();

    builder.Services.AddDbContext<OemsDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("OemsDbConnection"));
    });


    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IJwtAuthenticationTokenRepository, JwtAuthenticationTokenRepository>();
    builder.Services.AddScoped<IInstituteRepository, InstituteRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<ICategoriesInInstitutesRepository, CategoriesInInstitutesRepository>();
    builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
    builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
    builder.Services.AddScoped<IUserJoinRequestInInstituteRepository, UserJoinRequestInInstituteRepository>();
    builder.Services.AddScoped<IUserWithInstituteRepository, UserWithInstituteRepository>();
    builder.Services.AddScoped<IQuestionSetRepository, QuestionSetRepository>();
    builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
    builder.Services.AddScoped<IQuestionOptionsRepository, QuestionOptionsRepository>();
    builder.Services.AddScoped<ITutorDistrictRepository, TutorDistrictRepository>();
    builder.Services.AddScoped<ITutorAreaRepository, TutorAreaRepository>();

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password = new PasswordOptions()
        {
            RequireDigit = false,
            RequireLowercase = false,
            RequireNonAlphanumeric = false,
            RequireUppercase = false,
            RequiredLength = 6
        };
    }).AddEntityFrameworkStores<OemsDbContext>().AddDefaultTokenProviders();

    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JwtIssuer"],
            ValidAudience = builder.Configuration["JwtAudience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]!))
        };
    });

    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    builder.Services.AddSwaggerGen();

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
    
    app.UseAuthentication()
        .UseAuthorization();
    app.MapControllers();
    app.UseRouting();
    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();

    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "OEMS"); });

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Error occurred in the application startup. Message: {@Message}", e.Message);
    throw new ApplicationException("An application exception occurred at the time of start up");
}
finally
{
    Log.CloseAndFlush();
}