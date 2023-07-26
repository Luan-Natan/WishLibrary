﻿using Microsoft.AspNetCore.Mvc;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Web.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route(nameof(Genero))]
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

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarGenero(Genero genero)
        {
            try
            {
                await _generoService.CadastrarGenero(genero);
                return RedirectToAction("CadastrarGenero", "Admin");
            }
            catch (Exception)
            {
                return View(_configuration["Layouts:Error"]);
                throw;
            }
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarGeneros()
        {
            try
            {
                var generos = await _generoService.ObterGeneros();
                ViewBag.Data = generos;

                return PartialView(_configuration["Partials:Admin"] + "_ListarGeneros.cshtml", generos);
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