namespace WishLibrary.Core.DTOs
{
    public class ObterLivroDto
    {
        public int IdLivro { get; set; }
        public string NomeLivro { get; set; }
        public string NomeGenero { get; set; }
        public int GeneroId { get; set; }
        public DateTime DataLancamento { get; set; }
        public PaginacaoResponseDto? Paginacao { get; set; }
    }
}
