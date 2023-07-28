using Microsoft.AspNetCore.Mvc;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Web.Areas.Admin.Controllers
{
    [Area("AdminArea")]
    public class AdminController : Controller
    {
        private readonly ILivroService _livroService;

        public AdminController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        #region #Views

        public IActionResult CadastrarGenero()
        {
            return View();
        }

        public IActionResult CadastrarLivro()
        {
            return View();
        }

        public async Task<IActionResult> PainelControle()
        {
            var livros = await _livroService.ObterLivros();
            ViewBag.Generos = new Genero();
            ViewBag.Generos.Id = 0;
            return View(livros);
        }

        #endregion
    }
}
