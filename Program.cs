using Microsoft.EntityFrameworkCore;
using Sol;
using Sol.Data;

await using var context = new SolContext();
await Seed.Run();

var query =
    from a in context.Set<Animal>()
    where
        !context.Set<AnimalRelation>().Any(x => x.PredatorId == a.Id || x.PreyId == a.Id) &&
        !context.Set<Human>().Any(h => h.MostFavoriteAnimalId == a.Id || h.LeastFavoriteAnimalId == a.Id)
        
    orderby a.Name
    select a.Name;

var results = await query.ToArrayAsync();
 
foreach (var result in results)
{
    Console.WriteLine(result);
}
