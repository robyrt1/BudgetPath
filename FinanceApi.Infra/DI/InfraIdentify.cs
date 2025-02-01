using FinanceApi.Application.User.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Users.Port;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Infra.Data.Repositories.Users;
using FinanceApi.Infra.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class InfraIdentify
    {
        public static IServiceCollection AddInfraDepency(IServiceCollection services)
        {
            services.AddTransient<ICryptHash, BCryptPasswordHasher>();
            services.AddTransient<IFirebase, FirebaseService>();


            services.AddAuthorization();
            services.AddScoped<ITokenService, TokenService>();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtSettings:SecretKey")),
                    ValidateIssuer = false,
                   ValidateAudience = false
                };
           });

            return services;
        }
    }
}
