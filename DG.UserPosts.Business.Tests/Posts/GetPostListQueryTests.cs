using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.UserPosts.Business.Posts.Queries.GetList;
using DG.UserPosts.Contracts;
using Moq;
using NUnit.Framework;

namespace DG.UserPosts.Business.Tests.Posts
{
    public class GetPostListQueryTests
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
        public async Task ShouldGetAllPosts()
        {
            // Arrange

            var posts = _fixture
                .Build<PostListContract>()
                .CreateMany(5).ToList();

            _mockJSONPlaceholderService
                .Setup(x => x.GetPostListAsync())
                .ReturnsAsync(posts);

            var query = _fixture.Create<GetPostListQuery>();

            // Act

            var result = await query.GetQuery();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 5);
        }
    }
}
