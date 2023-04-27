using Serilog.Events;
using Serilog;
using Microsoft.Extensions.Configuration;
using SimpleApiExcercise.Repositories.DAL.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using SimpleApiExcercise.Repositories.Repository;
using SimpleApiExcercise.Services;

var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

// Add services to the container.
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddDbContext<apiexcerciseContext>(Options => {
    Options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Injecting Application Services
builder.Services.AddScoped<DbContext, apiexcerciseContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerService, CustomerService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
