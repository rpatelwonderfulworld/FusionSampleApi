using System.Threading.Tasks;
using FusionSample.Api.Data;
using FusionSample.Api.Models;
using FusionSample.Api.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FusionSample.Tests.Services
{
    public class RecipeServiceTests
    {
        private static RecipeService BuildService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "recipes_test_db")
                .Options;
            var ctx = new AppDbContext(options);
            return new RecipeService(ctx);
        }

        [Fact]
        public async Task Create_And_Get_Works()
        {
            var svc = BuildService();
            var created = await svc.CreateAsync(new Recipe { Name = "Test", Description = "Demo" });
            var fetched = await svc.GetAsync(created.Id);
            Assert.NotNull(fetched);
            Assert.Equal("Test", fetched!.Name);
        }
    }
}
