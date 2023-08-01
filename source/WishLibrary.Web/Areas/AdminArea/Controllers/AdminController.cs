using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WishLibrary.Application.Commands.CadastrarLivro;
using WishLibrary.Core.DTOs;
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
        private readonly IGeneroService _generoService;

        public AdminController(ILivroService livroService, IGeneroService generoService)
        {
            _livroService = livroService;
            _generoService = generoService;
        }

        #region #Views

        public IActionResult CadastrarGenero()
        {
            return View();
        }

        public IActionResult CadastrarLivro()
        {
            ViewBag.ListarGeneros = _generoService.ObterGeneros()?.Result?
                                                  .Select(c => new SelectListItem()
                                                  {
                                                      Text = c.Nome,
                                                      Value = c.Id.ToString()
                                                  }).ToList();

            return View();
        }

        public async Task<IActionResult> PainelControle()
        {
            ViewBag.ListarLivros = await _livroService.ObterLivros();

            return View();
        }

        #endregion
    }
}
