using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

public class IdentityRoleConfiguration: IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        IdentityRole[] defaultRoles =
        [
            new IdentityRole { Id = "3e850777-9c6e-4f70-a888-be2f8fa01670", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "3e850777-9c6e-4f70-a888-be2f8fa01670"},
            new IdentityRole { Id = "3e850777-9c6e-4f70-a888-be2f8fa01671", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "3e850777-9c6e-4f70-a888-be2f8fa01671"}
        ];
        builder.HasData(defaultRoles);
    }
}