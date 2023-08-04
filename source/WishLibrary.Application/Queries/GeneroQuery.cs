using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using WishLibrary.Application.Queries.Base;
using WishLibrary.Application.Queries.DbScript;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;

namespace WishLibrary.Application.Queries
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly IConfiguration _configuration;

        public GeneroQuery(IConfiguration configuration)
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

        public IEnumerable<ObterGeneroDto>? ObterGeneroPorPaginacao(PaginacaoRequestDto obj)
        {
            try
            {
                using IDbConnection connection = Connection;
                var query = GeneroDbScript.ObterGeneroPorPaginacao();
                var paginar = PaginacaoDbScript.GenericPaginationDbScript(obj, query, "IdGenero");

                var response = connection.SlapperSearch<ObterGeneroDto>(paginar);
                return response.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
