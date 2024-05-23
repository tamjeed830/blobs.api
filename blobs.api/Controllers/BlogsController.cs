using blobs.api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blobs.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsRepository _repo;

        public BlogsController(IConfiguration config)
        {
            _repo = new BlogsRepository(config);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogs = await _repo.GetAllBlogsAsync();
            return Ok(blogs);
        }
    }
}
