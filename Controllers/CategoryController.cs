using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Think_Digitally_week01.Models;
using Think_Digitally_week01.Services;

namespace Think_Digitally_week01.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            return Ok(_categoryService.AddCategory(category));
        }


        [HttpGet("paged")]
        public IActionResult GetPaged([FromQuery] string? search, int page = 1, int pageSize = 10, string? sortBy = "id", bool ascending = true)
        {
            return Ok(_categoryService.GetFilteredCategories(search, page, pageSize, sortBy, ascending));
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null || category.IsDeleted)
                return NotFound("Category not found.");
            return Ok(category);
        }
    }
}

