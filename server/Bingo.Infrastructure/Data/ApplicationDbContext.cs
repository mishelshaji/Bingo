using Bingo.Core.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Infrastructure.Data;

/// <summary>
/// Represents the application's database session.
///
/// Entity Framework Core uses this class to:
/// - Connect to the database.
/// - Track changes made to entities.
/// - Query data.
/// - Insert, update and delete records.
/// - Apply entity configurations.
/// </summary>
public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">
    /// Configuration options supplied by Dependency Injection.
    /// These options contain information such as:
    /// - Database provider (SQL Server, PostgreSQL, SQLite, etc.)
    /// - Connection string
    /// - Logging options
    /// </param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Configures the EF Core model.
    ///
    /// This method is executed once when Entity Framework builds the model.
    /// It is the ideal place to register entity configurations.
    /// </summary>
    /// <param name="modelBuilder">
    /// Provides the Fluent API used to configure entities and relationships.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Always call the base implementation first.
        base.OnModelCreating(modelBuilder);

        // Automatically scans this assembly for classes that implement
        // IEntityTypeConfiguration<T> and applies them.
        //
        // This avoids manually registering every configuration class.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    /// <summary>
    /// Represents the Categories table.
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Represents the Tags table.
    /// </summary>
    public DbSet<Tag> Tags { get; set; }

    /// <summary>
    /// Represents the Brands table.
    /// </summary>
    public DbSet<Brand> Brands { get; set; }

    /// <summary>
    /// Represents the Countries table.
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Represents the States table.
    /// </summary>
    public DbSet<State> States { get; set; }

    /// <summary>
    /// Represents the Contact Requests table.
    /// </summary>
    public DbSet<ContactRequest> ContactRequests { get; set; }

    /// <summary>
    /// Represents the Products table.
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Represents the ProductTags junction table used for the
    /// many-to-many relationship between Products and Tags.
    /// </summary>
    public DbSet<ProductTag> ProductTags { get; set; }
}