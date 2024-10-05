using Microsoft.AspNetCore.Mvc;

namespace OcelotDemo.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[Route("/product/{id?}")]
		public IActionResult ProductId(int id)		
		{
			return Ok(id);
		}
	}
}
