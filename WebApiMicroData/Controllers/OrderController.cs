using Microsoft.AspNetCore.Mvc;

namespace WebApiMicroData.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
