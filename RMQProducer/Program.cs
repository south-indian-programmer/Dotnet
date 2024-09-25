using RabbitMQ.Client;
using System.Text;

namespace RMQProducer
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			ProduceMessage();
		}

		static void ProduceMessage()
		{
			string UserName = "guest";
			string Password = "guest";
			string HostName = "localhost";

			//Main entry point to the RabbitMQ .NET AMQP client
			var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
			{
				UserName = UserName,
				Password = Password,
				HostName = HostName,
				Port=32770
			};

			var connection = connectionFactory.CreateConnection();
			var model = connection.CreateModel();

			////Create Exchange
			//model.ExchangeDeclare("demoExchange", ExchangeType.Direct);
			//Console.WriteLine("Creating Exchange");

			////Create Queue
			//model.QueueDeclare("demoqueue", true, false, false, null);
			//Console.WriteLine("Creating Queue");

			//// Bind Queue to Exchange
			//model.QueueBind("demoqueue", "demoExchange", "directexchange_key");
			//Console.WriteLine("Creating Binding");
			//Console.ReadLine();
			 
			var properties = model.CreateBasicProperties();
			properties.Persistent = false;
			byte[] messagebuffer = Encoding.Default.GetBytes("This is changed good Message");
			model.BasicPublish("demoExchange", "directexchange_key", properties, messagebuffer);
			Console.WriteLine("Message Sent");
			Console.ReadLine();
		}
	}
}
