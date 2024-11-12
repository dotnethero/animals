using Sol.Data;

namespace Sol;

public class Seed
{
    public static async Task Run()
    {
        await using var context = new SolContext();
        
        var mouse = new Animal
        {
            Name = "Mouse"
        };

        var snake = new Animal
        {
            Name = "Snake"
        };

        var eagle = new Animal
        {
            Name = "Eagle"
        };
        
        var elephant = new Animal
        {
            Name = "Elephant"
        };

        context.Add(mouse);
        context.Add(snake);
        context.Add(eagle);
        context.Add(elephant);

        await context.SaveChangesAsync();

        var snakeHuntsMouse = new AnimalRelation
        {
            PredatorId = snake.Id,
            PreyId = mouse.Id
        };

        var eagleHuntsSnake = new AnimalRelation
        {
            PredatorId = eagle.Id,
            PreyId = snake.Id,
        };
        
        var eagleHuntsMouse = new AnimalRelation
        {
            PredatorId = eagle.Id,
            PreyId = mouse.Id,
        };
        
        context.Add(snakeHuntsMouse);
        context.Add(eagleHuntsSnake);
        context.Add(eagleHuntsMouse);

        await context.SaveChangesAsync();

        var alice = new Human
        {
            MostFavoriteAnimalId = mouse.Id,
            LeastFavoriteAnimalId = eagle.Id,
        };

        var bob = new Human
        {
            MostFavoriteAnimalId = eagle.Id,
            LeastFavoriteAnimalId = snake.Id
        };

        context.Add(alice);
        context.Add(bob);

        await context.SaveChangesAsync();
    }
}