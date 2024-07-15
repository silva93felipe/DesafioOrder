using Order.Domian.Entity;

namespace Order.Aplication.Contracts
{
    public interface IOrderService{
        void CreateOrder(OrderEntity newOrder);
    }
}