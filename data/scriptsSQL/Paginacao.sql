						DECLARE @PagAtual  INT = 1, --@PaginaAtual
								@TamPag	   INT = 5, --@TamanhoPagina
								@Deslocar  INT = 0,			
								@NumPags   INT = 0,
								@Resultado INT = (SELECT COUNT(*) FROM {nomeTabela});

						SET @Deslocar = @TamPag * (@PagAtual - 1);

						WHILE @Resultado > 0
						BEGIN
							SET @Resultado = @Resultado - @TamPag;
							SET @NumPags += 1
						END;

						WITH SEQUENCIA AS 
						(SELECT *, ROW_NUMBER() OVER(ORDER BY Id) AS Seq FROM {nomeTabela})

						SELECT 
							 *
							,S.Seq As Paginacao_Sequencia
							,@NumPags AS Paginacao_NumeroPaginas 
						FROM SEQUENCIA AS S
						WHERE S.Seq BETWEEN (CASE WHEN @Deslocar = 0 THEN 1 
											 ELSE @Deslocar + 1 END) 
									 AND
											(CASE WHEN @Deslocar = 0 THEN @TamPag
											 ELSE (@Deslocar + @TamPag) END)
						ORDER BY S.Id