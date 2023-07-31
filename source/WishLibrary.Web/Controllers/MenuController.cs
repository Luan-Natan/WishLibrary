using Microsoft.AspNetCore.Mvc;

namespace WishLibrary.Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult ListarLivros()
        {
            return View();
        }
    }
}