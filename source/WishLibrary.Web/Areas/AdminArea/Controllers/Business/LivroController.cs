using MediatR;
using Microsoft.AspNetCore.Mvc;
using WishLibrary.Application.Commands.CadastrarLivro;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services;
using WishLibrary.Domain.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WishLibrary.Web.Areas.AdminArea.Controllers.Business
{
    [Area("AdminArea")]
    [Route(nameof(Livro))]
    public class LivroController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILivroService _livroService;
        private readonly IConfiguration _configuration;

        public LivroController(ILivroService LivroService, IConfiguration configuration, IMediator mediator)
        {
            _livroService = LivroService;
            _configuration = configuration;
            _mediator = mediator;
        }

        #region #Actions

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarLivro(CadastrarLivroDto livro)
        {
            try
            {
                //await _livroService.CadastrarLivro(Livro);

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

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarLivros()
        {
            try
            {
                var livros = await _livroService.ObterLivros();
                return Ok(livros);
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
