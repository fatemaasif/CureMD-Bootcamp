using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiUserBloggingPlatform.Models;
using System;
namespace MultiUserBloggingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataLayer dataLayer;

        public CategoriesController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        [HttpGet("{CategoryID}")]
        public IActionResult GetCategory(int id)
        {
            Category category = dataLayer.GetCategory(id);
            if (category == null)
            {
                return NotFound(); 
            }

            return Ok(category); 
        }

        [HttpPost]
        public IActionResult CreateCategory(Category newCategory)
        {
            try
            {
                dataLayer.CreateCategory(newCategory.CategoryName);
                return Ok(); 
            }
            catch (Exception Exc)
            {
                return StatusCode(500, Exc.Message); 

            }
        }

        [HttpPut("{CategoryID}")]
        public IActionResult UpdateCategory(int id, Category updatedCategory)
        {
            var existingCategory = dataLayer.GetCategory(id);
            if (existingCategory == null)
            {
                return NotFound(); 
            }

            dataLayer.UpdateCategory(id, updatedCategory.CategoryName);
            return Ok();
        }

        [HttpDelete("{CategoryID}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = dataLayer.GetCategory(id);
            if (existingCategory == null)
            {
                return NotFound(); 
            }

            dataLayer.DeleteCategory(id);
            return Ok(); 
        }

    }
}
