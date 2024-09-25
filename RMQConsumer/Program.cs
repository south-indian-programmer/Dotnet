using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RMQConsumer
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			ConsumeMessage();
		}

		static void ConsumeMessage()
		{
			var factory = new ConnectionFactory
			{
				HostName = "localhost",
				Port = 32770,
				UserName = "guest",
				Password = "guest"
			};
			using var connection = factory.CreateConnection();
			using var channel = connection.CreateModel();

			channel.QueueDeclare(queue: "demoqueue",
								 durable: true,
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
			channel.BasicConsume(queue: "demoqueue",
								 autoAck: true,
								 consumer: consumer);

			Console.WriteLine(" Press [enter] to exit.");
			Console.ReadLine();

		}
	}
}
