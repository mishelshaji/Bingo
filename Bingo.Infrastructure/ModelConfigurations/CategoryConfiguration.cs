using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="Category"/>.
/// </summary>
public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(x => x.Slug)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("Slug");

        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasColumnName("Description");
        
        // Indexes and keys.
        builder.HasIndex(x => x.Slug)
            .IsUnique();
    }
}
