using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Sillow.DAL.Context;
using Sillow.DAL.Interfaces;
using Sillow.DAL.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = Environment.GetEnvironmentVariable("SILLOW_DB_CONNECTION")
                       //?? builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<SillowContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
                         

// Add services to the container.
builder.Services.AddScoped<IAdminRepository, AdminRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
bool klk = false;
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SillowContext>();
    if (context.Database.CanConnect())
    {
        klk = true;
    }
    else
    {
        Console.WriteLine("Error");
    }
}

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


