using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Users.Queries.GetList
{
    public interface IGetUserListQuery
    {
        Task<List<UserListContract>> GetQuery();
    }
}
