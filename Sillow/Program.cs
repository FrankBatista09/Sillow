using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Sillow.DAL.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SillowContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SillowContext>();
    if (context.Database.CanConnect())
    {
        Console.WriteLine("Conexion exitosa");
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


