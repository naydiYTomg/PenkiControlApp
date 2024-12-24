namespace PenkiControlApp.Core.OutputModels;

public class TagOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
}