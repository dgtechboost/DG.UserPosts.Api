using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Posts.Queries.GetListByUserId
{
    public class GetPostListByUserIdQuery
        : IGetPostListByUserIdQuery
    {
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetPostListByUserIdQuery(
            IJSONPlaceholderService jSONPlaceholderService)
        {
            _jSONPlaceholderService = jSONPlaceholderService;
        }

        public async Task<List<PostListContract>> ExecuteAsync(int id)
        {
            return await _jSONPlaceholderService.GetPostListByUserIdAsync(id); ;
        }
    }
}
