using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DG.UserPosts.Contracts
{
    public interface IJSONPlaceholderService
    {
        [Get("/users")]
        Task<List<UserListContract>> GetUserListAsync();
        [Get("/users")]
        Task<List<UserContract>> GetUserAsync([Query("id")] int id);

        [Get("/posts")]
        Task<List<PostListContract>> GetPostListAsync();
        [Get("/posts")]
        Task<List<PostContract>> GetPostListByUserIdAsync([Query("userId")] int userId);
    }
}
