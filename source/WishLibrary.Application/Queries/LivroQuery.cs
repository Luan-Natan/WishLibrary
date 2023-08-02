using System.Data;
using WishLibrary.Application.Queries.DbScript;
using WishLibrary.Core.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WishLibrary.Application.Queries.Base;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.Models;

namespace WishLibrary.Application.Queries
{
    public class LivroQuery : ILivroQuery
    {
        private readonly IConfiguration _configuration;

        public LivroQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration["ConnectionString"]);
            }
        }

        public IEnumerable<ObterLivroDto>? PaginationObject(PaginacaoRequestDto obj)
        {
            try
            {
                var campos = $@"S.Id AS Id
							,S.Nome AS Nome
							,S.GeneroId AS GeneroId
							,S.DataLancamento AS DataLancamento";

                using IDbConnection connection = Connection;
                var query = PaginacaoDbScript.GenericPaginationDbScript(obj, campos);
                var response = connection.DapperSearch<ObterLivroDto>(query);
                return response.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
