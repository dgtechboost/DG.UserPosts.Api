using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Users.Queries.GetList
{
    public class GetUserListQuery
        : IGetUserListQuery
    {
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetUserListQuery(
            IJSONPlaceholderService jSONPlaceholderService)
        {
            _jSONPlaceholderService = jSONPlaceholderService;
        }

        public async Task<List<UserListContract>> GetQuery()
        {
            return await _jSONPlaceholderService.GetUserListAsync();
        }
    }
}

