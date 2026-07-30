using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class ContactMessageConfiguration: IEntityTypeConfiguration<ContactMessage>
{
    public void Configure(EntityTypeBuilder<ContactMessage> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        
        builder.Property(c => c.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(c => c.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(c => c.Email)
            .HasColumnName("Email")
            .HasMaxLength(250)
            .IsRequired(false);
        
        builder.Property(c => c.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasMaxLength(20)
            .IsRequired(false);
        
        builder.Property(c => c.Message)
            .HasColumnName("Message")
            .HasMaxLength(500)
            .IsRequired();
    }
}