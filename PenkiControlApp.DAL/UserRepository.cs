using Dapper;
using Npgsql;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.Core.Types;

namespace PenkiControlApp.DAL;


public class UserRepository
{
    public List<UserDTO> GetAllUsers()
    {
        string connectionString = Constants.CONNECTION_INFO;
        
        using (var connection = new NpgsqlConnection(connectionString)) {
            List<UserDTO> result = connection.Query<UserDTO>(UserQueries.GET_USERS_QUERY).ToList();
            return result;
        }
    }

    public UserDTO GetUserByLogin(string login)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_USER_BY_LOGIN_QUERY;
            var properties = new
            {
                Login = login
            };
            UserDTO user = connection.QueryFirst<UserDTO>(query, properties);
            return user;
        }
    }
 
    public Result<UserDTO> GetUserById(int id)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_USER_BY_ID_QUERY;
            var properties = new
            {
                Id = id
            };
            try
            {
                UserDTO user = connection.QueryFirst<UserDTO>(query, properties);
                return new Result<UserDTO>(user, null);
            }
            catch (Exception e)
            {
                return new Result<UserDTO>(null, e);
            }
            //QQQ
        }
    }

    public List<UserDTO> GetManagers()
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_MANAGERS_QUERY;
            List<UserDTO> result = connection.Query<UserDTO>(query).ToList();
            return result;
        }
    }

    public int InsertUser(UserDTO user)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.INSERT_USER_QUERY;
            var properties = new
            {
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                Manager = user.Manager,
                Administrator = user.Administrator
            };
            int ser = connection.Query<int>(query, properties).First();
            return ser;
            
        }
    }

    public UserDTO GetManagerByLogin(string login)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_MANAGER_BY_LOGIN_QUERY;
            var properties = new
            {
                Login = login
            };
            UserDTO user = connection.QueryFirst<UserDTO>(query, properties);
            return user;
        }
    }
    public UserDTO GetAdministratorByLogin(string login)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_ADMINISTRATOR_BY_LOGIN_QUERY;
            var properties = new
            {
                Login = login
            };
            UserDTO user = connection.QueryFirst<UserDTO>(query, properties);
            return user;
        }
    }

    public string GetUserPasswordByLogin(string login)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_USER_PASSWORD_BY_LOGIN_QUERY;
            var properties = new
            {
                Login = login
            };
            string password = connection.Query<string>(query, properties).First();
            return password;
        }
    }
    public string GetManagerPasswordByLogin(string login)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_MANAGER_PASSWORD_BY_LOGIN_QUERY;
            var properties = new
            {
                Login = login
            };
            string password = connection.Query<string>(query, properties).First();
            return password;
        }
    }
    public string GetAdministratorPasswordByLogin(string login)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = UserQueries.GET_ADMINISTRATOR_PASSWORD_BY_LOGIN_QUERY;
            var properties = new
            {
                Login = login
            };
            string password = connection.Query<string>(query, properties).First();
            return password;
        }
    }
}