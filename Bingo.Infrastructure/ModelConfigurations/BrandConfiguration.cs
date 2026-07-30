using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class BrandConfiguration: IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(x => x.WebsiteUrl)
            .HasMaxLength(250)
            .IsRequired(false)
            .HasColumnName("WebsiteUrl");
        
        builder.Property(x => x.LogoUrl)
            .HasMaxLength(250)
            .IsRequired(false)
            .HasColumnName("LogoUrl");
        
        builder.Property(x => x.SupportEmail)
            .HasMaxLength(250)
            .IsRequired(false)
            .HasColumnName("SupportEmail");

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}
