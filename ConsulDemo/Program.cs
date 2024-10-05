using Consul;

namespace ConsulDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			IConfiguration Configuration = builder.Configuration;
			
			ServiceConfig serviceConfig = Configuration.GetServiceConfig();  
			builder.Services.AddConsul(serviceConfig);
			var app = builder.Build();
			app.MapGet("/", () => "Hello World!");
			app.MapGet("/health", () => "health ok");
			app.Run();
		}
	}
}
