using System.Collections.Generic;

namespace DG.UserPosts.Business.UserPosts.Queries.GetList
{
    public class UsersPostListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public AddressModel Address { get; set; }
        public CompanyModel Company { get; set; }

        public IEnumerable<PostListModel> Posts { get; set; }
    }
}