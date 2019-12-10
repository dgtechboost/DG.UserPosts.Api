using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.UserPosts.Business.Posts.Queries.GetList;
using DG.UserPosts.Business.Users.Queries.GetList;

namespace DG.UserPosts.Business.UserPosts.Queries.GetList
{
    public class GetUsersPostListQuery
        : IGetUsersPostListQuery
    {
        private readonly IGetPostListQuery _getPostListQuery;
        private readonly IGetUserListQuery _getUserListQuery;

        public GetUsersPostListQuery(
            IGetPostListQuery getPostListQuery,
            IGetUserListQuery getUserListQuery)
        {
            _getPostListQuery = getPostListQuery;
            _getUserListQuery = getUserListQuery;
        }

        public async Task<List<UsersPostListModel>> GetQuery()
        {
            var postsTask = _getPostListQuery.GetQuery();
            var usersTask = _getUserListQuery.GetQuery();

            await Task.WhenAll(
                 usersTask,
                 postsTask
                 );

            var posts = await postsTask;
            var users = await usersTask;

            var result = from user in users
                         join post in posts on user.Id equals post.UserId into usersPosts
                         select new UsersPostListModel
                         {
                             Id = user.Id,
                             Name = user.Name,
                             Username = user.Username,
                             Email = user.Email,
                             Address = new AddressModel
                             {
                                 Street = user.Address.Street,
                                 Suite = user.Address.Suite,
                                 City = user.Address.City,
                                 Zipcode = user.Address.Zipcode,
                                 Geo = new GeoModel
                                 {
                                     Latitude = user.Address.Geo.Lat,
                                     Longitude = user.Address.Geo.Lng
                                 }
                             },
                             Company = new CompanyModel
                             {
                                 Name = user.Company.Name,
                                 CatchPhrase = user.Company.CatchPhrase,
                                 Bs = user.Company.Bs
                             },
                             Website = user.Website,
                             Phone = user.Phone,
                             Posts = usersPosts
                                        .Where(x => x.UserId == user.Id)
                                        .Select(x => new PostListModel
                                        {
                                            Id = x.Id,
                                            UserId = x.UserId,
                                            Body = x.Body,
                                            Title = x.Title
                                        })
                         };

            return result?.ToList();
        }
    }
}
