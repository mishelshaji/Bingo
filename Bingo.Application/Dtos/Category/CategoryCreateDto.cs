namespace Bingo.Application.Dtos.Category;

public class CategoryCreateDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }
}