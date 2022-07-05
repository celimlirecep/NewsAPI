using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.API.Models;
using News.Business.Abstract;
using News.DataAccess.Abstract;
using News.Entity;

namespace News.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInfos()
        {
            var infos = await _infoService.GetList();
            return Ok(infos);
        }
        [HttpGet]
        public async Task<IActionResult> GetLastFourNews()
        {
            var infos = await _infoService.GetFourNewsWithCategory();
            return Ok(infos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWithAllDetails(int id)
        {
            var info = await _infoService.GetByIdWithAllDetails(id);
            return Ok(info);
        }
        [HttpPost]
        public async Task<IActionResult> NewsAdd(NewsAddModel entity)
        {
            Info model = new Info()
            {
                CategoryId = entity.CategoryId,
                Content = entity.NewsContent,
                ImageUrl = entity.ImageUrl,
                NewsName = entity.NewsName
            };
            await _infoService.Add(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> NewsDelete(int id)
        {
            var model = await _infoService.GetById(id);
            await _infoService.Delete(model);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoWithCategoryLastTenNews(int id)
        {
            var values = await _infoService.GetLastTenByCategory(id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllInfoWithCategory(int id)
        {
            var values = await _infoService.GetLastTenByCategory(id);
            return Ok(values);
        }

    }
}
