using Aplication.Mapping;
using Company.UI.Extensions;
using Aplication.Services.EmployeeServices;
using Aplication.Services.OrganizationServices;
using Aplication.Services.ProjectServices;
using Aplication.Services.ReportServices;
using Aplication.Services.RoleServices;
using Aplication.Services.TaskServices;
using Aplication.Services.UserServices;
using Aplication.Servises;
using Domen.Repositories;
using Infrastructure;
using Infrastructure.GenericRepository;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Aplication.Services.Excel;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<ConpanyDbContext>();
        builder.Services.AddDbContext<ConpanyDbContext>(options => options.UseNpgsql("Server=localhost;Database=ConpanyDB;Username=postgres;Password=2244;"));

        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IOrganizationService, OrganizationService>();
        builder.Services.AddScoped<IProjectService, ProjectService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<ITaskService, TaskService>();
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();
        builder.Services.AddScoped<IOrganizationRepasitory, OrganizationRepasitory>();
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
        builder.Services.AddScoped<IReportService, ReportService>();    

        builder.Services.AddHttpClient<IPersonService, PersonService>();



        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddIdentityService(builder.Configuration);


        builder.Services.AddControllers();



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

        app.UseRouting();
        
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}