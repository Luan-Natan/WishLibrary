using MediatR;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Enums;

namespace WishLibrary.Application.Commands.PainelControle
{
    public class PainelControleCommand : IRequest<PaginacaoDto?>
    {
        public PainelControleCommand(PaginacaoRequestDto paginacaoObj, PainelControleEnum modelo)
        {
            PaginacaoObj = paginacaoObj;
            Modelo = modelo;
        }

        public PaginacaoRequestDto PaginacaoObj { get; set; }
        public PainelControleEnum Modelo { get; set; }
    }
}
