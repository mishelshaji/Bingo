using FluentValidation;

namespace Bingo.Application.Dtos.Product;

/// <summary>
/// Represents the information required to associate a tag with a product.
/// </summary>
public class ProductAddTagDto
{
    /// <summary>
    /// Gets or sets the identifier of the tag to associate with the product.
    /// </summary>
    public long TagId { get; set; }
}

/// <summary>
/// Validates the <see cref="ProductAddTagDto"/> before it is processed by the application.
/// </summary>
public class ProductAddTagDtoValidator : AbstractValidator<ProductAddTagDto>
{
    /// <summary>
    /// Initializes validation rules for <see cref="ProductAddTagDto"/>.
    /// </summary>
    public ProductAddTagDtoValidator()
    {
        RuleFor(x => x.TagId)
            // Ensures that a valid tag identifier is provided.
            .GreaterThan(0)
            .WithMessage("A valid tag must be selected.");
    }
}