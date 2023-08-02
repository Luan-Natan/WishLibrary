using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Web.Areas.Admin.Controllers
{
    [Area("AdminArea")]
    public class AdminController : Controller
    {
        private readonly ILivroQuery _livroQuery;
        private readonly ILivroService _livroService;
        private readonly IGeneroService _generoService;

        public AdminController(ILivroService livroService, IGeneroService generoService, ILivroQuery livroQuery)
        {
            _livroService = livroService;
            _generoService = generoService;
            _livroQuery = livroQuery;
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

        public async Task<IActionResult> PainelControle(PaginacaoRequestDto obj)
        {
            //ViewBag.ListarLivros = await _livroService.ObterLivros();
            obj = new PaginacaoRequestDto(3, 5, "T_LIVRO");
            ViewBag.ListarLivros = _livroQuery.PaginationObject(obj);

            return View();
        }

        #endregion
    }
}
