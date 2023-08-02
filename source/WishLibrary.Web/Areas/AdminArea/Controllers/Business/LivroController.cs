﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using WishLibrary.Application.Commands.CadastrarLivro;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;

namespace WishLibrary.Web.Areas.AdminArea.Controllers.Business
{
    [Area("AdminArea")]
    public class LivroController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly ILivroQuery _livroQuery;

        public LivroController(IConfiguration configuration, IMediator mediator, ILivroQuery livroQuery)
        {
            _configuration = configuration;
            _mediator = mediator;
            _livroQuery = livroQuery;
        }

        #region #Actions

        //POST: Cadastrar
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

        //GET: Listar
        public async Task<IActionResult> ObterLivros(PaginacaoRequestDto obj)
        {
            try
            {
                obj = new PaginacaoRequestDto(obj.PaginaAtual, obj.TamanhoPagina);
                ViewBag.ListarLivros = _livroQuery.PaginationLivro(obj);

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