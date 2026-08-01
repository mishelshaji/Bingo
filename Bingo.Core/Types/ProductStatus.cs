namespace Bingo.Core.Types;

/// <summary>
/// Represents the current status of a product.
/// </summary>
public enum ProductStatus
{
    /// <summary>
    /// The product is being created or edited and is not visible to customers.
    /// </summary>
    Draft = 1,

    /// <summary>
    /// The product is published and available for purchase.
    /// </summary>
    Active = 2,

    /// <summary>
    /// The product is temporarily unavailable and hidden from customers.
    /// </summary>
    Inactive = 3,

    /// <summary>
    /// The product is currently unavailable because it is out of stock.
    /// </summary>
    OutOfStock = 4,

    /// <summary>
    /// The product has been permanently discontinued and is no longer in use.
    /// </summary>
    Archived = 5
}