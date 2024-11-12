using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sol.Data;

public class Animal : IEntity<int>
{
    public int Id { get; init; }
    public required string Name { get; init; }
}

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> animal)
    {
        animal.ToTable("Animals");
        animal.Property(x => x.Name).HasMaxLength(256).IsRequired();
        animal.HasIndex(x => x.Name).IsUnique();
        animal.HasMany<AnimalRelation>().WithOne().HasForeignKey(x => x.PreyId).OnDelete(DeleteBehavior.Restrict);
        animal.HasMany<AnimalRelation>().WithOne().HasForeignKey(x => x.PredatorId).OnDelete(DeleteBehavior.Restrict);
    }
}
