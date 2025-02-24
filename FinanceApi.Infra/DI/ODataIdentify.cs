using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Categories;
using FinanceApi.Domain.CreditCards;
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
    public static class ODataIdentify 
    {
        public static IServiceCollection AddOData(IServiceCollection services)
        {
            services.AddControllers().AddOData(options =>
                        {
                            var modelBuilder = new ODataConventionModelBuilder();
            
                            var categoryEntity = modelBuilder.EntitySet<CategoryEntity>("Categories").EntityType;
                            categoryEntity.HasMany(c => c.SubCategories);

                            var Account = modelBuilder.EntitySet<AccountEntity>("Account").EntityType;
                            //Account.HasMany(c => c.CreditCard);

                            var creditCards = modelBuilder.EntitySet<CreditCardEntity>("CreditCard").EntityType;
                            creditCards.HasKey(c => c.Id);

                            options.Select().Expand().Filter().OrderBy().Count();
                            options.EnableQueryFeatures()
                                .AddRouteComponents("odata/v1", modelBuilder.GetEdmModel());
                        });
             return services;
        }   
    }
    
}