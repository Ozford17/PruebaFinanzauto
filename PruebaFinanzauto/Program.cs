using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.Data;
using PruebaFinanzauto.Interfaces;
using PruebaFinanzauto.Repository;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
var configu = configuration.Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options => {
    options.UseSqlServer(configu.GetConnectionString("DefaultConnection"));
    options.UseExceptionProcessor();
}
);

builder.Services.AddScoped(typeof(IStudent), typeof(StudentRepository));



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
