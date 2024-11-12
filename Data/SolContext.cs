using Microsoft.EntityFrameworkCore;

namespace Sol.Data;

public class SolContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=.;Database=Animals;Trusted_Connection=True;Encrypt=yes;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AnimalConfiguration());
        builder.ApplyConfiguration(new HumanConfiguration());
    }
}