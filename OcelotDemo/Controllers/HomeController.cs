using Microsoft.AspNetCore.Mvc;

namespace OcelotDemo.Controllers
{
	public class HomeController : Controller
	{
		[Route("/")]
		public IActionResult Index() 
		{
			return Ok("Welcome to home");
		}
	}
}
