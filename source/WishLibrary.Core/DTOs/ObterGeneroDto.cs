using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishLibrary.Core.DTOs
{
    public class ObterGeneroDto
    {
        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }
        public PaginacaoResponseDto? Paginacao { get; set; }
    }
}
