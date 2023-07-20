using Microsoft.AspNetCore.Mvc;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;
        private readonly IConfiguration _configuration;

        public GeneroController(IGeneroService generoService, IConfiguration configuration)
        {
            _generoService = generoService;
            _configuration = configuration;
        }

        #region #Actions

        [HttpPost]
        public async Task<IActionResult> CadastrarGenero(Genero genero)
        {
            try
            {
                await _generoService.CadastrarGenero(genero);
                return View("~/Areas/AdminArea/Views/HomeAdmin/Index.cshtml");
            }
            catch (Exception)
            {
                return View(_configuration["Layouts:Error"]);
                throw;
            }
        }

        #endregion
    }
}
