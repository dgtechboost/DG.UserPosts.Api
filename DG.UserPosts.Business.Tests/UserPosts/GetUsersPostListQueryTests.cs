using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.UserPosts.Business.Posts.Queries.GetList;
using DG.UserPosts.Business.UserPosts.Queries.GetList;
using DG.UserPosts.Business.Users.Queries.GetList;
using DG.UserPosts.Contracts;
using Moq;
using NUnit.Framework;

namespace DG.UserPosts.Business.Tests.UserPosts
{
    public class GetUsersPostListQueryTests
    {
        private IFixture _fixture;
        private Mock<IGetPostListQuery> _mockGetPostListQuery;
        private Mock<IGetUserListQuery> _mockGetUserListQuery;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockGetPostListQuery = _fixture.Freeze<Mock<IGetPostListQuery>>();
            _mockGetUserListQuery = _fixture.Freeze<Mock<IGetUserListQuery>>();
        }

        [Test]
        public async Task ShouldGetAllUsersPosts()
        {
            // Arrange

            var userId = 1;

            var user = _fixture
                .Build<UserListContract>()
                .With(x => x.Id, userId)
                .CreateMany(1).ToList();

            _mockGetUserListQuery
                .Setup(x => x.GetQuery())
                .ReturnsAsync(user);

            var posts = _fixture
                .Build<PostListContract>()
                .With(x => x.UserId, user.Single().Id)
                .CreateMany(1).ToList();

            _mockGetPostListQuery
                .Setup(x => x.GetQuery())
                .ReturnsAsync(posts);

            var query = _fixture.Create<GetUsersPostListQuery>();

            // Act

            var result = await query.GetQuery();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First().Posts.Count(), 1);
        }
    }
}
