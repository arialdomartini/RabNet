using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Collections;

namespace Consumer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Consuming messages");

            var connectionFactory = new ConnectionFactory() { HostName = "192.168.99.100" };
            using(var connection = connectionFactory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete:false,
                        arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) => {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Got: {0}", message);
                    };

                    channel.BasicConsume(
                        queue: "hello",
                        noAck: true,
                        consumer: consumer
                    );

                    Console.ReadLine();
                }
            }
        }
    }
}
