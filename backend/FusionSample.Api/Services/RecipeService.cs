using FusionSample.Api.Data;
using FusionSample.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FusionSample.Api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly AppDbContext _db;

        public RecipeService(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Recipe>> GetAllAsync() =>
            await _db.Recipes.OrderByDescending(r => r.CreatedAt).ToListAsync();

        public async Task<Recipe?> GetAsync(int id) =>
            await _db.Recipes.FindAsync(id);

        public async Task<Recipe> CreateAsync(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            await _db.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe?> UpdateAsync(int id, Recipe recipe)
        {
            var existing = await _db.Recipes.FindAsync(id);
            if (existing is null) return null;
            existing.Name = recipe.Name;
            existing.Description = recipe.Description;
            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Recipes.FindAsync(id);
            if (existing is null) return false;
            _db.Recipes.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
