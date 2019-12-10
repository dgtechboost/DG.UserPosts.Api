using System.Collections.Generic;
using System.Threading.Tasks;

namespace DG.UserPosts.Business.UserPosts.Queries.Get
{
    public interface IGetUserPostsByUserIdQuery
    {
        Task<UserPostByUserIdModel> ExecuteAsync(int id);
    }
}
