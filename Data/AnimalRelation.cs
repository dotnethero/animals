using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sol.Data;

public class AnimalRelation : IEntity<int>
{
    public int Id { get; init; }
    public required int PreyId { get; init; }
    public required int PredatorId { get; init; }
}

public class AnimalRelationConfiguration : IEntityTypeConfiguration<AnimalRelation>
{
    public void Configure(EntityTypeBuilder<AnimalRelation> relation)
    {
        relation.ToTable("AnimalRelations");
        relation.HasIndex(x => x.PreyId);
        relation.HasIndex(x => x.PredatorId);
    }
}
