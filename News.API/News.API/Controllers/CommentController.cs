using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.API.Models;
using News.Business.Abstract;
using News.Entity;

namespace News.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<IActionResult> CommentAdd(CommentAddModel entity)
        {
            Comment model = new Comment() { InfoId = entity.InfoId, UserName = entity.UserName, Content = entity.Content };
            var value = await _commentService.CreateAsync(model);
            return Ok(entity);
        }
    }
}
