using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;
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
            obj = new PaginacaoRequestDto(obj.PaginaAtual, obj.TamanhoPagina);

            //Livros
            var listaLivro = _livroQuery.PaginationLivro(obj);
            var numeroPaginasLivro = listaLivro.FirstOrDefault()?.Paginacao?.NumeroPaginas;
            ViewBag.LivrosList = new
            {
                Result = listaLivro,
                NumeroPaginas = numeroPaginasLivro,
                PaginaAnterior = obj.PaginaAtual == 1 ? 1 : obj.PaginaAtual - 1,
                ProximaPagina = obj.PaginaAtual == numeroPaginasLivro ? numeroPaginasLivro : obj.PaginaAtual + 1
            };

            return View(obj);
        }

        #endregion
    }
}
