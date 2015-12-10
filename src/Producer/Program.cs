using System;
using RabbitMQ.Client;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Threading;

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

            int port = 5672;
            var connectionFactory = new ConnectionFactory() { HostName = "192.168.99.100", Port = port };
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

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);


                    for(var i = 1; i<100000; i++)
                    {
                        var message = new MyMessage{ Number = i, TheMessage = "Hello" };
                        var serializedMessage = JsonConvert.SerializeObject(message);
                        var body = Encoding.UTF8.GetBytes(serializedMessage);

                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;
                        properties.DeliveryMode = 2;

                        //channel.ConfirmSelect();
                        //channel.BasicAcks += (sender, e) => {
                        //    Console.WriteLine("Confirmed");
                        //};

                        channel.BasicPublish(
                            exchange: "",
                            routingKey: "hello",
                            basicProperties: properties,
                            body: body,
                            mandatory: true
                        );
                        Console.WriteLine(serializedMessage);
                        Thread.Sleep(500);
                    }
                }
            }
        }
    }
}
