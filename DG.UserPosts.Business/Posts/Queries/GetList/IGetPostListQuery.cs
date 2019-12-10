using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Posts.Queries.GetList
{
    public interface IGetPostListQuery
    {
        Task<List<PostListContract>> GetQuery();
    }
}
    