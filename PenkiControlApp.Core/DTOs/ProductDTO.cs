namespace PenkiControlApp.Core.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }

    public override string ToString()
    {
        return $"{Id}//{Name}//{CategoryId}";
    }
}