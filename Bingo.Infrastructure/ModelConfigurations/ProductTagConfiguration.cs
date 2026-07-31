using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class ProductTagConfiguration: IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.ToTable("ProductTags");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x=>x.ProductId)
            .HasColumnName("ProductId")
            .IsRequired();
        
        builder.Property(x=>x.TagId)
            .HasColumnName("TagId")
            .IsRequired();
        
        // Configuring Keys and Index.
        builder.HasIndex(x => new { x.ProductId, x.TagId });
        
        builder.HasOne(x=>x.Product)
            .WithMany(x=>x.ProductTags)
            .HasForeignKey(x=>x.ProductId);
        
        builder.HasOne(x=>x.Tag)
            .WithMany(x=>x.ProductTags)
            .HasForeignKey(x=>x.TagId);
    }
}