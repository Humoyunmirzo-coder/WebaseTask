using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Options;
using Aplication.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Company.UI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = @"JWT Bearer. : Authorization: Bearer {token}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                    new List<string>(){}
                }
            });
        });
    }

    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)

    {
        services.Configure<JwtOption>(configuration.GetSection("JwtBearer"));

        services.AddSingleton(_ => new SymmetricSecurityKey(Encoding.UTF32.GetBytes(configuration["JwtBearer:SigningKey"])));
        
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {

            var signingKey = Encoding.UTF32.GetBytes(configuration["JwtBearer:SigningKey"]!);
            
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = configuration["JwtBearer:ValidIssuer"],
                ValidAudience = configuration["JwtBearer:ValidAudience"],
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = services.BuildServiceProvider().GetRequiredService<SymmetricSecurityKey>(),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwt(configuration);
        services.AddSwaggerGen();

        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<JwtOption>();
    }
}
