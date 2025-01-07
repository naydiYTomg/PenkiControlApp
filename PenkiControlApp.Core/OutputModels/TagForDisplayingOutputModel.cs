namespace PenkiControlApp.Core.OutputModels;

public class TagForDisplayingOutputModel : IOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
}