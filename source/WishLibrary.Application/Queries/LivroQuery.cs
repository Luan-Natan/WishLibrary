using System.Data;
using WishLibrary.Application.Queries.DbScript;
using WishLibrary.Core.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WishLibrary.Application.Queries.Base;
using WishLibrary.Application.Queries.Interfaces;

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

        public IEnumerable<ObterLivroDto>? PaginationLivro(PaginacaoRequestDto obj)
        {
            try
            {
                using IDbConnection connection = Connection;
                var query = PaginacaoDbScript.GenericPaginationDbScript(obj, "T_LIVRO");
                var response = connection.SlapperSearch<ObterLivroDto>(query);
                return response.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
