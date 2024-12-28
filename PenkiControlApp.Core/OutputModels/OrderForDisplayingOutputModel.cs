namespace PenkiControlApp.Core.OutputModels;

public class OrderForDisplayingOutputModel : IOutputModel
{
    public int Id { get; set; }
    public int Sum { get; set; }
    public int Date { get; set; }
    public int UserId { get; set; }
    public int ClientId { get; set; }
}