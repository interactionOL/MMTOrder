using Microsoft.Extensions.DependencyInjection;
using MMT.Orders.Contracts.Services;

namespace MMT.Orders.Services
{
    public static class DependencyInjection
    {
        public static void AddServices( this IServiceCollection services )
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
