using MediatR;
using Microsoft.AspNetCore.Mvc;
using WishLibrary.Application.Commands.CadastrarLivro;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;

namespace WishLibrary.Web.Areas.AdminArea.Controllers.Business
{
    [Area("AdminArea")]
    [Route(nameof(Livro))]
    public class LivroController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public LivroController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        #region #Actions

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarLivro(CadastrarLivroDto livro)
        {
            try
            {
                var command = new CadastrarLivroCommand(livro);
                var response = await _mediator.Send(command);

                return RedirectToAction("CadastrarLivro", "Admin");
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
