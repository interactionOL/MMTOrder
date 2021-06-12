using Microsoft.Extensions.DependencyInjection;
using MMT.Orders.Contracts.Data;

namespace MMT.Orders.Data
{
    public static class DependencyInjection
    {
        public static void AddDataAccess( this IServiceCollection services )
        {
            services.AddScoped<IOrderData, OrderData>();
        }
    }
}
