using CompanyApi.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace CompanyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

                Log.Information("Application starting");

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName ?? "Production"}.json", true, true)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddEnvironmentVariables();

                builder.Host.UseSerilog();


                var app = builder.Build();

                app.UseMiddleware<ValidationExceptionMiddleware>();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal("Fatal error!", ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }
    }
}