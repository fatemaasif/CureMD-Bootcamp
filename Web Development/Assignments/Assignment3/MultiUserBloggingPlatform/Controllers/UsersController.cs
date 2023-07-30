using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiUserBloggingPlatform.Models;
using System.Net;

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

        [HttpGet("{UserID}")]
        public IActionResult GetUser(int Userid)
        {
            User user = dataLayer.GetUser(Userid);
            if (user == null)
            {
                return NotFound(); // the user is not found
            }
            return Ok(user); // Returns 200 OK with the user data 
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                dataLayer.CreateUser(user.Username, user.PassWd, user.Email);
                return Ok(); // Returns 200 OK if the user is created successfully
            }
            catch (Exception Exc)
            {
                return StatusCode(500, Exc.Message); // Return the error message from the exception with status code 500

            }
        }
        [HttpPut("{UserID}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            User existingUser = dataLayer.GetUser(id);
            if (existingUser == null)
            {
                return NotFound(); // User with the given id not found
            }
            dataLayer.UpdateUser(id, updatedUser.Username, updatedUser.PassWd, updatedUser.Email);
            return Ok(); // Return 200 OK if the user is updated successfully
        }

        [HttpDelete("{UserID}")]
        public IActionResult DeleteUser(int id)
        {
            User existingUser = dataLayer.GetUser(id);
            if (existingUser == null)
            {
                return NotFound(); // User with the given id not found
            }
            dataLayer.DeleteUser(id);
            return Ok(); // Return 200 OK if the user is deleted successfully
        }


    }
}
