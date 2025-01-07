using Dapper;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;

namespace PenkiControlApp.DAL;

public class ClientRepository
{
    public List<ClientDTO> GetAllClients()
    {
        string connectionString = Constants.CONNECTION_INFO;

        using (var connection = new Npgsql.NpgsqlConnection(connectionString))
        {
            string query = ClientQueries.GET_CLIENT_QUERY;
            List<ClientDTO> result = connection.Query<ClientDTO>(query).AsList();
            return result;
        }
    }
}