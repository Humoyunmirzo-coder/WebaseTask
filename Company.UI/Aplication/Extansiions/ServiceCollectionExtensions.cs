﻿using Aplication.Services;
using Aplication.Services.Token;
using Aplication.Services.UserServices;
using Aplication.Servises;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Aplication.Extansiions
{
    public static class ServiceCollectionExtensions
    {
        private static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var signingKey = Encoding.UTF32.GetBytes(configuration.GetSection("JwtOptions:SignIngKey").Value);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration.GetSection("JwtOptions:ValidIssuer").Value,
                    ValidAudience = configuration.GetSection("JwtOptions:ValidAudience").Value,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = async context =>
                    {
                        if (string.IsNullOrEmpty(context.Token))
                        {
                            //agar requestni headerida 'Authorization'
                            //nomi bilan token junatilmasa
                            //tokenni requestni querysidan
                            //olish

                            //barcha routelar uchun
                            var accessToken = context.Request.Query["token"];
                            context.Token = accessToken;

                            // faqat 'hubs' bilan boshlangan routelar uchun
                            /*var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/hubs"))
                            {
                                context.Token = accessToken;
                            }*/
                        }
                    }
                };
            });


        }
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwt(configuration);

            services.AddScoped< ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService >();
        }
    }
}

