using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishLibrary.Core.DTOs
{
    public class CadastrarLivroDto
    {
        public string NomeLivro { get; set; }
        public DateTime DataLancamento { get; set; }
        public int IdGenero { get; set; }
    }
}
