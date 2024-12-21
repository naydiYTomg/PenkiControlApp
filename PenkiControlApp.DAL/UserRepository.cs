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
                Login = user.Login,
                Password = user.Password,
                Manager = user.Manager,
                Surname = user.Surname
            };
            connection.Open();
            int ser = connection.Query<int>(query, properties).First();
            return ser;
            
        }
    }
}