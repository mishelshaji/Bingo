using Bingo.Core.Domains;
using Bingo.Infrastructure.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Category> Categories { get; set; } 
    public DbSet<Tag> Tags { get; set; } 
    public DbSet<Brand> Brands { get; set; } 
    public DbSet<Country> Countries { get; set; } 
    public DbSet<State> States { get; set; }
    public DbSet<ContactRequest> ContactRequests { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
}
