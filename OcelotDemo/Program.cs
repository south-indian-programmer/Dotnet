using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var builder = WebApplication.CreateBuilder(args);
			var config=builder.Configuration.AddJsonFile("ocelot.json").Build();
			builder.Services.AddSwaggerGen();
			builder.Services.AddControllersWithViews();
			builder.Services.AddOcelot(config);

			var app = builder.Build();
			app.UseStaticFiles();
			app.UseRouting();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
			});
			//use endpoint is important. if only mapcontroller route is used it wont work and useocelot should be at last
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			app.UseOcelot();
			app.Run();
		}
	}
}
