using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Users.Queries.Get
{
    public interface IGetUserQuery
    {
        Task<List<UserContract>> ExecuteAsync(int id);
    }
}
