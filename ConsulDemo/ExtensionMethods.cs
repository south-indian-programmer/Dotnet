using Consul;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http.Features;
using System.Runtime.CompilerServices;

namespace ConsulDemo
{
	public static class ServiceDiscoveryExtensions
	{
		public static void AddConsul(this IServiceCollection services, ServiceConfig serviceConfig)
		{
			if (serviceConfig == null)
			{
				throw new ArgumentNullException(nameof(serviceConfig));
			}

			var consulClient = new ConsulClient(config =>
			{
				config.Address = serviceConfig.DiscoveryAddress;
			});

			services.AddSingleton(serviceConfig);
			services.AddSingleton<IConsulClient, ConsulClient>(_ => consulClient);
			services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
		}
	}
	public static class ServiceConfigExtensions
	{
		public static ServiceConfig GetServiceConfig(this IConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			var serviceConfig = new ServiceConfig
			{
				Id = configuration.GetValue<string>("ServiceConfig:Id"),
				Name = configuration.GetValue<string>("ServiceConfig:Name"),
				Address = configuration.GetValue<string>("ServiceConfig:Address"),
				Port = configuration.GetValue<int>("ServiceConfig:Port"),
				DiscoveryAddress = configuration.GetValue<Uri>("ServiceConfig:DiscoveryAddress"),
				HealthCheckEndPoint = configuration.GetValue<string>("ServiceConfig:HealthCheckEndPoint"),
			};

			return serviceConfig;
		}
	}
}
