using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class ContactRequestConfiguration: IEntityTypeConfiguration<ContactRequest>
{
    public void Configure(EntityTypeBuilder<ContactRequest> builder)
    {
        builder.ToTable("ContactRequests");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(250)
            .IsRequired(false);
        
        builder.Property(x => x.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasMaxLength(20)
            .IsRequired(false);
        
        builder.Property(x => x.Message)
            .HasColumnName("Message")
            .HasMaxLength(500)
            .IsRequired(false);
    }
}