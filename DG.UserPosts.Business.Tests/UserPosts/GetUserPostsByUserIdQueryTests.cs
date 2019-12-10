using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.UserPosts.Business.Posts.Queries.GetListByUserId;
using DG.UserPosts.Business.UserPosts.Queries.Get;
using DG.UserPosts.Business.Users.Queries.Get;
using DG.UserPosts.Contracts;
using Moq;
using NUnit.Framework;

namespace DG.UserPosts.Business.Tests.UserPosts
{
    public class GetUserPostsByUserIdQueryTests
    {
        private IFixture _fixture;
        private Mock<IGetPostListByUserIdQuery> _mockGetPostListByUserIdQuery;
        private Mock<IGetUserQuery> _mockGetUserQuery;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockGetPostListByUserIdQuery = _fixture.Freeze<Mock<IGetPostListByUserIdQuery>>();
            _mockGetUserQuery = _fixture.Freeze<Mock<IGetUserQuery>>();
        }

        [Test]
        public async Task ShouldGetAllPostsOfUserByUserId()
        {
            // Arrange

            var userId = 1;

            var user = _fixture
                .Build<UserContract>()
                .With(x => x.Id, userId)
                .CreateMany(1).ToList();

            _mockGetUserQuery
                .Setup(x => x.ExecuteAsync(userId))
                .ReturnsAsync(user);

            var posts = _fixture
                .Build<PostListContract>()
                .With(x => x.UserId, user.Single().Id)
                .CreateMany(1).ToList();

            _mockGetPostListByUserIdQuery
                .Setup(x => x.ExecuteAsync(userId))
                .ReturnsAsync(posts);

            var query = _fixture.Create<GetUserPostsByUserIdQuery>();

            // Act

            var result = await query.ExecuteAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, user.First().Id);
            Assert.AreEqual(result.Name, user.First().Name);
            Assert.AreEqual(result.Username, user.First().Username);
            Assert.AreEqual(result.Email, user.First().Email);
            Assert.AreEqual(result.Phone, user.First().Phone);
            Assert.AreEqual(result.Website, user.First().Website);
            Assert.AreEqual(result.Address.Street, user.First().Address.Street);
            Assert.AreEqual(result.Address.Suite, user.First().Address.Suite);
            Assert.AreEqual(result.Address.City, user.First().Address.City);
            Assert.AreEqual(result.Address.Zipcode, user.First().Address.Zipcode);
            Assert.AreEqual(result.Address.Geo.Latitude, user.First().Address.Geo.Lat);
            Assert.AreEqual(result.Address.Geo.Longitude, user.First().Address.Geo.Lng);
            Assert.AreEqual(result.Company.Name, user.First().Company.Name);
            Assert.AreEqual(result.Company.CatchPhrase, user.First().Company.CatchPhrase);
            Assert.AreEqual(result.Company.Bs, user.First().Company.Bs);
            Assert.AreEqual(result.Posts.First().Id, posts.First().Id);
            Assert.AreEqual(result.Posts.First().UserId, posts.First().UserId);
            Assert.AreEqual(result.Posts.First().Title, posts.First().Title);
            Assert.AreEqual(result.Posts.First().Body, posts.First().Body);
        }
    }
}
