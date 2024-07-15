using System.Text;
using Order.Infra.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Order.Infra
{
    public class RabbitMq : IQueue
    {
        private readonly string FILA_CREATE_ORDER = "create_order";
        private readonly string HOST = "172.17.0.2";
        private readonly IModel _channel;
        public RabbitMq()
        {
            Consumer();
        }
        public void Consumer()
        {
            var factory = new ConnectionFactory { HostName = HOST };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: FILA_CREATE_ORDER,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            };
            channel.BasicConsume(queue: FILA_CREATE_ORDER,
                                autoAck: true,
                                consumer: consumer);
        }

        public void Publish(string message)
        {
            var factory = new ConnectionFactory { HostName =  HOST};
            using var connection = factory.CreateConnection();
            var _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: FILA_CREATE_ORDER,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: string.Empty,
                        routingKey: FILA_CREATE_ORDER,
                        basicProperties: null,
                        body: body);
        }
    }
}