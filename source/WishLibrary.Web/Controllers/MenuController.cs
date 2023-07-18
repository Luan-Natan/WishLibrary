using Microsoft.AspNetCore.Mvc;

namespace WishLibrary.Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult CadastrarLivro()
        //{
        //    return View();
        //}
    }
}