using ElevatorAppServices.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using ElevatorAppServices.Implementations;
using Serilog;
using ElevatorAppData.Models;
using Microsoft.EntityFrameworkCore;
using Elevator.App.Models.MappingProfiles;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<ElevatorSystemContext>(options =>
            options.UseSqlServer(
                           builder.Configuration.GetConnectionString("ElevatorSystemDB"),
                           b => b.MigrationsAssembly(typeof(ElevatorSystemContext).Assembly.FullName)));
        builder.Services.AddScoped(sp => new HttpClient());

        builder.Services.AddScoped<ILimitCheckService, LimitCheckService>();

        builder.Services.AddAutoMapper(typeof(ElevatorMappingProfiles).Assembly);
        var logger = new LoggerConfiguration()
                     .Enrich.FromLogContext()
                     .WriteTo.RollingFile("./Logs/log-{Date}.txt")
                     .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(x => x
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true) // allow any origin
                        .AllowCredentials()); // allow credentials
        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}