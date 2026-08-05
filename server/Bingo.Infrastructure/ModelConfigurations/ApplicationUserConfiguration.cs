using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class ApplicationUserConfiguration: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x=>x.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(150)
            .IsRequired();
        
    }
}