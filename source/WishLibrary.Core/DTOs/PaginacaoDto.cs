namespace WishLibrary.Core.DTOs
{
    public class PaginacaoDto
    {
        public object Response { get; set; }
        public int? NumeroPaginas { get; set; }
        public int? PaginaAnterior { get; set; }
        public int? ProximaPagina { get; set; }

        public PaginacaoDto()
        {
        }

        public PaginacaoDto(int? numeroPaginas, int? paginaAtual, object resposta)
        {
            Response = resposta;
            NumeroPaginas = numeroPaginas;
            PaginaAnterior = paginaAtual == 1 ? 1 : paginaAtual - 1;
            ProximaPagina = paginaAtual == numeroPaginas ? numeroPaginas : paginaAtual + 1;
        }
    }
}
