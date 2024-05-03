using Aplication.Mapping;
using Aplication.Services;
using Company.UI.Controllers;
using Domen.Repositories;
using Infrastructure;
using Infrastructure.GenericRepository;
using Infrastructure.Repositories;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.                                      

        //builder.Services.AddScoped<ICompanyService, CompanyService>();


        builder.Services.AddScoped<ConpanyDbContext>();
        builder.Services.AddDbContext<ConpanyDbContext>(options => options.UseNpgsql("Server=localhost;Database=ConpanyDB;Username=postgres;Password=2244;"));
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddControllers();
     //   builder.Services.AddAutoMapper(typeof(MappingProfile));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });

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
    }
}