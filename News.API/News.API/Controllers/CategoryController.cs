using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Business.Abstract;

namespace News.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryWithNews(int id)
        {
            var values = await _categoryService.GetCategoryWithNews(id);
            return Ok(values);
        }
       
    }
}
