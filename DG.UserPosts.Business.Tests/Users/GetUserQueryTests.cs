using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.UserPosts.Business.Users.Queries.Get;
using DG.UserPosts.Contracts;
using Moq;
using NUnit.Framework;

namespace DG.UserPosts.Business.Tests.Users
{
    public class GetUserQueryTests
    {
        private IFixture _fixture;
        private Mock<IJSONPlaceholderService> _mockJSONPlaceholderService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockJSONPlaceholderService = _fixture.Freeze<Mock<IJSONPlaceholderService>>();
        }

        [Test]
        public async Task ShouldGetUser()
        {
            // Arrange

            var userId = 1;

            var user = _fixture
               .Build<UserContract>()
               .With(x => x.Id, userId)
               .CreateMany(1).ToList();

            _mockJSONPlaceholderService
                .Setup(x => x.GetUserAsync(userId))
                .ReturnsAsync(user);

            var query = _fixture.Create<GetUserQuery>();

            // Act

            var result = await query.ExecuteAsync(userId);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }
    }
}
