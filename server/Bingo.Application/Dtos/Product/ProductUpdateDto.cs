using Bingo.Core.Types;
using FluentValidation;

namespace Bingo.Application.Dtos.Product;

public class ProductUpdateDto
{
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string? ShortDescription { get; set; }
    public string? DetailedDescription { get; set; }
    public decimal? SalesPrice { get; set; }
    public decimal RegularPrice { get; set; }
    public double? Height { get; set; }
    public double? Width { get; set; }
    public double? Weight { get; set; }
    public int Stock { get; set; }
    public ProductStatus Status { get; set; }
    public long? BrandId { get; set; }
    public long? CategoryId { get; set; }
}

public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(150).WithMessage("Product name cannot exceed 150 characters.");

        RuleFor(x => x.Slug)
            .MaximumLength(50).WithMessage("Slug cannot exceed 50 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Slug));

        RuleFor(x => x.ShortDescription)
            .MaximumLength(500).WithMessage("Short description cannot exceed 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.ShortDescription));

        RuleFor(x => x.RegularPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Regular price cannot be negative.");

        RuleFor(x => x.SalesPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Sales price cannot be negative.")
            .When(x => x.SalesPrice.HasValue);

        RuleFor(x => x)
            .Must(x => !x.SalesPrice.HasValue || x.SalesPrice <= x.RegularPrice)
            .WithMessage("Sales price cannot be greater than the regular price.");

        RuleFor(x => x.Height)
            .GreaterThan(0).WithMessage("Height must be greater than zero.")
            .When(x => x.Height.HasValue);

        RuleFor(x => x.Width)
            .GreaterThan(0).WithMessage("Width must be greater than zero.")
            .When(x => x.Width.HasValue);

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than zero.")
            .When(x => x.Weight.HasValue);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid product status.");

        RuleFor(x => x.BrandId)
            .GreaterThan(0).WithMessage("Brand Id must be greater than zero.")
            .When(x => x.BrandId.HasValue);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category Id must be greater than zero.")
            .When(x => x.CategoryId.HasValue);
    }
}