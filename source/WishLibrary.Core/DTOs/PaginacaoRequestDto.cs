namespace WishLibrary.Core.DTOs
{
    public class PaginacaoRequestDto
    {
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public string NomeTabela { get; set; }

        public PaginacaoRequestDto(int paginaAtual, int tamanhoPagina, string nomeTabela)
        {
            PaginaAtual = paginaAtual;
            TamanhoPagina = tamanhoPagina;
            NomeTabela = nomeTabela;
        }

        public PaginacaoRequestDto()
        {
        }
    }
}
