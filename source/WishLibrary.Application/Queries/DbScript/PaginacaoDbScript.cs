using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishLibrary.Core.DTOs;

namespace WishLibrary.Application.Queries.DbScript
{
    public class PaginacaoDbScript
    {

        public static Dictionary<string, object> GenericPaginationDbScript(PaginacaoRequestDto obj, string campos)
        {
            var sql = $@"DECLARE @PagAtual INT = @PaginaAtual,
								@TamPag	   INT = @TamanhoPagina,
								@Deslocar  INT = 0,			
								@NumPags   INT = 0,
								@Resultado INT = (SELECT COUNT(*) FROM {obj.NomeTabela});

						SET @Deslocar = @TamPag * (@PagAtual - 1);

						WHILE @Resultado > 0
						BEGIN
							SET @Resultado = @Resultado - @TamPag;
							SET @NumPags += 1
						END;

						WITH SEQUENCIA AS 
						(SELECT *, ROW_NUMBER() OVER(ORDER BY Id) AS Seq FROM {obj.NomeTabela})

						SELECT 
							 {campos}
							,S.Seq As Paginacao_Sequencia
							,@NumPags AS Paginacao_NumeroPaginas 
						FROM SEQUENCIA AS S
						WHERE S.Seq BETWEEN (CASE WHEN @Deslocar = 0 THEN 1 
											 ELSE @Deslocar + 1 END) 
									 AND
											(CASE WHEN @Deslocar = 0 THEN @TamPag
											 ELSE (@Deslocar + @TamPag) END)
						ORDER BY S.Id";

            var parametros = new
            {
                //NomeTabela = obj.NomeTabela,
                PaginaAtual = obj.PaginaAtual,
                TamanhoPagina = obj.TamanhoPagina,
            };

            return new Dictionary<string, object> { { sql, parametros } };
        }
    }
}
