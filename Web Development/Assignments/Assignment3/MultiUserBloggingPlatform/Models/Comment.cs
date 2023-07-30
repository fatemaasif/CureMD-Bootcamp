namespace MultiUserBloggingPlatform.Models
{
    public class Comment
    {
        public int? CommentID { get; set; }
        public string? CommentText { get; set; }
        public int? UserID { get; set; }
        public int? PostID { get; set; }

    }
}
