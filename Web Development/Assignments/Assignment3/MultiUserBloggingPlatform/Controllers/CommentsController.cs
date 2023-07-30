using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MultiUserBloggingPlatform.Models;

namespace MultiUserBloggingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly DataLayer dataLayer;

        public CommentsController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        [HttpGet("{PostID}")]
        public IActionResult GetComment(int id)
        {
            var comment = dataLayer.GetComment(id);
            if (comment == null)
            {
                return NotFound(); 
            }

            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment newComment)
        {
            try
            {
                dataLayer.CreateComment(newComment.CommentText, (int)newComment.UserID, (int)newComment.PostID);
                return Ok(); // Return 200 OK if the user is created successfully
            }
            catch (Exception Exc)
            {
                return StatusCode(500, Exc.Message); // Return the error message from the exception with status code 500

            }
        }

        [HttpPut("{PostID}")]
        public IActionResult UpdateComment(int id, Comment updatedComment)
        {
            Comment existingComment = dataLayer.GetComment(id);
            if (existingComment == null)
            {
                return NotFound(); 
            }

            dataLayer.UpdateComment(id, updatedComment.CommentText, (int)updatedComment.UserID, (int)updatedComment.PostID);
            return Ok(); 
        }

        [HttpDelete("{PostID}")]
        public IActionResult DeleteComment(int id)
        {
            var existingComment = dataLayer.GetComment(id);
            if (existingComment == null)
            {
                return NotFound(); 
            }
            dataLayer.DeleteComment(id);
            return Ok();
        }
    }

}
