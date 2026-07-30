using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class StateConfiguration: IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");

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
            .HasColumnName("IsoCode");

        builder.HasIndex(p => new { p.Name, p.CountryId })
            .IsUnique();

        builder.HasIndex(p => p.IsoCode)
            .IsUnique();
        
        builder.HasOne(s => s.Country)
            .WithMany(c => c.States)
            .HasForeignKey(s => s.CountryId);
    }
}
