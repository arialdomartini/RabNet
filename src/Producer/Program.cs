using System;
using RabbitMQ.Client;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace Producer
{
    public class MyMessage
    {
        public int Number { get; set; }
        public string TheMessage { get; set; }
    }

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
                        queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete:false,
                        arguments: null
                    );

                    for(var i = 1; i<100; i++)
                    {
                        var message = new MyMessage{ Number = i, TheMessage = "Hello" };
                        var serializedMessage = JsonConvert.SerializeObject(message);
                        var body = Encoding.UTF8.GetBytes(serializedMessage);

                        channel.BasicPublish(
                            exchange: "",
                            routingKey: "hello",
                            basicProperties: null,
                            body: body
                        );
                        Console.WriteLine(serializedMessage);
                    }
                }
            }
        }
    }
}
