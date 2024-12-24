namespace PenkiControlApp.Core.OutputModels;

public class UserForLoginOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Login { get; set; }
}