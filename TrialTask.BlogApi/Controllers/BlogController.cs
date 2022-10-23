using TrialTask.BlogApi.Schemas;
using TrialTask.BusinessLogic;
using TrialTask.DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace TrialTask.BlogApi.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogService blogService;

        public BlogController(ILogger<BlogController> logger,
                              IBlogService blogService)
        {
            _logger = logger;
            this.blogService = blogService;
        }


        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<BlogResponse>> GetAll()
        {
            try
            {
                var blogs = blogService.ReadAll().Select(b => new BlogResponse
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    Name = b.Name,
                    Description = b.Description,
                    CreationDate = b.CreationDate
                });
                return Ok(blogs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Last10DaysBlogs")]
        public ActionResult<IEnumerable<BlogResponse>> GetLast10DaysBlogs()
        {
            try
            {
                var blogs = blogService.GetLast10DaysBlogs().Select(b => new BlogResponse
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    Name = b.Name,
                    Description = b.Description,
                    CreationDate = b.CreationDate
                });

                return Ok(blogs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("AddNew")]
        public ActionResult AddNew(BlogRequest blogRequest)
        {
            try
            {
                var blog = new Blog
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = blogRequest.Name,
                    CreationDate = DateTime.Now,
                    Description = blogRequest.Description,
                    UserId = blogRequest.UserId
                };
                blogService.AddNew(blog);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("Edit")]
        public ActionResult Edit(Blog blog)
        {
            try
            {
                blogService.Edit(blog);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAllTags")]
        public ActionResult<IEnumerable<Tag>> GetTags()
        {
            try
            {

                return Ok(blogService.GetTags());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("CreateTag")]
        public ActionResult CreateTag(Tag tag)
        {
            try
            {
                blogService.CreateTag(tag);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}