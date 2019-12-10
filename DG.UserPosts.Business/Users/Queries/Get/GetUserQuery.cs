using System.Collections.Generic;
using System.Threading.Tasks;
using DG.UserPosts.Contracts;

namespace DG.UserPosts.Business.Users.Queries.Get
{
    public class GetUserQuery
        : IGetUserQuery
    {
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetUserQuery(
            IJSONPlaceholderService jSONPlaceholderService)
        {
            _jSONPlaceholderService = jSONPlaceholderService;
        }

        public async Task<List<UserContract>> ExecuteAsync(int id)
        {
            return await _jSONPlaceholderService.GetUserAsync(id);
        }
    }
}
