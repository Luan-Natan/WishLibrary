using WishLibrary.Core.DTOs;

namespace WishLibrary.Application.Queries.DbScript
{
    public class PaginacaoDbScript
    {
        public static Dictionary<string, object> GenericPaginationDbScript(PaginacaoRequestDto obj, Dictionary<string, object> script, string orderById)
        {
            var result = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> item in script)
            {

                var sql = $@"DECLARE @PagAtual  INT = {obj.PaginaAtual},
									 @TamPag	INT = {obj.TamanhoPagina},
									 @Deslocar  INT,
									 @NumPags   INT;

						SET @Deslocar = @TamPag * (@PagAtual - 1);

						WITH SEQUENCIA AS 
						(
							{item.Key}
						)

						SELECT *, (SELECT TOP(1) SEQ.Paginacao_Sequencia FROM SEQUENCIA AS SEQ ORDER BY SEQ.{orderById} DESC) / @TamPag AS Paginacao_NumeroPaginas
						FROM SEQUENCIA AS S
						WHERE S.Paginacao_Sequencia 
							  BETWEEN (CASE WHEN @Deslocar = 0 THEN 1 
							           ELSE @Deslocar + 1 END) 
							  AND
									  (CASE WHEN @Deslocar = 0 THEN @TamPag
									   ELSE (@Deslocar + @TamPag) END)
						ORDER BY S.{orderById}";

                result.Add(sql, item.Value);
            }

            return result;
        }
    }
}
