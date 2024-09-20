using AppServices.Interface;
using DAL.Repository.Interface;
using Example.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IUserServices _userServices;
        private readonly HttpContext _httpContext;

        public UsersController(IUserRepo userRepo,
                                IUserServices userServices,
                                IHttpContextAccessor httpContext) 
        { 
            _userRepo = userRepo;
            _userServices = userServices;
            _httpContext = httpContext.HttpContext;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            return Ok(_userRepo.GetAll());
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterUserRequest userRequest)
        {
            _userServices.Register(userRequest.UserName, userRequest.Password, userRequest.Email);
            return Ok();

        }
        [HttpPost("Login")]
        public ActionResult Login(LoginUserRequest loginUser)
        {
            try
            {
                var token = _userServices.Login(loginUser.Email, loginUser.Password);
                _httpContext.Response.Cookies.Append("secretCookies", token);
                return Ok(token);
            }
            catch
            {
                return BadRequest("Failed to login");
            }
            
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindUsers(Guid id)
        {
            return Ok(_userRepo.Find(id));
        }

    }
}
