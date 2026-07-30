namespace Bingo.Application.Dtos.Category;

public class CategoryViewDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }
}