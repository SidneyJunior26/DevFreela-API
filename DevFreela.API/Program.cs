using DevFreela.API.Models;
using DevFreela.Application.Commands.Project.CreateProject;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

var serverVersion = new MariaDbServerVersion(new Version(10, 4, 12));
var connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<DevFreelaDbContext>(
    options => options.UseMySql(connectionString, serverVersion), optionsLifetime: ServiceLifetime.Singleton);

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateProjectCommand));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
