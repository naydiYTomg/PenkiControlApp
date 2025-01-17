namespace PenkiControlApp.Core.OutputModels;

public class UserForLoginOutputModel : IOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Login { get; set; }
}