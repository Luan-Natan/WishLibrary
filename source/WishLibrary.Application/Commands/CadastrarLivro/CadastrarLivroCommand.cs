using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;

namespace WishLibrary.Application.Commands.CadastrarLivro
{
    public class CadastrarLivroCommand : IRequest<Livro>
    {
        public CadastrarLivroDto CadastrarLivro { get; set; }

        public CadastrarLivroCommand(CadastrarLivroDto cadastrarLivro)
        {
            CadastrarLivro = cadastrarLivro;
        }

        public Livro ToEntity()
        {
            return new Livro(
                    nome: CadastrarLivro.NomeLivro,
                    dataLancamento: CadastrarLivro.DataLancamento,
                    generoId: CadastrarLivro.IdGenero);
        }
    }
}
