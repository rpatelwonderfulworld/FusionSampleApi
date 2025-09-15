using System.Threading.Tasks;
using FusionSample.Api.Controllers;
using FusionSample.Api.Data;
using FusionSample.Api.Models;
using FusionSample.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FusionSample.Tests.Controllers
{
    public class RecipesControllerTests
    {
        private static RecipeService BuildService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "recipes_controller_test_db")
                .Options;
            var ctx = new AppDbContext(options);
            return new RecipeService(ctx);
        }

        [Fact]
        public async Task Create_Get_Delete_Workflow()
        {
            var svc = BuildService();
            var controller = new RecipesController(svc);

            var createResult = await controller.Create(new Recipe { Name = "CtTest", Description = "desc" }) as CreatedAtActionResult;
            Assert.NotNull(createResult);

            var created = createResult.Value as Recipe;
            Assert.NotNull(created);
            Assert.Equal("CtTest", created.Name);

            var getResult = await controller.Get(created.Id) as OkObjectResult;
            Assert.NotNull(getResult);
            var fetched = getResult.Value as Recipe;
            Assert.NotNull(fetched);
        }
    }
}
