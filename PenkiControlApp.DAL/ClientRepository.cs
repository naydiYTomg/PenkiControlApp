using Dapper;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
namespace PenkiControlApp.DAL;

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
            List<ClientDTO> result = connection.Query<ClientDTO>(query).ToList();
            return result;
        }
    }

    public List<ClientDTO> GetClientById()
    {
        string connectionString = Constants.CONNECTION_INFO;

        using (var connection = new Npgsql.NpgsqlConnection(connectionString))
        {
            string query = ClientQueries.GET_CLIENT_QUERY;
            
            AllocConsole(); // Create a console window
            Console.WriteLine(connection.Query<ClientDTO>(query)); // Write to the console
            List<ClientDTO> result = connection.Query<ClientDTO>(query).ToList();
            return result;
        }
    }

}