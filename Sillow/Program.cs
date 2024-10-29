using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Sillow.BLL.Contracts;
using Sillow.BLL.Services;
using Sillow.DAL.Context;
using Sillow.DAL.Interfaces;
using Sillow.DAL.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("SILLOW_DB_CONNECTION")
                       ?? builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<SillowContext>(options =>
    options.UseSqlServer(connectionString));
                         

// Add services to the container.
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();


builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
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


