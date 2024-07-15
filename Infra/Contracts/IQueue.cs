namespace Order.Infra.Contracts
{
    public interface IQueue{
        void Publish(string message);
        void Consumer();
    }
}