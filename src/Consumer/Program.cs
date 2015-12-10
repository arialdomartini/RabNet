using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Collections;
using Producer;
using Newtonsoft.Json;

namespace Consumer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Consuming messages");

            int port = 5673;
            var connectionFactory = new ConnectionFactory() { HostName = "192.168.99.100", Port = port };
            Console.WriteLine("Using port {0}", port);
            using(var connection = connectionFactory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "hello",
                        durable: true,
                        exclusive: false,
                        autoDelete:false,
                        arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) => {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var mymessage = JsonConvert.DeserializeObject<MyMessage>(message);
                        Console.WriteLine("Got: {0}/{1}", mymessage.Number, mymessage.TheMessage);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };

                    channel.BasicConsume(
                        queue: "hello",
                        noAck: false,
                        consumer: consumer
                    );

                    Console.ReadLine();
                }
            }
        }
    }
}
