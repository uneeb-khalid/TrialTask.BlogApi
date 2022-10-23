using TrialTask.BlogApi.Schemas;
using TrialTask.BusinessLogic;
using TrialTask.DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace TrialTask.BlogApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;

        public AuthenticationController(ILogger<AuthenticationController> logger,
                                        IUserService userService)
        {
            _logger = logger;
            this._userService = userService;
        }

        //[HttpPost("Login")]
        //public ActionResult Login(User user)
        //{
        //    try
        //    {
        //        if (userService.Validate(user))
        //        {
        //            return Unauthorized("Email or password is not correct");
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<UserResponse>> GetAll()
        {
            try
            {
                var users = _userService.ReadAll().Select(u => new UserResponse
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,

                });
                return Ok(users) ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost("RegisterNewUser")]
        public ActionResult Register(UserRequest requestObj)
        {
            try
            {
                _userService.AddNew(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = requestObj.Email,
                    Name = requestObj.Name,
                    Password = requestObj.Password,  
                    LastModify = DateTime.Now,
                }); 
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