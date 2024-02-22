using Domain.Data;
using Domain.DTOS;
using Domain.Entities;
using Domain.Interfaces;
using FunnyCocktail.Application.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FunnyCocktail.Tests
{
    public class CocktailReviewServiceTests
    {
        private ICocktailService? CocktailService { get; set; }
        [Fact]
        public async Task CreateReviewAsync_UserNotFound_ThrowsArgumentException()
        {
            var mockDbSet = new Mock<DbSet<Author>>();
            mockDbSet.Setup(mock => mock.FindAsync(It.IsAny<object[]>())).ReturnsAsync((Author)null);

            var mockContext = new Mock<ApplicationDataBaseContext>();
            mockContext.Setup(c => c.Authors).Returns(mockDbSet.Object);


            var cocktailReviewsService = new CocktailReviewService(mockContext.Object, CocktailService);

            await Assert.ThrowsAsync<ArgumentException>(() => cocktailReviewsService.CreateReviewAsync(
                new Domain.DTOS.CocktailReviewDTO { Username = "nonexistinguser" }));
        }

        [Fact]
        public async Task CreateReviewAsync_UserFound_CreatesReview()
        {
            var user = new Author { Username = "existinguser", Id = 1 };
            var mockDbSet = new Mock<DbSet<Author>>();
            mockDbSet.Setup(mock => mock.FindAsync(It.IsAny<object[]>())).ReturnsAsync(user);

            var mockContext = new Mock<ApplicationDataBaseContext>();
            mockContext.Setup(c => c.Authors).Returns(mockDbSet.Object);

            var cocktailReviewsService = new CocktailReviewService(mockContext.Object, CocktailService);

            var result = await cocktailReviewsService.CreateReviewAsync(new CocktailReviewDTO { Username = "existinguser", CocktailId = 1, ReviewText = "Чудесный коктейль!" });

            Assert.True(result);
        }
    }
}
