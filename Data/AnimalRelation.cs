using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sol.Data;

public class AnimalRelation
{
    public required int PredatorId { get; init; }
    public required int PreyId { get; init; }
}

public class AnimalRelationConfiguration : IEntityTypeConfiguration<AnimalRelation>
{
    public void Configure(EntityTypeBuilder<AnimalRelation> relation)
    {
        relation.HasKey(x => new { x.PredatorId, x.PreyId });
        relation.HasIndex(x => x.PredatorId);
        relation.HasIndex(x => x.PreyId);
    }
}
