using Aplication.Mapping;
using Aplication.Extansiions;
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
using Aplication.Servises;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;


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


       
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer(); 
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "JWT Bearer. : \"Authorization: Bearer { token }\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });



            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
        });

        builder.Services.AddIdentity(builder.Configuration);



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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}