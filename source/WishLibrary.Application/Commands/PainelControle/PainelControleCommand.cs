using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Enums;

namespace WishLibrary.Application.Commands.PainelControle
{
    public class PainelControleCommand : IRequest<object?>
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
