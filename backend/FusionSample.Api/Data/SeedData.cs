using FusionSample.Api.Models;

namespace FusionSample.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Recipes.Any()) return;

            context.Recipes.AddRange(
                new Recipe { Name = "Seeded Recipe 1", Description = "Demo data" },
                new Recipe { Name = "Seeded Recipe 2", Description = "More demo data" }
            );
            context.SaveChanges();
        }
    }
}
