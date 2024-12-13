namespace PenkiControlApp.Core.OutputModels;

public class ManagerForDisplayingOutputModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public override string ToString()
    {
        return $"Manager {Name}";
    }
}