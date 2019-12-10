using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Posts.Queries.GetList
{
    public class GetPostListQuery
        : IGetPostListQuery
    {
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetPostListQuery(
            IJSONPlaceholderService jSONPlaceholderService)
        {
            _jSONPlaceholderService = jSONPlaceholderService;
        }

        public async Task<List<PostListContract>> GetQuery()
        {
            return await _jSONPlaceholderService.GetPostListAsync();
        }
    }
}
