namespace PenkiControlApp.Core.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public bool Manager { get; set; }
    public bool Administrator { get; set; }
    
    public override string ToString()
    {
        return $"{Id}, {Name}, {Login}, {Password}, {Manager}";
    }
}