namespace PenkiControlApp.Core.OutputModels;

public class UserOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
}