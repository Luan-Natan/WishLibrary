namespace WishLibrary.Core.DTOs
{
    public class PaginacaoRequestDto
    {
        public int? PaginaAtual { get; set; }
        public int? TamanhoPagina { get; set; }

        public PaginacaoRequestDto(int? paginaAtual, int? tamanhoPagina)
        {
            PaginaAtual = paginaAtual ?? 1;
            TamanhoPagina = tamanhoPagina ?? 5;
        }

        public PaginacaoRequestDto()
        {
        }
    }
}
