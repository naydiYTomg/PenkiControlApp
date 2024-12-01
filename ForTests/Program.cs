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
        
        var insertedId = repository.InsertUser(new UserDTO { Name = "Laura", Login = "laurawilson123", Password = "very_strong_password"});
        if (insertedId.IsSome())
        {
            Console.WriteLine($"Inserted user with id {insertedId.Unwrap()}");
            var gotUser = repository.GetUserById(insertedId.Unwrap());
            Console.WriteLine(gotUser.Unwrap());
        }
        else
        {
            Console.WriteLine($"Got error while inserting user::[ {insertedId.Except()} ]");
        }
        
    }
}