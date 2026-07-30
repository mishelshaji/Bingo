using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class CountryModelConfiguration: IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("Name");
        
        builder.Property(x => x.IsoCode)
            .HasMaxLength(10)
            .IsRequired()
            .HasColumnName("ISOCode");
        
        builder.Property(x => x.PhoneCode)
            .HasMaxLength(10)
            .IsRequired()
            .HasColumnName("PhoneCode");
        
        builder.HasIndex(x => x.Name)
            .IsUnique();
        
        builder.HasIndex(x => x.IsoCode)
            .IsUnique();
    }
}
