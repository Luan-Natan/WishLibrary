using Microsoft.AspNetCore.Mvc;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route(nameof(Livro))]
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        private readonly IConfiguration _configuration;

        public LivroController(ILivroService LivroService, IConfiguration configuration)
        {
            _livroService = LivroService;
            _configuration = configuration;
        }

        #region #Actions

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarLivro(Livro Livro)
        {
            try
            {
                await _livroService.CadastrarLivro(Livro);
                return RedirectToAction("CadastrarLivro", "Admin");
            }
            catch (Exception)
            {
                return View(_configuration["Layouts:Error"]);
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
