namespace PenkiControlApp.Core.OutputModels;

public class ClientForDisplayingOutputModel : IOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
}