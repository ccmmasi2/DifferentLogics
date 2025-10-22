using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Logics
{
    public class RabbitMQConsumer
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection()) 
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue",
                                        durable: false,
                                        autoDelete: false,
                                        exclusive: false,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);
                };

                channel.BasicConsume(queue: "my_queue",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine("Waiting for messages...");
                Console.ReadLine();
            }
        }
    }
}
