namespace PenkiControlApp.Core.OutputModels;

public class CategoryOutputModel : IOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
}