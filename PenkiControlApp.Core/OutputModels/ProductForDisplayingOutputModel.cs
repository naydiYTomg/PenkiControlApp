namespace PenkiControlApp.Core.OutputModels;

public class ProductForDisplayingOutputModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string CategoryName { get; set; }
}