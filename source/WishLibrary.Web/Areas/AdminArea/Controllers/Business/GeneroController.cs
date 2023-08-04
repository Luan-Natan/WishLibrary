using MediatR;
using Microsoft.AspNetCore.Mvc;
using WishLibrary.Application.Commands.CadastrarGenero;
using WishLibrary.Application.Commands.PainelControle;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Enums;

namespace WishLibrary.Web.Areas.AdminArea.Controllers.Business
{
    [Area("AdminArea")]
    public class GeneroController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public GeneroController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        #region #Actions

        //POST: Cadastrar
        public async Task<IActionResult> CadastrarGenero(CadastrarGeneroDto genero)
        {
            try
            {
                var command = new CadastrarGeneroCommand(genero);
                var response = await _mediator.Send(command);

                return RedirectToAction("CadastrarGenero", "Admin");
            }
            catch (Exception)
            {
                //return View(_configuration["Layouts:Error"]);
                throw;
            }
        }

        //GET: Listar
        public async Task<IActionResult> ObterGeneros(PaginacaoRequestDto obj)
        {
            try
            {
                obj = new PaginacaoRequestDto(obj.PaginaAtual, obj.TamanhoPagina);

                var command = new PainelControleCommand(obj, PainelControleEnum.Genero);
                var response = _mediator.Send(command);
                ViewBag.GeneroList = response.Result;

                return RedirectToAction("PainelControle", "Admin", obj);
            }
            catch (Exception)
            {
                //return View(_configuration["Layouts:Error"]);
                throw;
            }
        }

        #endregion
    }
}
