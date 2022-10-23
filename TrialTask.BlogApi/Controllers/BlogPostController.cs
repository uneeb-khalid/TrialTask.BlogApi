using TrialTask.BlogApi.Schemas;
using TrialTask.BusinessLogic;
using TrialTask.DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace TrialTask.BlogApi.Controllers
{
    [ApiController]
    [Route("api/blogpost")]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;
        private readonly IBlogPostingService blogPostingService;

        public BlogPostController(ILogger<BlogPostController> logger,
                              IBlogPostingService blogPostingService)
        {
            _logger = logger;
            this.blogPostingService = blogPostingService;
        }


        [HttpGet("GetById")]
        public ActionResult<BlogPost> Get(string id)
        {

            try
            {
                return Ok(blogPostingService.Read(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<BlogPost>> GetAll(string blogId)
        {
            try
            {
                return Ok(blogPostingService.ReadAll(blogId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Last30DaysPosts")]
        public ActionResult<IEnumerable<BlogPost>> Last30DaysPosts(string blogId)
        {

            try
            {
                return Ok(blogPostingService.GetLast30DaysPosts(blogId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
       
        [HttpPost("AddNewPost")]
        public ActionResult AddNew(BlogPostAddRequest blogPostAddRequest)
        {
            try
            {
                var blogPost = new BlogPost
                {
                    Id = Guid.NewGuid().ToString(),
                    BlogId = blogPostAddRequest.BlogId,
                    userId = blogPostAddRequest.userId,
                    Content = blogPostAddRequest.Content,
                    Title = blogPostAddRequest.Title,
                    CreationDateTime = DateTime.Now
                };
                blogPostingService.AddNew(blogPost);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("EditPost")]
        public ActionResult EditPost(BlogPostEditRequest blogPost)
        {
            try
            {

                var post = blogPostingService.Read(blogPost.Id);
                if(post == null)
                {
                    return NotFound("No such post is found");
                }
                post.Title = blogPost.Title;
                post.Content = blogPost.Content;    

                blogPostingService.Edit(post);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("DeletePost")]
        public ActionResult DeletePost(BlogPost blogPost)
        {
            try
            {
                blogPostingService.Delete(blogPost);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetComments")]
        public ActionResult<IEnumerable<Comment>> GetComments(string postId)
        {
            try
            {
                return Ok(blogPostingService.GetComments(postId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("AddComment")]
        public ActionResult AddComment(AddCommentRequest comment)
        {
            try
            {
                blogPostingService.AddComment(new Comment
                {
                    Id = Guid.NewGuid().ToString(),
                    Content = comment.Content,
                    PostId = comment.PostId,
                    UserId = comment.UserId,
                    LastModify = DateTime.Now
                });
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("EditComment")]
        public ActionResult EditComment(EditCommentRequest commentReq)
        {
            try
            {
               var comment =  blogPostingService.GetComment(commentReq.Id);
                if(comment == null)
                {
                    return NotFound("Comment not found");
                }
                comment.Content = commentReq.Content;

                blogPostingService.EditComment(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("DeleteComment")]
        public ActionResult DeleteComment(Comment comment)
        {
            try
            {
                blogPostingService.DeleteComment(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("GetTags")]
        public ActionResult<IEnumerable<Tag>> GetTags(string postId)
        {
            try
            {
              var tags =  blogPostingService.GetTags(postId);
                return Ok(tags);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost("AddTag")]
        public ActionResult AddTag(PostTag postTag)
        {
            try
            {
                blogPostingService.AddTag(postTag);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("RemoveTag")]
        public ActionResult RemoveTag(PostTag postTag)
        {
            try
            {
                blogPostingService.RemoveTag(postTag);
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