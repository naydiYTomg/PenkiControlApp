namespace PenkiControlApp.Core.OutputModels;

public class ProductForDisplayingOutputModel : IOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string CategoryName { get; set; }
    public int Cost { get; set; }
}