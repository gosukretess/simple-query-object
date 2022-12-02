using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;
using QueryObjectPatternExamples.Database.EntityFramework;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

namespace QueryObjectPatternExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddControllers();
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            // DAPPER executor
            builder.Services.AddSingleton<IQueryExecutor, QueryExecutor>();


            // EF connection and executor
            var efContextOptions = new DbContextOptionsBuilder<EfContext>().UseSqlServer(config.GetValue<string>("ConnectionString")).Options;
            builder.Services.AddTransient(c => new EfContext(efContextOptions));
            builder.Services.AddSingleton<IEfQueryExecutor, EfQueryExecutor<EfContext>>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
    }
}