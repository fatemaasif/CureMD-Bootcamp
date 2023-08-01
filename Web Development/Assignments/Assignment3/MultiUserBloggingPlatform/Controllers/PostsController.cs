using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiUserBloggingPlatform.Models;
using System;
using System.Collections.Generic;
namespace MultiUserBloggingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataLayer dataLayer;
        public PostsController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        [HttpGet("{PostID}")]
        public IActionResult GetPost(int PostID)
        {
            Post post = dataLayer.GetPost(PostID);
            if (post == null)
            {
                return NotFound(); // the user is not found
            }
            return Ok(post); // Return 200 OK with the user data if found
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            try
            {
                dataLayer.CreatePost(post.PostText, (int)post.CategoryID, (int)post.UserID, post.PostTitle,post.Username);
                return Ok(); // Return 200 OK if the user is created successfully
            }
            catch (Exception Exc)
            {
                return StatusCode(500, Exc.Message); // Return the error message from the exception with status code 500

            }
        }
        [HttpPut("{PostID}")]
        public IActionResult UpdatePost(int id, Post updatedPost)
        {
            Post existingPost = dataLayer.GetPost(id);
            if (existingPost == null)
            {
                return NotFound(); // User with the given id not found
            }
            dataLayer.UpdatePost(id, updatedPost.PostText, (int)updatedPost.CategoryID, (int)updatedPost.UserID);
            return Ok(); // Return 200 OK if the user is updated successfully
        }

        [HttpDelete("{PostID}")]
        public IActionResult DeletePost(int id)
        {
            Post existingPost = dataLayer.GetPost(id);
            if (existingPost == null)
            {
                return NotFound(); // User with the given id not found
            }
            dataLayer.DeletePost(id);
            return Ok(); // Return 200 OK if the user is deleted successfully
        }

        [HttpGet("{PostID}")]
        public IActionResult GetPostWithComments(int PostID)
        {
            List<Comment> comments = dataLayer.GetPostWithComments(PostID);
            if (comments == null || comments.Count == 0)
            {
                return NotFound(); // No comments found for the given PostID
            }
            return Ok(comments); // Return 200 OK with the list of comments
        }

        [HttpGet("{CategoryID}")]
        public IActionResult GetPostsByCategory(int CategoryID)
        {
            List<Post> posts = dataLayer.GetPostsByCategory(CategoryID);
            if (posts == null || posts.Count == 0)
            {
                return NotFound(); // No posts found for the given CategoryID
            }
            return Ok(posts); // Return 200 OK with the list of posts
        }

        [HttpGet("{UserID}")]
        public IActionResult GetPostsByUser(int UserID)
        {
            List<Post> posts = dataLayer.GetPostsByUser(UserID);
            if (posts == null || posts.Count == 0)
            {
                return NotFound(); // No posts found for the given UserID
            }
            return Ok(posts); // Return 200 OK with the list of posts
        }

    }
}
