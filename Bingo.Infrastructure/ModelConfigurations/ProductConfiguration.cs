using Bingo.Core.Domains;
using Bingo.Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(x => x.NormalizedName)
            .HasColumnName("NormalizedName")
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(x=>x.Slug)
            .HasColumnName("Slug")
            .IsRequired(false)
            .HasMaxLength(50);
        
        builder.Property(x=>x.ShortDescription)
            .HasColumnName("ShortDescription")
            .IsRequired(false)
            .HasMaxLength(500);
        
        builder.Property(x=>x.DetailedDescription)
            .HasColumnName("DetailedDescription")
            .IsRequired(false);
        
        builder.Property(x=>x.SalesPrice)
            .HasColumnName("SalesPrice")
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);
        
        builder.Property(x=>x.RegularPrice)
            .HasColumnName("RegularPrice")
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0)
            .IsRequired();
        
        builder.Property(x=>x.Height)
            .HasColumnName("Height")
            .HasDefaultValue(null)
            .IsRequired(false);
        
        builder.Property(x=>x.Width)
            .HasColumnName("Width")
            .HasDefaultValue(null)
            .IsRequired(false);
        
        builder.Property(x=>x.Weight)
            .HasColumnName("Weight")
            .HasDefaultValue(null)
            .IsRequired(false);
        
        builder.Property(x=>x.AverageRating)
            .HasColumnName("AverageRating")
            .HasDefaultValue(0)
            .IsRequired();
        
        builder.Property(x=>x.Stock)
            .HasColumnName("Stock")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasDefaultValue(ProductStatus.Draft)
            .IsRequired();
        
        builder.Property(x=>x.BrandId)
            .HasColumnName("BrandId")
            .IsRequired(false);
        
        builder.Property(x=>x.CategoryId)
            .HasColumnName("CategoryId")
            .IsRequired(false);
        
        // Keys and relations.
        builder.HasIndex(x => x.NormalizedName);
        
        builder.HasIndex(x => x.Slug)
            .IsUnique();
        
        builder.HasOne(x=>x.Brand)
            .WithMany(b=>b.Products)
            .HasForeignKey(x=>x.BrandId);
        
        builder.HasOne(x=>x.Category)
            .WithMany(c=>c.Products)
            .HasForeignKey(x=>x.CategoryId);
    }
}