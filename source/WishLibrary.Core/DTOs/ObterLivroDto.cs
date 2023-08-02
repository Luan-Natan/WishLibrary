namespace WishLibrary.Core.DTOs
{
    public class ObterLivroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
        public DateTime DataLancamento { get; set; }
        public PaginacaoResponseDto? Paginacao { get; set; }
    }
}
