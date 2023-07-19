using Microsoft.AspNetCore.Mvc;

namespace WishLibrary.Web.Areas.Admin.Controllers
{
    [Area("AdminArea")]
    public class AdminController : Controller
    {
        public IActionResult CadastrarLivro()
        {
            return View();
        }
        public IActionResult PainelControle()
        {
            return View();
        }
    }
}
