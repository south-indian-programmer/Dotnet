using Microsoft.AspNetCore.Mvc;
using RedisDemo.Models;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RedisDemo.Controllers
{
	public class WeatherForecastController : Controller
	{
		public HttpClient client { get; set; }
		public IConnectionMultiplexer mux { get; set; }
		public IDatabase redis { get; set; }
		public WeatherForecastController(HttpClient client, IConnectionMultiplexer mux)
		{
			this.client = client;
			this.mux = mux;
			this.redis = mux.GetDatabase();
		}
		public IActionResult Index()
		{
			return View();
		}
		private async Task<string> GetForecast(double latitude, double longitude)
		{
			var t = await Task.Run(() =>
			{
				Task.Delay(1000);
				return "This is forecasted data";
			});

			return t;
		}

		[HttpGet("/getweather")]
		public async Task<string> Get([FromQuery] double latitude, [FromQuery] double longitude)
		{
			string json;
			var keyName = $"forecast:{latitude},{longitude}";
			json = await redis.StringGetAsync(keyName);
			if (string.IsNullOrEmpty(json))
			{
				json = await GetForecast(latitude, longitude);
				var setTask = redis.StringSetAsync(keyName, json);
				var expireTask = redis.KeyExpireAsync(keyName, TimeSpan.FromSeconds(3600));
				await Task.WhenAll(setTask, expireTask);
			} 
			return json;
		}
	}
}
