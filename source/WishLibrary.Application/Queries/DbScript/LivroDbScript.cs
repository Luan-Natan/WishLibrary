namespace WishLibrary.Application.Queries.DbScript
{
    public class LivroDbScript
    {
        public static Dictionary<string, object> ObterLivroPorPaginacao()
        {
            var sql = @$"SELECT TOP(@TamPag * @PagAtual)
								ROW_NUMBER() OVER(ORDER BY L.Id) As Paginacao_Sequencia
								,L.Id AS IdLivro
								,L.Nome AS NomeLivro
								,L.GeneroId AS GeneroId
								,L.DataLancamento AS DataLancamento
								,G.Nome AS NomeGenero
						  FROM T_LIVRO AS L
						  INNER JOIN T_GENERO AS G ON G.Id = L.GeneroId";

            return new Dictionary<string, object> { { sql, null } };
        }
    }
}
