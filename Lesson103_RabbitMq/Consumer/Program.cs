using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Consumer is working!");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};


var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("first_queue", false, false, false, null);


var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) =>
{
    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    Console.WriteLine("Result: " + message);

    channel.BasicAck(args.DeliveryTag, false);
};

channel.BasicConsume(consumer, "first_queue", false);


Console.ReadKey();