using FinanceApi.Domain.Categories;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Infra.Persistence;
using FinanceApi.Infra.Services;
using FinanceApi.Infra.Shared.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.ModelBuilder;
using System.Text;

namespace FinanceApi.Infra.DI
{
    public static class InfraIdentify
    {
        public static IServiceCollection AddInfraDepency(IServiceCollection services)
        {
            services.AddTransient<ICryptHash, BCryptPasswordHasher>();
            services.AddTransient<IFirebase, FirebaseService>();

            services.AddScoped(typeof(IQueriesRepositoryBase<>), typeof(QueriesRepositoryBase<>));
            services.AddScoped(typeof(ICommandRepositoryBase<>), typeof(CommandRepositoryBase<>));

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

            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            return services;
        }
    }
}
