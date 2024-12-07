using PenkiControlApp.Core.Types;

namespace PenkiControlApp.Core.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return $"{Id}, {Name}, {Login}, {Password}";
    }
}