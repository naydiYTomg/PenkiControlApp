namespace PenkiControlApp.Core.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public override string ToString()
    {
        return $"{Id}//{Name}";
    }
}