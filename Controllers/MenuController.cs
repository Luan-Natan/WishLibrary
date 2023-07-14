using Microsoft.AspNetCore.Mvc;

namespace WishLibrary.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarLivro()
        {
            return View();
        }
    }
}