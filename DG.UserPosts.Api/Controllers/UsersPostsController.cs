using System;
using System.Threading.Tasks;
using DG.UserPosts.Business.UserPosts.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace DG.UserPosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersPostsController
        : ControllerBase
    {
        private readonly IGetUsersPostListQuery _getUsersPostListQuery;

        public UsersPostsController(
            IGetUsersPostListQuery getUsersPostListQuery)
        {
            _getUsersPostListQuery = getUsersPostListQuery;
        }

        /// <summary>
        /// Endpoint resource to get all UsersPosts
        /// </summary>
        /// <returns>List of UserPost list of objects</returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var usersPostList = await _getUsersPostListQuery.GetQuery();

                return Ok(usersPostList);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
