using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.UserPosts.Business.Posts.Queries.GetListByUserId;
using DG.UserPosts.Business.Users.Queries.Get;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.UserPosts.Queries.Get
{
    public class GetUserPostsByUserIdQuery
        : IGetUserPostsByUserIdQuery
    {
        private readonly IGetPostListByUserIdQuery _getPostListByUserIdQuery;
        private readonly IGetUserQuery _getUserQuery;

        public GetUserPostsByUserIdQuery(
            IGetPostListByUserIdQuery getPostListByUserIdQuery,
            IGetUserQuery getUserQuery)
        {
            _getPostListByUserIdQuery = getPostListByUserIdQuery;
            _getUserQuery = getUserQuery;
        }

        public async Task<UserPostByUserIdModel> ExecuteAsync(int id)
        {
            var postsTask = _getPostListByUserIdQuery.ExecuteAsync(id);
            var userTask = _getUserQuery.ExecuteAsync(id);

            await Task.WhenAll(
                 userTask,
                 postsTask
                 );

            var posts = await postsTask;
            var user = await userTask;

            if (user == null || user?.Count > 1 || user.Count == 0)
            {
                throw new IndexOutOfRangeException(nameof(user));
            }

            var result = MapToModel(posts, user);

            return result;
        }

        private UserPostByUserIdModel MapToModel(List<PostListContract> posts, List<UserContract> user)
        {
            return new UserPostByUserIdModel
            {
                Id = user.First().Id,
                Name = user.First().Name,
                Username = user.First().Username,
                Email = user.First().Email,
                Address = new AddressModel
                {
                    Street = user.First().Address.Street,
                    Suite = user.First().Address.Suite,
                    City = user.First().Address.City,
                    Zipcode = user.First().Address.Zipcode,
                    Geo = new GeoModel
                    {
                        Latitude = user.First().Address.Geo.Lat,
                        Longitude = user.First().Address.Geo.Lng
                    }
                },
                Company = new CompanyModel
                {
                    Name = user.First().Company.Name,
                    CatchPhrase = user.First().Company.CatchPhrase,
                    Bs = user.First().Company.Bs
                },
                Website = user.First().Website,
                Phone = user.First().Phone,
                Posts = posts.Select(x => new PostListModel
                                        {
                                            Id = x.Id,
                                            UserId = x.UserId,
                                            Body = x.Body,
                                            Title = x.Title
                                        })
            };
        }
    }
}
