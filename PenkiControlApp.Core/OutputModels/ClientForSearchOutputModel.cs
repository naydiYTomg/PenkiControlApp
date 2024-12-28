namespace PenkiControlApp.Core.OutputModels;

public class ClientForSearchOutputModel : IOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Surname { get; set; }
}