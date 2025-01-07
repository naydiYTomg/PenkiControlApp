using Dapper;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
namespace PenkiControlApp.DAL;

using PenkiControlApp.DAL.Internal;
using System;
using System.Runtime.InteropServices;
using System.Windows;

public class ClientRepository
{
    [DllImport("kernel32.dll")]
    private static extern bool AllocConsole();
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

    //public List<ClientDTO> GetClientById()
    //{
    //    string connectionString = Constants.CONNECTION_INFO;

    //    using (var connection = new Npgsql.NpgsqlConnection(connectionString))
    //    {
    //        string query = ClientQueries.GET_CLIENT_BY_ID_QUERY;
            
    //        AllocConsole(); // Create a console window
    //        Console.WriteLine(connection.Query<ClientDTO>(query)); // Write to the console
    //        List<ClientDTO> result = connection.Query<ClientDTO>(query).ToList();
    //        return result;
    //    }
    //}
    public ClientDTO GetClientIdByNameAndSurname(string name, string surname)
    {
        var connection = new ConnectionBuilder().WithQuery(ClientQueries.GET_CLIENT_ID_BY_NAME_AND_SURNAME_QUERY)
            .WithProperties(new { Name = name, Surname = surname }).Pack();
        return connection.ExecuteFirst<ClientDTO>();
    }
    public List<ClientFavoriteTagDTO> GetClientsFavoriteTags(int userId, int count)
    {
        var connection = new ConnectionBuilder().WithQuery(ClientQueries.GetClientsFavoriteNTagsQuery)
            .WithProperties(new { Id = userId, N = count }).Pack();
        return connection.Execute<ClientFavoriteTagDTO>().AsList();
    }

}