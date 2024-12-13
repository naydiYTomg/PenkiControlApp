using PenkiControlApp.Core.DTOs;
using PenkiControlApp.DAL;

namespace ForTests;

class Program
{
    static void Main(string[] args)
    {
        UserRepository repository = new UserRepository();
        var users = repository.GetAllUsers();
        if (users.IsSome())
        {
            users.Unwrap().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine($"Got error::[ {users.Except()} ]");
        }
        
        // var insertedId = repository.InsertUser(new UserDTO { Name = "JohnDaveyHarris", Login = "jdh993", Password = "very_strong_password", Manager = true});
        // var insertedId2 = repository.InsertUser(new UserDTO()
        //     { Name = "Artyom", Login = "cool_manager", Password = "cool", Manager = true });
        //УБРАЛ Ю
        //QQQ
    }
}