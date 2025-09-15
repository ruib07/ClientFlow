using Asp.Versioning;
using ClientFlow.API.Configurations;
using ClientFlow.Application.Constants;
using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Application.Services;
using ClientFlow.Infrastructure.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomDatabaseConfiguration(builder.Configuration);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IInteractionRepository, InteractionRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IInteractionsService, InteractionsService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(ApiConstants.AllowLocalhost,
        builder =>
        {
            builder.WithOrigins(ApiConstants.ClientOrigin)
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetPreflightMaxAge(TimeSpan.FromMinutes(10));
        });
});

var app = builder.Build();

app.UseCors(ApiConstants.AllowLocalhost);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
