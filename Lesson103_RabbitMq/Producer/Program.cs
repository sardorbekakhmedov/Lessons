using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Producer is working!");

var factory = new ConnectionFactory();
var connection = factory.CreateConnection();

var channel = connection.CreateModel();
channel.QueueDeclare("first_queue", false, false, false, null);
channel.BasicPublish("", "first_queue", null, Encoding.UTF8.GetBytes("First message for RabbitMQ"));



Console.ReadLine();