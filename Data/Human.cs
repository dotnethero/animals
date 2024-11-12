using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sol.Data;

public class Human : IEntity<int>
{
    public int Id { get; init; }

    public int? MostFavoriteAnimalId { get; set; }
    public int? LeastFavoriteAnimalId { get; set; }
}

public class HumanConfiguration : IEntityTypeConfiguration<Human>
{
    public void Configure(EntityTypeBuilder<Human> human)
    {
        human.ToTable("Humans");
        human.HasOne<Animal>().WithMany().HasForeignKey(x => x.MostFavoriteAnimalId).OnDelete(DeleteBehavior.Restrict);
        human.HasOne<Animal>().WithMany().HasForeignKey(x => x.LeastFavoriteAnimalId).OnDelete(DeleteBehavior.Restrict);
    }
}
