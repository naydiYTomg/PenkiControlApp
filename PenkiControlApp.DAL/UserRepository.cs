using Dapper;
using Npgsql;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Types;

namespace PenkiControlApp.DAL;


public class UserRepository
{
    public Result<List<UserDTO>> GetAllUsers()
    {
        string connectionString = Constants.CONNECTION_INFO;
        
        using (var connection = new NpgsqlConnection(connectionString)) {
            connection.Open();
            try
            {
                List<UserDTO> result = connection.Query<UserDTO>(Constants.GET_USERS_QUERY).ToList();
                return new Result<List<UserDTO>>(result, null);
            }
            catch (Exception e)
            {
                return new Result<List<UserDTO>>(null, e);
            }
        
        }
    }

    public Result<UserDTO> GetUserById(int id)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = Constants.GET_USER_BY_ID_QUERY;
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

    public Result<int> InsertUser(UserDTO user)
    {
        string connectionString = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string query = Constants.INSERT_USER_QUERY;
            var properties = new
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password
            };
            connection.Open();
            try
            {
                int ser = connection.Query<int>(query, properties).First();
                return new Result<int>(ser, null);
            }
            catch (Exception e)
            {
                return new Result<int>(0, e);
            }
        }
    }
}