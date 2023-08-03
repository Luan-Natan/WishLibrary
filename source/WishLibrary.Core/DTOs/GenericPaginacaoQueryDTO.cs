namespace WishLibrary.Core.DTOs
{
    public class GenericPaginacaoQueryDTO
    {
        public dynamic? Result { get; set; }
        public int? NumeroPaginas { get; set; }
        public int? PaginaAnterior { get; set; }
        public int? ProximaPagina { get; set; }

        public GenericPaginacaoQueryDTO(IEnumerable<U>? result, int? numeroPaginas, int? paginaAnterior, int? proximaPagina)
        {
            Result = result;
            NumeroPaginas = numeroPaginas;
            PaginaAnterior = paginaAnterior;
            ProximaPagina = proximaPagina;
        }
    }
}
