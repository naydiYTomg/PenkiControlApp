namespace PenkiControlApp.UI.InternalTypes;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public bool IsAdmin { get; set; } = false;
    public bool IsManager { get; set; } = false;
}