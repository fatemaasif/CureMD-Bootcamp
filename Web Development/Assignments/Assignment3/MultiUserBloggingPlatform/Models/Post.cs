namespace MultiUserBloggingPlatform.Models
{
    public class Post
    {
        public int? PostID { get; set; }
        public string? PostText { get; set; }
        public int? CategoryID { get; set; }
        public int? UserID { get; set; }

    }
}
