using Microsoft.AspNetCore.Mvc;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Web.Areas.Admin.Controllers
{
    [Area("AdminArea")]
    public class AdminController : Controller
    {
        #region #Views

        public IActionResult CadastrarGenero()
        {
            return View();
        }

        public IActionResult ListarGenero()
        {
            return View();
        }

        public IActionResult CadastrarLivro()
        {
            return View();
        }

        public IActionResult PainelControle()
        {
            return View();
        }

        #endregion
    }
}
