using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Posts.Queries.GetListByUserId
{
    public interface IGetPostListByUserIdQuery
    {
        Task<List<PostListContract>> ExecuteAsync(int id);
    }
}
