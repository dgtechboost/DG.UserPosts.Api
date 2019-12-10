using System;
using System.Threading.Tasks;
using DG.UserPosts.Business.UserPosts.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace DG.UserPosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostsController
        : ControllerBase
    {
        private readonly IGetUserPostsByUserIdQuery _getUserPostsByUserIdQuery;

        public UserPostsController(
            IGetUserPostsByUserIdQuery getUserPostsByUserIdQuery)
        {
            _getUserPostsByUserIdQuery = getUserPostsByUserIdQuery;
        }

        /// Endpoint resource to get all User posts based on UserId
        /// </summary>
        /// <returns>List of UserPhoto list of objects</returns>
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetListByUserId(int id)
        {
            try
            {
                var userPostsByUserId = await _getUserPostsByUserIdQuery.ExecuteAsync(id);

                return Ok(userPostsByUserId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
