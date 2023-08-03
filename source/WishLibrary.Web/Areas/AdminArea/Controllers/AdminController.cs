using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WishLibrary.Application.Commands.CadastrarLivro;
using WishLibrary.Application.Commands.PainelControle;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Enums;
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
        private readonly IMediator _mediator;

        public AdminController(ILivroService livroService, IGeneroService generoService, ILivroQuery livroQuery, IMediator mediator)
        {
            _livroService = livroService;
            _generoService = generoService;
            _livroQuery = livroQuery;
            _mediator = mediator;
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

            var command = new PainelControleCommand(obj, PainelControleEnum.Livro);
            var response = await _mediator.Send(command);
            ViewBag.LivroList = response;

            return View(obj);
        }

        #endregion
    }
}
