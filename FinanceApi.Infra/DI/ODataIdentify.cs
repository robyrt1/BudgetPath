using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Categories;
using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.Transactions;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;

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

                            var creditCards = modelBuilder.EntitySet<CreditCardEntity>("CreditCard").EntityType;
                            creditCards.HasKey(c => c.Id);

                            var transactions = modelBuilder.EntitySet<TransactionsEntity>("Transactions").EntityType;

                            options.Select().Expand().Filter().OrderBy().Count();
                            options.EnableQueryFeatures()
                                .AddRouteComponents("odata/v1", modelBuilder.GetEdmModel());
                        });
             return services;
        }   
    }
    
}