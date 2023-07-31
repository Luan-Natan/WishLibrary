using Microsoft.AspNetCore.Mvc;

namespace WishLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
