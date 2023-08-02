using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiUserBloggingPlatform.Models;
using System.Net;
using System;

namespace MultiUserBloggingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataLayer dataLayer;
        public UsersController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        [HttpGet("{username}/{password}")]
        public IActionResult GetUser(string username, string password)
        {
            User user = dataLayer.GetUser(username,password);
            if (user == null)
            {
                return NotFound("User not found"); // the user is not found
            }
            return Ok(user); // Returns 200 OK with the user data 
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                dataLayer.CreateUser(user.Username, user.PassWd, user.Email);
                return Ok("User created successfully"); // Returns 200 OK if the user is created successfully
            }
            catch (Exception Exc)
            {
                return StatusCode(500, Exc.Message); // Return the error message from the exception with status code 500

            }
        }
        [HttpPut("{UserID}")]
        public IActionResult UpdateUser(int userid, string updatedusername, string updatedpassword, string updatedemail, User updatedUser)
        {
            User existingUser = dataLayer.GetUser(updatedUser.Username, updatedUser.PassWd);
            if (existingUser == null)
            {
                return NotFound("User not found"); // User with the given id not found
            }
            dataLayer.UpdateUser(userid, updatedusername, updatedpassword, updatedemail);
            return Ok("User updated successfully"); // Return 200 OK if the user is updated successfully
        }

        [HttpDelete("{username}/{password}")]
        public IActionResult DeleteUser(string username, string password)
        {
            User existingUser = dataLayer.GetUser(username,password);
            if (existingUser == null)
            {
                return NotFound("User not found"); // User with the given id not found
            }
            dataLayer.DeleteUser((int)existingUser.UserID, username);
            return Ok("User deletded successfully"); // Return 200 OK if the user is deleted successfully
        }


    }
}
