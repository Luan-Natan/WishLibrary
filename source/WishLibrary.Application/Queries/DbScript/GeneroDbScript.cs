namespace WishLibrary.Application.Queries.DbScript
{
    public class GeneroDbScript
    {
        public static Dictionary<string,object> ObterGeneroPorPaginacao()
        {
            var sql = @$"SELECT TOP(@TamPag * @PagAtual)
								ROW_NUMBER() OVER(ORDER BY G.Id) As Paginacao_Sequencia
								,G.Id AS IdGenero
								,G.Nome AS NomeGenero
						 FROM T_GENERO AS G";

            return new Dictionary<string, object> { { sql, null } };
        }
    }
}
