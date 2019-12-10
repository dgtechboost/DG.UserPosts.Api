namespace DG.UserPosts.Business.UserPosts.Queries.GetList
{
    public class PostListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}