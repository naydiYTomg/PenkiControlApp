using Dapper;
using Npgsql;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.Core.Types;
using PenkiControlApp.DAL.Internal;

namespace PenkiControlApp.DAL;


public class UserRepository
{
    public List<UserDTO> GetAllUsers()
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_USERS_QUERY).Pack();
        return connection.Execute<UserDTO>().ToList();
    }

    public UserDTO GetUserByLogin(string login)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_USER_BY_LOGIN_QUERY)
            .WithProperties(new { Login = login }).Pack();
        return connection.ExecuteFirst<UserDTO>();
    }
 
    public UserDTO GetUserById(int id)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_USER_BY_ID_QUERY)
            .WithProperties(new { Id = id }).Pack();
        return connection.ExecuteFirst<UserDTO>();
    }

    public List<UserDTO> GetManagers()
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_MANAGERS_QUERY).Pack();
        return connection.Execute<UserDTO>().ToList();
    }

    public int InsertUser(UserDTO user)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.INSERT_USER_QUERY).WithProperties(new
        {
            Name = user.Name,
            Surname = user.Surname,
            Login = user.Login,
            Password = user.Password,
            Manager = user.Manager,
            Administrator = user.Administrator
        }).Pack();
        return connection.ExecuteFirst<int>();
    }

    public UserDTO GetManagerByLogin(string login)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_MANAGER_BY_LOGIN_QUERY)
            .WithProperties(new { Login = login }).Pack();
        return connection.ExecuteFirst<UserDTO>();
    }
    public UserDTO GetAdministratorByLogin(string login)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_ADMINISTRATOR_BY_LOGIN_QUERY)
            .WithProperties(new { Login = login }).Pack();
        return connection.ExecuteFirst<UserDTO>();
    }

    public string GetUserPasswordByLogin(string login)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_USER_PASSWORD_BY_LOGIN_QUERY)
            .WithProperties(new { Login = login }).Pack();
        return connection.ExecuteFirst<string>();
    }
    public string GetManagerPasswordByLogin(string login)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_MANAGER_PASSWORD_BY_LOGIN_QUERY)
            .WithProperties(new { Login = login }).Pack();
        return connection.ExecuteFirst<string>();
    }
    public string GetAdministratorPasswordByLogin(string login)
    {
        var connection = new ConnectionBuilder().WithQuery(UserQueries.GET_ADMINISTRATOR_PASSWORD_BY_LOGIN_QUERY)
            .WithProperties(new { Login = login }).Pack();
        return connection.ExecuteFirst<string>();
    }
}