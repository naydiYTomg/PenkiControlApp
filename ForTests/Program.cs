using System.Security.Cryptography;
using System.Text;
using Dapper;
using Npgsql;
using PenkiControlApp.BLL.SessionStoring;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.DAL;
namespace ForTests;

class Program
{
    static void Main(string[] args)
    {
        // UserRepository repository = new UserRepository();
        // var users = repository.GetAllUsers();
        // users.ForEach(Console.WriteLine);
        // Session session = new Session
        //     { Name = "William", Surname = "Davison", Login = "coolwilliam123", Password = "verystrong" };
        // // Storer.Store(session);
        //
        // var temp = Storer.Read();
        // if (temp is not null)
        // {
        //     Console.WriteLine($"{temp.Value.Name}, {temp.Value.Surname}, {temp.Value.Login}, {temp.Value.Password}");
        // }
        using (var connection = new NpgsqlConnection(Environment.GetEnvironmentVariable("DATABASE_ACCESS")))
        {
            connection.Query("""
                             update "User"
                             set "Password" = @Password
                             where "Surname" = 'Davey Harris'
                             """, new
            {
                Password = Encoding.UTF8.GetString(SHA256.HashData("very_strong_password"u8.ToArray()))
            });
        }
        // var insertedId = repository.InsertUser(new UserDTO { Name = "JohnDaveyHarris", Login = "jdh993", Password = "very_strong_password", Manager = true});
        // var insertedId2 = repository.InsertUser(new UserDTO()
        //     { Name = "Artyom", Login = "cool_manager", Password = "cool", Manager = true });
        //УБРАЛ Ю
        //QQQ
    }
}