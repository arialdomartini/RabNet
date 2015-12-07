using System;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Producing messages");

            var connectionFactory = new ConnectionFactory() { HostName = "192.168.99.100" };
            using(var connection = connectionFactory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "Hello",
                        durable: false,
                        exclusive: false,
                        autoDelete:false,
                        arguments: null
                    );

                    var message = "Hello, world!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body
                    );
                    Console.WriteLine("Message equeued");
                }
            }
        }
    }
}
