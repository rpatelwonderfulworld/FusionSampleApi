using FusionSample.Api.Models;

namespace FusionSample.Api.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe?> GetAsync(int id);
        Task<Recipe> CreateAsync(Recipe recipe);
        Task<Recipe?> UpdateAsync(int id, Recipe recipe);
        Task<bool> DeleteAsync(int id);
    }
}
