using RabbitMQ.Client;
using System.Text;

namespace Logics
{
    public class RabbitMQProducer
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello, RabbitMQ!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "my_queue",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine("Message published to the queue.");
            }
        }
    }
}
