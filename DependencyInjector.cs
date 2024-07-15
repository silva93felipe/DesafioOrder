using Order.Aplication.Contracts;
using Order.Aplication.Services;
using Order.Infra;
using Order.Infra.Contracts;

namespace Order
{
    public static class DependencyInjector{
        public static void Create(this IServiceCollection services){
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IQueue, RabbitMq>();
        }
    }
}