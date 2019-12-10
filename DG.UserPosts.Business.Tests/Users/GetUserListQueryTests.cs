using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.UserPosts.Business.Users.Queries.GetList;
using DG.UserPosts.Contracts;
using Moq;
using NUnit.Framework;

namespace DG.UserPosts.Business.Tests.Users
{
    public class GetUserListQueryTests
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
        public async Task ShouldGetUserList()
        {
            // Arrange

            var user = _fixture
               .Build<UserListContract>()
               .CreateMany(5).ToList();

            _mockJSONPlaceholderService
                .Setup(x => x.GetUserListAsync())
                .ReturnsAsync(user);

            var query = _fixture.Create<GetUserListQuery>();

            // Act

            var result = await query.GetQuery();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 5);
        }
    }
}
