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

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            Post post = dataLayer.GetPost(id);
            if (post == null)
            {
                return NotFound("Post not found"); // the post is not found
            }
            return Ok(post); // Return 200 OK with the post data if found
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            try
            {
                dataLayer.CreatePost(post.PostText, (int)post.CategoryID, (int)post.UserID, post.PostTitle, post.Username);
                return Ok("Post created successfully"); // Return 200 OK if the post is created successfully
            }
            catch (Exception Exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Exc.Message); // Return the error message from the exception with status code 500
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, Post updatedPost)
        {
            Post existingPost = dataLayer.GetPost(id);
            if (existingPost == null)
            {
                return NotFound("Post not found"); // Post with the given id not found
            }
            dataLayer.UpdatePost(id, updatedPost.PostText, (int)updatedPost.CategoryID, (int)updatedPost.UserID);
            return Ok("Post updated successfully"); // Return 200 OK if the post is updated successfully
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            Post existingPost = dataLayer.GetPost(id);
            if (existingPost == null)
            {
                return NotFound("Post not found"); // Post with the given id not found
            }
            dataLayer.DeletePost(id);
            return Ok("Post deleted successfully"); // Return 200 OK if the post is deleted successfully
        }

        [HttpGet("{id}/comments")]
        public IActionResult GetPostWithComments(int id)
        {
            List<Comment> comments = dataLayer.GetPostWithComments(id);
            if (comments == null || comments.Count == 0)
            {
                return NotFound("No comments found for the given PostID"); // No comments found for the given PostID
            }
            return Ok(comments); // Return 200 OK with the list of comments
        }

        [HttpGet("category/{categoryID}")]
        public IActionResult GetPostsByCategory(int categoryID)
        {
            List<Post> posts = dataLayer.GetPostsByCategory(categoryID);
            if (posts == null || posts.Count == 0)
            {
                return NotFound("No posts found for the given CategoryID"); // No posts found for the given CategoryID
            }
            return Ok(posts); // Return 200 OK with the list of posts
        }

        [HttpGet("user/{userID}")]
        public IActionResult GetPostsByUser(int userID)
        {
            List<Post> posts = dataLayer.GetPostsByUser(userID);
            if (posts == null || posts.Count == 0)
            {
                return NotFound("No posts found for the given UserID"); // No posts found for the given UserID
            }
            return Ok(posts); // Return 200 OK with the list of posts
        }

    }
}
