using MediatR;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;

namespace WishLibrary.Application.Commands.CadastrarGenero
{
    public class CadastrarGeneroCommand : IRequest<Genero>
    {
        public CadastrarGeneroDto CadastrarGenero { get; set; }

        public CadastrarGeneroCommand(CadastrarGeneroDto cadastrarGenero)
        {
            CadastrarGenero = cadastrarGenero;
        }

        public Genero ToEntity()
        {
            return new Genero(
                    nome: CadastrarGenero.NomeGenero);
        }
    }
}
