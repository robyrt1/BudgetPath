using FinanceApi.Domain.Categories;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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


            services.AddControllers().AddOData(options =>
            {
                var modelBuilder = new ODataConventionModelBuilder();

                var categoryEntity = modelBuilder.EntitySet<CategoryEntity>("Categories").EntityType;

                categoryEntity.HasMany(c => c.SubCategories);

                options.EnableQueryFeatures()
                    .AddRouteComponents("odata", modelBuilder.GetEdmModel());
            });
            return services;
        }
    }
}
