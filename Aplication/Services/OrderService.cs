using System.Text;
using System.Text.Json;
using Order.Aplication.Contracts;
using Order.Domian.Entity;
using Order.Infra.Contracts;

namespace Order.Aplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IQueue _queue;
        public OrderService(IQueue queue)
        {
            _queue = queue;
        }
        public void CreateOrder(OrderEntity newOrder)
        {
            var orderSerializada = JsonSerializer.Serialize(newOrder);
            _queue.Publish(orderSerializada);
        }
    }
}