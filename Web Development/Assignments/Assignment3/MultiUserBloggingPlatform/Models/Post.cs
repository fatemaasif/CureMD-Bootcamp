namespace MultiUserBloggingPlatform.Models
{
    public class Post
    {
        public int? PostID { get; set; }
        public string? PostText { get; set; }
        public string? PostTitle { get; set; }
        public string? Username { get; set; }
        public int? CategoryID { get; set; }
        public int? UserID { get; set; }

    }
}
