using FinanceApi.Application.PaymentMethod.Queries.Handlers;
using FinanceApi.Domain.PaymentMethod.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infra.DI
{
    public static class PaymentMethodIdentify
    {
        public static IServiceCollection AddPaymentMethodDepency(IServiceCollection services)
        {
            services.AddScoped<FindPaymentMethodQueryHandlerBase, FindPaymentMethodQueryHandlerImp>();

            return services;
        }
    }
}
